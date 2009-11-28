/* * *
 * Author:			Vorspire
 * Date:			25 November, 2009
 * Requirements:	RunUO 2.0
 * 
 * Information:
 * Provides an in-game command that can be used to wipe duplicate Items in the World.
 * Duplicate Items are Items of the same Type that have the same in-game Location and Map.
 * All messages associated with this command are logged to the command logs and are also displayed in the console window.
 * This command runs in it's own Thread, so if your server has a lot of items to check, the process won't interrupt Player's game-play.
 * Tested with an area of 10x10 tiles (200 MarbleFloor tiles on the same Z-axis) - 100 were successfully deleted with no error.
 * 
 * This command also supports automation, you can use the WipeDupesRepeater <double minutes> command to set the interval at which the wiping process starts.
 * The WipeDupesCMDRepeater class uses a default interval of 60.0 minutes.
 * Setting this value lower than 1.0 will disable the automated wipe process.
 * 
 * Items that are stored in Containers or Equipped will not be included in the wipe. This is based on Item.Parent being null.
 * Items created more recently than their dupes will not be included in the wipe. This is based on Serial.Value
 * Items within HouseRegions are not included in the wipe.
 * 
 * Please feel free to modify this script to your liking and I hope you find it useful.
 * 
 * Regards,
 * Vorspire
 * * */

using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

using Server;
using Server.Regions;
using Server.Prompts;

namespace Server.Commands
{
	public sealed class WipeDupesCMD
	{
		private static CommandEventArgs _CMDArgs;
		private static List<Item> _WorldItems;
		private static Thread _Thread;
		private static WipeProcess _Process;

		public static void Initialize()
		{
			CommandSystem.Register("WipeDupes", AccessLevel.Administrator, new CommandEventHandler(BeginProcess));
			CommandSystem.Register("WipeDupesRepeater", AccessLevel.Administrator, new CommandEventHandler(WipeDupesCMDRepeater.HandleCommand));
			WipeDupesCMDRepeater.Start();
		}

		private static void BeginProcess(CommandEventArgs e)
		{
			_CMDArgs = e;

			if (_CMDArgs.Mobile == null || _CMDArgs.Mobile.Deleted)
				return;

			if (_Process != null)
			{
				if (!_Process.Completed)
				{
					DualMessage(_CMDArgs.Mobile, "The duplicate item removal process is currently active, please wait until it has finished.");
					return;
				}
				else
				{
					if (_Thread != null)
						_Thread.Join();

					_Process = null;
				}
			}

			DualMessage(_CMDArgs.Mobile, "Collecting World item data...");

			_WorldItems = new List<Item>(World.Items.Values.Count / 2);
			foreach (Item i in World.Items.Values)
			{
				if (i == null || i.Deleted)
					continue;

				_WorldItems.Add(i);
			}

			if (_WorldItems.Count == 0)
			{
				DualMessage(_CMDArgs.Mobile, "There are no items to check.");
				return;
			}

			DualMessage(_CMDArgs.Mobile, "{0} items will be checked for duplications...", _WorldItems.Count.ToString("#,#"));
			_CMDArgs.Mobile.Prompt = new WipePrompt(_CMDArgs.Mobile, "Do you wish to continue? (Y/N):");
		}

		private static void DualMessage(Mobile m, string message, params object[] args)
		{
			if (m != null && !m.Deleted)
			{
				m.SendMessage(0x55, message, args);
				Console.WriteLine("[" + m.Name + "] " + message, args);
				CommandLogging.WriteLine(m, message, args);
			}
			else
			{
				Console.WriteLine(message, args);
			}
		}

		internal class WipeProcess
		{
			private bool _Completed = false;
			public bool Completed { get { return _Completed; } }

			public WipeProcess()
			{ }

			[STAThread]
			public void WipeDupes()
			{
				try
				{
					DualMessage(_CMDArgs.Mobile, "Item duplication removal process started...");

					int removedTotal = 0, mapsTotal = 0;

					foreach (Map map in Map.Maps)
					{
						if (map == null || map == Map.Internal)
							continue;

						DualMessage(_CMDArgs.Mobile, "Scanning map {0}...", String.IsNullOrEmpty(map.Name) ? map.MapID.ToString("#,#") : map.Name);

						Dictionary<Point3D, DupeEntry> checkList = new Dictionary<Point3D, DupeEntry>(_WorldItems.Count / 2);
						List<Item> dupeList = new List<Item>(_WorldItems.Count / 2);

						lock (_WorldItems)
						{
							foreach (Item item in _WorldItems)
							{
								if (item != null && !item.Deleted && item.Parent == null)
								{
									if (item.Map == map && !(Region.Find(item.Location, item.Map) is HouseRegion))
									{
										if (checkList.ContainsKey(item.Location))
										{
											DupeEntry toCheck = checkList[item.Location];

											if (toCheck.Map != map)
												continue;

											if (toCheck.Item.GetType() == item.GetType())
											{
												if (toCheck.Item.Serial.Value > item.Serial.Value)
												{
													if (!dupeList.Contains(item))
														dupeList.Add(item);
												}
												else if (toCheck.Item.Serial.Value < item.Serial.Value)
												{
													if (!dupeList.Contains(toCheck.Item))
														dupeList.Add(toCheck.Item);

													checkList[item.Location] = new DupeEntry(item);
												}
											}
										}
										else
										{ checkList.Add(item.Location, new DupeEntry(item)); }
									}
								}
							}
						}

						checkList.Clear();

						if (dupeList.Count == 0)
						{
							DualMessage(_CMDArgs.Mobile, "No duplicate items detected.");
							continue;
						}

						World.Save(false);

						DualMessage(_CMDArgs.Mobile, "Detected {0} duplicate items, deleting...", dupeList.Count.ToString("#,#"));

						int deleted = 0;

						foreach (Item item in dupeList)
						{
							if (item != null && !item.Deleted)
							{
								item.Delete();
								deleted++;
							}
						}

						DualMessage(_CMDArgs.Mobile, "Deleted {0} duplicate items.", deleted > 0 ? deleted.ToString("#,#") : "0");

						mapsTotal++;
						removedTotal += deleted;

						dupeList.Clear();
					}

					_WorldItems.Clear();
					_Completed = true;
				}
				catch (Exception ex)
				{
					DualMessage(_CMDArgs.Mobile, "{0}", ex.ToString());
					_WorldItems.Clear();
					_Completed = true;
				}
			}

			internal class DupeEntry
			{
				private Item _Item = null;
				public Item Item { get { return _Item; } }

				private Map _Map = Map.Internal;
				public Map Map { get { return _Map; } }

				private Point3D _Location = Point3D.Zero;
				public Point3D Location { get { return _Location; } }

				public DupeEntry(Item item)
				{
					_Item = item;
					_Map = _Item.Map;
					_Location = _Item.Location;
				}
			}
		}

		internal class WipeDupesCMDRepeater
		{
			private static Timer _Timer;

			private static TimeSpan _Interval = TimeSpan.FromMinutes(60.0);
			public static TimeSpan Interval { get { return _Interval; } set { _Interval = value; } }

			public static void HandleCommand(CommandEventArgs e)
			{
				string arg = e.ArgString.Trim();

				double val;
				if (Double.TryParse(arg, out val))
				{
					if (val >= 1.0)
					{
						_Interval = TimeSpan.FromMinutes(val);
						DualMessage(e.Mobile, "The repeater will automatically delete all duplicate items in the world every {0} minutes.", val.ToString("F1"));
						DualMessage(e.Mobile, "Setting the repeater interval to a value less than 1.0 will disable it.");

						BeginProcess(e);
					}
					else
					{
						_Interval = TimeSpan.Zero;
						DualMessage(e.Mobile, "The repeater has been disabled.");
					}
				}
				else
				{
					DualMessage(e.Mobile, "Usage: WipeDupesRepeater <double minutes>");
					DualMessage(e.Mobile, "Usage: The minimum minutes value is 1.0, a value less than 1.0 will disable the repeater.");
				}
			}

			public static void Start()
			{
				if (_Interval != null && _Interval != TimeSpan.Zero)
				{
					_Timer = Timer.DelayCall(_Interval, new TimerCallback(Repeat));
					_Timer.Priority = TimerPriority.OneMinute;
				}
				else
					Stop();
			}

			public static void Stop()
			{
				if (_Timer != null)
				{
					_Timer.Stop();
					_Timer = null;
				}
			}

			private static void Repeat()
			{
				Stop();
				Wipe();
				Start();
			}

			private static void Wipe()
			{
				_Process = new WipeProcess();
				_Thread = new Thread(_Process.WipeDupes);
				_Thread.Start();
			}
		}

		internal class WipePrompt : Prompt
		{
			public WipePrompt(Mobile m, string text)
			{
				DualMessage(m, text);
			}

			public override void OnResponse(Mobile from, string text)
			{
				DualMessage(from, text);

				if (text.Trim().ToUpper() == "Y")
				{
					_Process = new WipeProcess();
					_Thread = new Thread(_Process.WipeDupes);
					_Thread.Start();
				}
				else
				{
					DualMessage(from, "Item duplication removal process cancelled.");
					_WorldItems.Clear();
				}

				base.OnResponse(from, text);
			}

			public override void OnCancel(Mobile from)
			{
				DualMessage(from, "Item duplication removal process cancelled.");
				_WorldItems.Clear();
				base.OnCancel(from);
			}
		}
	}
}
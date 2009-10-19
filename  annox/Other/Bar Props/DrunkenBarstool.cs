/*
DrunkenBarstool.cs 
Version 1.0
snicker7
Released: 03/11/06
Updated: 03/11/06
Description:
Creates a barstool that when sat on
by a drunk mobile will generate random
trash nearby with a chance of BAC/3
percent every 3s. Orion Sin's idea. 20%
chance to vomit, if drunkard vomits,
any bartenders within 8 tiles will say
something about it.
*/
using System;
using Server;
using Server.Mobiles;

namespace Server.Items {
	public class DrunkenBarStool : Stool {
		private Timer i_Timer;
		
		[Constructable]
		public DrunkenBarStool() : base() {
			i_Timer= new DBSTimer(this);
			i_Timer.Start();
		}
		
		public override void OnAfterDelete() {
			if (i_Timer!=null)
				i_Timer.Stop();
		}
		
		private class DBSTimer : Timer {
			private Item t_Item;
			public DBSTimer(Item item) : base(TimeSpan.FromSeconds(5.0),TimeSpan.FromSeconds(5.0)) {
				t_Item=item;
				Priority=TimerPriority.OneSecond;
			}
			protected override void OnTick() {
				if(t_Item.Parent!=null) //not on the ground
					return;
				foreach(Mobile mob in t_Item.GetMobilesInRange(0)){
					if(Utility.RandomDouble()<((double)mob.BAC/300) && mob.BAC>0){
						Map m = t_Item.Map;
						int x = t_Item.X + Utility.RandomMinMax(-1,1);
						int y = t_Item.Y + Utility.RandomMinMax(-1,1);
						int z = t_Item.Z;
						if(!m.CanFit(x,y,z,16,false,true,true)) {
							z = m.GetAverageZ(x, y);
							if (z == t_Item.Z || !m.CanFit(x,y,z,16,false,true,true))
								continue;
						}
						Item trash = new SelfDestructiveBarTrash(mob);
						trash.MoveToWorld(new Point3D(x,y,z),m);
					}
				}
			}
		}
		
		public DrunkenBarStool(Serial serial) : base(serial) {}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			i_Timer=new DBSTimer(this);
			i_Timer.Start();
		}
	}
	
	public class SelfDestructiveBarTrash : Item {		
		public SelfDestructiveBarTrash(Mobile from) : base(0) {
			Movable = false;
			Name="some trash dropped by "+from.Name;
			Timer.DelayCall(TimeSpan.FromMinutes(2.5),new TimerStateCallback(DecayTimer),this);
			switch(Utility.RandomMinMax(0,4)){
				case 0: {
					ItemID=4334;
					break;
				}
				case 1: {
					ItemID=4335;
					break;
				}
				case 2: {
					ItemID=4336;
					break;
				}
				case 3: {
					ItemID=4337;
					break;
				}
				case 4: {
					ItemID=Utility.RandomMinMax(4650,4654);
					Name="some of "+from.Name+"'s vomit";
					Hue=0x31;
					from.Emote("*vomits*");
					Server.Effects.PlaySound(from.Location,from.Map,(from.Female ? 0x32D : 0x43F));
					Timer.DelayCall(TimeSpan.FromSeconds(Utility.RandomMinMax(2,3)),new TimerStateCallback(BarkeepSpeak),from);
					break;
				}
				default: break;
			}
		}

		private static void DecayTimer(object i) {
			Item item=(Item)i;
			if(!item.Deleted)
				item.Delete();
		}
		
		private static void BarkeepSpeak(object s) {
			Mobile m=(Mobile)s;
			foreach(Mobile bar in m.GetMobilesInRange(8)){
				if(bar is Barkeeper || bar is PlayerBarkeeper){
					string[] complaints = new string[] {
						"Who is going to clean that up?",
						"Great... another tidy drunk.",
						"Can someone call the janitor in?",
						"One more time "+m.Name+" and you have to leave.",
						"Don't you think you've had enough to drink?"
					};
					bar.Say(complaints[Utility.Random(complaints.Length)]);
					return;
				}
			}
		}
		
		public SelfDestructiveBarTrash(Serial serial) : base(serial) {}
		public override void Serialize( GenericWriter writer ) {
			base.Serialize(writer);
		}
		public override void Deserialize( GenericReader reader ) {
			base.Deserialize( reader );
			this.Delete();
		}
	}
}
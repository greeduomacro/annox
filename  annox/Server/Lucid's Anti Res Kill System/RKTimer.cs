// Modified by Lucid Nagual - Admin of the Conjuring.

using System;
using Server.Gumps;
using Server.Network; 
using Server.Mobiles;
using Server.Misc;


//--<Timer>--------------------------------------------------------------<Start>
namespace Server.Misc
{
	public class RKTimer: Timer 
	{ 
		private int m_Ticker; 
		private Mobile m_Mobile;
		
		public RKTimer( Mobile mobile, AntiResKillGump ark ): base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) ) 
		{ 
			m_Mobile = mobile;
			Priority = TimerPriority.TwoFiftyMS; 
			m_Ticker = 45; 
		} 
                                  
		protected override void OnTick() 
		{ 
			try
			{
				switch (m_Ticker) 
				{ 
					case 45: m_Mobile.SendMessage("You have immunity for 45 seconds."); break;
                    case 1:
                        {
                            m_Mobile.SendMessage("Your temporary immunity has ended.", m_Ticker.ToString()); 
                            m_Mobile.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Head);
                            m_Mobile.PlaySound(0x1EA);
                            break;
                        }
					case 0: AntiResKillGump.GenResKill( m_Mobile ); this.Stop(); break;
				}
			}
			catch
			{
				Console.WriteLine("Fatal Exception in file UraniumBomb.cs Lines 116 - 126");
				Console.WriteLine("OnTick(), switch(m_Ticker) Try/Catch Error");
			}
			m_Ticker--; 
		} 
	}
}
//--<Timer>----------------------------------------------------------------<End>


//--<Gump>---------------------------------------------------------------<Start>
namespace Server.Gumps
{
	public class AntiResKillGump : Gump
	{
		public AntiResKillGump() : base( 0, 0 )
		{
			this.Closable=false;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(78, 146, 346, 207, 9200);
			this.AddLabel(216, 160, 52, @"Lucid's Anti-Res Kill Option");
			this.AddLabel(198, 180, 47, @"Would you like to have immunity?");
			this.AddLabel(281, 222, 87, @"Yes");
			this.AddLabel(285, 262, 87, @"No");
			this.AddButton(91, 154, 9000, 248, 1, GumpButtonType.Reply, 0);
			this.AddImage(80, 120, 50994);
			this.AddButton(257, 227, 1210, 248, 2, GumpButtonType.Reply, 0);
			this.AddButton(259, 266, 1210, 248, 3, GumpButtonType.Reply, 0);
		}
		
		public static void GenResKill( Mobile from )
		{
			//System.Threading.Thread.Sleep(45000); //1000 = 1 sec
			from.Blessed = false;
			from.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Head );
			from.PlaySound( 0x1EA );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;

			if ( info.ButtonID == 0 ) // Cancel
			{
				from.Frozen = false;
				from.Blessed = false;
				return;
			}

			if ( info.ButtonID == 1 ) // Close Menu
			{	
				if ( from.Frozen || from.Alive || from.Blessed )
				{
					from.Frozen = false;
					from.Blessed = false;
					return;
				}

				else
					return;
			}

			if ( info.ButtonID == 2 ) // Yes
			{
				from.Frozen = false;
				from.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Head );
				from.PlaySound( 0x1EA );
				from.SendMessage( "You are granted temporary immunity!");
				RKTimer m_Timer = new RKTimer( from, this );
				m_Timer.Start();
			}

			if ( info.ButtonID == 3 ) // No
			{	
				from.Frozen = false;
				from.Blessed = false;
				return;
			}
		}
	}
}
//--<Gump>-----------------------------------------------------------------<End>


// RKTimer: Anti-RezKill Timer, makes the player invulnerable for [t] seconds from start time.
// scripted by Tashanna
// --------------------------
// When using this script, add the following lines to playermobile.cs in the OnLogin function (around line 244)
// Check for login of Blessed player and make unblessed
// if( ( pm.Blessed == true) &amp;&amp; ( pm.AccessLevel == AccessLevel.Player))
// pm.Blessed = false;
using System; 
using Server; 
using Server.Network;
using Server.Mobiles;

using Server.Commands;

namespace Server.Scripts.Commands 
{ 
	public class Tithe 
	{ 
		public static void Initialize() 
		{ 
			CommandSystem.Register( "Tithe", AccessLevel.Player, new CommandEventHandler( Tithe_OnCommand ) ); 
		} 

		private static void Tithe_OnCommand( CommandEventArgs e ) 
		{ 
			Mobile mob = e.Mobile; 
			if( e.Mobile is PlayerMobile )
			{
				mob.SendMessage( "You have {0} tithing points.", mob.TithingPoints );
			}


		} 


	} 
} 

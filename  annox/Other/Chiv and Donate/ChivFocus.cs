using System;
using Server;
using Server.Gumps;
using Server.Mobiles;

using Server.Commands;

namespace Server.Scripts.Commands
{

	public class ChivFocus
	{
		public static void Initialize() 
		{ 
			CommandSystem.Register( "ChivFocus", AccessLevel.Player, new CommandEventHandler( ChivFocus_OnCommand ) ); 
		} 

		[Usage( "ChivFocus" )]
		public static void ChivFocus_OnCommand( CommandEventArgs e)
		{
			Mobile from = e.Mobile;
			if(e.Mobile is PlayerMobile)
			{
				from.SendGump( new ChivFocusGump( from ) );
			}
		}
	}
}
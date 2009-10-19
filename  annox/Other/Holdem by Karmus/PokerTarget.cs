using Server.Targeting; 
using Server.Items;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Targets
{
	public class PokerTarget : Target
	{
		private PokerCards m_Cards;

		public PokerTarget( PokerCards cards ) : base( -1, false, TargetFlags.None )
		{
			m_Cards = cards;
		}

		protected override void OnTarget( Mobile from, object o )
		{
			if (o is PlayerMobile)
			{
				PlayerMobile p = (PlayerMobile)o;
				if ( m_Cards.CheckPlayer( p ) )
					p.SendGump( new PokerInviteGump( m_Cards ) );
				else
					from.SendMessage( "You can not add this player (anymore)." );
				from.Target = new PokerTarget( m_Cards );
			}
			else
				from.SendMessage( "Only players may be added!" );
		}

		protected override void OnTargetCancel( Mobile from, TargetCancelType cancelType )
		{
			from.SendMessage( "As soon as everyone has decided, doubleclick the card game to start the game." );
			m_Cards.LaunchGame = true;
		}

	}
}
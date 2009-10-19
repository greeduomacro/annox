using Server.Items;
using Server.Network;
using System.Collections.Generic;

namespace Server.Gumps
{
	public class PlayerPokerGump : Gump
	{
		private PokerCards m_Cards;
		private int m_Player;

		public PlayerPokerGump( PokerCards cards, int player ) : base( 10, 10 )
		{
			m_Cards = cards;
			m_Player = player;
			Closable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 331, 451, 9200 );

			AddLabel( 10, 10, 0, "Pot: " + cards.Pot.ToString() );

			for (int i = 0; i < cards.Players.Count; ++i)
			{
				AddLabel( 10, 180 + i * 15, 0, cards.Players[i].Player.Name + " (" + cards.Players[i].LastAction + "): " + cards.Players[i].Chips.ToString() );
			}

			string col = "";
			switch ((int)cards.Players[player].Hand[0].Colour)
			{
				case 9824: col="Spade"; break;
				case 9825: col="Heart"; break;
				case 9826: col="Diamond"; break;
				case 9827: col="Club"; break;
			}
			string val = "";
			switch ((int)cards.Players[player].Hand[0].Value)
			{
				case 2: val="2"; break;
				case 3: val="3"; break;
				case 4: val="4"; break;
				case 5: val="5"; break;
				case 6: val="6"; break;
				case 7: val="7"; break;
				case 8: val="8"; break;
				case 9: val="9"; break;
				case 10: val="10"; break;
				case 11: val="J"; break;
				case 12: val="Q"; break;
				case 13: val="K"; break;
				case 14: val="A"; break;
			}

			AddLabel( 10, 50, 0, "Hand" );
			ShowCard( 10, 70, col, val );

			AddLabel( 10, 120, 0, "Table" );
			ShowCard( 10, 150, "n", "n" );

			if (player == cards.CurrentPlayer)
			{
				AddLabel( 10, 20, 0, "Fold" );
				AddButton( 20, 40, 1209, 1210, 1, GumpButtonType.Reply, 0 );
				AddLabel( 50, 20, 0, "Call/Check" );
				AddButton( 70, 40, 1209, 1210, 2, GumpButtonType.Reply, 0 );
				AddLabel( 120, 20, 0, "Raise" );
				AddButton( 130, 40, 1209, 1210, 3, GumpButtonType.Reply, 0 );
			}
		}

		private void ShowCard( int x, int y, string col, string val )
		{
			AddBackground( x, y, 35, 50, 2171 );

			AddLabel( x+15, y+26, 0, col );
			AddLabel( x+7, y+5, 600, val );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if (m_Player == m_Cards.CurrentPlayer)
			{
				switch (info.ButtonID)
				{
					case 1: m_Cards.Fold(); break;
					case 2: m_Cards.Check(); break;
					case 3: m_Cards.Raise(); break;
					default: state.Mobile.SendGump( new PlayerPokerGump( m_Cards, m_Player ) ); break;
				}
			}
		}
	}
	public class PokerInviteGump : Gump
	{
		private PokerCards m_Cards;

		public PokerInviteGump( PokerCards cards ) : base( 10, 10 )
		{
			m_Cards = cards;
			AddPage( 0 );

			AddBackground( 0, 0, 450, 450, 9200 );

			AddLabel( 20, 210, 0, "You have been offered to participate in a game of poker. Wager:" );
			AddLabel( 20, 220, 0, cards.Wager.ToString() );

			AddButton( 95, 395, 0x2EE0, 0x2EE2, 1, GumpButtonType.Reply, 0 ); // Accept
			AddButton( 313, 395, 0x2EF2, 0x2EF4, 2, GumpButtonType.Reply, 0 ); // Refuse
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if (info.ButtonID == 1 && m_Cards.CheckPlayer( state.Mobile ) && !m_Cards.Running && CheckWager( state.Mobile, m_Cards.Wager ) )
			{
				m_Cards.User.SendMessage( state.Mobile.Name + " accepted!" );
				m_Cards.AddPlayer( state.Mobile );
			}
			else
				m_Cards.User.SendMessage( state.Mobile.Name + " refuses." );
		}

		public static bool CheckWager( Mobile from, int wager )
		{
			if (from.Backpack != null)
			{
				int totalGold = from.Backpack.GetAmount( typeof( Gold ) );

				List<BankCheck> checks = from.Backpack.FindItemsByType<BankCheck>();

				foreach (BankCheck check in checks)
					totalGold += check.Worth;

				if ( totalGold >= wager )
				{
					int leftPrice = wager - from.Backpack.ConsumeUpTo( typeof( Gold ), wager );

					if (leftPrice == 0)
						return true;

					for ( int i= 0; i < checks.Count; ++i )
					{
						if (!checks[i].Deleted)
						{
							if (leftPrice > checks[i].Worth)
							{
								leftPrice -= checks[i].Worth;
								checks[i].Delete();
							}
							else
							{
								checks[i].Worth -= leftPrice;

								if (checks[i].Worth == 0)
									checks[i].Delete();

								return true;
							}
						}
					}
				}
			}

			from.SendMessage( "You can not afford the wager (from your backpack)." );
			return false;
		}
	}
}
using System;
using Server.Misc;
using Server.Gumps;
using Server.Mobiles;
using Server.Prompts;
using System.Collections.Generic;
using Server.Targets;

namespace Server.Items
{
	public class PokerCards : Item
	{
		private static int m_MaxPlayers = 5;
		private bool m_InUse;
		private List<PokerPlayer> m_Players;
		public List<PokerPlayer> Players { get { return m_Players; } }
		private PlayerMobile m_User;
		private List<PlayCard> m_Set;
		private List<PlayCard> m_Drawn;
		private PlayCard[] m_Flop;
		private PlayCard m_Turn;
		private PlayCard m_River;
		private PlayCard[] m_LastFlop;
		private PlayCard m_LastTurn;
		private PlayCard m_LastRiver;
		private int m_DealerButton;
		private int m_Pot;
		public int Pot { get { return m_Pot; } }
		private int m_RoundsPlayed;
		private int m_Blinds;
		private int m_CurrentStakes;
		private int m_SmallBlindsPlayer;
		private int m_BigBlindsPlayer;
		private int m_CurrentPlayer;
		private int m_LastRaiseBy;
		private int m_TimesRaised;
		private bool m_AllowToRaise;
		private int m_PlayersIn;
		private int m_FoldingPlayers;
		public bool AllowToRaise { get { return m_AllowToRaise; } }
		public int CurrentPlayer { get { return m_CurrentPlayer; } }

		public PlayerMobile User
		{
			get
			{
				return m_User;
			}
			set
			{
				m_User = value;
				m_Players = new List<PokerPlayer>();
				m_Players.Add( new PokerPlayer( value, 1000 ) );
			}
		}

		private bool m_Running;
		public bool Running
		{
			get
			{
				return m_Running;
			}
			set
			{
				m_Running = value;
			}
		}

		public int Wager;
		public bool LaunchGame;

		public override void OnDoubleClick( Mobile from )
		{
			if (!from.InRange( this, 2 ))
				return;
			if (LaunchGame)
			{
				m_Running = true;
				Launch();
			}
			else if (User != null)
			{
				if (User == from)
					from.SendMessage( "You already use these." );
				else
					from.SendMessage( "This card set is already being in use." );
			}
			else
			{
				from.SendMessage( "Please submit the minimum wager. (Must be greater or equal to 1000 gold pieces.)" );
				from.Prompt = new PokerWagerPrompt( this );
			}
		}

		private class PokerWagerPrompt : Prompt
		{
			private PokerCards m_Cards;

			public PokerWagerPrompt( PokerCards cards )
			{
				m_Cards = cards;
			}

			public override void OnResponse( Mobile from, string text )
			{
				int wager;

				try
				{
					wager = Convert.ToInt32( text );
				}
				catch
				{
					from.SendMessage( "Commander, only numbers please." );
					return;
				}
				if (m_Cards.User != null)
					from.SendMessage( "These cards are already in use." );
				else if (wager < 1000)
					from.SendMessage( "The minimum wager is 1000 gold pieces." );
				else if (PokerInviteGump.CheckWager( from, wager ))
				{
					m_Cards.User = from as PlayerMobile;
					m_Cards.Wager = wager;
					from.SendMessage( "Add players to the table. Target yourself or cancel, as soon as everybody has accepted!" );
					from.Target = new PokerTarget( m_Cards );
				}
			}
		}

		public void AddPlayer( Mobile player )
		{
			if (CheckPlayer( player ))
				m_Players.Add( new PokerPlayer( (PlayerMobile)player, 1000 ) );
		}

		public bool CheckPlayer( Mobile player )
		{
			foreach (PokerPlayer p in m_Players)
			{
				if (player == p.Player)
					return false;
			}

			return m_Players.Count <= m_MaxPlayers;
		}

		public void Launch()
		{
			if (m_Players.Count == 1)
			{
				PayWager( m_Players[0].Player );
				ResetToDefaults();
			}
			else
			{
				m_Set = PlayCard.FreshCardsSet();
				m_Drawn = new List<PlayCard>();

				m_DealerButton = Utility.Random(m_Players.Count);

				StartMatch();
			}
		}

		public void StartMatch()
		{
			m_Blinds = 10;
			m_LastRaiseBy = -2;
			m_PlayersIn = m_Players.Count;
			m_FoldingPlayers = 0;

			m_DealerButton = Utility.Random( m_Players.Count );

			PayBlinds();
			GiveCards();

			ShowGumps();
		}

		public void StartNextRound()
		{
			int count = 0;
			for (int i = 0; i < m_Players.Count; ++i)
			{
				if (m_Players[i].Chips > 0)
				{
					m_Players[i].DidFold = false;
					if (m_Players[i].BetToPot != 0)
						Console.WriteLine( "Possible PokerBug with spliting pot." );
					m_Players[i].BetToPot = 0;
					m_Players[i].LastHand = m_Players[i].Hand;
					m_Players[i].Hand[0] = null;
					m_Players[i].Hand[1] = null;
					m_Players[i].LastAction = "";
					++count;
				}
				else
					m_Players[i].IsOut = true;
			}

			if (count == 1)
			{
				PayWager( m_Players[0].Player );
				ResetToDefaults();
			}
			else
			{
				m_Flop = null;
				m_Turn = null;
				m_River = null;
				for (int i = m_Drawn.Count - 1; i >= 0; --i)
					m_Set.Add( m_Drawn[i] );
				m_Drawn.Clear();
				m_DealerButton = GetNextPlayer( m_DealerButton );
				PayBlinds();
				GiveCards();

				ShowGumps();
			}
		}

		#region GetNextPlayer
		public int GetNextPlayer( int current )
		{
			return GetNextPlayer( current, 0 );
		}

		public int GetNextPlayer( int current, int overflow )
		{
			if ( overflow == m_Players.Count )
			{
				if (m_User != null) //sanity
					m_User.SendMessage( "Bug when trying to find next player, overflow catched." );

				Console.WriteLine( "Bug when trying to find next player, overflow catched." );
				return 0;
			}

			Console.WriteLine( current.ToString() + " <<< Current," + overflow.ToString() + ",Players >>> " + m_Players.Count.ToString() );

			int next = current + 1;
			if (next == m_Players.Count)
				next = 0;

			if (!m_Players[next].IsOut)
				return next;
			else
				return GetNextPlayer( next, ++overflow );
		}
		#endregion

		#region GiveCards
		public void GiveCards()
		{
			for (int i = 0; i < m_Players.Count; ++i)
				GiveTwoCardsTo( m_Players[i] );
		}

		public void GiveTwoCardsTo( PokerPlayer to )
		{
			int i = Utility.Random( m_Set.Count );
			to.Hand[0] = m_Set[i];
			m_Drawn.Add( m_Set[i] );
			m_Set.RemoveAt(i);
			i = Utility.Random( m_Set.Count );
			to.Hand[1] = m_Set[i];
			m_Drawn.Add( m_Set[i] );
			m_Set.RemoveAt(i);
		}
		#endregion

		#region PayBlinds
		public void PayBlinds()
		{
			// Here would be checked, if they want the blinds...
			m_SmallBlindsPlayer = GetNextPlayer( m_DealerButton );
			PaySmallBlinds();
			m_BigBlindsPlayer = GetNextPlayer( m_SmallBlindsPlayer );
			PayBigBlinds();
		}

		public void PaySmallBlinds()
		{
			PayChips( m_Players[m_SmallBlindsPlayer], m_Blinds / 2 );
		}

		public void PayBigBlinds()
		{
			PayChips( m_Players[m_BigBlindsPlayer], m_Blinds );
		}
		#endregion

		public void DoFlop()
		{
			int i = Utility.Random( m_Set.Count );
			PlayCard f0 = m_Set[i];
			m_Drawn.Add( m_Set[i] );
			m_Set.RemoveAt( i );
			i = Utility.Random( m_Set.Count );
			PlayCard f1 = m_Set[i];
			m_Drawn.Add( m_Set[i] );
			m_Set.RemoveAt( i );
			i = Utility.Random( m_Set.Count );
			PlayCard f2 = m_Set[i];
			m_Drawn.Add( m_Set[i] );
			m_Set.RemoveAt( i );
			m_Flop = new PlayCard[3]
				{
					f0,
					f1,
					f2
				};
		}

		public void DoTurn()
		{
			int i = Utility.Random( m_Set.Count );
			m_Turn = m_Set[i];
			m_Drawn.Add( m_Set[i] );
			m_Set.RemoveAt(i);
		}

		public void DoRiver()
		{
			int i = Utility.Random( m_Set.Count );
			m_River = m_Set[i];
			m_Drawn.Add( m_Set[i] );
			m_Set.RemoveAt( i );
		}

		public void ShowGumps() //deals cards too
		{
			if (m_CurrentPlayer == m_LastRaiseBy
				|| (m_LastRaiseBy == -1 && m_CurrentPlayer == GetNextPlayer( m_BigBlindsPlayer )))
			{
				if (m_FoldingPlayers == m_Players.Count - 1) // TODO: got to consider players, who are out
				{
					//TODO: Don't need any of these, but got to consider All-Ins later
					if (m_Flop == null)
						DoFlop();
					if (m_Turn == null)
						DoTurn();
					if (m_River == null)
						DoRiver();
					Evaluate();
				}
				else if (m_Flop == null)
					DoFlop();
				else if (m_Turn == null)
					DoTurn();
				else if (m_River == null)
					DoRiver();
				else
				{
					Evaluate();
					return;
				}
			}

			if (m_LastRaiseBy == -2) // To prevent mess up in showdown
				++m_LastRaiseBy;

			for (int i = 0; i < m_Players.Count; ++i)
			{
				m_Players[i].Player.CloseGump( typeof( PlayerPokerGump ) );
				m_Players[i].Player.SendGump( new PlayerPokerGump( this, i ) );
			}
		}

		#region Evaluate
		// Evaluates the Hand
		public void Evaluate()
		{
			//go through all players and determinate the 1st pot, evaluate all cards and award the pot, set the player done and repeat
			for (int j = 0; j < m_Players.Count; ++j)
			{
				int lowestBet = -1;
				for (int i = 0; i < m_Players.Count; ++i)
				{
					if (!m_Players[i].IsOut && !m_Players[i].DidFold && m_Players[i].BetToPot > 0 && ( m_Players[i].BetToPot < lowestBet || lowestBet == -1 ))
						lowestBet = m_Players[i].BetToPot;
				}

				if (lowestBet > 0)
				{
					Console.WriteLine( "Splitting pot stage " + j.ToString() );
					List<PokerPlayer> winners = EvaluateHandsForBet( lowestBet );
					int collect = 0;
					for (int i = 0; i < m_Players.Count; ++i)
					{
						if (m_Players[i].BetToPot > 0)
						{
							collect += Math.Min( lowestBet, m_Players[i].BetToPot );
							m_Players[i].BetToPot -= Math.Min( lowestBet, m_Players[i].BetToPot );
						}
					}
					m_Pot -= collect;
					for (int i = 0; i < winners.Count; ++i)
					{
						int floor = (int)Math.Floor( (double)collect / winners.Count );
						winners[i].Chips += floor;
						for (int k = 0; k < m_Players.Count; ++k)
						{
							m_Players[k].Player.SendMessage( winners[i].Name + " won " + floor.ToString() + " chips." );
						}
					}
				}
				else
					break;
			}

			StartNextRound();
		}

		public List<PokerPlayer> EvaluateHandsForBet( int bet )
		{
			List<PokerPlayer> winners = new List<PokerPlayer>();
			HandType highest = HandType.Unset;

			for (int i = 0; i < m_Players.Count; ++i)
			{
				if (m_Players[i].IsOut || m_Players[i].DidFold || m_Players[i].BetToPot <= 0)
					continue;

				m_Players[i].FinalHand = SortCardsByValue( m_Flop, m_Turn, m_River, m_Players[i].Hand );

				if (CheckFlush( ref m_Players[i].FinalHand ))
				{
					if (CheckStraight( ref m_Players[i].FinalHand ))
						m_Players[i].FinalHandType = HandType.StraightFlush;
					else
						m_Players[i].FinalHandType = HandType.Flush;
				}
				else if (CheckStraight( ref m_Players[i].FinalHand ))
				{
					m_Players[i].FinalHandType = HandType.Straight;
				}
				else
				{
					HandType hand = CheckMultiCards( ref m_Players[i].FinalHand );
					if (hand != HandType.HighCard)
					{
						m_Players[i].FinalHandType = hand;
					}
					else
					{
						m_Players[i].FinalHand = new PlayCard[5]
						{
							m_Players[i].FinalHand[0],
							m_Players[i].FinalHand[1],
							m_Players[i].FinalHand[2],
							m_Players[i].FinalHand[3],
							m_Players[i].FinalHand[4]
						};

						m_Players[i].FinalHandType = HandType.HighCard;
					}
				}

				if (m_Players[i].FinalHandType > highest)
				{
					winners.Clear();
					winners.Add( m_Players[i] );
				}
				else if (m_Players[i].FinalHandType == highest)
				{
					for (int j = 0; j < 5; ++j)
					{
						if (m_Players[i].FinalHand[j].Value > winners[0].FinalHand[j].Value)
						{
							winners.Clear();
							winners.Add( m_Players[i] );
							break;
						}
						else if (m_Players[i].FinalHand[j].Value < winners[0].FinalHand[j].Value)
							break;
						else if (j == 4)
						{
							winners.Add( m_Players[i] );
						}
					}
				}
			}

			return winners;
		}

		public HandType CheckMultiCards( ref PlayCard[] cards )
		{
			//int same = 1;
			int twostart1 = -1;
			int twostart2 = -1;
			int twostart3 = -1;
			int threestart1 = -1;
			int threestart2 = -1;
			int start = 0;
			int current = 0;
			for (int i = 0; i < cards.Length - 1; ++i)
			{
				if (cards[i].Value == cards[i + 1].Value && i != cards.Length - 2)
				{
					if (++current == 4)
					{
						OnFour( ref cards, start );
						return HandType.Four;
					}
				}
				else
				{
					if (cards[i].Value == cards[i + 1].Value && ++current == 4)
					{
						OnFour( ref cards, start );
						return HandType.Four;
					}
					else if (current == 3)
					{
						if (threestart1 == -1)
						{
							threestart1 = start;
						}
						else
						{
							threestart2 = start;
							break;
						}
					}
					else if (current == 2)
					{
						if (twostart1 == -1)
						{
							twostart1 = start;
						}
						else if (twostart2 == -1)
						{
							twostart2 = start;
							if (threestart1 != -1)
								break;
						}
						else
						{
							twostart3 = start;
							break;
						}
					}
					start = i;
					//same = 1;
				}
			}

			if (threestart1 != -1)
			{
				if (threestart2 != -1)
				{
					if (cards[threestart1].Value > cards[threestart2].Value)
						OnFullHouse( ref cards, threestart1, threestart2 );
					else
						OnFullHouse( ref cards, threestart2, threestart1 );
					return HandType.FullHouse;
				}
				else if (twostart1 != -1)
				{
					if (twostart2 != -1 && cards[twostart2].Value > cards[twostart1].Value)
						OnFullHouse( ref cards, threestart1, threestart2 );
					else
						OnFullHouse( ref cards, threestart1, twostart1 );
					return HandType.FullHouse;
				}
				else
				{
					if (threestart1 == 0)
					{
						cards = new PlayCard[5]
							{
								cards[0],
								cards[1],
								cards[2],
								cards[3],
								cards[4]
							};
					}
					else if (threestart1 == 1)
					{
						cards = new PlayCard[5]
							{
								cards[1],
								cards[2],
								cards[3],
								cards[0],
								cards[4]
							};
					}
					else
					{
						cards = new PlayCard[5]
							{
								cards[threestart1],
								cards[threestart1 + 1],
								cards[threestart1 + 2],
								cards[0],
								cards[1]
							};
					}
					return HandType.Three;
				}
			}
			else if (twostart1 != -1)
			{
				if (twostart2 != -1)
				{
					if (twostart3 != -1 && !(cards[twostart1].Value > cards[twostart3].Value && cards[twostart2].Value > cards[twostart3].Value))
					{
					}
					else
					{
						int high = 0;
						if (twostart1 == 0 || twostart2 == 0)
						{
							if (twostart1 == 2 || twostart2 == 2)
								high = 4;
							else
								high = 2;
						}

						if (cards[twostart1].Value > cards[twostart2].Value)
						{
							cards = new PlayCard[5]
								{
									cards[twostart1],
									cards[twostart1 + 1],
									cards[twostart2],
									cards[twostart2 + 1],
									cards[high]
								};
						}
						else
						{
							cards = new PlayCard[5]
								{
									cards[twostart2],
									cards[twostart2 + 1],
									cards[twostart1],
									cards[twostart1 + 1],
									cards[high]
								};
						}
					}
					return HandType.TwoPairs;
				}
				else if (twostart1 == 0)
				{
					cards = new PlayCard[5]
						{
							cards[0],
							cards[1],
							cards[2],
							cards[3],
							cards[4]
						};
				}
				else if (twostart1 == 1)
				{
					cards = new PlayCard[5]
						{
							cards[1],
							cards[2],
							cards[0],
							cards[3],
							cards[4]
						};
				}
				else if (twostart1 == 2)
				{
					cards = new PlayCard[5]
						{
							cards[2],
							cards[3],
							cards[0],
							cards[1],
							cards[4]
						};
				}
				else
				{
					cards = new PlayCard[5]
						{
							cards[twostart1],
							cards[twostart1 + 1],
							cards[0],
							cards[1],
							cards[2]
						};
				}
				return HandType.Pair;
			}
			else
				return HandType.HighCard;
		}

		public void OnFullHouse( ref PlayCard[] cards, int startthree, int starttwo )
		{
			cards = new PlayCard[5]
					{
						cards[startthree],
						cards[startthree + 1],
						cards[startthree + 2],
						cards[starttwo],
						cards[starttwo + 1]
					};
		}

		public void OnFour( ref PlayCard[] cards, int start )
		{
			if (start == 0)
			{
				cards = new PlayCard[5]
					{
						cards[0],
						cards[1],
						cards[2],
						cards[3],
						cards[4]
					};
			}
			else
			{
				cards = new PlayCard[5]
					{
						cards[start],
						cards[start + 1],
						cards[start + 2],
						cards[start + 3],
						cards[0]
					};
			}
		}

		public PlayCard[] SortCardsByValue( PlayCard[] flop, PlayCard turn, PlayCard river, PlayCard[] hand )
		{
			PlayCard[] cards = new PlayCard[7]
					{
						flop[0],
						flop[1],
						flop[2],
						turn,
						river,
						hand[0],
						hand[1]
					};

			for (int i = 0; i < 6; ++i)
			{
				for (int j = 1; j + i < 7; ++j)
				{
					if (cards[i].Value < cards[i + j].Value)
					{
						PlayCard temp = cards[i];
						cards[i] = cards[i + j];
						cards[i + j] = temp;
					}
				}
			}

			return cards;
		}

		public bool CheckFlush( ref PlayCard[] cards )
		{
			int spades = 0;
			int hearts = 0;
			int diamonds = 0;
			int clubs = 0;
			for (int i = 0; i < cards.Length; ++i)
			{
				if (cards[i].Colour == CardColour.Spade)
					++spades;
				else if (cards[i].Colour == CardColour.Heart)
					++hearts;
				else if (cards[i].Colour == CardColour.Diamond)
					++diamonds;
				else
					++clubs;
			}

			if (spades == 7 || hearts == 7 || diamonds == 7 || clubs == 7)
				return true;
			else if (spades < 5 && hearts < 5 && diamonds < 5 && clubs < 5)
				return false;

			if ( spades >= 5 )
				cards = RemoveCardsNotOfColor( CardColour.Spade, cards );
			else if (hearts >= 5)
				cards = RemoveCardsNotOfColor( CardColour.Heart, cards );
			else if (diamonds >= 5)
				cards = RemoveCardsNotOfColor( CardColour.Diamond, cards );
			else
				cards = RemoveCardsNotOfColor( CardColour.Club, cards );

			return true;
		}

		public PlayCard[] RemoveCardsNotOfColor( CardColour colour, PlayCard[] cards )
		{
			int[] pos = new int[6]
				{
					-1,
					-1,
					-1,
					-1,
					-1,
					-1
				};

			for (int i = 0; i < cards.Length; ++i)
			{
				if (cards[i].Colour == colour)
				{
					for (int j = 0; j < 6; ++j)
					{
						if (pos[j] == -1)
						{
							pos[j] = i;
							break;
						}
					}
				}
			}

			if (pos[5] != -1)
			{
				return new PlayCard[6]
					{
						cards[pos[0]],
						cards[pos[1]],
						cards[pos[2]],
						cards[pos[3]],
						cards[pos[4]],
						cards[pos[5]],
					};
			}
			else
			{
				return new PlayCard[5]
					{
						cards[pos[0]],
						cards[pos[1]],
						cards[pos[2]],
						cards[pos[3]],
						cards[pos[4]],
					};
			}
		}

		public bool CheckStraight( ref PlayCard[] cards )
		{
			int wasted = 0;
			for (int i = 0; i < cards.Length - 4; ++i)
			{
				if (wasted > 2)
					return false;

				int start = (int)cards[i].Value;
				int end = start == 5 ? 13 : start - 4;
				int[] pos = new int[5]
					{
						i,
						-1,
						-1,
						-1,
						-1
					};

				for (int j = i + 1; j < cards.Length; ++j)
				{
					if ((int)cards[j].Value != start - 1)
					{
						if (++wasted > 2)
							return false;

						if ((int)cards[i + 1].Value != start)
							break;
					}
					else
					{
						for (int k = 1; k < 5; ++k)
						{
							if (pos[k] == -1)
							{
								pos[k] = j;
								break;
							}
						}

						if (pos[4] != -1)
							break;
						else if (start == 2)
							start = 13;
						else
							--start;
					}
				}

				if (pos[4] != -1)
				{
					cards = new PlayCard[5]
						{
							cards[pos[0]],
							cards[pos[1]],
							cards[pos[2]],
							cards[pos[3]],
							cards[pos[4]]
						};
					return true;
				}
			}

			return false;
		}
		#endregion

		public bool CurrentMayRaise()
		{
			return m_Players[m_CurrentPlayer].Chips > 0;
		}

		#region Check-Raise-Fold
		public void Check() // Call
		{
			PayChips( m_Players[m_CurrentPlayer], m_CurrentStakes - m_Players[m_CurrentPlayer].BetToPot );
			m_Players[m_CurrentPlayer].LastAction = "Check";

			m_CurrentPlayer = GetNextPlayer( m_CurrentPlayer );
			ShowGumps();
		}
		public void Raise()
		{
			int toPay = m_CurrentStakes - m_Players[m_CurrentPlayer].BetToPot;
			if (m_Players[m_CurrentPlayer].Chips <= toPay) // Can't raise without Chips
			{
				Check();
				return;
			}
			m_Players[m_CurrentPlayer].LastAction = "Raise";

			if (++m_TimesRaised >= 4)
				m_AllowToRaise = false;

			int raiseAmount = Math.Min( m_Blinds, m_Players[m_CurrentPlayer].Chips - toPay );
			m_CurrentStakes += raiseAmount;

			PayChips( m_Players[m_CurrentPlayer], toPay + raiseAmount );

			m_LastRaiseBy = m_CurrentPlayer;
			m_CurrentPlayer = GetNextPlayer( m_CurrentPlayer );
			ShowGumps();
		}
		public void Fold()
		{
			m_Players[m_CurrentPlayer].DidFold = true;
			m_Players[m_CurrentPlayer].LastAction = "Fold";

			++m_FoldingPlayers;
			m_CurrentPlayer = GetNextPlayer( m_CurrentPlayer );
			ShowGumps();
		}
		#endregion

		public void PayChips( PokerPlayer p, int amount )
		{
			if (amount > p.Chips)
				amount = p.Chips;

			p.Chips -= amount;
			p.BetToPot += amount;
			m_Pot += amount;
		}

		public void PayWager( PlayerMobile to )
		{
			Container c = to.Backpack;
			if (c == null)
				return;
			for ( int i = 0; i < m_Players.Count; ++i )
				c.DropItem( new BankCheck( Wager ) );
		}

		public void ResetToDefaults()
		{
			m_Running = false;
			m_InUse = false;
			m_User = null;
			m_Players.Clear();
		}

		#region ctor/ser/deser
		[Constructable]
		public PokerCards() : base( 0xFA3 )
		{
		}

		public PokerCards( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
		#endregion
	}
}
using System.Collections.Generic;
using Server.Mobiles;

namespace Server.Misc
{
	public enum CardColour //not implemented... using 0 to 3 atm
	{
		Spade = 9824,
		Heart,
		Diamond,
		Club
	}

	public enum CardValue
	{
		NoCard = 0,
		Two = 2,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jester,
		Queen,
		King,
		Ace // = 14
	}

	public class PlayCard
	{
		public static List<PlayCard> FreshCardsSet()
		{
			List<PlayCard> set = new List<PlayCard>();

			for (int i = 0; i < 4; ++i)
			{
				for (int j = 2; j < 14; ++j)
				{
					set.Add( new PlayCard( (CardValue)j, (CardColour)i ) );
				}
			}

			return set;
		}

		public CardValue Value;
		public CardColour Colour;

		public PlayCard( CardValue val, CardColour col )
		{
			Value = val;
			Colour = col;
		}
	}

	public enum HandType
	{
		Unset,
		HighCard,
		Pair,
		TwoPairs,
		Three,
		Straight,
		Flush,
		FullHouse,
		Four,
		StraightFlush
	}

	public class PokerPlayer
	{
		public PlayerMobile Player;
		public string Name;
		public PlayCard[] Hand;
		public PlayCard[] LastHand;
		public int Chips;
		public int BetToPot;
		public bool DidFold;
		public bool IsOut;
		public string LastAction;
		public PlayCard[] FinalHand;
		public HandType FinalHandType;

		public PokerPlayer( PlayerMobile player, int gold )
		{
			Player = player;
			Hand = new PlayCard[2];
			LastHand = new PlayCard[2];
			Chips = gold;
			BetToPot = 0;
			IsOut = false;
			LastAction = "";
			Name = Player.RawName;
		}
	}
}
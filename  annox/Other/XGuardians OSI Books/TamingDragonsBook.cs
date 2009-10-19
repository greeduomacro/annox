using System;
using Server;

namespace Server.Items
{
	public class TamingDragonsBook : BrownBook
	{
		[Constructable]
		public TamingDragonsBook() : base( "Taming Dragons", "Wyrd Beastmaster ", 7, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"I have not much to tell", 
				"about dragons. The sole", 
				"time I approached one", 
				"with an eye towards", 
				"taming it, my initial", 
				"attempts at calming it",
				"met with failure. It",
				"fixed a massive beady eye", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"upon me, and began its", 
				"slithering approach,", 
				"intending no doubt to", 
				"insert me into its maw", 
				"and bear down with its", 
				"teeth.", 
				"", 
				"However, as I was engaged", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"in what remains to this", 
				"day the most terrifying", 
				"combat of my life, the", 
				"dragon suddenly whirled", 
				"as if in a panic, ran a", 
				"short distance, took off", 
				"into the air, then", 
				"transformed into a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"whirlwind. Lastly, it", 
				"exploded, showering", 
				"gouts of black blood and", 
				"heaving, stinking flesh", 
				"upon miles of", 
				"countryside. The fireball", 
				"was massive enough to", 
				"light a city I should", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"surmise.", 
				"", 
				"I never did discover the", 
				"exact cause of this",
				"strange behavior except",
				"to assume that it was not", 
				"typical for this", 
				"reptilian species. My", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"best guesses revolve", 
				"around a magical fracture", 
				"in the nature of reality,", 
				"which is far too esoteric",
				"a territory for one of",
				"my limited scholarship.", 
				"", 
				"Hence my basic advice to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"those who seek to tame a", 
				"dragon-be sure that thou", 
				"hast mastered the twin", 
				"skills of taming animals,",
				"and running away very",
				"fast.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TamingDragonsBook( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}
	}
}
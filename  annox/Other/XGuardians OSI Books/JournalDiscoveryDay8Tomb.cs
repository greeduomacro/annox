using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay8Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay8Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 7, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 8:", 
				"", 
				"Astounding progress was", 
				"made today, and my very", 
				"head spins with the", 
				"excitement of it. Upon",
				"full excavation of the",
				"far western hall, another", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"large antechamber was", 
				"revealed. By the larger,", 
				"mosaic style of the wall", 
				"carvings and their", 
				"framing, as well as the", 
				"numerous vellum scrolls", 
				"and tomes held within,", 
				"the room appears to have", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"been a great museum or", 
				"library of sorts. The", 
				"sheer amount of written", 
				"information encased", 
				"within this room would", 
				"surely take me decades", 
				"to study e'en if I could", 
				"immediately decipher the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"strange text with which", 
				"it was written. My sheer", 
				"joy at the discovery was", 
				"quickly noted by the", 
				"brute known as Morg", 
				"Bergen, who, even in his", 
				"simple way, seemed just", 
				"as delighted as I that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"some progress had been", 
				"made. I must confess,", 
				"upon his inclusion in our", 
				"party at the beginning of",
				"this journey I was",
				"somewhat suspect of his", 
				"nature, but he has a", 
				"startingly quick wit about", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"him for such a massive,", 
				"calloused warrior. While", 
				"Lysander and e'en", 
				"Grimmoch always seem to",
				"investigate the tomb",
				"with a scowling", 
				"determination, Bergen", 
				"seems to feel the same", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"thrill of discovery as I.", 
				"I am proud to now count", 
				"him as a friend, and am", 
				"thankful for his laughter",
				"as well as his strength.",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay8Tomb( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummelDay2 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummelDay2() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 6, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 2:", 
				"", 
				"We managed to dig out", 
				"the last of the remaining", 
				"rubble today , revealing", 
				"the entirety of the giant",
				"stone doors that sealed",
				"ol Khal Ankur and his", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"folks up ages ago.", 
				"Actually getting them", 
				"open was another matter", 
				"altogether, however. As", 
				"the workers set to the", 
				"task with picks and", 
				"crowbars, I could have", 
				"sworn I saw Lysander", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Gathenwale fiddling with", 
				"something in that musty", 
				"old tome of his. I've no", 
				"great knowledge of", 
				"things magical, but the", 
				"way his hand moved over", 
				"that book, and the look", 
				"of concentration on his", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"face as he whispered", 
				"something to himself", 
				"looked like every", 
				"description of an", 
				"incantation I've ever", 
				"heard. The strange thing", 
				"is, this set of doors", 
				"that an entire crew of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"excavators was laboring", 
				"over for hours, right", 
				"then when Gathenwale", 
				"finishes with his",
				"mumbling... well I swore",
				"the doors just gave open", 
				"at the exact moment he", 
				"spoke his last bit of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"whisper and shut the tome", 
				"tight in his hands. When", 
				"he looked up, it was", 
				"almost as if hew was",
				"expecting the doors to",
				"be open, rather than", 
				"shocked that they'd", 
				"finally given way.", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalGrimmochDrummelDay2( Serial serial ) : base( serial )
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
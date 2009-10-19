using System;
using Server;

namespace Server.Items
{
	public class AnNoxGuideBook : BrownBook
	{
		[Constructable]
        public AnNoxGuideBook()
            : base("Teusi's guide to An Nox", "Teusi ", 15, false) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"This reference work is", 
				"intended merely to serve", 
				"as a resource for those", 
				"curious about An Nox. ", 
				"Our world if full of", 
				"wonderful adventures.",
				"",
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"**Hours of Power**", 
				"From 6am till 9am and", 
				"then again from 9pm", 
				"till midnight.  At ", 
				"that special time ", 
				"skill advancement will", 
				"double its normal rate.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
                "**Free House Friday**", 
                "Visitors on Fridays will", 
				"recieve a free house, if",
				"they can find the 'Free", 
				"House Friday' status in", 
				"Minoc.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"**Super Sword Saturdays**",
				"Bring your friends.", 
				"Find the status in Minoc", 
				"and every hour you can ", 
				"get a new magical weapon.", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"**Mega Mount Mondays**", 
				"Visit a particular stable", 
				"on Monday and receive a", 
				"magical mount to use in ",
				"the land of An Nox.",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"**Race Gates**", 
				"Morph in to another form", 
				"by using the tailisman", 
				"you get after walking ",
				"through the race gate of",
				"your choice.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"**Bounty Hunter**", 
				"Goblins have invaded the", 
				"mines near Minoc.  Kill", 
				"them and scalp off their",
				"ears and the bounty ",
				"hunter will reward thee.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "**White bar above green", 
        //        "bar.", 
        //        "", 
        //        "Guild of Sorcery. A field",
        //        "divided diagonally in",
        //        "blue and purple.", 
        //        "", 
        //        "Healer's Guild. Gold", 
        //    };			
        //    Pages[cnt++].Lines = lines;
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "swath dividing green from", 
        //        "purple, gold accents.", 
        //        "", 
        //        "Lord British's Healers of",
        //        "Virtue. Golden ankh on", 
        //        "dark green.", 
        //        "", 
        //        "Masters of Illusion. Blue", 
        //    }; 
        //    Pages[cnt++].Lines = lines;
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "and purple checkers.", 
        //        "", 
        //        "Merchant's Guild. Gold", 
        //        "coins on green field.", 
        //        "", 
        //        "Mining Cooperative.", 
        //        "A gold cross, quartering", 
        //        "blue and black.", 
        //    }; 
        //    Pages[cnt++].Lines = lines;
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "Order of Engineers.", 
        //        "Purple, gold, and blue", 
        //        "vertical.", 
        //        "", 
        //        "Sailors' Maritime", 
        //        "Association. A white bar", 
        //        "centered on a blue field.", 
        //        "", 
        //    }; 
        //    Pages[cnt++].Lines = lines;
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "Seamen's Chapter. Blue", 
        //        "and white in a crossed", 
        //        "pennant pattern.", 
        //        "", 
        //        "Society of Cooks and", 
        //        "Chefs. White and red", 
        //        "diagonal fields checker", 
        //        "on green field.", 
        //    }; 
        //    Pages[cnt++].Lines = lines; 
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "Society of Shipwrights.", 
        //        "White diagonal above", 
        //        "blue.", 
        //        "", 
        //        "Society of Thieves.", 
        //        "Black and red diagonal", 
        //        "stripes.", 
        //        "", 
        //    }; 
        //    Pages[cnt++].Lines = lines;
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "Society of Weaponsmakers.", 
        //        "Gold diagonal above", 
        //        "black.", 
        //        "", 
        //        "Tailor's Hall. Purple", 
        //        "above gold above red.", 
        //        "", 
        //        "The Bardic Collegium.", 
        //    }; 
        //    Pages[cnt++].Lines = lines;
        ////		0----+----1----+----2----+
        //    lines = new string[] 
        //    { 
        //        "Purple and red checkers", 
        //        "on gold field.", 
        //        "", 
        //        "Trader's Guild. White", 
        //        "bar centered down green", 
        //        "field.", 
        //        "", 
        //        "", 
        //    }; 
        //    Pages[cnt++].Lines = lines;
		}

		public AnNoxGuideBook( Serial serial ) : base( serial )
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
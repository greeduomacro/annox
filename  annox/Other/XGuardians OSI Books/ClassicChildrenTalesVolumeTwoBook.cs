using System;
using Server;

namespace Server.Items
{
	public class ClassicChildrenTalesVolumeTwoBook : BrownBook
	{
		[Constructable]
		public ClassicChildrenTalesVolumeTwoBook() : base( "Classic children's tales: Volume two", "Guilhem ", 8, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Clarke's Printery is", 
				"Honored to Present Tales", 
				"from Ages Past! Guilhem", 
				"the Scholar Shall End", 
				"Each Volume with Staid", 
				"Commentary.",
				"",
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"THE RHYME", 
				"Dance in the Star Chamber", 
				"And Dance in the Pit", 
				"And Eat of your Entrees", 
				"In the Glass House you Sit.", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"COMMENTARY", 
				"", 
				"A common rhyme for little", 
				"babies, 'tis thought that", 
				"this littl(e) ditty is", 
				"part of the corpus of", 
				"legendary tales regarding", 
				"the world before Sosaria", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"(see the wonderful fables", 
				"of Fabio the Poor for", 
				"fictionalized versions of", 
				"these stories, also", 
				"available from this same", 
				"publisher). According to", 
				"these old tales, which", 
				"survive mostly in th(e)", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"hills and remote villages", 
				"where Lord British is as", 
				"yet a distant and", 
				"mythical ruler, the gods",
				"of old (a fanciful",
				"notion!) met to discuss", 
				"the progress of creating", 
				"the world in mystical", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"rooms. A simple analysis", 
				"reveals these rooms to", 
				"be mere mythological", 
				"generalizations.",
				"",
				"The Star Chamber is", 
				"clearly a reference to the", 
				"sky. The Pit is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"certainl(y) an Underworld", 
				"analogous to the Snake", 
				"hills of other tales, and", 
				"the Glass House is no",
				"doubt the vantage point",
				"from which the gods", 
				"observed their creation.", 
				"All is simple when seen", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"from this perspective,", 
				"leaving only the", 
				"mysterious reference to", 
				"dinners(.) Oddly enough",
				"the rhyme is",
				"universally(y) used only", 
				"for midnight feedings,", 
				"never during the day.", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public ClassicChildrenTalesVolumeTwoBook( Serial serial ) : base( serial )
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
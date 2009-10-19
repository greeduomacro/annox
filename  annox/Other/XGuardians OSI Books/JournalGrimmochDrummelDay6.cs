using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummelDay6 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummelDay6() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 6, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 6:", 
				"", 
				"The camp was attacked", 
				"last night by a pack of,", 
				"well, I don't have a", 
				"clue. I've never seen",
				"the likes of these",
				"beasts anywhere. Huge", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"things, with fangs the", 
				"size of your forefinger,", 
				"covered in hair and with", 
				"the strangest arched back", 
				"I've ever seen. And so", 
				"many of them. We were", 
				"forced back into the Tomb", 
				"for the night, just to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"keep our hides on us. And", 
				"today Gathenwale", 
				"practically orders us all", 
				"to move the entire", 
				"exterior camp into the", 
				"Tomb. Now, I don't", 
				"disagree that we'd be", 
				"well off to use the place", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"as a point of", 
				"fortification... but I", 
				"don't like it one bit,", 
				"in anycase. I don't like", 
				"the looks of this place,", 
				"nore the sound of it. The", 
				"way the wind gets into", 
				"the passageways,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"whistling up the", 
				"strangest noises. Deep,", 
				"sustained echoes of the", 
				"wind, not so much flute-",
				"like as...well, it",
				"sounds ridiculous. In", 
				"any case, we've set to", 
				"work moving the bulk of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the exterior camp into", 
				"the main antechamber so", 
				"there's no moaning about", 
				"it now.",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalGrimmochDrummelDay6( Serial serial ) : base( serial )
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
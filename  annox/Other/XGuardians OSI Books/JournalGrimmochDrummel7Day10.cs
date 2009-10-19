using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummel7Day10 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummel7Day10() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 7-10:", 
				"", 
				"I cannot stand this", 
				"place, I cannot bear it.", 
				"I've got to get out.", 
				"Something evil lurks in",
				"this ancient place,",
				"something best left", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"alone. I hear them, yet", 
				"none of the others do.", 
				"And yet they must. Hands,", 
				"claws, scratching at", 
				"stone, the awful", 
				"scratching and the", 
				"piteous cries that sound", 
				"almost like laughter.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I can hear them above", 
				"even the cracks of the", 
				"workmen's picks, and at", 
				"night they are all I can", 
				"hear. And yet the others", 
				"hear nothing. We must", 
				"leave this place, we", 
				"must. Three workers have", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"gone missing - Tavara", 
				"expects they've abandoned", 
				"us - and I count them", 
				"lucky if they have. I", 
				"don't care what the", 
				"others say, we must leave", 
				"this place. We must do", 
				"those before and pile up", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the stones, block all", 
				"access to this primeval", 
				"crypt, seal it up again", 
				"for all eternity.",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

        public JournalGrimmochDrummel7Day10(Serial serial)
            : base(serial)
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
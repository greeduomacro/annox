using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummel3Day5 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummel3Day5() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 6, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 3-5:", 
				"", 
				"I might have written too", 
				"hastily in my first entry", 
				"- this place doesn't", 
				"seem too bent on giving",
				"up any secrets. Though",
				"the main antechamber is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"open to us, the main exit", 
				"hall is blocked by yet", 
				"another pile of rubble.", 
				"Doesn't look a bit like", 
				"anything caused by a", 
				"quake or instability in", 
				"the stonework... I swear", 
				"it looks as if someone", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"actually piled the stones", 
				"up themselves, some time", 
				"after the tomb was built.", 
				"The stones aren't of the", 
				"same set nor quality of", 
				"the carved work that", 
				"surrounds them - if", 
				"anything, they resemble", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the grade of common rock", 
				"we saw in great", 
				"quantities on the trip", 
				"here. Which makes it feel", 
				"all the more like someone", 
				"hauled them in and", 
				"covered this passage. But", 
				"then why not decorate", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"them in the same ornate", 
				"manner as the rest of the", 
				"stone in this place?", 
				"Lysander wouldn't hear a",
				"work of what I had to say",
				"- to him, it was a quake", 
				"sometime in the history", 
				"of the tomb, and that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"was it, shut up and move", 
				"on. So I shut up, and", 
				"got back to work.", 
				"",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

        public JournalGrimmochDrummel3Day5(Serial serial)
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
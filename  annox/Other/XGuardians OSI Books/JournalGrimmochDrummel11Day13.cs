using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummel11Day13 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummel11Day13() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 3, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 11-13:", 
				"", 
				"Lysander is gone, and two", 
				"more workers with him.", 
				"Good riddance to the", 
				"first. He knows",
				"something. He heard them",
				"too, I know he did -", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"and yet he scowled at me", 
				"when I mentioned them.", 
				"I cannot stop the noise", 
				"in my head, the", 
				"scratching, the clawing", 
				"tears at my senses. What", 
				"is it? What does", 
				"Lysander seek that I can", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"only turn from? Where has", 
				"he gone? The only answer", 
				"to my questions comes as", 
				"laughter from behind the", 
				"stones.", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

        public JournalGrimmochDrummel11Day13(Serial serial)
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
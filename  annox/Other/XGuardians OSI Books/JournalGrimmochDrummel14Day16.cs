using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummel14Day16 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummel14Day16() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 14-16:", 
				"", 
				"We are lost ... we are", 
				"lost ... all is lost. The", 
				"dead are piled up at my", 
				"feet. Bergen and I",
				"managed somehow in the",
				"madness to piece together", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"a barricade, barring", 
				"access to the camp", 
				"antechamber. He knows as", 
				"well as I that we cannot", 
				"hold it forever. The dead", 
				"come. They took Lysander", 
				"before our eyes. I pity", 
				"the soul of even such a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"madman - no one should", 
				"die in such a manner. And", 
				"yet so many have. We're", 
				"trapped in this horror.", 
				"So many have died, and", 
				"for what? What curse have", 
				"we stumbled upon? I", 
				"cannot bear it, the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"moaning, wailing cries of", 
				"the dead. Poor Thomas,", 
				"cut to pieces by their", 
				"blades. We had only an", 
				"hour to properly bury", 
				"those we could, before", 
				"the undead legions struck", 
				"again. I cannot go on...", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I cannot go on.", 
				"", 
				"", 
				"",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalGrimmochDrummel14Day16( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummelDay1 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummelDay1() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 1:", 
				"", 
				"Tis a grand sight, this", 
				"primeval tomb, I agree", 
				"with Tavara on that. And", 
				"we've a good crew here,",
				"they've strong backs and",
				"a good attitude. I'm a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"bit concerned by those", 
				"that worked as guides for", 
				"us, however. All seemed", 
				"well enough until we", 
				"revealed the immense", 
				"stone doors of the tomb", 
				"structure itself. Seemed", 
				"to send a shiver up their", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"spines and get them all", 
				"stirred up with", 
				"whispering. I'll watch", 
				"the lot of them with a", 
				"close eye, but I'm", 
				"confidant we won't have", 
				"any real problems on the", 
				"dig. I'm especially", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"proud to see Thomas", 
				"standing out - he was a", 
				"good hire despite the", 
				"warnings from his", 
				"previous employers. He's", 
				"drummed up the workers", 
				"into a furious pace - we", 
				"ve nearly halved the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"estimate on the timeline", 
				"for excavating he Tomb's", 
				"entrance.", 
				"",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalGrimmochDrummelDay1( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay2Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay2Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 8, false ) // true writable so players can make notes
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
				"Everything we'd heard and", 
				"read of the tomb has", 
				"proved correct - and yet,", 
				"nothing could prepare me",
				"for the sight of it with",
				"my own eyes. The Tomb of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Khal Ankur has given up", 
				"its secrets at last! The", 
				"intricate stonework that", 
				"covered the tomb doors", 
				"seems to continue", 
				"throughout the entirety", 
				"of the catacombs, each", 
				"hallway and room yielding", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"a seemingly endless", 
				"amount of information for", 
				"my companions and I to", 
				"record. It will take", 
				"years to catalogue the", 
				"entirety of the Tomb, if", 
				"those legends of its", 
				"massive size prove true.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Sadly, a good deal (of)", 
				"the Tomb's interior has", 
				"been damaged or utterly", 
				"destroyed, whether by", 
				"seismic activity in the", 
				"surrounding mountainside", 
				"or merely the slow", 
				"efforts of Time itself,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I do not know. A good", 
				"deal of the stonework has", 
				"been cracked or collapsed", 
				"entirely, especially near",
				"the entrance supports of",
				"the main hall. Our", 
				"passage has indeed", 
				"already been entirely", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"blocked in the first", 
				"major room we've", 
				"discovered, a massive", 
				"pile of boulders and",
				"stones blocking any exit",
				"from the antechamber.", 
				"What could have caused", 
				"such a localized", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"disruption of the support", 
				"structures, one can only", 
				"guess - but it will", 
				"surely take an entire",
				"afternoon's effort to",
				"remove even a fraction", 
				"of it. I look forward to", 
				"more progress tomorrow", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"once the workers have set", 
				"to excavating the hall.", 
				"", 
				"",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay2Tomb( Serial serial ) : base( serial )
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
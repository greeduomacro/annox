using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay1Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay1Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 5, false ) // true writable so players can make notes
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
				"The workers continue", 
				"tireless in their efforts", 
				"to unload our supplies", 
				"even as light fades. I",
				"feel I should lend a hand",
				"in the effort, and yet", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I cannot bear to take my", 
				"attention away from the", 
				"magnificent stone doors", 
				"of the tomb. Every inch", 
				"of their massive frame is", 
				"covered with intricately", 
				"carved design work -", 
				"'tis truly a sight to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"see. I've spent the day", 
				"sketching and cataloging", 
				"what I can of them while", 
				"my companions set up our", 
				"camp and make", 
				"preparations for", 
				"tomorrow's work. Though", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the stonework symbols", 
				"inspire me to new flights", 
				"of fancy, some of the", 
				"workers seem strangely", 
				"fearful of them. I cannot", 
				"wait 'til the morrow when", 
				"those ancient works of", 
				"stone shall swing open", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"and deliver unto me", 
				"everything I have dreamed", 
				"of for the last ten years", 
				"of my life.",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay1Tomb( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay9and10Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay9and10Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 9-10:", 
				"", 
				"The excavation of the", 
				"next set of tunnels has", 
				"ceased, as three of the", 
				"workers have gone missing",
				"in the night. Bergen",
				"voiced the opinion that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"they had most likely", 
				"abandoned our group", 
				"altogether and headed", 
				"back, as they were of the", 
				"number that seemed", 
				"especially disturbed by", 
				"the Tomb. Lysander had", 
				"other ideas, however. In", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the middle of our", 
				"discussion on the matter,", 
				"he went into a wild", 
				"tirade on the possibility", 
				"that they had somehow", 
				"infilitrated the tonb's", 
				"interior without us. The", 
				"pure, hateful venom in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"his voice when he spoke", 
				"of the workers shocked", 
				"me, as I had always", 
				"though(t) him to be a", 
				"levelheaded man of great", 
				"learning. As we are still", 
				"at work digging out the", 
				"rubble that blocks all", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"access to the inner", 
				"chanbers, I cannot help", 
				"but believe the workers", 
				"must have fled the site",
				"altogether, as Bergen",
				"said.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay9and10Tomb( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay14and15Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay14and15Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 6, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 14-15:", 
				"", 
				"Lysander has returned...", 
				"and yet, how can I", 
				"describe the horror of", 
				"it? He stands across the",
				"chamber from me even now,",
				"a changed man. His hair", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"hangs in grimy knots", 
				"across his face, his", 
				"clothes filthy and torn", 
				"in places... and the", 
				"blood - covered in blood,", 
				"his skin shining in", 
				"scarlet reflections of", 
				"the torchlight. He will", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"let no one approach; a", 
				"thick rusted dagger in", 
				"his hand warding off any", 
				"attempts to overcome him.", 
				"And the blood, which runs", 
				"down in great rivulets", 
				"from his arms and hands -", 
				"it is not his own, and", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"this is enough to keep is", 
				"at a wary distance. Morg", 
				"Bergen wishes to subdue", 
				"him quickly, but there is", 
				"something in Lysander's", 
				"eyes - and I remember the", 
				"power of his spells, even", 
				"as he swings the jagged", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"dagger back and forth in", 
				"a wide swath before him.", 
				"Something about the sight", 
				"of it makes my stomach",
				"churn. Something has",
				"happened, something that", 
				"changes everything.", 
				"Lysander has lost his", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"sanity to this tomb... or", 
				"to something within it.", 
				"Do we dare approach? We", 
				"must make a decision",
				"soon.",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay14and15Tomb( Serial serial ) : base( serial )
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
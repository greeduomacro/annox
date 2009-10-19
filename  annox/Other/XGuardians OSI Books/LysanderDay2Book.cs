using System;
using Server;

namespace Server.Items
{
	public class LysanderDay2Book : BlueBook
	{
		[Constructable]
		public LysanderDay2Book() : base( "Lysander's Notebook Day 2", "L. Gathenwale ", 5, false ) // true writable so players can make notes
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
				"The woman, Tavara Sewel,", 
				"is unbearable. Her", 
				"entire demeanor sickens", 
				"me. I would take her",
				"life for Thee now, my",
				"Lord. But I cannot alert", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the others. Progress is", 
				"made too slowly, I cannot", 
				"wait this perpetual", 
				"waiting. Today I knelt", 
				"down with the workers,", 
				"tossing stones and dirt", 
				"aside with my very hands", 
				"as they dug all the last", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of the rubble covering", 
				"the entrance to Thy", 
				"Sanctum. The Sewel woman", 
				"was shocked at my", 
				"demeanor, dirtying my", 
				"robes on my knees in the", 
				"muck as I clawed at the", 
				"rocks. She thought I did", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"this for those sickly", 
				"scholars, or for her, or", 
				"for what she laughably", 
				"calls 'The Gift of", 
				"Discovery', of learning.", 
				"As if I did not know", 
				"what I went to find!", 
				"I come for Thee, Master.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Soon shall I receive Thy", 
				"gifts, Thy blessings.", 
				"Patience, eternal", 
				"patience. I must take my",
				"lessons well. I have",
				"learned from Thee, Master,", 
				"I have.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public LysanderDay2Book( Serial serial ) : base( serial )
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
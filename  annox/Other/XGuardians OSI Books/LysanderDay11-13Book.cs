using System;
using Server;

namespace Server.Items
{
	public class LysanderDay11and13Book : BlueBook
	{
		[Constructable]
		public LysanderDay11and13Book() : base( "Lysander's Notebook Day 11-13", "L. Gathenwale ", 5, false ) // true writable so players can make notes
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
				"I come for Thee, my", 
				"Master. I come! The way", 
				"is clear, I have found", 
				"Thy path and washed it in",
				"the blood of the two",
				"workers that caught sight", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of me. Ah, how sweet it", 
				"was to cut them open, to", 
				"see the blood pour out in", 
				"great torrents, to stand", 
				"in it, to revel in it.", 
				"If only I had time for", 
				"the Sewel woman. But", 
				"there will be time enough", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"for her. I have learned", 
				"Thy Patience, Master.", 
				"I come for Thee. I walk", 
				"thy halls in penance, my", 
				"last steps in this", 
				"repulsive living frame.", 
				"I come for Thee and Thy", 
				"Gifts my Master. Glory", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Unto Thee, Khal Ankur,", 
				"Keeper of the Seventh", 
				"Death, Master, Leader of", 
				"the Chosen, the Khaldun.", 
				"Praises in Thy Name,", 
				"Master of Life and Death,", 
				"Lord of All. Khal Ankur,", 
				"Master, Prophet, I join", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Thy ranks this night,", 
				"a member of the Khaldun", 
				"at last.", 
				"",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public LysanderDay11and13Book( Serial serial ) : base( serial )
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
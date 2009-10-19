using System;
using Server;

namespace Server.Items
{
	public class LysanderDay8and10Book : BlueBook
	{
		[Constructable]
		public LysanderDay8and10Book() : base( "Lysander's Notebook Day 8-10", "L. Gathenwale ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 8-10:", 
				"", 
				"Have you taken them,", 
				"Master ? They could not", 
				"have found a way past the", 
				"stones that block our",
				"path! The three workers,",
				"My Master, where have", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"they gone ? Curses upon", 
				"them! I'll cut them all", 
				"to pieces if they show", 
				"their faces again, then", 
				"burn the rest alive upon", 
				"a pyre, for all to see,", 
				"as a warning of Thy", 
				"Power. How could they", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"have gotten past me ?", 
				"I sleep against the very", 
				"walls, to hear Thy Words,", 
				"to feel Thy Breath.", 
				"I can find no egress", 
				"from the chambers that", 
				"the Sewel woman does not", 
				"know of not have men", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"working at excavating.", 
				"Where have they gone,", 
				"Master ? Have you taken", 
				"them, or do they truly", 
				"flee from Thy Presence ?", 
				"I will kill them if", 
				"they show their faces", 
				"again. Give me Strength,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"my Master, to let them", 
				"live a while longer,", 
				"until they have fulfilled", 
				"their purpose and I kneel",
				"before Thee, covered in",
				"their blood.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public LysanderDay8and10Book( Serial serial ) : base( serial )
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
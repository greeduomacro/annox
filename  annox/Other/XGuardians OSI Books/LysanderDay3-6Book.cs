using System;
using Server;

namespace Server.Items
{
	public class LysanderDay3and6Book : BlueBook
	{
		[Constructable]
		public LysanderDay3and6Book() : base( "Lysander's Notebook Day 3-6", "L. Gathenwale ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 3-6:", 
				"", 
				"What are these Beasts", 
				"that dare to defy our", 
				"presence here? Hast Thou", 
				"sent them, Master? To",
				"tear apart these foolish",
				"ones that accompany me?", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"That repugant pustule,", 
				"Drummel, put forth his", 
				"absurd little theories as", 
				"to the nature of the", 
				"Beasts that attacked our", 
				"camp, but I'll have none", 
				"of his words. He asks too", 
				"many questions. He is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"taint upon the grounds of", 
				"Thy Sanctum, Master -", 
				"I will deal with him", 
				"after the Sewel woman.", 
				"Speaking of Sewel,", 
				"I have convinced that", 
				"empty-headed harlot that", 
				"we should move our", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"encampement within the", 
				"antechamber. She thinks", 
				"I worry for her safety.", 
				"I come for thee, Master.", 
				"I make my camp in thy", 
				"chambers. I sleep under", 
				"Thy roof. I can feel", 
				"Thine presence even now.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Soon, Master. Soon.", 
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

		public LysanderDay3and6Book( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class JournalGrimmochDrummel17Day22 : BrownBook
	{
		[Constructable]
		public JournalGrimmochDrummel17Day22() : base( "The daily journal of Grimmoch Drummel", "Grimmoch ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 17-22:", 
				"", 
				"The fighting never ceases", 
				"the blood never stop", 
				"flowing, like a river", 
				"through the bloated",
				"corpses of the dead. And",
				"yet there are still more.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Always more, with the red", 
				"fire gleaming in their", 
				"eyes. My arm aches, I'v", 
				"taken to the sword as my", 
				"bow seems to do little", 
				"good... the dull ache in", 
				"my arm... so many swings,", 
				"cleavig a mountain of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"decaying flesh. And", 
				"Thomas... he was there,", 
				"in the thick of it..", 
				"Thomas was beside me...", 
				"his face cleaved in twain", 
				"- and yet beside me,", 
				"fighting with us against", 
				"the horde until he was", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"cut down once again. And", 
				"I swear I see him even", 
				"now, there in the dark", 
				"corner of the", 
				"antechamber, his eyes", 
				"flickering in the last", 
				"dying embers of the", 
				"fire... and he stares at", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"me, and a scream fills", 
				"the vault - wheather his", 
				"or mine, I can no longer", 
				"tell.",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalGrimmochDrummel17Day22( Serial serial ) : base( serial )
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
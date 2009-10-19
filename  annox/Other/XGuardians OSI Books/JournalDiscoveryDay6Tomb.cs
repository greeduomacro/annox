using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay6Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay6Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 7, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 6:", 
				"", 
				"Late last night our camp", 
				"was set upon by a pack of", 
				"wild beasts - behemoth", 
				"creatures with a speed",
				"and viciousness I'd n'ere",
				"before seen. Even", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Grimmoch, well versed in", 
				"all manner of wildlife,", 
				"was unsure as to their", 
				"nature - though I lay", 
				"blame upon the darkness", 
				"covering their movements", 
				"rather than on his skill", 
				"as a huntsman.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The attacks did not let", 
				"up the entire night, and", 
				"we were eventually", 
				"forced to flee into the", 
				"Tomb itself to take", 
				"refuge from the ravenous", 
				"creatures - e'en", 
				"Lysander's spells could", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"not keep the foul things", 
				"from attacking in great", 
				"numbers. The Tomb", 
				"performed well as an", 
				"impromptu fortress, and", 
				"we managed to spend the", 
				"night unscathed.", 
				"Morning's light seemed", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"to have scattered the", 
				"beasts, as not a single", 
				"one of them was to be", 
				"seen as exited the Tomb -",
				"not even a carcass of",
				"the few that were slain", 
				"a'fore we fled. Lysander", 
				"set the crew to work,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"moving our supplies and", 
				"gear into the Tomb, in", 
				"case the creatures did", 
				"opt to return. Such",
				"savage fury had the",
				"beasts - and not a single", 
				"one ever turned to run,", 
				"even in the face of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"certain death.", 
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

		public JournalDiscoveryDay6Tomb( Serial serial ) : base( serial )
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
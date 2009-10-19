using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay3and5Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay3and5Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 3-5:", 
				"", 
				"I do not understand this", 
				"place... not as I once", 
				"thought I did. Something", 
				"palatable seems to hinder",
				"our every attempt to",
				"investigate this ancient", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"site. Excavation work on", 
				"the first major hallway", 
				"finished only yesterday -", 
				"the amount of stone and", 
				"rubble blocking the", 
				"egress was astounding,", 
				"it stands in immense", 
				"piles outside the Tomb's", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"entrance, as if we were", 
				"digging the tunnels of", 
				"this abhorred place", 
				"ourselves! The", 
				"satisfaction of", 
				"completing our efforts", 
				"was quickly thwarted,", 
				"however, as we discovered", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the end of the hallway we", 
				"had just revealed was", 
				"blocked by yet another", 
				"colossal pile of stone.", 
				"I've had a few of the", 
				"workers set up primitive", 
				"scaffolding in the main", 
				"antechamber so that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I can spend my time", 
				"pouring over the detail", 
				"work on the stone", 
				"carvings while the rest",
				"of the crew continue",
				"excavating the inner", 
				"halls.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay3and5Tomb( Serial serial ) : base( serial )
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
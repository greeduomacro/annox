using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay17and19Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay17and19Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 3, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 17-19:", 
				"", 
				"I cannot go on much", 
				"longer. I know now t'was", 
				"no work of the earth", 
				"that trapped us here -",
				"I can feel His force in",
				"it. It was His will, His", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"power that has sealed us", 
				"in this nightmare. The", 
				"barricade will not be", 
				"enough. So many of them.", 
				"They come like unto the", 
				"ocean's waves -", 
				"ceaseless, neverending.", 
				"For every five we strike", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"down, another ten rise up", 
				"against us. And like the", 
				"sands we cannot help bu", 
				"be brought down, wasted", 
				"away in this ocean of", 
				"blood.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay17and19Tomb( Serial serial ) : base( serial )
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
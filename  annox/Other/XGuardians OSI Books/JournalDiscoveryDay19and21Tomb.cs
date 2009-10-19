using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay19and21Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay19and21Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 2, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 19-21:", 
				"", 
				"The barricade won't hold", 
				"- never, and they'll", 
				"come, they come even now.", 
				"I would tear the last of",
				"it down, let them in to",
				"devour us all, if only to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"stop the screaming - the", 
				"awful, wailing cries that", 
				"fill the tomb with their", 
				"presence. May my", 
				"ancestors forgive me, but", 
				"it must be done. I must", 
				"end this.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay19and21Tomb( Serial serial ) : base( serial )
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
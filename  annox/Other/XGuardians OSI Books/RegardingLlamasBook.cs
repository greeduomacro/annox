using System;
using Server;

namespace Server.Items
{
	public class RegardingLlamasBook : BrownBook
	{
		[Constructable]
		public RegardingLlamasBook() : base( "Regarding Llamas", "Martin ", 4, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Llamas are curious beasts", 
				"shaggy and sought after", 
				"for their wool, yet of a", 
				"curiously arrogant", 
				"disposition reflected in", 
				"their eyes. They live in",
				"mountainous areas, though",
				"who may have first tamed", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"them is lost in the mists", 
				"of history.", 
				"", 
				"Tis a well-known fact", 
				"that llamas can indeed be", 
				"tamed, and used as", 
				"grazing animals, for", 
				"their meat, and of course", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"for their wool. Yet 'tis", 
				"lesser known that their", 
				"ornery disposition and", 
				"tendency to spit at", 
				"those they dislike makes", 
				"them appealing guard", 
				"creatures as well, though", 
				"they have little sound", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"with which to sound an", 
				"alarum.", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public RegardingLlamasBook( Serial serial ) : base( serial )
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
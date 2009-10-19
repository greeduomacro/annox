using System;
using Server;

namespace Server.Items
{
	public class SongOfSamletheBook : BrownBook
	{
		[Constructable]
		public SongOfSamletheBook() : base( "A song of Samlethe", "Sandra ", 5, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"The first bear did swim", 
				"by day,", 
				"And it did sleep by", 
				"night,", 
				"It kept itself within", 
				"its cave",
				"and ate by starry light.",
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The second bear it did", 
				"cavort", 
				"'Neath canopies of trees,", 
				"And danced its odd", 
				"bearish sort", 
				"Of joy for all to see.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The first bear, well,", 
				"'twas hunted,", 
				"And today adorns a floor.", 
				"Its ruggish face has", 
				"been dented", 
				"By footfalls and the", 
				"door.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The second bear did step", 
				"once", 
				"Into a mushroom ring,", 
				"And now does dance", 
				"the dunce", 
				"For wisps and unseen", 
				"things.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"So do not dance, and do", 
				"not sleep,", 
				"Or else be led astray", 
				"For bears all end up",
				"six feet deep",
				"At the end of", 
				"Samlethe's day.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public SongOfSamletheBook( Serial serial ) : base( serial )
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
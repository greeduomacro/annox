using System;
using Server;

namespace Server.Items
{
	public class TaleTribesBook : BrownBook
	{
		[Constructable]
		public TaleTribesBook() : base( "A tale of three tribes", "Janet, scribe ", 9, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"The dungeon known as", 
				"Despise is in fact not a", 
				"dungeon as such, but", 
				"rather a large natural", 
				"cave. Inhospitable and", 
				"unfriendly to visitors,",
				"it is filled with damp",
				"spots where the deadly", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Exploding Red Spotted", 
				"Toadstool grows in", 
				"abundance.", 
				"", 
				"According to the oldest", 
				"of historical texts, in", 
				"days gone by the cave was", 
				"once the home of three", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"separate tribes who had", 
				"come to an accommodation", 
				"with each other. Oddly", 
				"enough, the three tribes", 
				"were of dragons, lizard", 
				"men, and rat men. While", 
				"today few except", 
				"extremists associated", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"with Lord Blackthorn", 
				"regard these latter two", 
				"as being intelligent", 
				"beings, apparently they", 
				"have indeed fallen from a", 
				"more evolved state over", 
				"the years.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"'Tis said that these", 
				"three races did dwell in", 
				"relative harmony within", 
				"the vast cave, building",
				"when they required it,",
				"and trading amongst", 
				"themselves if needed.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"But over time, something", 
				"happened, and they were", 
				"forced to withdraw from", 
				"their society, until",
				"today thou mayst find",
				"individuals of each", 
				"species within the", 
				"dungeon, but never", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"again as a civilization.", 
				"", 
				"'Tis also said that", 
				"someday the three tribes",
				"may return to Despise,",
				"to once again inhabit", 
				"it together.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Until then, nothing", 
				"remains as a token of", 
				"this save an oddly", 
				"intelligent skeleton,",
				"magically enchanted,",
				"that doth speak when", 
				"questions are asked, and", 
				"from whom I obtained", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"these tales one day, when", 
				"I was pursued by evil", 
				"monsters and fled into", 
				"his skeletal arms.",
				"", 
				"Fortunately, I escaped", 
				"and lived to write", 
				"it all down!", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TaleTribesBook( Serial serial ) : base( serial )
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
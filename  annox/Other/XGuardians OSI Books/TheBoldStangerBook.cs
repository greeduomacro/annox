using System;
using Server;

namespace Server.Items
{
	public class TheBoldStangerBook : BrownBook
	{
		[Constructable]
		public TheBoldStangerBook() : base( "The bold stanger", "Old Fabio the Poor ", 12, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"In a time before time,", 
				"the Gods that Be", 
				"assembled a group of", 
				"artisans, craftsmen and", 
				"lore masters (for, yes,", 
				"even in those days, art",
				"existed) to create the",
				"world of Sosaria. To", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"this group, the gods gave", 
				"a tiny world, Rytabul, in", 
				"which to test their works", 
				"to see if they were of", 
				"the quality desired for", 
				"the true world in which", 
				"they would be placed. And", 
				"though the gods were", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"tight fisted with their", 
				"gold, this small crew", 
				"worked hard and long, and", 
				"were happy in their", 
				"tasks.", 
				"", 
				"A small corner of Rytabul", 
				"had been claimed by the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"artisan Selrahc the Slow.", 
				"Though he was not the", 
				"fastest of the assembled", 
				"workers, the gods smiled", 
				"upon his work, even", 
				"presenting him with a", 
				"mystic talisman", 
				"proclaiming his work the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"best among the newer", 
				"artisans. And so Selrahc", 
				"went about his business,", 
				"creatin (sic) hundreds of",
				"designs which would one",
				"day add color and variety", 
				"to Sosaria.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"One day a stranger", 
				"appeared to Selrahc. His", 
				"chest was bare and he", 
				"wore the trousers of the",
				"brightest green, and",
				"wherever he went, plants", 
				"grew in his footsteps.", 
				"This caused Selrahc no en", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"(sic) of trouble, the", 
				"stranger always looking", 
				"over his shoulder, and", 
				"the plants sprouting in",
				"places Selrahc required",
				"to ply his art. And so", 
				"Selrahc approached the", 
				"stranger and bade him", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"speak. But this man in", 
				"green remained silent.", 
				"Selrahc pleaded with the", 
				"stranger to give his",
				"name, and would he",
				"please leave Selrahc to", 
				"his work. But this", 
				"mysterious stranger", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"remained mute.", 
				"", 
				"This angered Selrahc", 
				"mightily. Who was this",
				"silent man, interfering", 
				"with tasks the gods", 
				"themselves had entrusted", 
				"to Selrahc? In an attempt", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"to embarass this", 
				"interloper, Selrahc stole", 
				"his green trousers,", 
				"leaving him naked and", 
				"open to comments about", 
				"his very manhood, and", 
				"still the stranger would", 
				"not speak, would not", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"leave this tiny corner of", 
				"Rytabul.", 
				"", 
				"Vexed to his very limits,", 
				"Selrahc took his war axe", 
				"and smote the silent one", 
				"mightily, again and again", 
				"until the silent stranger", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"ran away, having never", 
				"said a word, and never", 
				"showed himself in Rytabul", 
				"again.", 
				"", 
				"Thus endeth the tale of", 
				"the bold stranger.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TheBoldStangerBook( Serial serial ) : base( serial )
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
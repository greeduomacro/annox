using System;
using Server;

namespace Server.Items
{
	public class TheWildGirlBook : BrownBook
	{
		[Constructable]
		public TheWildGirlBook() : base( "The wild girl of the forest", "Horace, trader ", 14, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Her name was Leyla, she", 
				"said, and her hair was", 
				"braided wild with", 
				"creepers and thorns.", 
				"I marveled that they did", 
				"not hurt her, but when",
				"I asked, she but shrugged",
				"and let her eyes roam", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"once more across the", 
				"woods. Though I had my", 
				"hands securely fastened", 
				"by her ropes, I itched to", 
				"reach out and comb that", 
				"unruly golden mane,", 
				"dirtied and leaf-ridden.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Her provenance, she told", 
				"me over nights", 
				"illuminated by campfires,", 
				"was once the city of", 
				"Trinsic. She claimed to", 
				"have been kidnapped and", 
				"raised by orcs, which I", 
				"judged an unlikely tale,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"for all know orcs delight", 
				"in eating the meat of", 
				"honest folk. When I told", 
				"her this, she laughed a", 
				"fey laugh, and gaily", 
				"admitted that honest she", 
				"was not, for oft had she", 
				"stolen folk away from", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"caravans to loot their", 
				"possessions from an", 
				"unconscious body!", 
				"",
				"At this, I began to fear",
				"for my life, and her", 
				"smile seemed full of", 
				"teeth sharper than a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"human ought to have, for", 
				"the tale of orcish", 
				"raising had struck fear", 
				"into the marrow of my",
				"bones. Wil thou eat me?",
				"I asked, a-tremble,", 
				"fearing the answer.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"And she cocked her head", 
				"at me, like a wild animal", 
				"facing a word that it", 
				"dost not understand, and",
				"the fixity in her eyes",
				"was a glimpse into the", 
				"deeper reaches of the", 
				"Abyss. But she finally", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"grunted, and said Nay,", 
				"in a voice that recalled", 
				"to me a child. Nay, she", 
				"said, for thou dost",
				"remind me of a boy I knew",
				"once, when I was a girl", 
				"who played in a city of", 
				"great sandstone walls,", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"before I was taken. He", 
				"had sandy hair like thee,", 
				"and I dreamt as a child", 
				"of holding his hand and",
				"sharing flavored ice.", 
				"His name was Japheth.", 
				"", 
				"The next morning she let", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"me go, stripped of my", 
				"pouch and clothes, and", 
				"bade me run through the", 
				"woods, and to fear", 
				"recapture, for surely her", 
				"heart would not soften", 
				"again. 'Twas a fearful", 
				"run, and I came to the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"road to Yew with welts", 
				"and scratches run rampant", 
				"crost my skin, but", 
				"I did not see her again.", 
				"", 
				"Oft have I wondered of", 
				"the boy named Japheth,", 
				"and whether he remembers", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"a girl who lived in", 
				"sandstone walls. The only", 
				"Japheth I know is the", 
				"Guildmaster of Paladins", 
				"who died last year", 
				"warring amidst the orcs,", 
				"and though he had indeed", 
				"sandy hair, I cannot", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"picture him side by side", 
				"with a feral girl whose", 
				"tongue has tasted of", 
				"human flesh. Yet the", 
				"paths of fate are strange", 
				"indeed, and I suppose.", 
				"'tis possible that this", 
				"paladin died defending", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"his remembered lady's", 
				"honor, unknowingly", 
				"struck down by the orc", 
				"that she called father", 
				"", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TheWildGirlBook( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class TalkingWispsBook : BrownBook
	{
		[Constructable]
		public TalkingWispsBook() : base( "Talking to wisps", "Heigel of Moonglow ", 8, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"This volume was sponsored", 
				"by donations from Lord", 
				"Blackthorn, ever a.", 
				"supporter of", 
				"understanding the other", 
				"sentient races of",
				"Britannia",
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Wisps are the most", 
				"intelligent of the", 
				"nonhuman races inhabiting", 
				"Britannia. 'Tis claimed", 
				"by the great sages that", 
				"someday we shall be able", 
				"to converse with them", 
				"openly in our native", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"tongue -- indeed, we must", 
				"hope that wisps learn our", 
				"language, for it is not", 
				"possible for humans to", 
				"pronounce wispish!", 
				"", 
				"The wispish language", 
				"seems to only contain one", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"vowel, the letter Y.", 
				"However, the letters", 
				"W, C, M, and L seem to", 
				"be treated grammatically", 
				"as vowels, and in", 
				"addition every letter is", 
				"followed by what sounds", 
				"to the human ear like a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"glottal stop. It is", 
				"possible that the glottal", 
				"stop is considered", 
				"a vowel as well.",
				"",
				"Wisps do make use of", 
				"what sounds to us like", 
				"pitch and emphasis", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"shifts similar to", 
				"exclamations and", 
				"questions.", 
				"",
				"The average word in",
				"wispish seems to consist", 
				"of three phonemes and", 
				"three glottal stops,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"plus possibly a pitch", 
				"shift. It often sounds", 
				"burning or crackling.", 
				"Some have speculated",
				"that what we are",
				"analyzing is in fact", 
				"nothing more than the", 
				"very air crackling near", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the wisp's glow, and not", 
				"language, but this is of", 
				"course unlikely.", 
				"",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TalkingWispsBook( Serial serial ) : base( serial )
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
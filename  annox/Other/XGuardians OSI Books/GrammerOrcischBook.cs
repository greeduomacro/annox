using System;
using Server;

namespace Server.Items
{
	public class GrammerOrcischBook : BrownBook
	{
		[Constructable]
		public GrammerOrcischBook() : base( "A grammar of orcish", "Yorick of Yew ", 24, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"This volume, and others", 
				"in the series, are", 
				"sponsored by donations", 
				"from Lord Blackthorn,", 
				"ever a supporter of", 
				"understanding the other",
				"sentient races of",
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Britannia.", 
				"", 
				"The Orcish tongue may", 
				"fall unpleasingly 'pon", 
				"the ear, yet it has", 
				"within it a complex", 
				"grammar oft", 
				"misunderstood by those", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"who merely hear the few", 
				"broken words of English", 
				"our orcish brothers", 
				"manage without education.", 
				"", 
				"These are the basic rules", 
				"of orcish:", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Orcish has five tenses:", 
				"present, past, future", 
				"imperfect, present", 
				"interjectional, and", 
				"prehensile.", 
				"", 
				"Examples: gugroflu,", 
				"gugrofloog, gugrobo,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"gugrolu!, gugrogug.", 
				"", 
				"All transitive verbs in", 
				"the prehensile tense end",
				"it ug.",
				"", 
				"Examples: urgleighug,", 
				"biggugdaghgug,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"curdakalmug.", 
				"", 
				"All present", 
				"interjectional.",
				"conjugations start with",
				"the letter G unless the(y)", 
				"contain the third", 
				"declensive accent of the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"letter U", 
				"", 
				"Examples: ghothudunglug,", 
				"but n azhbuugub.",
				"",
				"The past tense can only", 
				"refer to events since the", 
				"last meal, but the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"prehensile tense can", 
				"refer to any event within", 
				"reach.", 
				"",
				"The present tense is",
				"conjugated like the", 
				"future imperfect tense,", 
				"when the interrogative", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"mode is used by pitching", 
				"the sound a quarter-tone", 
				"higher.", 
				"",
				"Orcish hath no concept", 
				"of person, as in first", 
				"person, third person,", 
				"I, we, etc.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Orcish grammar relies", 
				"upon the three cardinal", 
				"rules of accretion,", 
				"prefixing, and", 
				"agglutination, in", 
				"addition to pitch. In the", 
				"former, phonemes combine", 
				"into larger words which", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"may contain full phrasal", 
				"significance. In the", 
				"second, prefixing", 
				"specific phonetic sounds", 
				"changes the subject of", 
				"the sentence into object,", 
				"interrogative, addressed", 
				"individual, or dinner.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Agglutination occurs", 
				"whenever four of the same", 
				"letter are present in a", 
				"word, in which case, any", 
				"two of them may be", 
				"removed or slurred.", 
				"", 
				"Pitch changes the phoneme", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"value of individual", 
				"syllables, thus", 
				"completely altering what", 
				"a word may mean. The", 
				"classic example if ", 
				"Aktgluthugrot bigglogubuu", 
				"dargilgaglug lublublub", 
				"which can mean You are", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"such a pretty girl,", 
				"My mother ate your", 
				"primroses, or Jellyfish", 
				"nose paints alms potato,", 
				"depending on pitch.", 
				"", 
				"Orcish poetry often", 
				"relies upon repeating the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"same phrase in multiple", 
				"pitches, eve(n) changing", 
				"pitch midword. None of", 
				"this great are is", 
				"translatable.", 
				"", 
				"The orcish language uses", 
				"the following vowels: ab,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"ad, ag, akt, at, augh,", 
				"auh, azh, e, i, o, oo, u,", 
				"uu. The vowel sound a is", 
				"not recognized as a vowel", 
				"and does not exist in", 
				"their alphabet. The", 
				"orcish alphabet i(s) best", 
				"learned using th(e)", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"classic rhyme repeated at", 
				"23 different pitchs:", 
				"", 
				"Lugnog ghu blat", 
				"suggaroglug. Gaghbuu", 
				"dakdar ab highugbo,", 
				"Gothnogbuim ad", 
				"gilgubbugbuilug", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Bilgeaugh thurggulg", 
				"stuiggro!", 
				"", 
				"A translation of the", 
				"first pitch:", 
				"Eat food, the first", 
				"letter is ab,", 
				"", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Kill people, the next", 
				"lette(r) is ad,", 
				"", 
				"I forget the rest But augh is in there somewhere!", 
				"", 
				"", 
				"", 
				"", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Kill people, the next", 
				"lette(r) is ad,", 
				"", 
				"I forget the rest But", 
				"augh is in ther", 
				"somewhere!", 
				"", 
				"What follows is a", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"complete phonetic library", 
				"of the orcish language:", 
				"ab, ad, ag, akt, alm, at,", 
				"augh, auh, azh, ba, ba,", 
				"bag, bar, baz, bid, bilge,", 
				"bo, bog, bog, brui, bu,", 
				"buad, bug, bug, buil,", 
				"buim, bum, buo, buor,", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"buu, ca, car, clog, cro,", 
				"cuk, cur, da, dagh, dagh,", 
				"dak, dar, deak, der, dil,", 
				"dit, dor, dre, dri, dru,", 
				"du, dud, duf, dug, dug,", 
				"duh, dun, eag, eg, egg,", 
				"eichel, ek, ep, ewk,", 
				"faugh, fid, flu, fog,",
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"foo, foz, fruk, fu, fub,", 
				"fud, fun, fup, fur, gaa,", 
				"gag, gagh, gan, gar, gh,", 
				"gha, ghat, ghed, ghid,", 
				"gho, ghu, gig, gil, gka,", 
				"glu, glu, glug, gna, gno,", 
				"gnu, gol, gom, goth,", 
				"grunt, grut, gu, gub,",
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"gub, gug, gug, gugh, guk,", 
				"guk,", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"",
			};
			Pages[cnt++].Lines = lines;
		}

		public GrammerOrcischBook( Serial serial ) : base( serial )
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
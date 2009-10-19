using System;
using Server;

namespace Server.Items
{
	public class PhonemesOrcishTongueBook : BrownBook
	{
		[Constructable]
		public PhonemesOrcishTongueBook() : base( "Phonemes of the orcish tongue", "Yorick of Yew ", 6, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"ab, ad, ag, akt, alm, at,", 
				"augh, auh, azh, ba, ba,", 
				"bag, bar, baz, bid, bilge,", 
				"bo, bog, bog, brui, bu,", 
				"buad, bug, bug, buil,", 
				"buim,bum, buo, buor, buu,",
				"ca, car, clog, cro, cuk,",
				"cur, da, dagh, dagh, dak,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"dar, deak, der, dil, dit,", 
				"dor, dre, dri, dru, du,", 
				"dud, duf, dug,dug, duh,", 
				"dun, eag, eg, egg, eichel,", 
				"ek, ep, ewk, faugh, fid,", 
				"flu, fog, foo, foz, fruk,", 
				"fu, fub, fud, fun, fup,", 
				"fur, gaa, gag, gagh, gan,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"gar, gh, gha, ghat, ghed,", 
				"ghig, gho, ghu, gig, gil,", 
				"gka, glu, glu, glug, gna,", 
				"gno, gnu, gol, gom, goth,", 
				"grunt, grut, gu, gub, gub", 
				"gug, gugh, guk, guk (with", 
				"an umlaut), gulg, gur,", 
				"gurt, ha, hagh, hat, hig,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"hig, hok, hrak, hrol,", 
				"hug, i, ig, igg, igh,", 
				"ign, ihg, ikk, it,jak,", 
				"jek, jja, ju, juk, ka,", 
				"ka, ke, kgh, kh, ki,", 
				"klap, klu, knod, knu,", 
				"kod, krug, kt, kug, lat,", 
				"log, log, lub, lug, lug,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"luh, ma, nag, nar,natz,", 
				"neg, neh, nog, nug, nug,", 
				"nuk, o, oag, ob, og, ogh,", 
				"oh, olm, om, oo, oog,",
				"oth, pa, pig, qo, qua,",
				"quil, rekk, rim, ro, rod,", 
				"ru, rug,rukk, rur, sag,", 
				"sah, sg, snarf, stu, thu,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"thu, thu, thug, tk, tug,", 
				"u, ud, ug, ugh, ukk, ulg,", 
				"urd, urg, urgle, ut, zug", 
				"",
				"",
				"", 
				"", 
				"", 
			};
			Pages[cnt++].Lines = lines;
		}

		public PhonemesOrcishTongueBook( Serial serial ) : base( serial )
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
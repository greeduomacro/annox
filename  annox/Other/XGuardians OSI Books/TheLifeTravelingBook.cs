using System;
using Server;

namespace Server.Items
{
	public class TheLifeTravelingBook : BrownBook
	{
		[Constructable]
		public TheLifeTravelingBook() : base( "The life of a traveling ministrel", "Sandra of Yew ", 16, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"While 'tis true that the", 
				"musician who seeketh", 
				"only to make sweet music", 
				"for herself and for", 
				"others needs little more", 
				"than some talent, and",
				"stern practice at the",
				"chosen instrument those", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of us who seek the open", 
				"road shall find indeed", 
				"that a greater skill is", 
				"required. Herein discover", 
				"those secrets which", 
				"I have learned over the", 
				"years as an itinerant", 
				"performer..", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Once I was in Jhelom, and", 
				"accidently angered the", 
				"bravo of some local", 
				"repute, whose blade", 
				"flickered all too", 
				"eagerly near my slender", 
				"neck (for I was young", 
				"then). After various", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"threats to ruin my", 
				"pretty face this bravo", 
				"grabbed my arm in a most", 
				"unseemly fashion and", 
				"tossed me into a barbaric", 
				"enclosure locally", 
				"entitled a dueling pit.", 
				"My plaintive cries for", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"help went unheeded by the", 
				"guards, for the", 
				"inhabitants of Jhelom are", 
				"eager indeed to measure",
				"fighting prowess at any",
				"time!", 
				"", 
				"What saved me was the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"ability to improvise a", 
				"melody and tune that", 
				"satirized the proceedings", 
				"and sufficiently angered",
				"an onlooker to prod him",
				"to coming to my defense.", 
				"Once that fight was", 
				"underway I was able to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"make good my escape.", 
				"Hence, I regard the", 
				"ability to incite fights", 
				"as indispensable to the",
				"prudent bard.",
				"", 
				"Upon another occasion,", 
				"'twas the obverse side of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"that coin which saved me", 
				"for I was being held", 
				"prisoner by a", 
				"particularly nasty band",
				"of ruffians who had",
				"seized me unawares from", 
				"the road to Vesper.", 
				"", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"They had worked", 
				"themselves into a frenzy", 
				"and were ready to attack", 
				"and I fear, tear me limb",
				"from limb, when I began", 
				"to sing frantically,", 
				"tapping my fallen drum", 
				"wit my tied up feet. The", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"melody developed into a", 
				"soothing one, and the", 
				"brigands slowly calmed", 
				"down to the extent of", 
				"apologizing, and they let", 
				"me go!", 
				"", 
				"A final example I would", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"pray you grant your", 
				"attention: once I was", 
				"lost upon a large isle", 
				"far to the east of the", 
				"mainland, well beyond", 
				"Serpent's Hold, where", 
				"lava made its sluggish", 
				"way across the surface", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"landscape. And this", 
				"accursed land was filled", 
				"with vile beats and", 
				"cunning dragons.", 
				"", 
				"I was being pursued by", 
				"one of said fell dragons", 
				"when I found myself", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"trapped. I quickly", 
				"skirted a bubbling pool", 
				"of molten rock and", 
				"attempted to hide. The", 
				"dragon scented me and was", 
				"preparing to skirt the", 
				"pool, when I began to", 
				"play a lusty tune upon", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"my lute that attracted", 
				"its attention. Mesmerized", 
				"and enticed by the", 
				"melody, it stepped", 
				"directly towards me, and", 
				"into the lava-where its", 
				"foot was so burned that", 
				"it quickly hopped away,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"undignified and annoyed.", 
				"", 
				"'Tis my fond hope that", 
				"other travelling", 
				"minstrels shall learn", 
				"from my experience and", 
				"apply themselves to", 
				"practicing these skills", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"in order to preserve life", 
				"and limb.", 
				"", 
				"", 
				"", 
				"-Sarah of Yew", 
				" Songmistress", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TheLifeTravelingBook( Serial serial ) : base( serial )
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
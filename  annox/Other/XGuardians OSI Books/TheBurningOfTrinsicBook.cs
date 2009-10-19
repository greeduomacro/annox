using System;
using Server;

namespace Server.Items
{
	public class TheBurningOfTrinsicBook : BrownBook
	{
		[Constructable]
		public TheBurningOfTrinsicBook() : base( "The burning of Trinsic", "Paladin Japheth ", 23, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Twas a sight to see, the", 
				"sunlight falling lightly", 
				"on the sandstone walls of", 
				"Trinsic 'pon a morning in", 
				"spring.", 
				"",
				"Children ran along the",
				"parapets and walkways,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"their laughter and", 
				"running providing music", 
				"to the daybreak, despite", 
				"their oft-ragged", 
				"clothing.", 
				"", 
				"The guards who maintained", 
				"a vigilant outlook from", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"atop the towers would", 
				"smile indulgently as", 
				"children slammed into", 
				"their armored legs and", 
				"brushed past them.", 
				"", 
				"And I was one of those", 
				"young ones, letting my", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"joy rise up to the skies.", 
				"", 
				"Little did we all know of", 
				"the darker days that", 
				"would lie ahead, for we", 
				"were too young.", 
				"", 
				"Had we but gained access", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"to the quiet coucils held", 
				"in the Paladin tower as", 
				"it faced the sea,", 
				"councils lit by",
				"candlelight and worry,",
				"we would have learned", 
				"more of the fears of", 
				"imminent attack from the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"forest, where foul", 
				"creatures born of dank", 
				"caves and darkness were", 
				"marauding ever more often",
				"into the lands around",
				"Trinsic's moat.", 
				"", 
				"But we were children! The", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"parapets and the moat", 
				"were places to play, not", 
				"stout defenses, and we", 
				"gave no thought to the",
				"necessities that must",
				"have required their", 
				"construction.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"We used to reach the", 
				"sheltered orchards on the", 
				"lee side of the parapet", 
				"walls, where the southern",
				"river cut through the",
				"city, by swimming across", 
				"the water.", 
				"", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The rich folk who lived", 
				"in the great manses there", 
				"would shout from their", 
				"windows and shake their",
				"fists, for we would run", 
				"through their gardens", 
				"and tear up the delicate", 
				"foxgloves and orfleurs", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"with our unshod dirty", 
				"feet.", 
				"", 
				"Then we would dive into", 
				"the water and splash", 
				"merrily to the fruit", 
				"trees.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The southern river lazily", 
				"slid under an ungated", 
				"arch in the mighty wall,", 
				"and we would lay on the", 
				"grassy bank and watch it", 
				"gurgle by the lily pads.", 
				"", 
				"That spring that pleasant", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"spot became the doorway", 
				"through which our city of", 
				"Trinsic let in the", 
				"monstrous deformed", 
				"humanoids that savaged", 
				"us.", 
				"", 
				"I lay upon that grassy", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"bank and watched them", 
				"wade in, their coarse", 
				"hair wet and matted,", 
				"algae and muck festooning", 
				"their wild brows. They", 
				"caught sight of a", 
				"quicksilver girl with", 
				"bright blond hair and", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"lively eyes. Her name", 
				"was Leyla and that spring", 
				"I had held fond dreams of", 
				"holding her hand and", 
				"sharing flavored ice", 
				"while dangling our feet", 
				"off the small bridge by", 
				"Smugglers Gate.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"And I said nothing when", 
				"they caught her, and did", 
				"not cry out when they", 
				"dragged her off through", 
				"that breach in our wall,", 
				"and did not warn the city", 
				"when I saw the helmeted", 
				"orc captains call the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"charge upon the mansions.", 
				"", 
				"Blame me not, for I was", 
				"but a child, and one who", 
				"hid in the branches of", 
				"the peach trees, all", 
				"a-tremble whilst", 
				"I watched the smoke rise", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"from Sean the tailor's,", 
				"and fire lash out at the", 
				"roof of witchy Eleanor's", 
				"tavern.", 
				"", 
				"To this day I have had no", 
				"word of Leyla, and to", 
				"this day the smell of", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"burning wood can conjure", 
				"terrible dreams. Yet with", 
				"the eyes of adulthood,", 
				"'tis possible to examine", 
				"the flaws in the defense", 
				"of Trinsic on that", 
				"fateful day, and the", 
				"reasons why our walls are", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"now double-thick, and why", 
				"our buildings are now", 
				"built as fortresses", 
				"within a somber fortified", 
				"city.", 
				"", 
				"While I can look out from", 
				"the top of the new", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Paladin tower, and spy", 
				"the mighty white sails", 
				"across the barrier island", 
				"and can descry the small", 
				"hollow south of the city", 
				"where gypsies are wont to", 
				"camp, I can also envision", 
				"the city as it might be", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"burning, and I bless the", 
				"bargain we made: space", 
				"for safety, grace for", 
				"sturdiness and wood for", 
				"stone.", 
				"", 
				"Whilst I live, I shall", 
				"not see Trinsic burn,", 
			}; 
			Pages[cnt++].Lines = lines;
	//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"and no more cries of", 
				"little girls will haunt", 
				"the sleep of our", 
				"fair citizens.", 
				"", 
				"This is mine oath", 
				"as I live and", 
				"breath.", 
			}; 
			Pages[cnt++].Lines = lines;
	//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"", 
				"", 
				"-Japheth", 
				"Paladin", 
				"Guildmaster of the", 
				"City of Trinsic", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TheBurningOfTrinsicBook( Serial serial ) : base( serial )
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
using System;
using Server;

namespace Server.Items
{
	public class DiversityLandBook : BrownBook
	{
		[Constructable]
		public DiversityLandBook() : base( "On the diversity of our land", "Lord British ", 13, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"While I deplore the", 
				"depredations of the", 
				"misguided and belligerent", 
				"races wit(h) which we", 
				"share our fair Britannia,", 
				"and alongside the",
				"populace do mourn the",
				"needless deaths that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"their raids cause,", 
				"I cannot countenance the", 
				"policy of wholesale", 
				"slaughter of these races", 
				"that seems to be the", 
				"habity of our soldierly", 
				"element. Can we not", 
				"regard the ratmen,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"lizard men, and orcs are", 
				"fellow intelligent", 
				"beings with whom we share", 
				"a planet? Why must we", 
				"slay them on sight,", 
				"rather than attempt to", 
				"engage them in dialogue?", 
				"There is no policy of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"shooting at wisps when", 
				"they grace us with their", 
				"presence (not that an", 
				"arrow could do much to", 
				"pierce them!).", 
				"", 
				"To view these creatures", 
				"as vermin denies their", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"obvious intelligence, and", 
				"we cannot underestimate", 
				"the repercussions that", 
				"their slaughter may have.",
				"If we regard the slaying",
				"of fellow humans as a", 
				"crime, so must we regard", 
				"the killing of an orc.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"At the same time, should", 
				"a lizardman slay a human", 
				"whould we not forgive", 
				"their ignorance and",
				"foolishness? Let us not",
				"surrender the high moral", 
				"ground by descending to", 
				"bestiality.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Now, I say not that we", 
				"should fail to defend", 
				"ourselves in case of", 
				"attack,",
				"for even amongst humans",
				"we see war, we see famine", 
				", and we see assault", 
				"(though we owe a debt of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"gratitude to our Lord", 
				"British for preserving us", 
				"from the worst of", 
				"these!). However,",
				"incursions such as the",
				"recent tragedy which cost", 
				"us the life of Japheth,", 
				"Guildmaster of Trinsic's", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Paladins, are folly.", 
				"I had met Japheth, and", 
				"like all paladins, he", 
				"burned with an inner",
				"fire. Yet though I had", 
				"the utmost respect for", 
				"him, none could deny the", 
				"hatred that flashed in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"his eyes the mere mention", 
				"of orcs.And thus he", 
				"carried his battle to the", 
				"orc camps, and died", 
				"there, unable to rise", 
				"above his own childhood", 
				"experiences depicted in", 
				"his book, The Burning of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Trinsic. Tis a shame that", 
				"even our mightiest men", 
				"fall prey to this!", 
				"ignorance", 
				"", 
				"Are there not legends of", 
				"orcs adopting human", 
				"children to raise as", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"their own? Tales of", 
				"complex societies built", 
				"underground by races we", 
				"regard as bestial?", 
				"", 
				"Let us not repeat the", 
				"mistake of Japheth of the", 
				"Paladins, and let us", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"cease to persecute the", 
				"nonhuman races, before", 
				"we discover that we are", 
				"harming ourselves in the", 
				"process.", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public DiversityLandBook( Serial serial ) : base( serial )
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
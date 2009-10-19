using System;
using Server;

namespace Server.Items
{
	public class TheMajorTradeBook : BrownBook
	{
		[Constructable]
		public TheMajorTradeBook() : base( "The major trade associations", "Pieter of Vesper ", 18, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"There are ten major trade", 
				"associations that operate", 
				"legitimately in the lands", 
				"of Britannia and among", 
				"its trading partners.", 
				"Many of these guilds are",
				"divided into local or",
				"specialty subguilds, who", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"use the same colors but", 
				"vary the heraldic pattern.", 
				"There are many lesser", 
				"trade associations that", 
				"have closed membership,", 
				"and one can join only by", 
				"invitation. Beltran's", 
				"Guide to the Guilds is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the definitive text on", 
				"the fulll range of guilds", 
				"and other associations in", 
				"Britannia, and I heartily", 
				"recommend it.", 
				"", 
				"In what follows I have", 
				"attempted to bring", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"together the known", 
				"information regarding", 
				"these guilds. I offer", 
				"thee the name, typical", 
				"membership, heraldic", 
				"colors, known specialty", 
				"organizaitons within the", 
				"larger guild, and any", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"known affiliations to", 
				"other guilds, which often", 
				"occur because of trade", 
				"reasons.",
				"",
				"League of Rangers", 
				"Members: rangers,", 
				"bowyers, animal trainers", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Colors: Red, gold, and", 
				"blue", 
				"", 
				"he Guild of Arcane Arts",
				"Members: alchemists and",
				"wizards", 
				"Colors: blue and purple", 
				"Subguilds: Illusionists,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Mages, Wizards", 
				"Affiliations: Healer's", 
				"Guild", 
				"",
				"The Warrior's Guild",
				"Members: mercenaries,", 
				"soldiery, guardsmen,", 
				"weapons masters,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"paladins", 
				"Colors: Blue and red", 
				"Subguilds: Cavalry,", 
				"Fighters, Warriors",
				"Affiliations: League of",
				"Rangers", 
				"", 
				"Merchant's Association", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Members: innkeepers,", 
				"taverners, jewelers,", 
				"provisioners", 
				"Colors: gold coins on a",
				"green field for Merchants", 
				"White & green for others", 
				"Subguilds: Barters,", 
				"Provisioners, Traders,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Merchants", 
				"", 
				"Guild of Healers", 
				"Members: Healers", 
				"Colors: Green, gold, and", 
				"purple", 
				"Affiliations: Guild of", 
				"Arcane Arts", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Mining Cooperative", 
				"Members: miners", 
				"Colors: blue and black", 
				"checkers, with a gold", 
				"cross", 
				"Affiliations: Order", 
				"of Engineers", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Order of Engineers:", 
				"Members: tinkers and", 
				"engineers", 
				"Colors: Blue, gold, and", 
				"purple vertical bars", 
				"Affiliations: Mining", 
				"Cooperative", 
				"", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Society of Clothiers", 
				"Members: tailors and", 
				"weavers", 
				"Colors: purple, gold, and", 
				"red horizontal bars", 
				"", 
				"Maritime Guild", 
				"Members: fishermen,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"sailors, mapmakers,", 
				"shipwrights", 
				"Colors: blue and white", 
				"Subguilds: Fishermen,", 
				"Sailors, Shipwrights", 
				"", 
				"Bardic Collegium:", 
				"Members: bards, musicians", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"storytellers", 
				"Colors: Purple, red, and", 
				"gold checkerboard", 
				"", 
				"In addition to these", 
				"aboveboard guilds, there", 
				"is one other covert", 
				"organization well known", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"to exist, whose membership", 
				"is likewise open to those", 
				"who seek to apply. In some", 
				"places where illegal", 
				"activities are condoned", 
				"more openly, they dare", 
				"post their sigils", 
				"publicly.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"No law-abiding citizen", 
				"would ever join a guild", 
				"such as this, of course!", 
				"Yet their existence must", 
				"be acknowledged of the", 
				"sake of completeness.", 
				"", 
				"", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Society of Thieves", 
				"Members: beggers,", 
				"cutpurses, assassins,", 
				"and brigands", 
				"Colors: Red and black", 
				"Subguilds: Rogues", 
				"(beggars), Assassins,", 
				"Thieves", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TheMajorTradeBook( Serial serial ) : base( serial )
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
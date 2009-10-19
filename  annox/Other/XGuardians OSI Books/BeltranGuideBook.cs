using System;
using Server;

namespace Server.Items
{
	public class BeltranGuideBook : BrownBook
	{
		[Constructable]
		public BeltranGuideBook() : base( "Beltran's guide to guilds", "Beltran ", 15, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"This reference work is", 
				"intended merely to serve", 
				"as a resource for those", 
				"curious as to the full", 
				"range of trades and", 
				"societies extant in",
				"Britannia and nearby",
				"nations. For each trade", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"or guild, their blazon", 
				"is given.", 
				"", 
				"Armourer's Guild. Gold", 
				"bar above black bar.", 
				"", 
				"Association of Warriors.", 
				"Blue cross on a red", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"field.", 
				"", 
				"Barters' Guild. Green and", 
				"white stripes, diagonal.", 
				"", 
				"Blacksmith's Guild. Gold", 
				"alongside black.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Federation of Rogue and", 
				"Beggars. Red above black.", 
				"", 
				"Fighters and Footmen.", 
				"Blue horizontal bar on", 
				"red field.", 
				"", 
				"Guild of Archers. A gold", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"swath parting red and", 
				"blue.", 
				"", 
				"Guild of Armaments.",
				"Swath of gold on black",
				"field, gold accents.", 
				"", 
				"Guild of Assassins.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Black and red quartered.", 
				"", 
				"Guild of Barbars.", 
				"Red and white stripes.",
				"",
				"Guild of Cavalry and", 
				"Horse. Vertical blue on", 
				"a red field.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Guild of Fishermen.", 
				"Blue and white,quartered.", 
				"", 
				"Guild of Mages. Purple",
				"and blue, in a crossed",
				"pennant pattern.", 
				"", 
				"Guild of Provisioners.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"White bar above green", 
				"bar.", 
				"", 
				"Guild of Sorcery. A field",
				"divided diagonally in",
				"blue and purple.", 
				"", 
				"Healer's Guild. Gold", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"swath dividing green from", 
				"purple, gold accents.", 
				"", 
				"Lord British's Healers of",
				"Virtue. Golden ankh on", 
				"dark green.", 
				"", 
				"Masters of Illusion. Blue", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"and purple checkers.", 
				"", 
				"Merchant's Guild. Gold", 
				"coins on green field.", 
				"", 
				"Mining Cooperative.", 
				"A gold cross, quartering", 
				"blue and black.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Order of Engineers.", 
				"Purple, gold, and blue", 
				"vertical.", 
				"", 
				"Sailors' Maritime", 
				"Association. A white bar", 
				"centered on a blue field.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Seamen's Chapter. Blue", 
				"and white in a crossed", 
				"pennant pattern.", 
				"", 
				"Society of Cooks and", 
				"Chefs. White and red", 
				"diagonal fields checker", 
				"on green field.", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Society of Shipwrights.", 
				"White diagonal above", 
				"blue.", 
				"", 
				"Society of Thieves.", 
				"Black and red diagonal", 
				"stripes.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Society of Weaponsmakers.", 
				"Gold diagonal above", 
				"black.", 
				"", 
				"Tailor's Hall. Purple", 
				"above gold above red.", 
				"", 
				"The Bardic Collegium.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Purple and red checkers", 
				"on gold field.", 
				"", 
				"Trader's Guild. White", 
				"bar centered down green", 
				"field.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public BeltranGuideBook( Serial serial ) : base( serial )
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
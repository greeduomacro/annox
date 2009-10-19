using System;
using Server;

namespace Server.Items
{
	public class BritannianFloraBook : BrownBook
	{
		[Constructable]
		public BritannianFloraBook() : base( "Britannian flora: A casual guide", "Herbert the Lost ", 17, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Oft 'pon rambling through", 
				"the woods avoiding bears", 
				"have I spotted some plant", 
				"whose like I have never", 
				"seen before, and", 
				"concluding that I was a",
				"blithering idiot for",
				"failing to notice it in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the past. Equally as oft", 
				"have I concluded that", 
				"I was a worse idiot for", 
				"not running faster", 
				"from the bear.", 
				"", 
				"While not all my readers", 
				"may share my proclivites", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"for tree-climbing, it", 
				"occurred to me that", 
				"mayhap mine information.", 
				"might serve some humble", 
				"purpose", 
				"", 
				"The two most unique", 
				"flower plants in the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Britannian countryside", 
				"are the orfleur and the", 
				"whiteflower, also called", 
				"white horns.", 
				"", 
				"The orfleur is notable", 
				"for its massive", 
				"orange-red blossoms,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"which dwarf marigolds", 
				"like the sun dwarfs you", 
				"(sic) common fireball", 
				"spell. The odor of said",
				"blooms is best described",
				"as peppermint-apple,", 
				"with a dash of garlic.", 
				"'Tis a popular potted", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"plant despite, or perhaps", 
				"because of, its exotic", 
				"nature.", 
				"",
				"Whiteflowers exude ",
				"a subtle fragrance not", 
				"unlike that of freshly", 
				"shaven wood mixed with", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"cool lemon ice. Their", 
				"tall stands always droop", 
				"with the heavy weight of", 
				"their massive blooms,",
				"oft as large as a child's",
				"head.", 
				"", 
				"The flowers are so large", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"that one may scoop out", 
				"the pollen in handfuls,", 
				"and during the spring", 
				"season many a prank hath",
				"been played by idle boys",
				"'pon their sisters by", 
				"dumping said pollen into", 
				"their clothing drawers,", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"causing sneezes for days.", 
				"", 
				"The most interesting", 
				"native tree to Britannia",
				"is the spider tree. The", 
				"reason for its naming is", 
				"obscure, but may have to", 
				"do with the twisted gray", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"stalks from which the", 
				"spherical canopy sprouts.", 
				"'Tis something of a", 
				"misnomer to term these", 
				"trunks as they are", 
				"spindly and flexible.", 
				"Spider trees provide", 
				"a fresh, piney smell", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"to a room and are", 
				"therefore often potted.", 
				"", 
				"In jungle climes, one", 
				"finds the blade plant,", 
				"whose sharp leaves oft", 
				"collect water for the", 
				"thirsty traveler, yet", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"can draw blood easily.", 
				"", 
				"The deadliest plant, if", 
				"you can call a fungus", 
				"a plant, is the", 
				"Exploding Red Spotted", 
				"Toadstool. No pattern", 
				"can be discerned to its", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"habitats save malice, for", 
				"merely approaching", 
				"results in the cap", 
				"exploding with powder,", 
				"noxious gas, and tiny", 
				"painful pellets flying", 
				"in all directions.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Unfortunately, 'tis", 
				"impossible to tell it", 
				"apart from the Ordinary", 
				"Red Spotted Toadstool", 
				"save through", 
				"experimentation.", 
				"", 
				"Truly odd among the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"varied flora of", 
				"Britannia, however, are", 
				"those which bear names", 
				"clearly alien to our", 
				"tongue. Among these I", 
				"name the Tuscany pine", 
				"(for I have never seen", 
				"a region of this world", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"named Tuscany), the o'hii", 
				"tree, whose very name", 
				"sounds like some tropical", 
				"isle, and the welsh", 
				"poppy, which while", 
				"different from an", 
				"ordinary poppy in color", 
				"and appearance, is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"prefaced with the odd", 
				"word welsh, which as", 
				"far as I know means to", 
				"forgo paying a debt.", 
				"", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public BritannianFloraBook( Serial serial ) : base( serial )
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
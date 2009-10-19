using System;
using Server;

namespace Server.Items
{
	public class DimensionalTravelBook : BrownBook
	{
		[Constructable]
		public DimensionalTravelBook() : base( "Dimensional Travel: A monograph", "Dryus Doost, Mage ", 17, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Tis beyond the scope of", 
				"this small monograph to", 
				"discuss the details of", 
				"moongates, and the", 
				"manners in which they", 
				"distort the fabric of",
				"reality in such a manner",
				"as to permit the passage", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of living flesh from", 
				"place to place, world to", 
				"world, or indeed from", 
				"dimension to dimension.", 
				"", 
				"Instead, allow me to", 
				"bring thy attention,", 
				"Gentle Reader, to the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"curious characteristics", 
				"that are shared by", 
				"certain individuals", 
				"within our realm.", 
				"", 
				"Long has it been known", 
				"that the blue moongate", 
				"permits travel from", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"place to place, and none", 
				"have trouble in taking", 
				"this path. Yet 'tis also", 
				"known, albeit only to a", 
				"few, that certain", 
				"individuals are unable", 
				"to traverse the black", 
				"moongates that permit", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"travel from one", 
				"dimension to another.", 
				"", 
				"The noted mage and peer",
				"of our realm, Lord ",
				"Blackthorn, once told me", 
				"in conversation that his", 
				"arcane research had", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"indicated that the issue", 
				"was one of conservation", 
				"of ether. To wit, given", 
				"the postulate that ",
				"matter within a given",
				"dimension may be but a ", 
				"cros-section of ethereal", 
				"matter that exists in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"multiple dimensions, it ", 
				"becomes obvious that said", 
				"ethereal structure cannot", 
				"enter dimensions in which",
				"it is already present.",
				"", 
				"Imagine an individual", 
				"(and the Lord Blackthorn", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"hinted that he was one", 
				"such) who exist already", 
				"in some form in multiple", 
				"dimensions: said",
				"individual would not be",
				"able to cross into", 
				"another dimension because", 
				"HE IS ALREADY THERE.", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The implications of this", 
				"are staggering, and merit", 
				"further study. 'Tis well", 
				"known by theorists in the",
				"field that divisions in ", 
				"the ethereal structure of", 
				"an individual are already", 
				"implicit at the temporal", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"level, as causality", 
				"forces divisions upon the", 
				"ether. This is the basic", 
				"operating mechanism by", 
				"which white moongates", 
				"function, permitting time", 
				"travel.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"As time travel is not", 
				"barred by the presence of", 
				"an earlier self (though", 
				"encountering said earlier", 
				"self can prove arcanely", 
				"perilous), there must be", 
				"some rigidity to the", 
				"ethereal structure that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"bars multiple", 
				"instantiations of", 
				"structures from", 
				"manifesting within the", 
				"same context.", 
				"", 
				"If one regards time and", 
				"causal bifurcation as a", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"web, perhaps the", 
				"appropriate analogy for", 
				"dimensional matrices is", 
				"that of a crystalline", 
				"structure with rigid", 
				"linkages.", 
				"", 
				"The only way in which an", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"individual such as Lord", 
				"Blackthorn, who exists in", 
				"multiple dimensional", 
				"matrices, can cross", 
				"worlds via a black", 
				"moongate, would be for", 
				"the entire crystalline", 
				"structure of the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"dimension to perfectly", 
				"match the ethereal", 
				"resonance of the", 
				"destination dimension.", 
				"", 
				"The problem of why", 
				"certain individuals are", 
				"already replicated in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"multiple crystalline", 
				"matrices is one that", 
				"I fail to provide any", 
				"schema for in these poor", 
				"theories. It is my", 
				"fondest hope that someday", 
				"someone shall conquer", 
				"that thorny problem and", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"enlighten the world.", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"",
			}; 
			Pages[cnt++].Lines = lines;
		}

		public DimensionalTravelBook( Serial serial ) : base( serial )
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
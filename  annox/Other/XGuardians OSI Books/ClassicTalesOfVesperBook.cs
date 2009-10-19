using System;
using Server;

namespace Server.Items
{
	public class ClassicTalesOfVesperBook : BrownBook
	{
		[Constructable]
		public ClassicTalesOfVesperBook() : base( "Classic tales of Vesper: Volume 1", "Clarke Printery ", 18, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Tis an Honor to present", 
				"to Thee these Tales", 
				"collected from Ages Past", 
				". In this Inaugural", 
				"Volume, we present this", 
				"Verse oft Recited as a",
				"Lullabye for sleepy",
				"Children.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Preface by Guilhem", 
				"the Scholar", 
				"", 
				"The meaning of this verse", 
				"has oft been discussed in", 
				"halls of scholarly sorts,", 
				"for its mysterious", 
				"singsongy melody is oddly", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"disturbing to adult ears,", 
				"though children seem to", 
				"find it restful as they", 
				"sleep. Perhaps it is but", 
				"the remnant of a longer", 
				"ballad once extant, for", 
				"there are internal", 
				"indications that it once", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"told a longer story about", 
				"ill-fated lovers, and a", 
				"magical experiment gone", 
				"awry. However, poetic", 
				"license and the folk", 
				"process has distorted the", 
				"words until now the", 
				"locale o(f?) the tale is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"no more than in the wind,", 
				"which while it serves a", 
				"pleasingly metaphorical", 
				"purpose, fails to inform",
				"the listener as to any",
				"real locale!", 
				"", 
				"Another possibility is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"that this is some form of", 
				"creation myth explaining", 
				"the genesis of the", 
				"variou(s) humanoid",
				"creatures that roam the",
				"lands o(f?) Britannia.", 
				"It does not take a", 
				"stretch of the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"imagination to name the", 
				"middle verse's girl", 
				"becomes a tree as a", 
				"possible explanation for",
				"the reaper, for in the",
				"area surrounding Minoc,", 
				"reapers are oft referred", 
				"to among the lumber", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"jacking community as", 
				"widowmakers. That these", 
				"creatures are of arcane", 
				"origin is assumed, but",
				"the verse seems to imply",
				"a long ago creator,and", 
				"uses the antique magickal", 
				"terminology of plaiting", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"strands of ether that", 
				"is so often found in", 
				"ancient texts. In", 
				"addition, the reference",
				"to snakehills may", 
				"profitably be regarde(d)", 
				"as a reference to an", 
				"actual location, such as", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"perhaps a local term for", 
				"the Serpent's Spine.", 
				"", 
				"A commoner", 
				"interpretation is that", 
				"like many nursery", 
				"rhymes, it is a simple", 
				"explanation for death,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"wherein the wind", 
				"snatches up boys and", 
				"girls and when they", 
				"sleep in order to keep", 
				"the balance of the world.", 
				"Notable tales have been", 
				"written for children of", 
				"adventures in the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Snakehills, which are", 
				"presumed to be an", 
				"Afterworld whence the", 
				"spirit lives on.", 
				"A grim lullabye, to be", 
				"sure, but no worse than", 
				"lest I die before I wake", 
				"surely.", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"In either case, 'tis an", 
				"old favorite herein", 
				"printed for the first", 
				"time for thy enjoyment", 
				"and perusal!", 
				"", 
				"In the Wind where the", 
				" Balance Is Whispered", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"in Hallways", 
				"In the Wind where the", 
				"Magic Flows All through", 
				"the Night", 
				"There live Mages and", 
				"Mages", 
				"With Robes make of", 
				"Whole Days", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Reading Books full of", 
				"Doings", 
				"Printed on Light", 
				"", 
				"In the Wind where the", 
				"Lovers Are Crossed under", 
				"Shadows", 
				"Where they Meet and are", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Parted", 
				"By the Orders of Fate", 
				"The Girl becomes Tree,", 
				"And thus becomes Widow", 
				"The Boy becomes Earth", 
				"And Wanders Till Late", 
				"", 
				"In the Wind are the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Monster", 
				"First Born First Created", 
				"When Chanting and Ether", 
				"Mix Meddling and Night", 
				"Fear going to Wind,", 
				"Fear Finding its", 
				"Plaitings,", 
				"Go Not to the Snakehills", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Lest you Care to Die", 
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

		public ClassicTalesOfVesperBook( Serial serial ) : base( serial )
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
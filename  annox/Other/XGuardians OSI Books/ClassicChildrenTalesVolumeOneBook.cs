using System;
using Server;

namespace Server.Items
{
	public class ClassicChildrenTalesVolumeOneBook : BrownBook
	{
		[Constructable]
		public ClassicChildrenTalesVolumeOneBook() : base( "Classic children's tales: Volume two", "Guilhem ", 17, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Clarke's Printery is", 
				"Honored to Present Tales", 
				"from Ages Past! Guilhem", 
				"the Scholar Shall End", 
				"Each Volume with Staid", 
				"Commentary.",
				"",
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"THE RHYME", 
				"In the Wind where the", 
				"Balance", 
				"Is Whispered in Hallways", 
				"In the Wind where the", 
				"Magic", 
				"Flows All through the", 
				"Night", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"There live Mages and", 
				"Mages", 
				"With Robes made of", 
				"Whole Days", 
				"Reading Books full of", 
				"Doings", 
				"Printed on Light", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"In the Wind where the", 
				"Lovers", 
				"Are Crossed under Shadows", 
				"Where they Meet and are", 
				"Parted", 
				"By the Orders of Fate", 
				"The Girl becomes Tree", 
				"And thus becomes Widow", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The Boy becomes Earth", 
				"And Wanders Till Late", 
				"In the Wind are the", 
				"Monsters",
				"First Born First Created",
				"When Chanting and Ether", 
				"Mix Meddling and Night", 
				"Fear going to Wind", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Fear Finding its", 
				"Plaitings", 
				"Go Not to the Snakehills", 
				"Lest You Care To Die",
				"",
				"THE END", 
				"", 
				"COMMENTARY", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The meaning of this", 
				"verse has oft been", 
				"discussed in halls of", 
				"scholarly sorts.",
				"Perhaps it is but the",
				"remnant of a longer ballad", 
				"once extant, for there are", 
				"internal indications that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"it once told a longer", 
				"story about ill-fated", 
				"lovers, and magical", 
				"experiment gone awry.",
				"However, poetic license",
				"and the folk process has", 
				"distorted the words until", 
				"now the locale of the tale", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"is no more than in the", 
				"wind, which while it", 
				"serves a pleasingly", 
				"metaphorical purpose,",
				"fails to inform the", 
				"listener as to any real", 
				"locale!", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Another possibility is", 
				"that this is some form of", 
				"creation myth explaining", 
				"the genesis of the", 
				"various humanoid", 
				"creatures that roam the", 
				"lands of Britannia. It", 
				"does not take a stretch", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of the imagination to", 
				"name the middle verse's", 
				"girl becomes tree as a", 
				"possible explanation for", 
				"the reaper, for in the", 
				"area surrounding Minoc,", 
				"reapers are oft referred", 
				"to amon the lumberjacking", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"community as widowmakers.", 
				"", 
				"The verse seems to imply", 
				"a long ago creator, and", 
				"uses the antique magickal", 
				"terminology of plaiting", 
				"strands of ether that is", 
				"so often found in ancient", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"texts. In addition, the", 
				"reference to snakehills", 
				"may well be regarded as a", 
				"reference to an actual", 
				"location, such as perhaps", 
				"a local term for the", 
				"Serpent's Spine.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"A commoner interpretation", 
				"is that like many nursery", 
				"rhymes, it is a simple", 
				"explanation for death,", 
				"whereing the wind snatches", 
				"up boys and girls when", 
				"they sleep in order to", 
				"keep the balance of the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"world. Notable tales have", 
				"been written for children", 
				"of adventures in the", 
				"Snakehills, which are", 
				"presumed to be an", 
				"Afterworld whence the", 
				"spirit liveth on. A grim", 
				"lullabye, to be sure, but", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"no worse than lest I die", 
				"before I wake surely.", 
				"", 
				"In either case, 'tis an", 
				"old favorite, hering", 
				"printed for the first", 
				"time for thy enjoyment", 
				"and perusal!", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"-Guilhem the Scholar", 
			};
			Pages[cnt++].Lines = lines;
		}

		public ClassicChildrenTalesVolumeOneBook( Serial serial ) : base( serial )
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
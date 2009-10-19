using System;
using Server;

namespace Server.Items
{
	public class DeceitDungeonHorrosBook : BrownBook
	{
		[Constructable]
		public DeceitDungeonHorrosBook() : base( "Deceit: A dungeon of horrors", "Mercenary Justin ", 11, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"My employers have oft", 
				"taken me into this den of", 
				"hideous creatures, and", 
				"I thought that it behooved", 
				"me to write down what", 
				"I know of it, now that",
				"I am retired from the",
				"life of an adventurer", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"for hire.", 
				"", 
				"Deceit was once a temple", 
				"to forgotten powers of", 
				"old. It was taken over by", 
				"mages who eventually", 
				"were driven out by the", 
				"depredations of their own", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"evil lackeys. However,", 
				"many of the magical traps", 
				"and devices that they", 
				"placed for their defenses", 
				"remain, particularly", 
				"those the wizards used", 
				"to protect their", 
				"treasures.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The dungeon is mystically", 
				"linked by crystal balls", 
				"placed in different", 
				"locations. These magical", 
				"orbs do transmit speech,", 
				"and even have memory of", 
				"things that have been", 
				"said near them. No doubt", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"they once served as a", 
				"warning system.", 
				"", 
				"Be wary of a brazier that",
				"giveth warning when",
				"approached: thou canst", 
				"use it to summon deadly", 
				"creatures.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"There be a tantalizing", 
				"chest, undoubtedly full", 
				"of treasure, that cannot", 
				"be reached save past a",
				"complex series of",
				"pressure plates that", 
				"trigger deadly spikes.", 
				"As I never had sufficient", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"folk with me to unlock", 
				"the puzzle, I never", 
				"obtained the riches that", 
				"awaited there.",
				"",
				"Do not investigate the", 
				"iron maidens too closely,", 
				"for they make suck you", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"within them!", 
				"", 
				"There is one place where", 
				"a deadly trap can only be",
				"disarmed by making use of",
				"a statue that cleverly", 
				"conceals a lever.", 
				"", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Oft one encounters the", 
				"deadly exploding", 
				"toadstool; the ones in", 
				"Deceit are deadlier than",
				"most, as they explode", 
				"continually. Likewise,", 
				"the very pools of water", 
				"and slime on the floor", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"may poisen thee.", 
				"", 
				"The most magical device", 
				"in the dungeon is a", 
				"mystical bridge that can", 
				"only be triggered by a", 
				"lever embedded in the", 
				"floor. Be wary, however,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"for the bridge thus", 
				"created doth burst into", 
				"flame when one passeth", 
				"across it!", 
				"", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public DeceitDungeonHorrosBook( Serial serial ) : base( serial )
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
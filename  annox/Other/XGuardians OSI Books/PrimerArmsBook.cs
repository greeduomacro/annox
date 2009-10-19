using System;
using Server;

namespace Server.Items
{
	public class PrimerArmsBook : BrownBook
	{
		[Constructable]
		public PrimerArmsBook() : base( "A primer on arms", "Martin ", 14, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"These are the basic", 
				"element to consider in", 
				"assessing a weapon of", 
				"which all warrior who", 
				"regard themselves as more", 
				"than mere mercenaries",
				"should be aware. First",
				"and most obvious is the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"amount of damage that", 
				"the weapon may do against", 
				"unprotected flesh. While", 
				"'tis this that first", 
				"attracts the attention of", 
				"the novice, 'tis a deadly", 
				"mistake to regard it as", 
				"the sole value of a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"weapon. While it may", 
				"prove devastating indeed", 
				"as a means of causing", 
				"damage, a weapon must", 
				"also serve as stout", 
				"shield when engaged in", 
				"combat.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Hence the second issue", 
				"to which to pay attention", 
				"is the amount of", 
				"protection that a weapon", 
				"may offer. Pay close", 
				"attention to the guard", 
				"on it, if it be a blade,", 
				"or the stoutness of it's", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"wood if it is a polearm.", 
				"Oft related to this is", 
				"the wait of a weapon, for", 
				"a heavy weapon is more",
				"difficult to maneuver to",
				"block with, though it", 
				"may do more damage to", 
				"they opponent. If a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"weapon is too heavy for", 
				"the wielder to move it", 
				"freely, they should", 
				"choose another and not",
				"attempt to prove their",
				"prowess by the size of", 
				"their sword.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The reach of the weapon", 
				"both increase its", 
				"defensive ability, and", 
				"renders it more useful in",
				"open spaces as it allows",
				"attack against the", 
				"opponent without the need", 
				"to close. But be aware of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the limitations of thy", 
				"weapon! For a weapon with", 
				"great reach may be", 
				"useless in close quarter,",
				"for lack of space to",
				"maneuver it. Should that", 
				"dagger-wielding enemy", 
				"close on thee and they", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"halberd, 'tis best to", 
				"flee.", 
				"", 
				"Lastly, a factor that",
				"must always be considered", 
				"is the condition of the", 
				"weapon. It might be a", 
				"wondrous magical blade", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of surpassing sharpness", 
				"and it may leap to block", 
				"blows with a mind of its", 
				"own. It also might be of", 
				"such flimsy construction,", 
				"or damaged to such an", 
				"extent, that the first", 
				"time it clangs against", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"steel, 'twill shatter", 
				"into useless shards. Seek", 
				"ye a good blacksmith", 
				"should they weapon become", 
				"damaged, but be aware", 
				"that their ministrations", 
				"may simply make the", 
				"matter worse.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"While mages of some", 
				"ability oft create", 
				"magical weapons which", 
				"enhance skill, are", 
				"preternaturally sharp,", 
				"or incinerate the enemy", 
				"as they fall, to mind the", 
				"greatest gift that they", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"can grant a stout sword", 
				"is to make it resistant", 
				"to damage, for they own", 
				"skill can make up the", 
				"difference. Except for", 
				"the fireball, but if the", 
				"corpse is charred, then", 
				"so will be the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"possessions, which maketh", 
				"looting difficult!", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public PrimerArmsBook( Serial serial ) : base( serial )
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
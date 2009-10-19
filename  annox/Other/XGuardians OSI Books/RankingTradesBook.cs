using System;
using Server;

namespace Server.Items
{
	public class RankingTradesBook : BrownBook
	{
		[Constructable]
		public RankingTradesBook() : base( "The ranking of trades", "Lord Higginbotham ", 9, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Whilst 'tis true that", 
				"within each trade, on(e)", 
				"finds differing titles", 
				"and accolades granted to", 
				"the members of a given", 
				"guild, nonetheless for",
				"the betterment of trade",
				"and understanding, we", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"must have a commonality", 
				"of titling.", 
				"", 
				"For those who may find", 
				"themselves ignorant of", 
				"the finer distinctions", 
				"between a three-knot", 
				"member o(f?) the Sailors'", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Maritime Association and", 
				"a second thaumaturge,", 
				"this book shall serve as", 
				"a simple introduction to", 
				"the common cant used", 
				"when members of", 
				"differing guilds and", 
				"trade organizations must", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"trade with each other and", 
				"must establish relative", 
				"credentials.", 
				"", 
				"Neophyte", 
				"Has shown interest in", 
				"learning the craft and", 
				"some meager talent.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Novice", 
				"Is practicing basic", 
				"skills but has not bee(n)", 
				"admitted to full",
				"standing.",
				"", 
				"Apprentice", 
				"A student of the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"discipline.", 
				"", 
				"Journeyman", 
				"Warrented to practice",
				"the discipline under the",
				"eyes of a tutor.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Expert", 
				"A full member of the", 
				"guild.", 
				"",
				"Adept",
				"A member of the guild", 
				"qualified to teach", 
				"others.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Master", 
				"Acknowledged as qualified", 
				"to lead a hall or", 
				"business.",
				"",
				"Grandmaster", 
				"Rarely a permanent title,", 
				"granted in common.", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"parlance to those who", 
				"have shown extreme", 
				"mastery of their craft", 
				"recently",
				"", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public RankingTradesBook( Serial serial ) : base( serial )
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
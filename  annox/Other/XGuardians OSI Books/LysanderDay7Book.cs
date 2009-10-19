using System;
using Server;

namespace Server.Items
{
	public class LysanderDay7Book : BlueBook
	{
		[Constructable]
		public LysanderDay7Book() : base( "Lysander's Notebook", "L. Gathenwale ", 6, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 7:", 
				"", 
				"The Sewel woman pratters", 
				"on endlessly. And she", 
				"dares to speak Thy Name,", 
				"Master! I wish so",
				"vehemently to take a",
				"knife to that little neck", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of hers. She struts", 
				"around the chambers of", 
				"Thy Sanctum with her", 
				"repugnant airs, her", 
				"scholarly conjecture on", 
				"this or that. That", 
				"I could peel the skin", 
				"from her face and show", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"her how vile and ugly she", 
				"truly is, how unworthy of", 
				"entrance to Thy Sanctum.", 
				"I must take her, Master.", 
				"I must rend that little", 
				"wench to pieces. I ask", 
				"this gift of Thee, that", 
				"I might cleanse Thy", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Sanctum of her presence.", 
				"Give me the Sewel woman", 
				"and I shall show you my", 
				"mastery of Death, Master.", 
				"I shall cut her to bits", 
				"and scatter them before", 
				"the others as a warning.", 
				"I cannot stand her", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"presence, I cannot abide", 
				"it. And Drummel! He is a", 
				"pustule that must be", 
				"lanced, a sickness that",
				"I must cure by blade and",
				"fire. Not a trace of him", 
				"will be left when I'm", 
				"done with him. Praises to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Thee, Master. I shall", 
				"honor Thee with many", 
				"sacrifices, soon enough.", 
				"",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public LysanderDay7Book( Serial serial ) : base( serial )
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
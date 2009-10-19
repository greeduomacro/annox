using System;
using Server;

namespace Server.Items
{
	public class TheFightBook : BrownBook
	{
		[Constructable]
		public TheFightBook() : base( "The Fight", "M. De La Garza ", 7, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"A cold autumn morning", 
				"with misty fog secures", 
				"a dozen brave knights,", 
				"supplying hidden shelter", 
				"from prying eyes deep in", 
				"the foothills of the",
				"vibrant valley. Dragons",
				"soar like fierce warriors,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"circling around and", 
				"around, then roaring like", 
				"thunder, rallying all that", 
				"listen. The dragons land", 
				"swiftly beside the proud", 
				"warriors, bending necks", 
				"and extending wings,", 
				"lifting black claws and", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"allowing valiant fighters", 
				"to ride forth and win an", 
				"arisen battle. The", 
				"increasing winds silence", 
				"the sounds of combat,", 
				"and they fight, standing", 
				"their ground like mothers", 
				"protecting their children", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"bright armor flashing as", 
				"each one falls.", 
				"", 
				"A cold autumn's evening", 
				"with misty fog cradles", 
				"a dozen battered corpses", 
				"of knights, creasing", 
				"them in currents of winds", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"that run deep in the", 
				"foothills of the desolate", 
				"valley. Dragons glide", 
				"like silent angels,",
				"circling around and",
				"around, then calling", 
				"like banshees; keening", 
				"cries of mourning.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The dragons land heavily", 
				"beside the peaceful", 
				"bodies, bending their", 
				"necks and extending wings",
				"lifting black claws and",
				"pinching the sacred", 
				"ground and new eternal", 
				"home. The dying winds", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"whistle among the dead in", 
				"somber procession, and", 
				"they lie, grasping", 
				"weapons to protect",
				"themselves like knights",
				"still in battle,", 
				"shattered armor shining", 
				"like newly born stars.", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TheFightBook( Serial serial ) : base( serial )
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
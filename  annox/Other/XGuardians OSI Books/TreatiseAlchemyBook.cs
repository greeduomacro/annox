using System;
using Server;

namespace Server.Items
{
	public class TreatiseAlchemyBook : BrownBook
	{
		[Constructable]
		public TreatiseAlchemyBook() : base( "Treatise on alchemy", "Felicia Hierophant ", 10, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"The alchemical arts are", 
				"notable for their", 
				"deceptive simplicity.", 
				"Tis true that to our best", 
				"knowledge currently,", 
				"there are but eight",
				"valid potions that can",
				"be made (though", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I emphasize that new", 
				"discoveries may always", 
				"await). However, the", 
				"delicate balance of", 
				"confecting the potions is", 
				"difficult indeed, and", 
				"requires great skill.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"To give thee an example", 
				"of the simpler potions", 
				"that can be created by", 
				"those well-versed in the", 
				"subtleties of alchemy.", 
				"", 
				"Black pearl, that rare", 
				"substance that is oft", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"found lying unannounced", 
				"upon the surface of the", 
				"ground, when properly", 
				"crushed with mortar and", 
				"pestle, can yield a fine", 
				"powder. Said powder in", 
				"the proper proportions", 
				"when mixed via the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"alchemical arts can yield", 
				"a wonderfully refreshing", 
				"drink.", 
				"",
				"The revolting blood moss",
				"so gingerly scraped off", 
				"windowsills by fastidious", 
				"housewives is but a tiny", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"cousin to the wilder", 
				"version, which when", 
				"properly prepared yields", 
				"a magical liquid that for",
				"a time can make the",
				"imbiber a more agile and", 
				"dextrous individual.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"However, beware of the", 
				"deadly nightshade, for it", 
				"yields a deceptively", 
				"sweet-tasting poison that",
				"can prove highly fatal to",
				"the drinker, and in fact", 
				"is also used by assassins", 
				"to coat their blades.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Fortunately, this latter", 
				"art of poisoning is", 
				"little known!", 
				"",
				"There is much to reward",
				"the student of alchemy,", 
				"indeed. The rumors of", 
				"longtime alchemists", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"losing their hair and", 
				"acquiring an unhealthy", 
				"pallor, not to mention", 
				"unsightly blotches upon",
				"their once-fair skin, are", 
				"unhappily, true. Yet the", 
				"joys of the mind make up", 
				"for the complete loss of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"interest that others may", 
				"have in thee as an object", 
				"of courtship, and I have", 
				"never regretted that", 
				"choice. Honestly, truly.", 
				"Not once.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public TreatiseAlchemyBook( Serial serial ) : base( serial )
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
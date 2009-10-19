using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay7Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay7Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 6, false ) // true writable so players can make notes
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
				"T'was written that, upon", 
				"his death, Khal Ankur's", 
				"followers, those known as", 
				"the Keepers of the Seven",
				"Death, sealed them selves",
				"within the Sanctum they", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"had carved from the", 
				"mountains in his honor.", 
				"The Zealots of his order", 
				"entombed the lesser", 
				"followers alive, then,", 
				"when all but two remained,", 
				"slit their throats and", 
				"joined Khal Ankhur in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"death. Surely this is not", 
				"suprising for a Cult that", 
				"worshipped death and", 
				"sacrifice so vehemently", 
				"as it is said that the", 
				"Keepers did - and yet,", 
				"to be in this Tomb, to", 
				"know that somewhere in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"its depths hundreds upon", 
				"hundreds of bodies lay,", 
				"sealed alive at their own", 
				"behest... I must confess", 
				"that the very thought of", 
				"it troubles my dreams at", 
				"night. I've asked", 
				"Lysander if we might", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"reestablish the camp", 
				"outside the Tomb, setting", 
				"up night watches and some", 
				"sort of fortification,",
				"but he'll have none of",
				"it. I did not press the", 
				"issue, as I suddenly", 
				"felt foolish even at my", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"askance.", 
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

		public JournalDiscoveryDay7Tomb( Serial serial ) : base( serial )
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
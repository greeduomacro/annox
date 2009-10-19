using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay11and13Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay11and13Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 7, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 11-13:", 
				"", 
				"Two more workers have", 
				"gone missing. Even more", 
				"disturbing is the fact", 
				"that Lysander has joined",
				"him. Late last night the",
				"workers finished", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"excavating the next main", 
				"hall, and we retired to", 
				"the main antechamber and", 
				"our camp to rest up for", 
				"exploration on the", 
				"'morrow. In the middle of", 
				"the night we woke to a", 
				"strange howling sound,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"and as the men prepared", 
				"themselves for another", 
				"onslaught of the beasts", 
				"that had troubled our", 
				"outer camp, it was", 
				"noticed that Lysander", 
				"was nowhere in our", 
				"number. I cannot fathom", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"where he has gone - the", 
				"newly revealed chamber", 
				"holds no immediate", 
				"egress, blocked again by", 
				"piles of stone and", 
				"rubble, and I cannot", 
				"believe that Lysander,", 
				"of all people, would", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"have fled this site -", 
				"indeed, he had lately", 
				"grown almost fanatical in", 
				"his work to discover more",
				"of the secrets barred to",
				"us by the consistently", 
				"slow progress of", 
				"excavating each new", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"hallway. The men are at", 
				"work even now, and as the", 
				"ceaseless thumps and", 
				"cracks of their picks",
				"reverberate throughout",
				"the entirety of the tomb,", 
				"the dust continous to", 
				"pour down from the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"ancient stonework above", 
				"us like some horrible,", 
				"eldritch curse upon us", 
				"all.",
				"",
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay11and13Tomb( Serial serial ) : base( serial )
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
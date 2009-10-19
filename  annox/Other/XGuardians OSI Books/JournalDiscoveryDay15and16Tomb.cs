using System;
using Server;

namespace Server.Items
{
	public class JournalDiscoveryDay15and16Tomb : RedBook
	{
		[Constructable]
		public JournalDiscoveryDay15and16Tomb() : base( "Journal: Discovery of the Tomb", "Tawara Sewel ", 6, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Day 15-16:", 
				"", 
				"Why do I write? I must...", 
				"not so much because there", 
				"must be some record of", 
				"this... what's happened",
				"here... as for my own",
				"sanity. The act of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"putting pen to paper", 
				"calms me, focuses me,", 
				"even in this madness.", 
				"Lysander is dead. So many", 
				"are dead. And we're", 
				"trapped here, trapped", 
				"forever in this nightmare.", 
				"He would not let us pass,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"wild in his psychosis,", 
				"furious, spitting,", 
				"covered in blood, he", 
				"swung the ancient dagger", 
				"at any who approached.", 
				"He babbled incoherently,", 
				"cursed at us, the most", 
				"hateful curses, prophecy,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"doom upon us. Bergen", 
				"would have none of it.", 
				"Finally, he leapt at", 
				"Lysander, his massive axe", 
				"at his side. But he would", 
				"not be the end of the mad", 
				"mage... no... they were..", 
				"those hands, covered in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the dirt of the grave,", 
				"maggots, filth. They rose", 
				"up behind Lysander. That", 
				"look of curiosity on the",
				"mage's face as Bergen",
				"skidded to a halt... t", 
				"was almost a moment of", 
				"sanity for him, surely,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"to attempt to comprehend", 
				"what could have stopped", 
				"the warrior in his", 
				"tracks. And then they",
				"were upon him. Skeletal",
				"hands, arms, and faces", 
				"with loose, corrupted", 
				"flesh hanging from", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"yellow bone. Inhuman, yet", 
				"once human, staggering", 
				"towards us as their", 
				"companions tore at",
				"Lysander, coming towards",
				"us in droves.", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public JournalDiscoveryDay15and16Tomb( Serial serial ) : base( serial )
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
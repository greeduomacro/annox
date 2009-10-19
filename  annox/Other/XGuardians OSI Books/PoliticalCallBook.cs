using System;
using Server;

namespace Server.Items
{
	public class PoliticalCallBook : BrownBook
	{
		[Constructable]
		public PoliticalCallBook() : base( "A political call to anarchy", "Lord British ", 13, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Let it never be said", 
				"that I have augh(t) as", 
				"quarrel with my liege", 
				"Lord British, for indeed", 
				"we be of the best of", 
				"friends, sharing amicable",
				"games of chess 'pon winter",
				"'s night, and talking at", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"length into the wee hours", 
				"of the issues that affect", 
				"the realm of Britannia.", 
				"", 
				"Yet true friendship doth", 
				"not prevent true", 
				"philosophical", 
				"disagreement either. ", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"approval my lord's", 
				"affection for his", 
				"carefully crafted", 
				"philosophy of the Eight", 
				"Virtues, wherein moral", 
				"behavior is encouraged", 
				"in the populace, I view", 
				"with less approval the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"expenditure of public", 
				"funds upon the", 
				"construction of shrines", 
				"to said ideals.", 
				"", 
				"The issue is not on(e)", 
				"of funds, however, but", 
				"a disagreement most", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"intellectual over the", 
				"proper way of humankind", 
				"in an ethical sense.", 
				"Surely freedom of",
				"decision must be regarded",
				"as paramount in any such", 
				"moral decision?  Though", 
				"none fail to censure the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"murderer, a subtler", 
				"question arises when we", 
				"ask if his behavior would", 
				"be ethical if he were",
				"forced to it.",
				"", 
				"I say to thee, the reader", 
				", quite flatly, that no", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"ethical system shall have", 
				"sway over me unless it", 
				"convinceth me, for that", 
				"freely made choice is",
				"to me the sigh that the",
				"system has validity.", 
				"", 
				"Whereas the system of", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Virtues that my liege", 
				"espouses is indeed a", 
				"compilation of commonly", 
				"approved virtues,",
				"I approve of it. Where",
				"it seeks to control the", 
				"populace and restrict", 
				"their diversity and", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"their range of behaviors,", 
				"I quarrel with it. And", 
				"thus do I issue this", 
				"politic call to anarchy,",
				"whilst humbly begging", 
				"forgivness of Lord", 
				"British for my", 
				"impertinence:", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Celebrate thy differences", 
				". Take thy actions", 
				"according to they own", 
				"lights. Question from", 
				"what source a law, a rule", 
				", a judge, and a virtue", 
				"may arise. 'Twere", 
				"possible (though I ", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"suggest it not seriously)", 
				"that a daemon planted the", 
				"seed of these Virtues", 
				"in my Lord British's mind;", 
				"'twere possible that", 
				"the Shrines were but a", 
				"plan to destroy this", 
				"world. Thou canst not", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"know unless thou", 
				"questioneth,doubteth, and", 
				"in the end, unless thou", 
				"relyest upon THYSELF and", 
				"they judgement. I offer", 
				"these words as mere", 
				"philosophical musings", 
				"for those who seek", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"enlightenment, for 'tis", 
				"the issue that hath", 
				"occupied mine interest", 
				"and that of Lord British", 
				"for some time now.", 
				"", 
				"", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		}

		public PoliticalCallBook( Serial serial ) : base( serial )
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
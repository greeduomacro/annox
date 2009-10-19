using System;
using Server;

namespace Server.Items
{
	public class EthicalHedonismBook : BrownBook
	{
		[Constructable]
		public EthicalHedonismBook() : base( "Ethical hedonism: An introduction", "Richard Garriott ", 22, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Societies oft have common", 
				"codes of conduct which it", 
				"[sic] expects all its", 
				"people to abide by. Now,", 
				"while 'tis true that this", 
				"can offer some advantages,",
				"most of the codes I see",
				"today around Britannia", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"have fatal flaws. Let us", 
				"examine them.", 
				"", 
				"First, there is", 
				"Blackthorn's code of", 
				"Chaos or basically", 
				"Anarchy. Whereas this", 
				"affords the individual", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"maximum opportunity for", 
				"individuality and eve", 
				"[sic] pursuit of personal", 
				"happiness, it does not", 
				"offer even basic", 
				"interpersonal conduct", 
				"codes to prevent people", 
				"from killing each other.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Without such basic tenets", 
				"all the people will need", 
				"to spend a significant", 
				"portion of their time and", 
				"effort towards personal", 
				"protection and thus less", 
				"time towards other more", 
				"beneficial pursuits.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Then there are the moral", 
				"codes that are so popular", 
				"today. These codes are", 
				"built largely on",
				"historical tradition",
				"rather than current logic", 
				"and thus are also", 
				"antiquated. For example", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"many moral codes we see", 
				"today include statements", 
				"about not eating certain", 
				"foods that once were",
				"often poisonous, but",
				"today can be prepared", 
				"safely.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Many forbid contact", 
				"between young people of", 
				"the opposite gender,", 
				"which can in fact be",
				"hazardous; but the codes",
				"often have lost the", 
				"context as to why this is", 
				"done, instead merely", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"calling it amoral. In", 
				"this day and age to call", 
				"that a necessary moral", 
				"would need a new",
				"reasoning. I put forth",
				"that tradition is not", 
				"enough.", 
				"", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Then there are Lord", 
				"British's Virtues. It", 
				"strikes me that while a", 
				"system of virtues is",
				"wonderful as a touchstone", 
				"to guide a society to", 
				"good behavior, these are", 
				"but shades of the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"underlying truth as t", 
				"[sic] why one may wish", 
				"to live a life according", 
				"to certain rules of", 
				"conduct.", 
				"", 
				"On the other hand,", 
				"clearly the Virtues that", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I have heard Lord British", 
				"speak of are clearly", 
				"positive codes of conduct,", 
				"far better than the world", 
				"of anarchy that Lord", 
				"Blackthorn suggests. Yet,", 
				"are not these Virtues", 
				"still derived from a set", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of principles which", 
				"though they sound good,", 
				"are difficult to pin down", 
				"as actual, undeniable,", 
				"rational truths?", 
				"", 
				"Worse yet though imagine", 
				"a society who's [sic]", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"code of conduct was based", 
				"on pure survival of the", 
				"strongest. While this", 
				"society may function and", 
				"even accomplish much, it", 
				"can be fairly argued that", 
				"personal happiness would", 
				"suffer greatly except for", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"those at the top. To rule", 
				"that out, however, we", 
				"must first believe that", 
				"people have a right to", 
				"pursue happiness.", 
				"I hope is [sic] a safe", 
				"assumption that all", 
				"beings wish to be happy;", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I will broadly describe", 
				"this as Hedonism. Yet, if", 
				"all people did is live a", 
				"life of hedonism, their", 
				"hedonism might be in", 
				"conflict with those near", 
				"them, so I will use the", 
				"term Ethics to describe", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"limits one might put on", 
				"one's hedonistic", 
				"tendencies to allow", 
				"others to pursue their", 
				"happiness as well.", 
				"", 
				"Allow me to give this", 
				"example: If one were to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"live alone on a desert", 
				"isle, one could live a", 
				"life of pure hedonism,", 
				"for no action one might", 
				"take could interfere with", 
				"another's right to pursue", 
				"their happiness. Poison", 
				"th [sic] lake if you", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"like, ther [sic] is no", 
				"one to blame but", 
				"yourself!", 
				"", 
				"Now suppose two of you", 
				"live on that island.", 
				"Thou dost not want thy", 
				"neighbor to feel free to", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"poison the lake. Would it", 
				"not be better to consider", 
				"it unethical to poison th", 
				"[sic] lake without first", 
				"thinking of those whose", 
				"pursuit of happiness might", 
				"be affected by this", 
				"action?", 

			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"I put forth that it is", 
				"the fact that we as a", 
				"people choose to live in", 
				"groups known as a", 
				"society that causes us to", 
				"compromise our pure", 
				"hedonism with logical", 
				"ethics. Likewise we", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"accept not being able to", 
				"kill others without", 
				"reason, because our own", 
				"pursuit of happiness", 
				"would be greatly", 
				"interfered with if we", 
				"feared others would do", 
				"the same to us. From", 
			};
						Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"this basis of logic can", 
				"be formed the Tenets of", 
				"Ethical Hedonism.", 
				"", 
				"", 
				"", 
				"", 
				"", 
			};
			Pages[cnt++].Lines = lines;
		}

		public EthicalHedonismBook( Serial serial ) : base( serial )
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
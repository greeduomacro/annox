using System;
using Server;

namespace Server.Items
{
	public class MyStoryBook : BrownBook
	{
		[Constructable]
		public MyStoryBook() : base( "My Story", "Sherry the mouse ", 45, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"Twas on a chill night,", 
				"when the moon shone", 
				"pasty-faced above the", 
				"horizon, balanced on the", 
				"towers of Lord British's", 
				"castle, that the events",
				"I am about to relate",
				"took place, some years", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"ago now. I witnessed them", 
				"all from my tiny", 
				"mousehole.", 
				"", 
				"Milords British and", 
				"Blackthron are accustomed", 
				"to a game of chess 'pon", 
				"an evening, over which", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"they argue the issues", 
				"that affect the course of", 
				"the realm. Lord", 
				"Blackthorn was on his", 
				"way to Lord British's", 
				"chambers, and Lord", 
				"British stood by a window", 
				"casement, just having", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"finished setting the", 
				"pieces upon the board.", 
				"", 
				"Suddenly the shutters", 
				"blew open, and Lord", 
				"British fell to the", 
				"ground, one hand", 
				"shileding his eyes. A", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"chill wind entered the", 
				"room, and it seemd a gash", 
				"was torn in the very air.", 
				"Through the gas I could",
				"see stars and swirling",
				"clouds of stellar dust,", 
				"and a coldness sucked all", 
				"the warmth from the air.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"A terrible wind tossed", 
				"books and blankets across", 
				"the room, and furniture", 
				"toppled.",
				"",
				"From within this gash", 
				"issued a great voice,", 
				"unlike any I have ever", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"heard. And these are the", 
				"words it spoke (for I", 
				"memorized them most", 
				"carefully):",
				"",
				"Greetings, Lord British.", 
				"I am the Time Lord, a", 
				"being from beyond your", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"dimension, as thou art", 
				"from a world other than", 
				"Sosaria. I am here to", 
				"bring thee warning. Dost",
				"thou recall how long ago",
				"mysterious Stranger came", 
				"to Sosaria and saved the", 
				"world from the evil", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"wizard Mondain? He", 
				"shattered the Gem of", 
				"Immortality, within which", 
				"dwelled a perfect",
				"likeness of this world.", 
				"", 
				"Lord British slowly stood", 
				"and faced the hole in the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"air. I remember, he", 
				"said. Oft have I wished", 
				"that stranger would", 
				"return.", 
				"", 
				"He hath returned, spoke", 
				"the voice. But not to", 
				"here. When the Gem was", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"shattered, a thousand", 
				"shards were scattered", 
				"across the dimensions,", 
				"and in each shard there", 
				"is a perfect likeness of", 
				"this world. And thou dost", 
				"live upon one such shard,", 
				"for thou art not of the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"true world-thou art", 
				"merely a reflection.", 
				"", 
				"Lord British looked", 
				"shaken by this, and I did", 
				"not know what to think!", 
				"Was I merely a shadow of", 
				"the real me, which lives", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"still somewhere else", 
				"across uncounted", 
				"universes?", 
				"", 
				"My task is to heal this", 
				"shattered world, Lord", 
				"British, said the voice.", 
				"And I seek to enlist thee", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"in my cause. Be warned", 
				"that in this case,", 
				"healing carries with it", 
				"a terrible price.", 
				"", 
				"Concern warred with", 
				"curiosity on my liege's", 
				"face, but ever one to", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"shoulder a burden, he", 
				"straightened and faced", 
				"the gash in the air", 
				"bravely. Name thy price.", 
				"", 
				"A shard of a universe is", 
				"a powerful thing, and", 
				"universe shattered is", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"always in danger from the", 
				"powers of darkness.", 
				"Already three shards were", 
				"turned to evil, and sent", 
				"to plague the original", 
				"universe in the form of", 
				"Shadowlords. Many times", 
				"have I brought the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Stranger back to", 
				"Britannia, to preserve it", 
				"from its own folly or", 
				"from outside dangers. Yet", 
				"as long as the world", 
				"remaineth in pieces, it", 
				"remaineth vulnerable. We", 
				"must bring the shards", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"into harmony, so that", 
				"they resonate in such a", 
				"manner that matches the", 
				"original universe. Then", 
				"the two universes shall", 
				"merge, and be again as", 
				"one.", 
				"", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"But if we are only", 
				"shadows... Lord British", 
				"said wonderingly.", 
				"", 
				"The light from the stars", 
				"within the hole seemed to", 
				"dim. Indeed, the", 
				"reflections shall become", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"one with the orginal.", 
				"Thou wouldst cease to be", 
				"as thou art, and become", 
				"part of the larger you.", 
				"Thou shalt not die;", 
				"however, uncounted", 
				"generations have passed", 
				"and borne children since", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"that day, and they have", 
				"no counterparts. They", 
				"would perish utterly.", 
				"Lord British sagged in", 
				"shock, realizing the", 
				"terrible price that would", 
				"be paid to heal the", 
				"universe. All of my", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"people, he breathed.", 
				"", 
				"Tis for the greateer good", 
				"", 
				"Lord British bowed his", 
				"head.", 
				"", 
				"Twas then I saw the", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"movement by the door,", 
				"half-hid by the heavy red", 
				"curtains. Lord Blackthron", 
				"stood there, concealed",
				"from the rest of the",
				"room, his face white. How", 
				"long had he been", 
				"listening? I cannot say,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"yet I suspect that he had", 
				"heard all that the", 
				"mysterious voice had to", 
				"say.",
				"",
				"How then, shall I aid", 
				"thee? Lord British said,", 
				"weariness in his voice.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Aid the nobility that", 
				"resideth in human heart.", 
				"Protect the Virtues that", 
				"so recently came to thee",
				"in thought late at night.",
				"They are the Virtues of", 
				"life, as your counterpart", 
				"understands them to be.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"For when thy populace", 
				"doth live and breathe", 
				"these Virtues shall it", 
				"match the true Britannia,",
				"and thy shard shall",
				"rejoin with it.", 
				"", 
				"The gash in the air began", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"to close, and with it", 
				"warmth stole back into", 
				"the room.", 
				"",
				"I was going to discuss my", 
				"idea with Blackthorn", 
				"tonight, Lord British", 
				"breathed. Have I no", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"thoughts that are my own?", 
				"Is my life but a", 
				"reflection of another me?", 
				"", 
				"Nay, said the voice,", 
				"smaller through the", 
				"diminished opening. Say,", 
				"rather, that you are", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"parallel, for there is no", 
				"guarantee that thou shalt", 
				"accomplish what I have", 
				"set thee to. I speak", 
				"tonight to a thousand of", 
				"thee, and ask the same of", 
				"all. Perhaps not all", 
				"shall seek to aid me.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"And with that, the gash", 
				"closed, and the voice was", 
				"gone, leaving a room that", 
				"appeared tossed by a", 
				"mighty storm.", 
				"", 
				"Destroy the world to save", 
				"the universe, Lord", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"British said bitterly.", 
				"I do not wonder that some", 
				"may balk.", 
				"", 
				"Lord Blackthorn collected", 
				"himself, and strode into", 
				"the room, a decent", 
				"mimicry of surprise on his", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"face. My liege! What has", 
				"happened here? he", 
				"exclaimed, feigning", 
				"dismay well. But not well", 
				"enough to fool his old", 
				"friend, whose eyes", 
				"narrowed at seeing him", 
				"there.", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"How much didst thou hear?", 
				"Demanded Lord British.", 
				"", 
				"Why, nothing, managed", 
				"Blackthorn, his head", 
				"ducked away from his", 
				"friend, as he bent to", 
				"retrieve the fallen chess", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"pieces. I merely came for", 
				"our game of chess.", 
				"", 
				"Together, they righted", 
				"the table, and set the", 
				"pieces upon the black", 
				"and white squares.", 
				"Such simplicity to the", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"game, Blackthorn, mused", 
				"Lord British, idly", 
				"brushing one finger", 
				"against the board. Black", 
				"and white, each to its", 
				"own color, as if life", 
				"were so simple. What", 
				"think you?", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Blackthorn sat heavily on", 
				"a hassock beside the", 
				"chess table. I think", 
				"that matters are never so", 
				"simple, my liege. And", 
				"that I would regret it", 
				"deeply if someone, such", 
				"as a friend, saw it thus.", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Lord British's eyes met", 
				"his. Yet sometimes one", 
				"must sacrifice a pawn", 
				"to save a king.", 
				"", 
				"Lord Blackthorn met his", 
				"gaze squarely. Even pawns", 
				"have lives and loves at", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"home, my lord. Then he", 
				"reached out for a pawn,", 
				"and firmly moved it", 
				"forward to squares. Shall", 
				"we play a game? he asked.", 
				"", 
				"The chess game that night", 
				"was a draw, and they", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"played grimly.", 
				"", 
				"And the next day, Lord", 
				"British gathered the", 
				"nobles to proclaim the", 
				"idea of a new system of", 
				"Virtues, and declared", 
				"that shrines should be", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"built across the land.", 
				"", 
				"Lord Blackthorn opposed", 
				"it bitterly, and many", 
				"thought him strange for", 
				"doing so, for ever had", 
				"he been a noble and", 
				"upright man, and ever", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"had he and Lord British", 
				"been in accord. Declaring", 
				"that he should start his", 
				"own shrine, he departed", 
				"the castle that day to", 
				"live in a tower in a", 
				"lake on the north side", 
				"", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of the city.", 
				"", 
				"They are still the best", 
				"of friends, yet a sadness", 
				"hangs between them, as if", 
				"they were forced into", 
				"making choices that", 
				"appealed not to them. And", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"at night, when I creep", 
				"softly from one corner of", 
				"my liege's bedchamber to", 
				"another, I sometimes see", 
				"him take a pawn from his", 
				"night table, and hold it", 
				"in his hand, and quietly", 
				"weep.", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"But I am but a mouse, and", 
				"none hear me. This tale", 
				"goes unknown, save for my", 
				"writing these enormous", 
				"letters with mine", 
				"ink-stained tiny paws for", 
				"thee to read, for I fear", 
				"indeed for our world and", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"for our people in these", 
				"perilous times.", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"", 
			};
			Pages[cnt++].Lines = lines;
		}

		public MyStoryBook( Serial serial ) : base( serial )
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
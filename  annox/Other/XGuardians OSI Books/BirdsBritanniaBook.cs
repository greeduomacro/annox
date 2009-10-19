using System;
using Server;

namespace Server.Items
{
	public class BirdsBritanniaBook : BrownBook
	{
		[Constructable]
		public BirdsBritanniaBook() : base( "Birds of Britannia", "Thom the Heathen ", 26, false ) // true writable so players can make notes
		{
		// NOTE: There are 8 lines per page and 
		// approx 22 to 24 characters per line! 
		//		0----+----1----+----2----+ 
		int cnt = 0; 
			string[] lines; 
			lines = new string[] 
			{ 
				"The WREN is a tiny", 
				"insect-eating bird with a", 
				"loud voic(e.) The", 
				"cheerful trills of Wrens", 
				"are extraordinarily", 
				"varied and melodious.",
				"",
				"The SWALLOW is easily", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"recognized by its forked", 
				"tail. Swallows catch", 
				"insects in flight, and", 
				"have squeaky, twittering", 
				"songs.", 
				"", 
				"The WARBLER is an", 
				"exceptional singer,", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"whose extensive songs", 
				"combine the best", 
				"qualities of Wrens and", 
				"Swallows.", 
				"", 
				"The NUTHATCH climbs down", 
				"trees headfirst,", 
				"searching for insects in", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"the bark. It sings a", 
				"repetitive series of", 
				"notes with a nasal tone", 
				"quality.", 
				"", 
				"The agile CHICKADEE has a", 
				"buzzy chick-a-dee-dee", 
				"call, from which its name", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"is derived. Its song is a", 
				"series of whistled notes.", 
				"", 
				"The THRUSH is a brown",
				"bird with a spotted",
				"breast, which eats worms", 
				"and snails, and has a", 
				"beautiful singing voice.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Thrushes use a stone as", 
				"an anvil to smash the", 
				"shells of snails.", 
				"",
				"The little NIGHTINGALE is",
				"also known for its", 
				"beautiful song, which it", 
				"sings even at night.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The STARLING is a small", 
				"dark bird with a yellow", 
				"bill an(d) a squeaky,", 
				"high-pitched song.",
				"Starlings can mimic the",
				"sounds of other birds.", 
				"", 
				"The SKYLARK sings a", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"series of high-pitched", 
				"melodius trills in", 
				"flight.", 
				"",
				"The FINCH is a small",
				"seed-eating bird with a", 
				"conical beak and a", 
				"musical, warbling song.", 
			};			
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The CROSSBILL (sic) is a", 
				"kind of Finch with a", 
				"strange crossed bill,", 
				"which it uses to extract",
				"seeds from pine cones.", 
				"", 
				"The CANARY is a kind of", 
				"Finch that I often kept as", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"a pet. Miners would often", 
				"take Canaries underground", 
				"with them, to warn them", 
				"of the presence of", 
				"hazardous vapors in the", 
				"air.", 
				"", 
				"The SPARROW weaves a nest", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"of grass, and has an", 
				"unmusical chirp for", 
				"voice.", 
				"", 
				"The TOWHEE is a kind of", 
				"Sparrow that continually", 
				"reminds listeners to", 
				"drink their tea.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The SHRIKE is a gray bird", 
				"with a hooked bill.", 
				"Shrikes have the habit of", 
				"impaling their prey on", 
				"thorns.", 
				"", 
				"The WOODPECKER has a", 
				"pointed beak that is", 
			}; 
			Pages[cnt++].Lines = lines; 
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"suitable for pecking at", 
				"wood to get at the", 
				"insects inside.", 
				"", 
				"The KINGFISHER dives for", 
				"fish, which it catches", 
				"with its long, pointed", 
				"beak.", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The TERN migrates over", 
				"great distances, from one", 
				"end of Britannia to the", 
				"other each year. Terns", 
				"dive from the air to", 
				"catch fish.", 
				"", 
				"The PLOVER is (a) bird", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"that distracts predators", 
				"by pretending to have a", 
				"broken wing.", 
				"", 
				"The LAPWING is a kind of", 
				"Plover that has a long", 
				"black crest.", 
				"", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"The HAWK is a predator", 
				"that feeds o(n) small", 
				"birds, mice, squirrels,", 
				"and other small animals.", 
				"Small hawks are known as", 
				"Kites.", 
				"", 
				"The DOVE is a seed-eating", 
			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"bird with a peaceful", 
				"reputation. Doves have a", 
				"low-pitched cooing song.", 
				"", 
				"The PARROT is (a)", 
				"brightly colored bird", 
				"with a hooked bill,", 
				"favored as a companion by", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"pirates(.) Parrots can be", 
				"taught to imitate the", 
				"human voice.", 
				"", 
				"The CUCKOO is a devious", 
				"bird that lays eggs in", 
				"the nests of Warblers and", 
				"other small birds.", 

			}; 
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"Cuckoos have the uncanny", 
				"ability to keep track of", 
				"time, singing once at the", 
				"beginning of each hour.", 
				"", 
				"The ROADRUNNER is an", 
				"unusual bird with a long", 
				"tail, which runs swiftly", 

			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"along the ground hunting", 
				"for lizards and snakes.", 
				"", 
				"The SWIFT is a very agile", 
				"bird that spends nearly", 
				"its entire life in the", 
				"air. With their mouths", 
				"wide open, Swifts capture", 

			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"insects in mid-flight.", 
				"", 
				"The HUMMINGBIRD is a ", 
				"cross between a Swift and", 
				"a Fairy. These tiny,", 
				"brightly colored birds", 
				"hover magically near", 
				"flowers, and live on the", 

			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"nectar they provide.", 
				"", 
				"The OWL is a reputedly", 
				"wise bird that is active", 
				"at night, unlike most", 
				"birds. Owls have excellent", 
				"night vision and", 
				"low-pitched hooting", 

			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"calls. Their wings are", 
				"silent in flight.", 
				"", 
				"The GOATSUCKER is a", 
				"strange owl-like bird", 
				"that is thought to live", 
				"on the milk of goats.", 
				"These mysterious birds", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"make jarring sounds at", 
				"night, for which reason", 
				"they are also called", 
				"Nightjars.", 
				"", 
				"The DUCK is a bird that", 
				"swims more than it flies,", 
				"and has a nasal voice", 
			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"that is described best as", 
				"a quack.", 
				"", 
				"The SWAN is a kind of", 
				"long-necked Duck that is", 
				"all white. Swans are", 
				"usually voiceless, but", 
				"they are said to have an", 

			};
			Pages[cnt++].Lines = lines;
		//		0----+----1----+----2----+
			lines = new string[] 
			{ 
				"extraordinarily beautiful", 
				"song.", 
				"", 
				"", 
				"", 
				"", 
				"", 
				"", 

			};
			Pages[cnt++].Lines = lines;
		}

		public BirdsBritanniaBook( Serial serial ) : base( serial )
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
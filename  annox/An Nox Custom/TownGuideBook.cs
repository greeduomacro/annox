//04OCT2006 Bags of Assorted Town Guide Books
using System;
using Server;

namespace Server.Items
{
    #region Bag of Town Guide Books
    public class BagOfTownGuideBooks : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfTownGuideBooks()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Town Guide Books";  //change the name
            Hue = hue;      

            DropItem(new TownGuideBookBritain());
            DropItem(new TownGuideBookTrinsic());
            DropItem(new TownGuideBookJhelom());
            DropItem(new TownGuideBookSkaraBrae());
            DropItem(new TownGuideBookMagincia());
            DropItem(new TownGuideBookYew());
            DropItem(new TownGuideBookVesper());
            DropItem(new TownGuideBookCove());
        }

        public BagOfTownGuideBooks(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    #endregion

    #region Town Guide Book - Britain
    public class TownGuideBookBritain : BrownBook
    {
        int hue = 0;

        [Constructable]
        public TownGuideBookBritain()
            : base("Town Guide - Britain", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Hue = hue;      

            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
               {
              "Britain is a thriving,",
              "picturesque city just a",
              "short distance from Lord",
              "British's castle on",
              "Britanny Bay. The towne is",
              "an important center of",
              "commerce for all of",
              "Britannia and has a number",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
	     	{ 

              "of interesting places to",
              "visit, such as the Bard's",
              "Library, Iolo the Bard's",
              "arbalest shoppe, a highly",
              "recommended pub or the",
              "Blue Boar Inn. Those who",
              "dwell here are welcoming",
              "and compassionate, so ",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "travelers often find ",
              "Britain one of the most",
              "hospitable places in the",
              "realm to visit.",
              "",
              "",
              "",
              "",
			};
            Pages[cnt++].Lines = lines;
        }

        public TownGuideBookBritain(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion

    #region Town Guide Book - Trinsic
    public class TownGuideBookTrinsic : BrownBook
    {
        [Constructable]
        public TownGuideBookTrinsic()
            : base("Town Guide - Trinsic", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
			{ 

              "The Western Road begins",
              "amongst the cities and",
              "villages of Brittany Bay",
              "and comes to its end far",
              "to the south on the Great",
              "Sea's coast. It is here",
              "that the magnificient",
              "walled city of Trinsic",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "proudly stands facing the",
              "sea, a glorious challenge",
              "to those who would bring",
              "dishonour to the Kingdom.",
              "A visitor will likely find",
              "a city where enduring",
              "friendships are readily",
              "made, and where lagging",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "faith in the ultimate",
              "triumph of honour and",
              "truth will be bountifully",
              "restored.",
              "",
              "",
              "",
              "",
			};
            Pages[cnt++].Lines = lines;
        }

        public TownGuideBookTrinsic(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion

    #region Town Guide Book - Jhelom
    public class TownGuideBookJhelom : BrownBook
    {
        [Constructable]
        public TownGuideBookJhelom()
            : base("Town Guide - Britain", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
			{ 

              "In the mountainous",
              "Valorian Isles, far to",
              "the southwest of the",
              "Britannian mainland, can",
              "be found the bulwarked",
              "towers of Jhelom. Home to",
              "the elite of Britannian",
              "knighthood, this city's",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "gates are open to all who",
              "valorously strive to",
              "defend the Realm. Though",
              "some of the citizens may",
              "appear rather brusque at",
              "times, time and patience",
              "spent befriending a knight",
              "of Jhelom will seldom be",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "nought.",
              "",
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

        public TownGuideBookJhelom(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion

    #region Town Guide Book - Skara Brae
    public class TownGuideBookSkaraBrae : BrownBook
    {
        [Constructable]
        public TownGuideBookSkaraBrae()
            : base("Town Guide - Skara Brae", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
            {
              "On a western isle just off",
              "the coast of Spiritwood",
              "lies the quiet retreat of",
              "Skara Brae. Long known as",
              "a home for the Rangers of",
              "Britannia, a private",
              "people who strive to",
              "better the lives of others",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "through a deep",
              "understanding of",
              "Spirituality, Skara Brae",
              "is a rustic shire of",
              "streams and forests with a",
              "few shoppes and dwellings",
              "unobtrusively scattered",
              "about. Those sick or",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "wounded folk who seek aid",
              "at the Spirit Healers of",
              "Skara Brae may find refuge",
              "from their pain there,",
              "irrespective of their",
              "personal wealth.",
              "",
              "",

			};
            Pages[cnt++].Lines = lines;
        }

        public TownGuideBookSkaraBrae(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion

    #region Town Guide Book - Magincia
    public class TownGuideBookMagincia : BrownBook
    {
        [Constructable]
        public TownGuideBookMagincia()
            : base("Town Guide - Magincia", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
{ 

              "The tales of the",
              "insufferable pride of",
              "Old Magincia's citizens,",
              "and the ineffable",
              "destruction cast down upon",
              "them for their pride's",
              "sake, must never be",
              "allowed to slip from our",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "minds. Ages have passed",
              "since daemons laid waste",
              "to the fair city leaving",
              "nought but smoking rubble",
              "and unliving souls in",
              "their wake, but only in",
              "recent years has the",
              "remote island colony been",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "repopulated. Now, New",
              "Magincia has sprung up",
              "from the ancient and",
              "desolate ruins, built by",
              "a simple, unassuming",
              "people who know and",
              "treasure the innate value",
              "of all living things.",

			};
            Pages[cnt++].Lines = lines;
        }

        public TownGuideBookMagincia(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion

    #region Town Guide Book - Yew
    public class TownGuideBookYew : BrownBook
    {
        [Constructable]
        public TownGuideBookYew()
            : base("Town Guide - Yew", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
			{ 

              "Though once the large,",
              "prosperous city of",
              "Justice, Yew has been",
              "swallowed by the Deep",
              "Forest. However, let not",
              "it be said that this turn,",
              "of events was not by the",
              "will of the people. As the",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "cities grew throughout the",
              "land, many found it",
              "difficult to continue",
              "peaceful existances as",
              "simple farmers and herders.",
              "More and more it became",
              "necessary to learn trades",
              "involving the exchange of",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "goods and services, and",
              "there was considerably",
              "less instances of self-",
              "sufficiency. While most",
              "Britannians found this",
              "pleasing, there were those",
              "who wanted a return to the",
              "less mechanical side of",

			};
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
			{ 

              "life. And those same",
              "people, many of whom came",
              "from Yew, began to",
              "populate the Deep Forest.",
              "",
              "",
              "",
              "",

			};
            Pages[cnt++].Lines = lines;
        }

        public TownGuideBookYew(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion

    #region Town Guide Book - Vesper
    public class TownGuideBookVesper : BrownBook
    {
        [Constructable]
        public TownGuideBookVesper()
            : base("Town Guide - Vesper", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
               {
               "One of the most peculiar",
               "and perhaps dangerous",
               "places to live in is",
               "Vesper, a small village in",
               "the Great Drylands. Once",
               "the entire village and its",
               "residents disappeared",
               "completely, leaving no",
            };
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
            { 
               "trace of its existance.",
               "Vesper remained missing",
               "for a long time, and then",
               "suddenly reappeared. An",
               "astral copy of the entire",
               "village had existed in the",
               "Ethereal Void meanwhile.",
               "This phenomenon has but",
            };
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
            { 
              "happened once in the",
              "history of Britannia, but",
              "the remarkability of it",
              "has rendered it one of",
              "Britannia's biggest",
              "mysteries. Vesper is also",
              "known for the relatively",
              "high number of gargoyles",
            };
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
            { 
              "residing there, and the",
              "hostile feelings towards",
              "them that linger with the",
              "human population.",
              "",
              "",
              "",
              "",
            };
            Pages[cnt++].Lines = lines;
        }

        public TownGuideBookVesper(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion

    #region Town Guide Book - Cove
    public class TownGuideBookCove : BrownBook
    {
        [Constructable]
        public TownGuideBookCove()
            : base("Town Guide - Cove", "Lord Shalineth", 15, false) // true writable so players can make notes
        {
            // NOTE: There are 8 lines per page and 
            // approx 22 to 24 characters per line! 
            //0----+----1----+----2----+ 
            int cnt = 0;
            string[] lines;
            lines = new string[] 
               {
                    "Lock Lake is an inland sea",
                    "surrounded by mountains",
                    "and other natural barriers",
                    "that assure the solitude",
                    "of any who dwell upon its",
                    "shores. Among the southern",
                    "mountains of those lost",
                    "shores lies the woundrous",

            };
            Pages[cnt++].Lines = lines;
            //		0----+----1----+----2----+
            lines = new string[] 
            { 

                    "village of Cove, home of a",
                    "legendary healer and the",
                    "only mainland apothecary",
                    "shoppe that offers the",
                    "essential herbs Nightshade",
                    "and Mandrake Root.",
                    "",
                    "",
            };
            Pages[cnt++].Lines = lines;
        }

        public TownGuideBookCove(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
    #endregion
}
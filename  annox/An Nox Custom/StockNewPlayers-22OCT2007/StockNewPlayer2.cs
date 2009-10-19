//16NOV2007 StockNewPlayer2 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using System.Collections;
using Server;
using Server.Accounting;
using Server.Custom;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;

namespace Server.Items
{
    public class StockNewPlayer : Item
    {
        //Setup startup systems
        public static string ShardName = "An Nox";              //enter your shard name
        public static bool change_StartingLocation = true;      //change starting location
        public static bool change_StartingMusic = true;         //change starting music
        public static bool change_AllPlayers = true;            //Sets OLD and NEW players to your stat & skills settings. (If changed to false it disables all Stat & Skills features.)
        public static bool change_StatCap = true;               //http://www.runuo.com/forums/script-support/78540-frequent-script-edit-requests.html
        public static bool change_SkillsCap = true;             //http://www.runuo.com/forums/script-support/78540-frequent-script-edit-requests.html
        public static bool change_PowerScrolls = false;          //http://www.runuo.com/forums/script-support/83276-skill-100-maximum.html
        public static bool change_PlayerStartingStat = false;    //Set players stat at 100.00  (see below)
        public static bool change_PlayerStartingSkills = false;  //Set players skills at 100.0 (see below)

        //Starting Location
        public static CityInfo city = new CityInfo("Minoc", "Sweet Dreams Inn", 2493, 377, 0, Map.Felucca);

        //Starting Music **BROKEN**
        public static MusicName m_Music = MusicName.Serpents;

        //Configure Stat & Skills settings
        public static int set_StatCap = 300;                    //RunUO default 225
        public static int set_SkillsCap = 9000;                 //RunUO default 7200
        public static int set_PowerScrolls = 120;               //RunUO default is 100 or maybe 120
        public static int set_PlayerStatTo = 100;              //Set Str, Dex, Int to 100
        public static int set_PlayerSkillsTo = 100;            //Set all skills to 100

        //Increase this number each time you need to update values.
        public static string set_AllPlayersLastChangeVersion = "2";

        //Custom Startup Scripts
        public static bool enable_EmailCollector = true;        //http://www.runuo.com/forums/runuo-post-archive/41474-email-collector-2-0-a.html


        //****************Main****************\\
        public static void Initialize()
        {
            EventSink.CharacterCreated += new CharacterCreatedEventHandler(EventSink_CharacterCreated);
            EventSink.Login += new LoginEventHandler(EventSink_Login);
        }

        private static void EventSink_CharacterCreated(CharacterCreatedEventArgs args)
        {
            Mobile from = args.Mobile;

            from.SendMessage("Welcome to " + ShardName + ", " + from.Name + ".");

            //Set custom starting point 
            if (change_StartingLocation)
            {
                //CityInfo city = new CityInfo("Minoc", "Sweet Dreams Inn", 2493, 377, 0, Map.Felucca);
                from.MoveToWorld(city.Location, city.Map);
            }

            //This calls the items from the list below (see near line #143)
            GetListOfItems(from);

            //Add your custom extrnal startup code here
            if (enable_EmailCollector)
            {
                //Email Collector *** START ***
                new StartTimer(from).Start();  //http://www.runuo.com/forums/runuo-post-archive/41474-email-collector-2-0-a.html
                //Email Collector *** END   ***
            }
        }

        public static void GetListOfItems(Mobile from)
        {
            //List of Item Locations Message
            //***Put item into Backpack
            #region Backpack
            from.SendMessage("You will find new items in your Backpack.");
            from.Backpack.AddItem(new KillBook());                          //http://www.runuo.com/forums/custom-script-releases/80034-book-kills.html
            from.Backpack.AddItem(new AnNoxGuideBook());
            #endregion

            //***Drop item on the Ground
            #region Ground
            //put item under player on the ground
            from.SendMessage("You will find new items on the ground near by.");
            new SewingKit().MoveToWorld(from.Location, from.Map);
            new Bible().MoveToWorld(from.Location, from.Map);               //http://www.runuo.com/forums/custom-script-releases/71826-runuo-2-0-rc1-lokais-xml-bible-system.html
            new BeltranGuideBook().MoveToWorld(from.Location, from.Map);    //http://www.runuo.com/forums/runuo-post-archive/34074-osi-library-books.html
            new PrimerArmsBook().MoveToWorld(from.Location, from.Map);      //http://www.runuo.com/forums/runuo-post-archive/34074-osi-library-books.html

            //put item near player on the ground
            new BagOfDresses().MoveToWorld(new Point3D(from.X + Utility.RandomMinMax(-5, 5), from.Y + Utility.RandomMinMax(-5, 5), from.Z), from.Map);
            new BagOfJewlery().MoveToWorld(new Point3D(from.X + Utility.RandomMinMax(-5, 5), from.Y + Utility.RandomMinMax(-5, 5), from.Z), from.Map);
            new BagOfShirts().MoveToWorld(new Point3D(from.X + Utility.RandomMinMax(-5, 5), from.Y + Utility.RandomMinMax(-5, 5), from.Z), from.Map);
            new BagOfPants().MoveToWorld(new Point3D(from.X + Utility.RandomMinMax(-5, 5), from.Y + Utility.RandomMinMax(-5, 5), from.Z), from.Map);
            new BagOfShoes().MoveToWorld(new Point3D(from.X + Utility.RandomMinMax(-5, 5), from.Y + Utility.RandomMinMax(-5, 5), from.Z), from.Map);
            new BagOfCloaks().MoveToWorld(new Point3D(from.X + Utility.RandomMinMax(-5, 5), from.Y + Utility.RandomMinMax(-5, 5), from.Z), from.Map);
            new BagOfHats().MoveToWorld(new Point3D(from.X + Utility.RandomMinMax(-5, 5), from.Y + Utility.RandomMinMax(-5, 5), from.Z), from.Map);
            #endregion

            //***Put item into Bank
            #region Bank
            from.SendMessage("You will find new items in your Bank.");
            BankBox bank = from.BankBox;
            Container cont;

            // Begin box of money
            cont = new WoodenBox();
            cont.Name = "Money Box";
            cont.ItemID = 0xE7D;
            cont.Hue = 0x489;

            PlaceItemIn(cont, 64, 51, new BankCheck(5000));
            PlaceItemIn(cont, 16, 115, new Factions.Silver(1000));
            PlaceItemIn(cont, 34, 115, new Gold(1000));

            PlaceItemIn(bank, 18, 169, cont);

            // Begin bag of archery ammo
            cont = new Bag();
            cont.Name = "Bag Of Archery Ammo";

            PlaceItemIn(cont, 48, 76, new Arrow(50));
            PlaceItemIn(cont, 72, 76, new Bolt(50));

            PlaceItemIn(bank, 118, 124, cont);

            // Begin bag of raw materials
            cont = new Bag();
            cont.Hue = 0x835;
            cont.Name = "Raw Materials Bag";

            PlaceItemIn(cont, 92, 84, new Leather(50));
            PlaceItemIn(cont, 30, 118, new Cloth(50));
            PlaceItemIn(cont, 30, 84, new Board(50));
            PlaceItemIn(cont, 57, 80, new BlankScroll(50));

            PlaceItemIn(bank, 98, 169, cont);

            // Begin bag of spell casting stuff
            cont = new Backpack();
            cont.Hue = 0x480;
            cont.Name = "Spell Casting Stuff";

            PlaceItemIn(cont, 45, 105, new Spellbook(UInt64.MaxValue));
            PlaceItemIn(cont, 65, 105, new NecromancerSpellbook((UInt64)0xFFFF));
            PlaceItemIn(cont, 85, 105, new BookOfChivalry((UInt64)0x3FF));
            PlaceItemIn(cont, 105, 105, new BookOfBushido());	//Default ctor = full
            PlaceItemIn(cont, 125, 105, new BookOfNinjitsu()); //Default ctor = full

            Runebook runebook = new Runebook(10);
            runebook.CurCharges = runebook.MaxCharges;
            PlaceItemIn(cont, 145, 105, runebook);

            Item toHue = new BagOfReagents(50);
            toHue.Hue = 0x2D;
            toHue.Name = "Bag of Basic Reagents";
            PlaceItemIn(cont, 45, 150, toHue);

            toHue = new BagOfNecroReagents(50);
            toHue.Hue = 0x488;
            toHue.Name = "Bag of Necro Reagents";
            PlaceItemIn(cont, 65, 150, toHue);

            toHue = new BagOfAllReagents(50);
            toHue.Hue = 0x2D;
            toHue.Name = "Bag of All Reagents";
            PlaceItemIn(cont, 140, 150, toHue);

            for (int i = 0; i < 9; ++i)
                PlaceItemIn(cont, 45 + (i * 10), 75, new RecallRune());

            PlaceItemIn(cont, 141, 74, new FireHorn());

            PlaceItemIn(bank, 78, 169, cont);
            #endregion
        }

        private static void PlaceItemIn(Container parent, int x, int y, Item item)
        {
            parent.AddItem(item);
            item.Location = new Point3D(x, y, 0);
        }

        private static void EventSink_Login(LoginEventArgs args)
        {
            Mobile from = args.Mobile;

            TimeSpan gameTime = TimeSpan.Zero;
            gameTime = ((PlayerMobile)from).GameTime;


            Console.WriteLine("Starting LoginEvenArgs");

            //Convert players to new settings when they log in.
            #region Convert players to new settings when they log in.
            Console.WriteLine("change_AllPlayers = " + change_AllPlayers);
            Console.WriteLine("set_AllPlayersLastChangeVersion = " + set_AllPlayersLastChangeVersion);
            Console.WriteLine("MobileGameTime = " + gameTime);
            Console.WriteLine("TimeSpan = " + TimeSpan.FromSeconds(15));

            if (change_AllPlayers || gameTime < TimeSpan.FromSeconds(15)) //TimeSpan = "00:00:00"
            {
                //Change starting music
                if (change_StartingMusic)
                {
                    from.Send(Network.PlayMusic.GetInstance(StockNewPlayer.m_Music));
                }

                string gump_message;
                gump_message = "<p>";

                //This sets the new Stat Cap                
                if (change_StatCap && (from.StatCap != set_StatCap))
                {
                    gump_message = gump_message + ("<p>Current Stat Cap is: " + from.StatCap);
                    from.StatCap = set_StatCap;
                    gump_message = gump_message + ("<p>New Stat Cap is:     " + from.StatCap);
                }

                //This sets the new Skills Cap                
                if (change_SkillsCap && (from.SkillsCap != set_SkillsCap))
                {
                    gump_message = gump_message + ("<p>Current Skills Cap is: " + from.SkillsCap);
                    from.SkillsCap = set_SkillsCap;
                    gump_message = gump_message + ("<p>New Skills Cap is:     " + from.SkillsCap);
                }

                //This turns on power scrolls, or turns up indivudal skills
                if (change_PowerScrolls)
                {
                    gump_message = gump_message + ("<p>Updateing Power Scrolls");
                    for (int i = 0; i < PowerScroll.Skills.Length; ++i)
                    {
                        from.Skills[PowerScroll.Skills[i]].Cap = set_PowerScrolls;
                        //from.Skills[PowerScroll.Skills[i]].ObeyCap = true;
                    }
                }

                if (change_PlayerStartingStat) // && (from.Str < set_PlayerStatTo) || (from.Int < set_PlayerStatTo) || (from.Dex < set_PlayerStatTo))
                {
                    gump_message = gump_message + ("<p>Current Stats are...<p>Str: " + from.Str + " Int: " + from.Int + " Dex: " + from.Dex);
                    if (from.Str < set_PlayerStatTo)
                        from.Str = set_PlayerStatTo;

                    if (from.Int < set_PlayerStatTo)
                        from.Int = set_PlayerStatTo;

                    if (from.Dex < set_PlayerStatTo)
                        from.Dex = set_PlayerStatTo;

                    //from.SendMessage("New Stats are: Str-" + from.Str + " Int-" + from.Int + " Dex-" + from.Dex);
                    gump_message = gump_message + ("<p>New Stats are...<p>Str: " + from.Str + " Int: " + from.Int + " Dex: " + from.Dex);
                }

                if (change_PlayerStartingSkills)
                {
                    gump_message = gump_message + ("<p>Increase all skils to " + set_PlayerSkillsTo);
                    Server.Skills skills = from.Skills;

                    for (int i = 0; i < skills.Length; ++i)
                        skills[i].Base = set_PlayerSkillsTo;
                }

                gump_message = gump_message + ("</p>");

                if (gump_message != "<p></p>")
                {
                    from.SendGump(new StockNewPlayerGump(gump_message));
                    Console.WriteLine(gump_message);
                }
            }
            #endregion
        }

        public StockNewPlayer(Serial serial)
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
}

#region Gump
///////////////////////////////////////////
// C# Exporter Generated: 11/5/2007 7:12:56 PM
//
// Designed by Ravenal of OrBSydia
// Version: 2.0
//
// Script: StockNewPlayerGump
///////////////////////////////////////////

namespace Server.Gumps
{
    public class StockNewPlayerGump : Gump
    {
        public StockNewPlayerGump(string Name)
            : base(500, 350)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;

            AddPage(0);
            AddBackground(8, 7, 364, 245, 9300);
            AddImage(282, 56, 9000);
            AddButton(280, 220, 12006, 12008, 0, GumpButtonType.Reply, 0);
            AddHtml(26, 52, 236, 189, @"" + Name, (bool)false, (bool)false);
            AddLabel(32, 22, 61, @"Stock New Player v2.0");
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int button = info.ButtonID;
            Mobile m = sender.Mobile;

            switch (button)
            {
                case 0:
                    {
                        m.CloseGump(typeof(StockNewPlayerGump));
                        break;
                    }
            }
        }
    }
}

#endregion

/*
                    Account acct = (Account)from.Account;
                    string agreed = "";
                    agreed = acct.GetTag("FreeSword");

                    if (agreed != now.Hour.ToString())
                    {
                        from.SendMessage("You get a super sword.");
                        acct.SetTag("FreeSword", now.Hour.ToString());
                    }
*/
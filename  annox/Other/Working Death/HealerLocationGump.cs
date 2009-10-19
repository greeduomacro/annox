// Author: CEO
// Released: 12/08/07
//Converted to Healer Location Gump by RavonTUS 04AUG2008

using System;
using System.Collections;
using Server.Commands;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Gumps
{
    public class HealerLocationGump : Gump
    {
        private Mobile m_Mobile;
        private Map m_Map;
        private int m_Index;

        private int m_LocalizedStart = 1075072;
        private int[,] m_CityInfo = new int[9, 3] { { 1011032, 80, 130 },   // Yew
                                                    { 1011031, 224, 79 },   // Minoc   
                                                    { 1011028, 149, 188},   // Britian
                                                    { 1011344, 372, 145},   // Moonglow
                                                    { 1011029, 177, 293},   // Trinsic
                                                    { 1011345, 312, 234},   // Magincia
                                                    { 1011343, 137, 380},   // Jhelom
                                                    { 1011347, 75, 233},    // Skara Brae
                                                    { 1011030, 249, 124}};  // Vesper

        private Point3D[] m_CityLocations = new Point3D[] { 
                                                    new Point3D( 545, 969, 0),      // Yew (City Center)
                                                    new Point3D( 2577, 604, 0),     // Minoc (The Barnacle)   
                                                    new Point3D( 1481, 1612, 20),   // Britian (Sweet Dreams Inn)
                                                    new Point3D( 4397, 1089, 0),    // Moonglow (The Scholar's Inn)
                                                    new Point3D( 1915, 2814, 0),    // Trinsic (The Traveler's Inn)
                                                    new Point3D( 3686, 2232, 20),   // Magincia
                                                    new Point3D( 1410, 3793, 0),    // Jhelom (The Morning Star Inn)
                                                    new Point3D( 612, 2225, 0),     // Skara Brae (The Falconer's Inn)
                                                    new Point3D( 2929, 853, 0)};    // Vesper

        public HealerLocationGump(Mobile mobile, Map map, int index)
            : base(100, 100)
        {
            Closable = false;
            Dragable = false;

            m_Mobile = mobile;
            m_Map = map;
            m_Index = index;

            AddPage(0);

            AddBackground(0, 0, 615, 480, 0x2436);

            //04AUG2008 Clean up map picture *** START ***
            AddImage(35, 35, 0x248A);
            AddImage(35, 35, 0x2487);
            AddImage(35, 35, 0x2489);
            AddImage(25, 35, 0x006F);
            //if (m_Map == Map.Trammel)
            //{
            //    AddImage(0, 400, 0xC72E);
            //}
            //else
            //{
            //    AddImage(0, 400, 0xC72F);
            //}


            //AddImage(0, 0, 0x157C);
            AddImage(35, 35, 0x1598); //map
            AddButton(295, 430, 0x992, 0x993, 1, GumpButtonType.Reply, 0);
            AddButton(355, 430, 0x995, 0x997, 0, GumpButtonType.Reply, 0);
            //04AUG2008 Clean up map picture *** END  ***


            for (int i = 0; i < 9; i++)
            {
                AddHtmlLocalized(m_CityInfo[i, 1] - 3, m_CityInfo[i, 2] - 17, 100, 20, m_CityInfo[i, 0], i == m_Index ? 0xffffff : 0xFFFF69, false, false);
                AddButton(m_CityInfo[i, 1], m_CityInfo[i, 2], 0x845, 0x846, 100 + i, GumpButtonType.Reply, 0);
            }
            AddHtmlLocalized(420, 50, 175, 410, m_Index > 9 ? 3000126 : 1075072 + m_Index, true, true);
            AddHtmlLocalized(80, 430, 250, 20, 1010591, 0xffffff, false, false);
        }


        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (info.ButtonID == 0) // close/cancel
                return;
            else if (info.ButtonID >= 100 && info.ButtonID <= 109)
                m_Mobile.SendGump(new HealerLocationGump(m_Mobile, m_Map, info.ButtonID - 100));
            else if (info.ButtonID == 1)
            {
                m_Mobile.MoveToWorld(m_CityLocations[m_Index], m_Map);
                Effects.PlaySound(m_CityLocations[m_Index], m_Map, 0x1FE);
            }
        }

        public static void Initialize()
        {
            CommandSystem.Register("Healer", AccessLevel.Player, new CommandEventHandler(Start_OnCommand));
        }

        [Usage("Healer")]
        [Description("Healer Location Gump - Transports players to heal of choice.")]
        private static void Start_OnCommand(CommandEventArgs args)
        {
            Mobile m = args.Mobile;
            m.CloseGump(typeof(HealerLocationGump));
            if (m.Map == Map.Trammel)
            {
                m.SendGump(new HealerLocationGump(m, Map.Trammel, 2));
            }
            else
            {
                m.SendGump(new HealerLocationGump(m, Map.Felucca, 2));
            }
        }
    }
}
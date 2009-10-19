using System;
using Server;
using Server.Items;
using System.Net;
using System.Text;
using System.Collections;
using System.Diagnostics;
using Server.Prompts;
using Server.Network;
using Server.Accounting;
using Server.Scripts.Commands;
using Server.Gumps;
using Server.Misc;
using Server.Guilds;
using Server.Factions;
using Server.Mobiles;


namespace Server.PlayerScoreBoard
{

    public class RankSort : IComparable
    {
        public Mobile Killer;
        public int Wins;
        public int Loses;


        public RankSort(Mobile m)
        {
            Killer = m;
            if (m is PlayerMobile)
            {
                Wins = ((PlayerMobile)m).Wins;
                Loses = ((PlayerMobile)m).Loses;
            }

        }

        public int CompareTo(object obj)
        {
            RankSort p = (RankSort)obj;

            if (p.Wins - Wins == 0)
            {
                return Loses - p.Loses;
            }

            return p.Wins - Wins;
        }
    }

    public class PlayerScoreGump : Gump
    {
        public Mobile m_From;
        public ArrayList m_List;

        private const int LabelColor = 0x7FFF;
        private const int SelectedColor = 0x421F;
        private const int DisabledColor = 0x4210;

        private const int LabelColor32 = 0xFFFFFF;
        private const int SelectedColor32 = 0x8080FF;
        private const int DisabledColor32 = 0x808080;

        private const int LabelHue = 0x480;
        private const int GreenHue = 0x40;
        private const int RedHue = 0x20;

        public PlayerScoreGump(Mobile from, PlayerScoreGump pageType, ArrayList list, int listPage, string notice, object state)
            : base(50, 40)
        {
            from.CloseGump(typeof(PlayerScoreGump));

            m_List = list;
            m_From = from;

            ArrayList playerlist = new ArrayList();

            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m != null && m.Player)
                {
                    PlayerMobile pm = (PlayerMobile)(m);

                    if (pm != null && (pm.Wins != 0 && pm.Loses != 0))
                    {
                        playerlist.Add(new RankSort(pm));
                    }
                }
            }

            for (int i = 0; i < playerlist.Count; i++)
            {
                if (i > 9)
                    break;

                RankSort p = playerlist[i] as RankSort;

            }



            AddPage(0);

            AddBackground(0, 0, 420, 540, 5054);

            AddBlackAlpha(10, 10, 400, 520);

            if (notice != null)
                AddHtml(12, 392, 396, 36, Color(notice, LabelColor32), false, false);


            AddLabel(160, 15, RedHue, "Top 20 Duelers");
            AddLabel(20, 40, LabelHue, "Players");
            AddLabel(185, 40, LabelHue, "Wins");
            AddLabel(345, 40, LabelHue, "Loses");

            playerlist.Sort();

            for (int i = 0; i < playerlist.Count; ++i)
            {
                if (i >= 20)
                {

                    break;

                }

                RankSort g = (RankSort)playerlist[i];

                string name = null;

                if ((name = g.Killer.Name) != null && (name = name.Trim()).Length <= 15)
                    name = g.Killer.Name;

                string wins = null;

                if (g.Killer is PlayerMobile)
                    wins = ((PlayerMobile)g.Killer).Wins.ToString();

                string loses = null;

                if (g.Killer is PlayerMobile)
                    loses = ((PlayerMobile)g.Killer).Loses.ToString();

                AddLabel(20, 70 + ((i % 20) * 20), GreenHue, name);
                AddLabel(198, 70 + ((i % 20) * 20), GreenHue, wins);
                AddLabel(358, 70 + ((i % 20) * 20), GreenHue, loses);
            }
        }

        public string Color(string text, int color)
        {
            return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
        }

        public void AddBlackAlpha(int x, int y, int width, int height)
        {
            AddImageTiled(x, y, width, height, 2624);
            AddAlphaRegion(x, y, width, height);
        }
    }
}
//23MAY2007 Added Total Game to the web features.
//22NOV2007 Switch from Account TotalGameTime to Player Mobile GameTime.
//28FEB2008 Added sessionTime and TotalSessionTime
//28FEB2008 Added He/She instead of They

using System;
using System.Text;
using System.Collections;

using Server;
using Server.Gumps;
using Server.Mobiles;

using Server.Commands;

//28MAR2007 Adding Web Based List *** START ***
using System.IO;
using Server.Network;
using Server.Accounting;
//28MAR2007 Adding Web Based List *** END   ***

namespace Server.Custom.Misc
{
    public class JustMissed
    {
        public JustMissed() { }

        private static bool m_Enabled = true;
        private static Hashtable m_LogoutTable;

        [CommandProperty(AccessLevel.GameMaster)]
        public static bool Enabled { get { return m_Enabled; } set { m_Enabled = value; } }

        public static JustMissed Instance { get { return new JustMissed(); } }

        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(EventSink_Login);
            EventSink.Logout += new LogoutEventHandler(EventSink_Logout);
            CommandSystem.Register("JMSettings", AccessLevel.GameMaster, new CommandEventHandler(JMSettings_OnCommand));

            m_LogoutTable = new Hashtable();
        }

        private static void JMSettings_OnCommand(CommandEventArgs e)
        {
            Mobile m = e.Mobile;

            if (m == null)

                return;

            m.SendGump(new PropertiesGump(m, Instance));
        }

        //28MAR2007 Adding Web Based List *** START ***
        private static string Encode(string input)
        {
            StringBuilder sb = new StringBuilder(input);

            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("\"", "&quot;");
            sb.Replace("'", "&apos;");

            return sb.ToString();
        }
        //28MAR2007 Adding Web Based List *** END   ***

        private static void EventSink_Logout(LogoutEventArgs e)
        {
            if (!Enabled)
            {
                Console.WriteLine("Just Missed with Web Report - Disabled");
                return;
            }

            Mobile m = e.Mobile;

            if (m == null)
            {
                Console.WriteLine("Just Missed with Web Report - Null");
                return;
            }

            //28FEB2008 Added He/She instead of They
            string HeShe = "";
            if (m.Female)
                HeShe = "She";
            else
                HeShe = "He";


            //23MAY2007 *** START ***
            //22NOV2007 Switch from Account TotalGameTime to Player Mobile GameTime.
            Account acct = m.Account as Account;
            //TimeSpan time = acct.TotalGameTime; //TotalGameTime from Account file.

            //28FEB2008 Added sessionTime and TotalSessionTime
            TimeSpan sessionTime = TimeSpan.Zero;
            sessionTime = DateTime.Now - ((PlayerMobile)m).SessionStart;
            TimeSpan gameTime = TimeSpan.Zero;
            gameTime = ((PlayerMobile)m).GameTime;


            //String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}", ts.Days, ts.Hours % 24, ts.Minutes % 60, ts.Seconds % 60);
            //string TotalGameTime = String.Format("{0} days, {1} hours, {2} minutes, and {3} seconds", time.Days, time.Hours, time.Minutes, time.Seconds);
            //string TotalGameTime = String.Format("{0} days, {1} hours and {2} minutes", time.Days, time.Hours, time.Minutes);
            string TotalSessionTime = String.Format("{0} hours and {1} minutes", sessionTime.Hours, sessionTime.Minutes);
            string TotalGameTime = String.Format("{0} days, {1} hours and {2} minutes", gameTime.Days, gameTime.Hours, gameTime.Minutes);
            
            
            //Console.WriteLine("JustMissed: " + acct.Username + " Total Game Time: " + TotalGameTime + "Session Time: " + TotalSessionTime);
            Console.WriteLine("JustMissed: " + acct.Username + " Session Time:    " + TotalSessionTime);
            Console.WriteLine("            " + acct.Username + " Total Game Time: " + TotalGameTime);
            //23MAY2007 *** END   ***

            //28MAR2007 Adding Web Based List *** START ***

            /*******************************************************/
            /*            path to where your website is stored     */
            string path = "C:/Inetpub/wwwroot/status/web/yjm";
            /*******************************************************/

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(path + "/youjustmissed.html"))
            {
                using (StreamWriter op = new StreamWriter(path + "/youjustmissed.html"))
                {
                    op.WriteLine("<html>");
                    op.WriteLine("   <head>");
                    op.WriteLine("      <title>You Just Missed - updated by Ravon of An Nox</title>");
                    op.WriteLine("   </head>");
                    op.WriteLine("   <body bgcolor=\"black\">");
                    op.WriteLine("      <a href='http://annox.no-ip.com'><img src='http://bp1.blogger.com/_CGKuPVAFxb0/Rg0886xjEbI/AAAAAAAAAF0/Ir4dztLGzDk/s200/wandering+alone.JPG' alt='http://annox.no-ip.com' /></a>");
                    op.WriteLine("      <h1><font color=\"red\">You Just Missed:</font></h1>");
                    op.WriteLine("      <font color=\"yellow\">{0}</font><font color=\"white\"> just left </font><font color=\"cyan\">{1}</font>", Encode(m.Name), m.Region.Name);
                    op.WriteLine("      <font color=\"white\">(</font><font color=\"khaki\">{0}, {1}, {2}</font><font color=\"white\">) </font>", m.X, m.Y, m.Z);
                    op.WriteLine("      <font color=\"white\">on {0:dddd} {1:t} after playing for </font><font color=\"red\">{2}</font>.  ", DateTime.Now, DateTime.Now, TotalSessionTime);
                    op.WriteLine("      <font color=\"white\">{0} is {1} old.</font><br>", HeShe, TotalGameTime);
                    op.WriteLine("   </body>");
                    op.WriteLine("</html>");
                }
            }
            else
            {
                using (StreamWriter op = File.AppendText(path + "/youjustmissed.html"))
                {
                    op.WriteLine("<html>");
                    op.WriteLine("   <body bgcolor=\"black\">");
                    op.WriteLine("      <font color=\"yellow\">{0}</font><font color=\"white\"> just left </font><font color=\"cyan\">{1}</font>", Encode(m.Name), m.Region.Name);
                    op.WriteLine("      <font color=\"white\">(</font><font color=\"khaki\">{0}, {1}, {2}</font><font color=\"white\">) </font>", m.X, m.Y, m.Z);
                    op.WriteLine("      <font color=\"white\">on {0:dddd} {1:t} after playing for </font><font color=\"red\">{2}.  </font>", DateTime.Now, DateTime.Now, TotalSessionTime);
                    op.WriteLine("      <font color=\"white\">{0} is {1} old.</font><br>", HeShe, TotalGameTime);
                    op.WriteLine("   </body>");
                    op.WriteLine("</html>");
                }
            }
            //28MAR2007 Adding Web Based List *** END   ***

            if (m_LogoutTable.ContainsKey(m.Serial))
                m_LogoutTable.Remove(m.Serial);

            m_LogoutTable.Add(m.Serial, new JMLogTimer(m));

        }

        private static void EventSink_Login(LoginEventArgs e)
        {
            if (!Enabled)
            {
                Console.WriteLine("Just Missed With Web Report - Disabled");
                return;
            }

            Mobile m = e.Mobile;

            if (m == null)
            {
                Console.WriteLine("Just Missed With Web Report - Null");
                return;
            }

            //28FEB2008 Added He/She instead of They
            string HeShe = "";
            if (m.Female)
                HeShe = "She";
            else
                HeShe = "He";

            if (m_LogoutTable.ContainsKey(m.Serial))
                m_LogoutTable.Remove(m.Serial);

            foreach (JMLogTimer t in m_LogoutTable.Values)
            {
                if (t.Mobile == null)
                    continue;

                int minutes = t.Ticks / 60;
                m.SendMessage("You just missed {0}, {1} logged out {2} minute{3} ago.",
                    t.Mobile.Name,
                    HeShe,
                    (minutes > 0) ? minutes.ToString() : "less than 1",
                    (minutes > 0) ? "s" : "");
            }
        }

        public static void RemoveTimer(JMLogTimer timer)
        {
            if (m_LogoutTable.ContainsKey(timer.Mobile.Serial))
                m_LogoutTable.Remove(timer.Mobile.Serial);
        }
    }

    public class JMLogTimer : Timer
    {
        private Mobile m_LoggedMobile;
        private int m_Ticks;

        public Mobile Mobile { get { return m_LoggedMobile; } }
        public int Ticks { get { return m_Ticks; } }

        public JMLogTimer(Mobile m)
            : base(TimeSpan.FromSeconds(0.0), TimeSpan.FromSeconds(1.0))
        {
            m_LoggedMobile = m;
            Start();
        }

        protected override void OnTick()
        {
            if (m_Ticks > 3600)
            {
                JustMissed.RemoveTimer(this);
                Stop();
            }

            m_Ticks++;
        }
    }
}

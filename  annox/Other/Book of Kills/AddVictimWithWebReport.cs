//Author plus
using System;
using Server;
using Server.Items;
using System.Collections;

//28MAR2007 Adding Web Based List *** START ***
using System.IO;
using System.Text;
using Server.Network;
//28MAR2007 Adding Web Based List *** END   ***

namespace Server.Mobiles
{
    public class KillBookSystem
    {
        public static void Initialize()
        {
            EventSink.PlayerDeath += new PlayerDeathEventHandler(EventSink_PlayerDeath);
        }

        public static void EventSink_PlayerDeath(PlayerDeathEventArgs e)
        {
            Killed(e.Mobile);
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
        //28MAR2007 Adding Web Based List *** END ***

        public static void Killed(Mobile m) //done
        {

            PlayerMobile owner = m as PlayerMobile;

            Mobile m_Killer = (Mobile)m.LastKiller;

            Mobile from = (Mobile)m.LastKiller;

            if (m_Killer != null && m_Killer.Player && owner != null && owner.Player)
            {
                KillBook book = m_Killer.Backpack.FindItemByType(typeof(KillBook), true) as KillBook;

                if (book != null)
                {
                    if ((owner != book.BookOwner) && (m_Killer == book.BookOwner))
                    {
                        book.AddEntry(owner.Name, 1);
                        book.TotKills++;

                        //28MAR2007 Adding Web Based List *** START ***
                        /*********************************************************/
                        /*             path to where your website is stored      */
                        string path = "C:/Inetpub/wwwroot/status/web/kills";
                        /*********************************************************/

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        //if (!File.Exists(path + "/index.html"))
                        //{
                        //    //29MAR2006 Checks for index.html file if not present it creates one
                        //    using (StreamWriter op = new StreamWriter(path + "/index.html"))
                        //    {
                        //        op.WriteLine("<html>");
                        //        op.WriteLine("   <head>");
                        //        op.WriteLine("      <title>Book of Kills - updated by Ravon of An Nox</title>");
                        //        op.WriteLine("   </head>");
                        //        op.WriteLine("   <body bgcolor=\"black\">");
                        //        op.WriteLine("      <a href='http://annox.no-ip.com'><img border='0' src='http://bp2.blogger.com/_CGKuPVAFxb0/Rgp566xjEaI/AAAAAAAAAFo/Dv4bJaNU_xs/s200/Cemetery.jpg' alt='http://annox.no-ip.com' /></a>");
                        //        op.WriteLine("      <h1><font color='red'>Book of Kills Index</h1>");
                        //        op.WriteLine("      <font color='yellow'><a href='http://annox.no-ip.com/status/web/kills/{0}.html'>{1}</a><font color='white'> began killing on {2}.<br>", Encode(m_Killer.Name), Encode(m_Killer.Name), DateTime.Now);
                        //        op.WriteLine("   </body>");
                        //        op.WriteLine("</html>");
                        //    }
                        //}
                        //else
                        //{
                        //    //29MAR2006 Checks for index.html file it is present and adds information
                        //    using (StreamWriter op = File.AppendText(path + "/index.html"))
                        //    {
                        //        op.WriteLine("<html>");
                        //        op.WriteLine("   <body bgcolor=\"black\">");
                        //        op.WriteLine("      <font color='yellow'><a href='http://annox.no-ip.com/status/web/kills/{0}.html'>{1}</a><font color='white'> began killing on {2}.<br>", Encode(m_Killer.Name), Encode(m_Killer.Name), DateTime.Now);
                        //        op.WriteLine("   </body>");
                        //        op.WriteLine("</html>");
                        //    }
                        //}

                        //if (!File.Exists(path + "/" + Encode(m_Killer.Name) + ".html"))
                        if (!File.Exists(path + "/index.html"))
                        {
                            //29MAR2006 Creates m_Killer.Name.html file
                            //using (StreamWriter op = new StreamWriter(path + "/" + Encode(m_Killer.Name) + ".html"))
                            using (StreamWriter op = new StreamWriter(path + "/index.html"))
                            {
                                op.WriteLine("<html>");
                                op.WriteLine("   <head>");
                                op.WriteLine("      <title>Book of Kills - updated by Ravon of An Nox</title>");
                                op.WriteLine("   </head>");
                                op.WriteLine("   <body bgcolor=\"black\">");
                                op.WriteLine("      <a href='http://annox.no-ip.com'><img border='0' src='http://bp2.blogger.com/_CGKuPVAFxb0/Rg2-IKxjEdI/AAAAAAAAAGE/tyKWGQFaFic/s200/laugh.jpg' alt='http://annox.no-ip.com' /></a>");
                                //op.WriteLine("      <h1><font color='red'>{0} Kill Status</font></h1>", Encode(m_Killer.Name));
                                op.WriteLine("      <h1><font color='red'>The Book of Kills</font></h1>");
                                //op.WriteLine("      <font color='white'>Kill #{0}</font><br>", book.TotKills);
                                op.WriteLine("      <font color='yellow'>{0}</font><font color='white'> has killed {1} people.  {2}'s last kill was </font><font color='cyan'>{3}</font> ", Encode(m_Killer.Name), book.TotKills, Encode(m_Killer.Name), Encode(owner.Name));
                                op.WriteLine("      <font color='white'>in </font><font color='gold'>{0}</font> ", m.Region.Name);
                                op.WriteLine("      <font color='white'>(</font> <font color=\"khaki\">{0}, {1}, {2}</font>)<font color='white'>) in the land of {3}</font> ", from.X, from.Y, from.Z, from.Map);
                                op.WriteLine("      <font color='white'>on </font><font color=\"red\">{0}.</font><br>", DateTime.Now);
                                op.WriteLine("   </body>");
                                op.WriteLine("</html>");
                            }
                        }
                        else
                        {
                            //29MAR2006 Update m_Killer.Name.html file (Yes, this seems repetive, my mental block)
                            //13NOV2007 Mental block cleared, append not new, duh
                            //using (StreamWriter op = new StreamWriter(path + "/" + m_Killer.Name + ".html"))
                            //using (StreamWriter op = File.AppendText(path + "/" + Encode(m_Killer.Name) + ".html"))
                            using (StreamWriter op = File.AppendText(path + "/index.html"))
                            {
                                op.WriteLine("<html>");
                                op.WriteLine("   <body bgcolor=\"black\">");
                                op.WriteLine("      <font color='yellow'>{0}</font><font color='white'> has killed {1} people.  {2}'s last kill was </font><font color='cyan'>{3}</font> ", Encode(m_Killer.Name), book.TotKills, Encode(m_Killer.Name), Encode(owner.Name));
                                op.WriteLine("      <font color='white'>in </font><font color='gold'>{0}</font> ", m.Region.Name);
                                op.WriteLine("      <font color='white'>(</font> <font color=\"khaki\">{0}, {1}, {2}</font>)<font color='white'>) in the land of {3}</font> ", from.X, from.Y, from.Z, from.Map);
                                op.WriteLine("      <font color='white'>on </font><font color=\"red\">{0}.</font><br>", DateTime.Now);
                                op.WriteLine("   </body>");
                                op.WriteLine("</html>");
                            }
                        }
                        //28MAR2007 Adding Web Based List *** END   ***
                    }
                }
            }

            if (owner != null && owner.Player && m_Killer != null && m_Killer.Player)
            {
                KillBook deathbook = owner.Backpack.FindItemByType(typeof(KillBook), true) as KillBook;

                if (deathbook != null)
                {
                    if (owner == deathbook.BookOwner)
                    {
                        if (deathbook.TotDeaths >= 0)
                            deathbook.TotDeaths++;
                    }
                }
            }
        }
    }
}

using System;
using System.IO;
using System.Text;
using Server;
using Server.Network;
using Server.Guilds;

using System.Collections;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Accounting;


namespace Server.Misc
{
    public class StatusPage : Timer
    {
        public static void Initialize()
        {
            new StatusPage().Start();
        }

        public StatusPage()
            : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(60.0))
        {
            Priority = TimerPriority.FiveSeconds;
        }

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

        protected override void OnTick()
        {


            if (!Directory.Exists("C:/Inetpub/wwwroot/status/web"))
                Directory.CreateDirectory("C:/Inetpub/wwwroot/status/web");

            using (StreamWriter op = new StreamWriter("C:/Inetpub/wwwroot/status/web/status.html"))
            {
                //op.WriteLine("<html>");
                //op.WriteLine("   <head>");
                //op.WriteLine("      <title>RunUO Server Status</title>");
                //op.WriteLine("   </head>");
                //op.WriteLine("   <body bgcolor=\"black\">");
                //op.WriteLine("      <h1>RunUO Server Status</h1>");
                //op.WriteLine("      Online clients:<br>");

                op.WriteLine("<html>");
                op.WriteLine("   <head>");
                op.WriteLine("      <title>Server Status - updated by Ravon of An Nox</title>");
                op.WriteLine("   </head>");
                op.WriteLine("   <body bgcolor=\"black\">");
                op.WriteLine("      <a href='http://annox.no-ip.com'><img src='http://annox.no-ip.com/images/EarthStar4.Jpg' alt='http://annox.no-ip.com' width='200' height='100'/></a>");
                op.WriteLine("      <h1><font color=\"red\">Who is on-line:</h1>");

                foreach (NetState state in NetState.Instances)
                {
                    Mobile m = state.Mobile;

                    if (m != null)
                    {
                        //28FEB2008 Added He/She instead of They
                        string HeShe = "";
                        if (m.Female)
                            HeShe = "She";
                        else
                            HeShe = "He";

                        //28FEB2008 Added sessionTime and TotalSessionTime
                        TimeSpan sessionTime = TimeSpan.Zero;
                        sessionTime = DateTime.Now - ((PlayerMobile)m).SessionStart;
                        TimeSpan gameTime = TimeSpan.Zero;
                        gameTime = ((PlayerMobile)m).GameTime;

                        string TotalSessionTime = String.Format("{0} hours and {1} minutes", sessionTime.Hours, sessionTime.Minutes);
                        string TotalGameTime = String.Format("{0} days, {1} hours and {2} minutes", gameTime.Days, gameTime.Hours, gameTime.Minutes);

                        string whereAmI = "";
                        if (m.Region.Name == null)
                            whereAmI = "the wilderness";
                        else
                            whereAmI = m.Region.Name;

                        op.WriteLine("      <font color=\"yellow\">{0}<font color=\"white\"> is near <font color=\"cyan\">{1}", Encode(m.Name), whereAmI);
                        //op.WriteLine("      <font color=\"white\">(<font color=\"khaki\">{0}, {1}, {2}<font color=\"white\">) ", m.X, m.Y, m.Z);
                        op.WriteLine("      <font color=\"white\">on {0:dddd} {1:t} and has been playing for <font color=\"red\">{2}.  ", DateTime.Now, DateTime.Now, TotalSessionTime);
                        op.WriteLine("      <font color=\"white\">{0} is {1} old.<br>", HeShe, TotalGameTime);
                    }
                }

                op.WriteLine("      </table>");
                op.WriteLine("   </body>");
                op.WriteLine("</html>");
                //    op.WriteLine( "      <table width=\"100%\">" );
                //    op.WriteLine( "         <tr>" );
                //    op.WriteLine( "            <td bgcolor=\"black\"><font color=\"white\">Name</font></td><td bgcolor=\"black\"><font color=\"white\">Location</font></td><td bgcolor=\"black\"><font color=\"white\">Kills</font></td><td bgcolor=\"black\"><font color=\"white\">Karma / Fame</font></td>" );
                //    op.WriteLine( "         </tr>" );

                //    foreach ( NetState state in NetState.Instances )
                //    {
                //        Mobile m = state.Mobile;

                //        if ( m != null )
                //        {
                //            Guild g = m.Guild as Guild;

                //            op.Write( "         <tr><td>" );

                //            if ( g != null )
                //            {
                //                op.Write( Encode( m.Name ) );
                //                op.Write( " [" );

                //                string title = m.GuildTitle;

                //                if ( title != null )
                //                    title = title.Trim();
                //                else
                //                    title = "";

                //                if ( title.Length > 0 )
                //                {
                //                    op.Write( Encode( title ) );
                //                    op.Write( ", " );
                //                }

                //                op.Write( Encode( g.Abbreviation ) );

                //                op.Write( ']' );
                //            }
                //            else
                //            {
                //                op.Write( Encode( m.Name ) );
                //            }

                //            op.Write( "</td><td>" );
                //            op.Write( m.X );
                //            op.Write( ", " );
                //            op.Write( m.Y );
                //            op.Write( ", " );
                //            op.Write( m.Z );
                //            op.Write( " (" );
                //            op.Write( m.Map );
                //            op.Write( ")</td><td>" );
                //            op.Write( m.Kills );
                //            op.Write( "</td><td>" );
                //            op.Write( m.Karma );
                //            op.Write( " / " );
                //            op.Write( m.Fame );
                //            op.WriteLine( "</td></tr>" );
                //        }
                //    }

                //    op.WriteLine( "         <tr>" );
                //    op.WriteLine( "      </table>" );
                //    op.WriteLine( "   </body>" );
                //    op.WriteLine( "</html>" );
            }
        }
    }
}
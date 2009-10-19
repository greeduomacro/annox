//GM Arthanys - Mystara Shard: www.mystara.com.br
//http://www.runuo.com/forums/custom-script-releases/83574-2-0-rc1-stone-suggestions.html
//28MAR2007 Added WEB access and HTML by RavonTUS

using System;
using Server;
using System.IO;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Accounting;
using System.Collections;
using Server.Commands;
using System.Text;
namespace Server.Gumps
{
    public class Suggestion : Gump
    {
        public Suggestion()
            : base(0, 0)
        {
            Closable = false;
            Disposable = false;
            Dragable = true;

            AddPage(0);
            AddBackground(241, 189, 288, 276, 9300);
            AddImageTiled(254, 210, 260, 11, 50);
            AddImageTiled(254, 451, 260, 11, 50);
            AddImageTiled(245, 190, 11, 274, 50);
            AddImageTiled(512, 189, 11, 273, 50);
            AddImage(481, 426, 9005, 231);
            AddImage(255, 426, 9005, 231);
            AddImage(474, 435, 95, 231);
            AddImage(289, 434, 97, 231);
            AddButton(424, 405, 69, 70, 1, GumpButtonType.Reply, 0); // Close Button
            AddButton(292, 405, 69, 70, 0, GumpButtonType.Reply, 0); // Okay Button
            AddLabel(317, 194, 0, @"Suggestion Box"); // Suggestion Box Label 1
            AddTextEntry(257, 223, 254, 400, 0, 0, @"");
            AddLabel(300, 433, 0, @"Okay"); // Label 2
            AddLabel(432, 433, 0, @"Close"); // Label 3
        }
        public enum Buttons
        {
            TextEntry1,
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

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
            Account acct = (Account)from.Account;

            switch (info.ButtonID)
            {

                case 0:
                    string tudo = (string)info.GetTextEntry((int)Buttons.TextEntry1).Text;
                    
                    if (tudo == "")
                    {
                        break;
                    }


                    Console.WriteLine("");
                    Console.WriteLine("{0} From Account {1} Sent a suggestion", from.Name, acct.Username);//from.Name of account send a suggestion
                    Console.WriteLine("");

                    //04AUG2008 Replace text file with HTML file *** START ***
                    //if (!Directory.Exists("suggestion")) //create directory
                    //    Directory.CreateDirectory("suggestion");

                    //using (StreamWriter op = new StreamWriter("suggestion/suggestion.txt", true))
                    //{
                    //    op.WriteLine("");
                    //    op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
                    //    op.WriteLine("Message: {0}", tudo);
                    //    op.WriteLine("");
                    //}


                    /*********************************************************/
                    /*             path to where your website is stored      */
                    string path = "C:/Inetpub/wwwroot/status/web/suggestion";
                    /*********************************************************/

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (!File.Exists(path + "/suggestion.html"))
                    {
                        using (StreamWriter op = new StreamWriter(path + "/suggestion.html"))
                        {
                            op.WriteLine("<html>");
                            op.WriteLine("   <head>");
                            op.WriteLine("      <title>Suggestion by Players - updated by Ravon of An Nox</title>");
                            op.WriteLine("   </head>");
                            op.WriteLine("   <body bgcolor=\"black\">");
                            op.WriteLine("      <a href='http://annox.no-ip.com'><img src='http://annox.no-ip.com/forums/tp-images/Image/Medieval_Weaponry.jpg' alt='http://annox.no-ip.com' /></a>");
                            op.WriteLine("      <h1><font color=\"red\">Suggestion Box:</font></h1><br>");
                            op.WriteLine("      <font color='white'> Date: </font><font color='yellow'>{0}</font><br>", DateTime.Now);
                            op.WriteLine("      <font color='white'> Name of Character: </font><font color='yellow'>{0}</font><font color='white'>.  Account Name:  </font><font color='yellow'>{1}</font><font color='white'>.</font><br>", Encode(from.Name), Encode(acct.Username));
                            op.WriteLine("      <font color='white'>Message: </font><font color='cyan'>{0}</font><br>", Encode(tudo));
                            op.WriteLine("      <font color=\"red\">--------------------</font><br>");
                            op.WriteLine("   </body>");
                        }
                    }
                    else
                    {
                        using (StreamWriter op = File.AppendText(path + "/suggestion.html"))
                        {
                            op.WriteLine("<html>");
                            op.WriteLine("   <body bgcolor=\"black\">");
                            op.WriteLine("      <font color='white'> Date: </font><font color='yellow'>{0}</font><br>", DateTime.Now);
                            op.WriteLine("      <font color='white'> Name of Character: </font><font color='yellow'>{0}</font><font color='white'>.  Account Name:  </font><font color='yellow'>{1}</font><font color='white'>.</font><br>", Encode(from.Name), Encode(acct.Username));
                            op.WriteLine("      <font color='white'>Message: </font><font color='cyan'>{0}</font><br>", Encode(tudo));
                            op.WriteLine("      <font color=\"red\">--------------------</font><br>");
                            op.WriteLine("   </body>");
                            op.WriteLine("</html>");
                        }
                    }
                    //28MAR2007 Adding Web Based List *** END  ***

                    from.SendMessage("Thanks for your suggestion!");//thanks to send your suggestion

                    break;

                case 1:
                    from.CloseGump(typeof(Suggestion));
                    break;
            }
        }
    }
}

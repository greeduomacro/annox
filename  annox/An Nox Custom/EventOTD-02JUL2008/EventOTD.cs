//04MAY2007 Tip of the Day by RavonTUS@Yahoo.com
//Play at An Nox, the cure for the UO addiction.
//http://annox.no-ip.com

using System;
using Server;
using Server.Gumps;
using System.Collections;
using Server.Items;
using Server.Commands;
using Server.Network;

namespace Server.Gumps
{
    public class EventOTDGump : Gump
    {
        int Image1 = Utility.RandomMinMax(21632, 21642);
        string dat_EventOTD = "Event of the Day.";

        private static bool Enabled = true; //Turn on/off Event of the Day
        string dat_MondayEventOTD = "<center>Today is <b>Monday</b>.</center><br><p>It's Free Mount Monday.  Seek our the Mount Stone in Minoc for a free mount.</p>";
        string dat_TuesdayEventOTD = "<center>Today is Tuesday</b>.</center>"; //<br><p>There will be a mass player event Friday at 10:00 pm.</p>";
        string dat_WednesdayEventOTD = "<center>Today is Wednesday</b>.</center>"; //<br><p>There will be a mass player event Friday at 10:00 pm.</p>";
        string dat_ThursdayEventOTD = "<center>Today is Thursday</b>.</center><br>"; //<p>There will be a mass player event tomorrow at 10:00 pm.</p><br><p>Visit tomorrow for Free House Friday.</p>";
        string dat_FridayEventOTD = "<center>Today is Friday</b>.</center><br><p>It's Free House Friday.  Search for the housing stone in Minoc and receive a small house.</p>"; //<br><p>Gather at Minoc at 10:00 pm. The pipe piper will try to attack the city with hords of rats.</p><br><p>It's Free House Friday.  Search for the housing stone in Minoc and receive a small house.</p>";
        string dat_SaturdayEventOTD = "<center>Today is Saturday</b>.</center><br>Welcome to Super Sword Saturday.  Find ye the Weapons Stone in Minoc and be rewarded with a fablous weapon.</p>";
        string dat_SundayEventOTD = "<center>Today is Sunday</b>.</center></p>Tomorrow is Free Mount Monday.";

        public EventOTDGump()
            : base(20, 20)
        {
            DateTime now = DateTime.Now;

            switch (now.DayOfWeek.ToString())  //picks one of the following
            {
                case "Monday":
                    { dat_EventOTD = dat_MondayEventOTD; break; }
                case "Tuesday":
                    { dat_EventOTD = dat_TuesdayEventOTD; break; }
                case "Wednesday":
                    { dat_EventOTD = dat_WednesdayEventOTD; break; }
                case "Thursday":
                    { dat_EventOTD = dat_ThursdayEventOTD; break; }
                case "Friday":
                    { dat_EventOTD = dat_FridayEventOTD; break; }
                case "Saturday":
                    { dat_EventOTD = dat_SaturdayEventOTD; break; }
                case "Sunday":
                    { dat_EventOTD = dat_SundayEventOTD; break; }
            }

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(55, 60, 365, 327, 9380);
            this.AddImage(96, 101, Image1);//random image
            this.AddHtml(90, 181, 303, 140, @"<p>" + dat_EventOTD + "</p>", (bool)true, (bool)true);
            this.AddLabel(195, 145, 349, @"" + String.Format(" Players Online: {0}", Server.Network.NetState.Instances.Count));
            this.AddLabel(185, 109, 164, @"Welcome to An Nox");
            this.AddLabel(90, 330, 0, @"Server Time: " + now);       
            this.AddButton(358, 330, 4025, 4024, (int)Buttons.OK, GumpButtonType.Reply, 0);
        }

        public enum Buttons
        {
            OK,
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile m = sender.Mobile;
            switch (info.ButtonID)
            {
                case 0:
                    {
                        m.CloseGump(typeof(EventOTDGump));
                        break;
                    }
            }
        }

        public static void Initialize()
        {
            if (Enabled)
            {
                EventSink.Login += new LoginEventHandler(EventSink_Login);
                CommandSystem.Register("EOTD", AccessLevel.Player, new CommandEventHandler(TOTD_OnCommand));
            }
        }

        private static void EventSink_Login(LoginEventArgs args)
        {
            Mobile m = args.Mobile;
            m.CloseGump(typeof(EventOTDGump));
            m.SendGump(new EventOTDGump());
        }

        [Usage("EOTD")]
        [Description("Show Tip Of The Day menu.")]
        private static void TOTD_OnCommand(CommandEventArgs args)
        {
            Mobile m = args.Mobile;
            m.CloseGump(typeof(EventOTDGump));
            m.SendGump(new EventOTDGump());
        }
    }
}
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
    public class RandomTOTDGump : Gump
    {
        private static bool Enabled = false; //Turn on/off Event of the Day
        int Image1 = Utility.RandomMinMax(21632, 21642);
        string dat_TOTD = RandomTOTDXMLReader.RandomName("dat_TOTD");

        public RandomTOTDGump()
            : base(20, 20)
        {
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(55, 60, 365, 327, 9380);
            this.AddImage(96, 101, Image1);//random image
            this.AddHtml(90, 181, 303, 140, @"<p>" + dat_TOTD + "</p>", (bool)true, (bool)true);
            this.AddLabel(195, 145, 349, @"" + String.Format(" Players Online: {0}", Server.Network.NetState.Instances.Count));
            this.AddLabel(185, 109, 164, @"Welcome to An Nox");
            this.AddButton(90, 330, 2507, 2507, (int)Buttons.Tips, GumpButtonType.Reply, 0);
            this.AddButton(358, 330, 4025, 4024, (int)Buttons.OK, GumpButtonType.Reply, 0);
        }

        public enum Buttons
        {
            OK,
            Tips
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile m = sender.Mobile;
            switch (info.ButtonID)
            {
                case 0:
                    {
                        m.CloseGump(typeof(RandomTOTDGump));
                        break;
                    }

                case 1:
                    {
                        m.CloseGump(typeof(RandomTOTDGump));
                        m.SendGump(new RandomTOTDGump());
                        break;
                    }
            }
        }

        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(EventSink_Login);
            CommandSystem.Register("TOTD", AccessLevel.Player, new CommandEventHandler(TOTD_OnCommand));
        }

        private static void EventSink_Login(LoginEventArgs args)
        {
            if (Enabled)
            {
                Mobile m = args.Mobile;
                m.CloseGump(typeof(RandomTOTDGump));
                m.SendGump(new RandomTOTDGump());
            }
        }

        [Usage("TOTD")]
        [Description("Show Tip Of The Day menu.")]
        private static void TOTD_OnCommand(CommandEventArgs args)
        {
            Mobile m = args.Mobile;
            m.CloseGump(typeof(RandomTOTDGump));
            m.SendGump(new RandomTOTDGump());
        }
    }
}
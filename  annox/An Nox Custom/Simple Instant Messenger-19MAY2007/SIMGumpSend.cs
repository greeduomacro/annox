using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
    public class SIMGumpSend : Gump
    {
        public SIMGumpSend(string Author, string Message)
            : base(0, 0)
        {
            int Image1 = Utility.RandomMinMax(30010, 30057);

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(79, 44, 290, 197, 5170);
            this.AddLabel(119, 73, 57, @"From: " + Author);
            this.AddHtml(119, 100, 216, 67, @"" + Message, (bool)true, (bool)true);
            this.AddImage(123, 180, Image1); //30010-30057
            this.AddButton(269, 183, 247, 248, (int)Buttons.Button1, GumpButtonType.Reply, 0);
            this.AddLabel(155, 185, 1117, @"[SIM to reply");
        }

        public enum Buttons
        {
            Button1,
        }

    }
}
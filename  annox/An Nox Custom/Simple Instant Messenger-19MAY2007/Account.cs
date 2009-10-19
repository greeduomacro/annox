using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class MyGump : Gump
	{
		public MyGump()
			: base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(78, 44, 290, 197, 5170);
			this.AddLabel(119, 73, 57, @"From:");
			this.AddHtml( 119, 100, 216, 67, @"", (bool)true, (bool)true);
			this.AddImage(123, 180, 30010);
			this.AddButton(269, 183, 247, 248, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			this.AddLabel(155, 185, 1117, @"[SIM to reply");
			this.AddLabel(103, 241, 0, @"Account:");

		}
		
		public enum Buttons
		{
			Button1,
		}

	}
}
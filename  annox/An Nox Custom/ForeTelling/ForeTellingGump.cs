using System;
using Server;
using Server.Gumps;

namespace Server.Gumps
{
	public class ForeTellingGump : Gump
	{
        public ForeTellingGump(int VendorX, int VendorY, int PlayerX, int PlayerY)
			: base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddImage(0, 0, 5011);
			//this.AddImage(203, 104, 2360);
            this.AddImage(PlayerX, PlayerY, 2361);
            this.AddImage(VendorX, VendorY, 2362);
			this.AddButton(217, 271, 247, 248, (int)Buttons.Button1, GumpButtonType.Reply, 0);

		}
		
		public enum Buttons
		{
			Button1,
		}

	}
}
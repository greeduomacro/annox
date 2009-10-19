using System;
using Server;
using System.Net;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class SoulstoneDeedGump : Gump
	{
		private Mobile m_Mobile;
	    private Item m_Deed;

      	public SoulstoneDeedGump(Mobile from, Item deed) : base(30, 20)
        {
            m_Mobile = from;
            m_Deed = deed;
			
			Closable = true;
            Disposable = true;
            Dragable = true;
			Resizable = false;
			
	        AddPage(0);
			AddBackground( 0, 0, 350, 250, 0xA28 );
            AddLabel(125, 20, 0, @"Soulstone Deed"); 

			AddItem( 62, 112, 0x2A93 );
			AddButton( 65, 55, 0x868, 0x869, 1, GumpButtonType.Reply, 1 ); // Green Soulstone

			AddItem( 152, 112, 0x32F3 );
			AddButton( 155, 55, 0x868, 0x869, 2, GumpButtonType.Reply, 2 ); // Red Soulstone
			
			AddItem( 242, 112, 0x2ADC );
			AddButton( 245, 55, 0x868, 0x869, 3, GumpButtonType.Reply, 3 ); // Blue Soulstone
		}
		
		public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0: //Close Gump 
                {
                    from.CloseGump(typeof(SoulstoneDeedGump));
                    break;
				}
                case 1: // Green Soulstone
                {
                    Item item = new SoulStone(from.Account.ToString());								
					from.BankBox.AddItem( item );
			        from.CloseGump( typeof( SoulstoneDeedGump ));
					from.SendMessage( "A green soulstone has been placed into your bankbox." );
			        m_Deed.Delete();
			        break;
                }
                case 2: // Red Soulstone
                {
					Item item = new RedSoulstone( from.Account.ToString() );								
					from.BankBox.AddItem( item );
			        from.CloseGump( typeof( SoulstoneDeedGump ));
					from.SendMessage( "A red soulstone has been placed into your bankbox." );
			        m_Deed.Delete();
			        break;
                }
                case 3: // Blue Soulstone
                {
					Item item = new BlueSoulstone( from.Account.ToString() );								
					from.BankBox.AddItem( item );
			        from.CloseGump( typeof( SoulstoneDeedGump ));
					from.SendMessage( "A blue soulstone has been placed into your bankbox." );
			        m_Deed.Delete();
			        break;
                }
            }
        }
    }
}
//==============================================//
// Created by Dupre				//
// Thanks to:					//
// Ignacio					//
// Modification by Almrac Avanti		//
//==============================================//

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{
    public class TentDGump : Gump
    {
        public TentDGump(TentDestroyer tentdestroyer, Mobile owner)
            : base(150, 75)
        {
            m_TentDestroyer = tentdestroyer;
            owner.CloseGump(typeof(TentDGump));
            this.Closable = false;
            this.Disposable = false;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(0, 0, 445, 250, 9200);
            this.AddBackground(10, 10, 425, 160, 3500);
            this.AddLabel(95, 30, 195, @"* Do you want to RePack your Tent? *");
            this.AddLabel(107, 205, 172, @"RePack");
            this.AddLabel(270, 205, 32, @"Don't RePack");
            AddButton(115, 180, 4023, 4024, 1, GumpButtonType.Reply, 0);
            AddButton(295, 180, 4017, 4018, 0, GumpButtonType.Reply, 0);
        }

        private TentDestroyer m_TentDestroyer;

        public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
        {

            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
                    {
                        //Cancel
                        from.SendMessage("Your choose not to RePack your Tent.");
                        break;
                    }

                case 1: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
                    {

                        //RePack 
                        m_TentDestroyer.Delete();
                        from.AddToBackpack(new TentDeed());
                        from.SendMessage("You roll up your Tent and place it in your backpack.");
                        break;
                    }
            }
        }
    }

    public class TentGump : Gump
    {
        public TentGump(Mobile owner)
            : base(150, 75)
        {
            this.Closable = false;
            this.Disposable = false;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(0, 0, 445, 395, 9200);
            this.AddBackground(10, 10, 425, 375, 3500);
            this.AddLabel(40, 240, 1359, @"There is a bedroll and kindling in the chest.");
            this.AddLabel(40, 260, 1359, @"You will need to set up camp with the kindling and");
            this.AddLabel(40, 280, 1359, @"use the bedroll to log out safely!");
            this.AddButton(310, 330, 9723, 9724, (int)Buttons.Button1, GumpButtonType.Reply, 0);
            this.AddLabel(135, 50, 195, @"* You have placed a Tent *");
            this.AddLabel(40, 80, 1359, @"Outsdie Your Tent you will find a tent carring case, The");
            this.AddLabel(40, 100, 1359, @"carring case is used to RePack your tent.");
            this.AddLabel(140, 335, 32, @"I understand");
        }

        public enum Buttons
        {
            Button1,
        }
    }
}

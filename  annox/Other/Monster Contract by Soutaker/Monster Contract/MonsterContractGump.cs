/***************************
**    Monster Contract Dealer   **
**    Creator: Raisor: Created the Monster Contract sytem for RunUO ver 1.0	**
**    Darkness_PR Made the NPC for the Monster Contract System for RunUO ver 1.0 **
**    Current Updater for RunUO ver 2.0: Soultaker    **
**    Version: 2.0a				**
***************************/
// Currently Being Updated by Soultaker
// All Credit goes to Raisor & Darkness_PR otherwise we wouldnt have this fantastic system.
//04MAR2008 Make sure player's pet or spell gets credit for the kill by RavonTUS

using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Gumps
{
    public class MonsterContractGump : Gump
    {
        private MonsterContract MCparent;

        public MonsterContractGump(Mobile from, MonsterContract parentMC)
            : base(0, 0)
        {
            from.CloseGump(typeof(MonsterContractGump));

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            this.AddPage(0);
            this.AddBackground(0, 0, 300, 170, 5170);
            this.AddLabel(40, 40, 0, @"A Contract for: " + parentMC.AmountToKill + " " + parentMC.Monster);
            this.AddLabel(40, 60, 0, @"Amount Killed: " + parentMC.AmountKilled);
            this.AddLabel(40, 80, 0, @"Reward: " + parentMC.Reward);
            if (parentMC.AmountKilled != parentMC.AmountToKill)
            {
                this.AddButton(90, 110, 2061, 2062, 1, GumpButtonType.Reply, 0);
                this.AddLabel(104, 108, 0, @"Claim Corpse");
            }
            else
            {
                this.AddButton(90, 110, 2061, 2062, 2, GumpButtonType.Reply, 0);
                this.AddLabel(104, 108, 0, @"Claim Reward");
            }

            MCparent = parentMC;
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile m_from = state.Mobile;

            if (info.ButtonID == 1)
            {
                m_from.SendMessage("Please choose the corpse to add.");
                m_from.Target = new MonsterCorpseTarget(MCparent);
            }
            if (info.ButtonID == 2)
            {
                MCparent.Delete();
                m_from.SendMessage("The reward has been placed in your bank!");
                m_from.BankBox.DropItem(new BankCheck(MCparent.Reward));
            }
        }

        private class MonsterCorpseTarget : Target
        {
            private MonsterContract MCparent;

            public MonsterCorpseTarget(MonsterContract parentMC)
                : base(-1, true, TargetFlags.None)
            {
                MCparent = parentMC;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Corpse)
                {
                    Corpse MCcorpse = (Corpse)o;

                    if (MCcorpse.Channeled)
                    {
                        from.SendMessage("This corpse has been desecrated and can not be claimed!");
                        return;
                    }

                    //04MAR2008 Make sure player's pet or spell gets credit for the kill *** START ***
                    if (MCcorpse.Killer == null)
                        return;


                    if ((MCcorpse.Killer == from) || (((BaseCreature)MCcorpse.Killer).SummonMaster) == from)
                    //04MAR2008 Make sure player's pet or spell gets credit for the kill *** END ***
                    {
                        string m_type = "a " + MCparent.Monster;
                        m_type = m_type.ToLower();
                        string m_type2 = "an " + MCparent.Monster;
                        m_type2 = m_type2.ToLower();
                        string m_corpse = MCcorpse.Owner.Name;
                        m_corpse = m_corpse.ToLower();

                        if (m_type == m_corpse || m_type2 == m_corpse)
                        {
                            MCparent.AmountKilled += 1;
                            MCcorpse.Delete();
                        }
                        else
                        {
                            from.SendMessage("That corpse is not of the correct type!");
                        }
                    }
                    else
                    {
                        from.SendMessage("You cannot claim someone elses work!");
                    }
                }
                else
                {
                    from.SendMessage("That is not a corpse");
                }
            }
        }
    }
}

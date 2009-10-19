/***************************
**    Monster Contract Dealer   **
**    Creator: Raisor: Created the Monster Contract sytem for RunUO ver 1.0	**
**    Darkness_PR Made the NPC for the Monster Contract System for RunUO ver 1.0 **
**    Current Updater for RunUO ver 2.0: Soultaker    **
**    Version: 2.0a				**
***************************/
// Currently Being Updated by Soultaker
// All Credit goes to Raisor & Darkness_PR otherwise we wouldnt have this fantastic system.

using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
    [CorpseName("Good Luck Getting Your Contract!")]
    public class MonsterContractDealer : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public MonsterContractDealer()
        {
            Name = "Rio";
            Title = "The Contract Dealer";
            Body = 0x190;
            CantWalk = true;
            Hue = Utility.RandomSkinHue();

            AddItem(ItemSet(new Cloak()));
            AddItem(ItemSet(new Robe()));
            AddItem(ItemSet1(new ShepherdsCrook()));

            Item Boots = new Boots();
            Boots.Hue = 2112;
            Boots.Name = "Non-Leather Boots";
            Boots.Movable = false;
            AddItem(Boots);

            Item FancyShirt = new FancyShirt();
            FancyShirt.Hue = 1267;
            FancyShirt.Name = "Shirt";
            FancyShirt.Movable = false;
            AddItem(FancyShirt);

            Item LongPants = new LongPants();
            LongPants.Hue = 847;
            LongPants.Name = "Pants";
            LongPants.Movable = false;
            AddItem(LongPants);

            int hairHue = 1814;

            switch (Utility.Random(1))
            {
                case 0: AddItem(new PonyTail(hairHue)); break;
                case 1: AddItem(new Goatee(hairHue)); break;
            }

            Blessed = true;

        }

        public static Item ItemSet(Item item)
        {
            item.Movable = false;
            item.Hue = 1109;

            return item;
        }

        public static Item ItemSet1(Item item)
        {
            item.Movable = false;
            item.Hue = 1153;

            return item;
        }


        public MonsterContractDealer(Serial serial)
            : base(serial)
        {
        }

        //		public override void GetContextMenuEntries( Mobile from, ArrayList list ) //removed for Runuo 2.0
        public override void GetContextMenuEntries(Mobile m, System.Collections.Generic.List<ContextMenuEntry> list) //added for Runuo 2.0
        {
            base.GetContextMenuEntries(m, list);
            list.Add(new MonsterContractDealerEntry(m, this));
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public class MonsterContractDealerEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public MonsterContractDealerEntry(Mobile m, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = m;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                if (!(m_Mobile is PlayerMobile))
                    return;

                PlayerMobile mobile = (PlayerMobile)m_Mobile;

                {
                    if (!mobile.HasGump(typeof(MonsterContractDealerGump)))
                    {
                        mobile.SendGump(new MonsterContractDealerGump(mobile));
                        mobile.AddToBackpack(new MonsterContract());
                    }
                }
            }
        }

        /*public override bool OnDragDrop( Mobile m, Item dropped )
        {          		
                    Mobile m = m;
            PlayerMobile mobile = m as PlayerMobile;

            if ( mobile != null)
            {
                if( dropped is BlazeLeather)
                {
                    if(dropped.Amount!=15)
                    {
                    this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "That is not the amount I asked for.", mobile.NetState );
                        return false;
                    }

                    dropped.Delete(); 
                    mobile.AddToBackpack( new DruidTravelSkull() );
                    mobile.AddToBackpack( new DruidicSpellbook() );
                    mobile.SendGump( new DruidQuestFinishGump());

				
                    return true;
                }
                else if ( dropped is BlazeLeather)
                {
                this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
                    return false;
                }
                else
                {
                    this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I did not ask for this item.", mobile.NetState );
                }
            }
            return false;
        */
    }
}

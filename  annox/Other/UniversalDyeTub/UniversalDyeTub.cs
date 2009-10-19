//15MAR2008 modified by RavonTUS
//20MAR2008 added suggestion by Lord_Greywolf

using System;
using Server;
using Server.Targeting;
using Server.Regions;
using Server.Multis;

namespace Server.Items
{

    public class UnivTubTarget : Target
    {
        private Item m_Item;

        public UnivTubTarget(Item item)
            : base(12, false, TargetFlags.None)
        {
            m_Item = item;
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (targeted is Item)
            {
                Item targ = (Item)targeted;

                if (!targ.IsChildOf(from.Backpack))
                {
                    //if (from.Region is HouseRegion)
                    //{
                    //    targ.Hue = m_Item.Hue;
                    //    from.PlaySound(0x23F);
                    //}
                    //else
                    //{
                    //    from.SendLocalizedMessage(1062617); //	You can only hue objects that are in your backpack.
                    //    // You don't have room for the item in your pack, so you stop working on it.
                    //    //1042001	That must be in your pack for you to use it.
                    //    //1045112	You cannot hue that item
                    //    //1062617	You can only hue objects that are in your backpack.
                    //    //1042083	You cannot dye that.
                    //}
                    BaseHouse house = BaseHouse.FindHouseAt(from);

                    if (house == null || !house.IsCoOwner(from))
                    {
                        from.SendLocalizedMessage(502092); //You must be in your house to do this.
                    }
                    else
                    {
                        if (!house.IsInside(targ))
                        {
                            from.SendLocalizedMessage(1042270);  //That is not in your house.
                        }
                        else
                        {
                            if (!(from.InRange(targ.GetWorldLocation(), 2)))
                            {
                                from.SendLocalizedMessage(500295);  //You are too far away to do that.
                            }
                            else
                            {
                                targ.Hue = m_Item.Hue;
                                from.PlaySound(0x23F);
                                //from.SendLocalizedMessage(1062617); //	You can only hue objects that are in your backpack.
                            }
                        }
                    }
                }
                else
                {
                    targ.Hue = m_Item.Hue;
                    from.PlaySound(0x23F);
                }
            }
        }
    }

    public class UniversalDyeTub : Item
    {

        private bool m_Redyable;
        private int m_DyedHue;

        [Constructable]
        public UniversalDyeTub()
            : base(0xFAB)
        {
            Weight = 10.0;
            Hue = 0;
            Name = "Universal Dye Tub";
            m_Redyable = true;
        }

        public UniversalDyeTub(Serial serial)
            : base(serial)
        {
        }

        public override void OnSingleClick(Mobile from)
        {
            this.Name = "Universal Dye Tub #" + this.Hue;
        }

        public override void OnDoubleClick(Mobile from)
        {
            this.Name = "Universal Dye Tub #" + this.Hue;
            from.Target = new UnivTubTarget(this);
            from.SendLocalizedMessage(1045104); //	Target the item you wish to hue
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((bool)m_Redyable);
            writer.Write((int)m_DyedHue);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Redyable = reader.ReadBool();
                        m_DyedHue = reader.ReadInt();

                        break;
                    }
            }
        }
    }
}
using System;
using Server;
using Server.Multis;
using Server.Targeting;

namespace Server.Items
{
    public interface NewIDyable
    {
        bool Dye(Mobile from, NewUniversalDyeTub sender);
    }

    public class NewUniversalDyeTub : Item
    {
        private bool m_Redyable;
        private int m_DyedHue;


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

        [CommandProperty(AccessLevel.Player)]
        public bool Redyable
        {
            get
            {
                return m_Redyable;
            }
            set
            {
                m_Redyable = value;
            }
        }

        [CommandProperty(AccessLevel.Player)]
        public int DyedHue
        {
            get
            {
                return m_DyedHue;
            }
            set
            {
                if (m_Redyable)
                {
                    m_DyedHue = value;
                    Hue = value;
                }
            }
        }

        [Constructable]
        public NewUniversalDyeTub()
            : base(0xFAB)
        {
            Weight = 10.0;
            m_Redyable = true;
        }

        public NewUniversalDyeTub(Serial serial)
            : base(serial)
        {
        }

        // Select the clothing to dye.
        public virtual int TargetMessage { get { return 500859; } }

        // You can not dye that.
        public virtual int FailMessage { get { return 1042083; } }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 1))
            {
                from.SendLocalizedMessage(TargetMessage);
                from.Target = new InternalTarget(this);
            }
            else
            {
                from.SendLocalizedMessage(500446); // That is too far away.
            }
        }

        private class InternalTarget : Target
        {
            private NewUniversalDyeTub m_Tub;
            private Item m_Item;

            public InternalTarget(NewUniversalDyeTub tub)
                : base(1, false, TargetFlags.None)
            {
                m_Tub = tub;
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
    }
}
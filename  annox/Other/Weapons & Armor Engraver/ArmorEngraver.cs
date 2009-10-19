using System;
using Server;
using Server.Multis;
using Server.Targeting;
using Server.Items;
using Server.Prompts;
using Server.Engines.Craft;
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;


namespace Server.Items
{
    [FlipableAttribute(0x0FBF, 0x0FC0)]
    public class ArmorEngraver : Item, ICraftable
    {
        private int m_CurCharges, m_MaxCharges;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((int)m_CurCharges);
            writer.Write((int)m_MaxCharges);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_CurCharges = reader.ReadInt();
                        m_MaxCharges = reader.ReadInt();

                        break;
                    }
            }
        }
        public override void AddNameProperty(ObjectPropertyList list)
        {
            int charges;


            if ((charges = m_CurCharges) == 1)
                list.Add(" Armor Engraver with 1 charge");

            else
                if ((charges = m_CurCharges) == 0)
                    list.Add(" Armor Engraver with no charges");

                else
                {
                    charges = m_CurCharges;
                    list.Add(" Armor Engraver with {0} charges", charges.ToString());
                }
        }


        #region ICraftable Members

        public int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue)
        {
            int charges = 5 + quality + (int)(from.Skills[SkillName.Inscribe].Value / 30);

            if (charges > 10)
            {
                charges = 10;
            }

            MaxCharges = (Core.SE ? charges * 2 : charges);

            return quality;
        }

        #endregion

        [CommandProperty(AccessLevel.GameMaster)]
        public int CurCharges
        {
            get
            {
                return m_CurCharges;
            }
            set
            {
                m_CurCharges = value;
                InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxCharges
        {
            get
            {
                return m_MaxCharges;
            }
            set
            {
                m_MaxCharges = value;
            }
        }

        [Constructable]
        public ArmorEngraver()
            : base(0x0FBF)
        {
            Name = " Armor Engraver";
            Weight = 1.0;
            m_CurCharges = 10;
            m_MaxCharges = 10;
        }
        public ArmorEngraver(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (m_CurCharges > 0)
            {
                if (from.InRange(this.GetWorldLocation(), 1))
                {
                    from.SendMessage("Target the armor you wish to name.");
                    from.Target = new InternalTarget(this);
                }
                else
                {
                    from.SendMessage("That is too far away.");
                }
            }
            else
            {
                from.SendMessage("You are out of charges.");
            }
        }

        public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
        {
            list.Add(new Recharge(from, item));
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            ArmorEngraver.GetContextMenuEntries(from, this, list);
        }

        public virtual void Charge()
        {
            m_CurCharges++;
            InvalidateProperties();
        }


        private class Recharge : ContextMenuEntry
        {
            private ArmorEngraver m_Item;
            private Mobile m_Mobile;

            public Recharge(Mobile from, Item item)
                : base(407)
            {
                m_Item = (ArmorEngraver)item;
                m_Mobile = from;
            }

            public override void OnClick()
            {
                if (!Owner.From.CheckAlive())
                    return;

                if (m_Item.m_CurCharges >= 0 && m_Item.m_CurCharges <= 9)
                {
                    Container pack = m_Mobile.Backpack;
                    Item a = pack.FindItemByType(typeof(Feather));

                    if (a != null)
                    {
                        m_Item.Charge();
                        m_Mobile.SendMessage("You add a charge to this tool");
                        a.Consume(1);
                    }

                    else
                        m_Mobile.SendMessage("You need Feathers in pack to recharge");
                }

                else
                    m_Mobile.SendMessage("This is already fully charged");
            }
        }
        private class InternalTarget : Target
        {
            private ArmorEngraver m_ArmorEngraver;
            private BaseArmor m_engtarg;

            public InternalTarget(ArmorEngraver engrave)
                : base(1, false, TargetFlags.None)
            {
                m_ArmorEngraver = engrave;
            }
            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is BaseArmor)
                {
                    m_engtarg = (BaseArmor)targeted;

                    if (!from.InRange(m_ArmorEngraver.GetWorldLocation(), 2) || !from.InRange(m_engtarg.GetWorldLocation(), 2))
                    {
                        from.SendLocalizedMessage(500446); // That is too far away.
                    }
                    else
                        if (m_engtarg.Parent == null)
                        {
                            BaseHouse house = BaseHouse.FindHouseAt(m_engtarg);

                            if (house == null || !house.IsLockedDown(m_engtarg))
                            {
                                from.SendMessage("You must Lock this down before you can Engrave it.");
                            }

                            else
                                if (!house.IsCoOwner(from))
                                {
                                    from.SendLocalizedMessage(501023); // You must be the owner to use this item.
                                }

                                else
                                {
                                    from.Prompt = new RenameArmorPrompt(m_engtarg);
                                    from.SendMessage("What would you like to engrave on the armor ?");
                                    m_ArmorEngraver.CurCharges = (m_ArmorEngraver.CurCharges - 1);
                                    from.SendMessage("You use your Armor Engraver. You now have {0} uses left.", m_ArmorEngraver.CurCharges);

                                    if (m_ArmorEngraver.CurCharges == 0)
                                    {
                                        from.SendMessage("You have ran out of charges. Refill the Armor Engraver with Feathers.");

                                    }
                                }
                        }
                        else
                        {
                            from.SendMessage("You must be in your house to engrave that.");
                        }
                }
                else
                {
                    from.SendMessage("You cannot engrave that.");
                }
            }
        }
    }
}

namespace Server.Prompts
{
    public class RenameArmorPrompt : Prompt
    {
        private BaseArmor m_engtarg;

        public RenameArmorPrompt(BaseArmor rarmor)
        {
            m_engtarg = rarmor;
        }
        public override void OnResponse(Mobile from, string text)
        {
            m_engtarg.Name = text;
            from.SendMessage("You have engraved the armor.");
        }
    }
}

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
    public class BaseRegentPlant : Item
    {

        public Item item;
        public BaseRegentPlant item2;
        public Mobile m;
        public int held;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Held
        {
            get { return held; }
            set { held = value; InvalidateProperties(); }
        }

        public void HarvestPlant(Mobile from, Item i_item, BaseRegentPlant i_item2)
        {
            item = i_item;
            item2 = i_item2;
            m = from;

            if (m.InRange(this.GetWorldLocation(), 2))
            {

                item.Amount = held;

                if (m.Skills[SkillName.Cooking].Value > 95.0 && held >= 0 || m.Skills[SkillName.Lumberjacking].Value > 95.0 && held >= 0)
                {
                    item.Amount += (int)(m.Skills[SkillName.Cooking].Value - 95.0);
                    item.Amount += (int)(m.Skills[SkillName.Lumberjacking].Value - 95.0);
                    m.SendMessage("You use you expert skill to gain more then average from the plant.");
                }

                if (held > 0)
                {
                    double chance = Utility.RandomDouble();

                    if (0.30 > chance)
                        GiveSeed(m, item2);

                    m.SendMessage("You harvest from the plant.");
                    AddHarvestToPack(m, item);
                    item2.Delete();
                }
                else
                {
                    m.SendMessage("There is not enough there to harvest.");
                    item.Delete();
                    return;
                }

            }
        }

        public void GiveSeed(Mobile m, BaseRegentPlant plant)
        {
            Backpack pack = (Backpack)m.Backpack;

            if (pack == null)
                return;

            if (plant is BloodMossPlant)
            {
                pack.DropItem(new BaseRegentSeed(0));
            }
            else if (plant is GarlicPlant)
            {
                pack.DropItem(new BaseRegentSeed(1));
            }
            else if (plant is GinsengPlant)
            {
                pack.DropItem(new BaseRegentSeed(2));
            }
            else if (plant is MandrakePlant)
            {
                pack.DropItem(new BaseRegentSeed(3));
            }
            else if (plant is NightshadePlant)
            {
                pack.DropItem(new BaseRegentSeed(4));
            }
        }

        private void AddHarvestToPack(Mobile m_mob, Item i)
        {
            Container pack = m_mob.Backpack;

            m = m_mob;

            NewPackItem(i);
        }


        public void NewPackItem(Item item)
        {
            Backpack pack = (Backpack)m.Backpack;

            if (pack != null)
                m.AddToBackpack(item);
            else
                item.Delete();
        }

        public BaseRegentPlant(int itemID)
            : base(itemID)
        {
            Movable = false;
            held = Utility.RandomMinMax(1, 5);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("amount: "+held);
        }


        public BaseRegentPlant(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(held);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            held = reader.ReadInt();
        }


    }

    
}
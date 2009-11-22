using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
    public class HumanBrigandCamp : BaseCamp
    {
        //public virtual Mobile Camper { get { return new HumanBrigand(); } }
        public virtual Mobile Camper { get { return new EscortableMage(); } }

        private Mobile m_Prisoner;

        [Constructable]
        public HumanBrigandCamp()
            : base(8612)
        {
        }
        public HumanBrigandCamp(Serial serial)
            : base(serial)
        {
        }

        public override void AddComponents()
        {
            BaseCreature bc;

            AddItem(new Static(0xFAC), 0, 0, 0); // fire pit
            AddItem(new Static(0xDE3), 0, 0, 0); // camp fire
            AddItem(new Static(0x974), 0, 0, 1); // cauldron

            // Chest
            MetalChest chest = new MetalChest();

            switch (Utility.Random(3))
            {
                case 0: chest.ItemID = 0x9AB; break; // MetalChest
                case 1: chest.ItemID = 0xe43; break; // WoodenChest
                case 2: chest.ItemID = 0x9A9; break; // SmallCrate
            }

            chest.Movable = false;
            chest.Locked = true;
            chest.TrapType = TrapType.ExplosionTrap;
            chest.TrapPower = Utility.RandomMinMax(30, 40);
            chest.TrapLevel = 2;
            chest.RequiredSkill = 76;
            chest.LockLevel = 66;
            chest.MaxLockLevel = 116;
            chest.DropItem(new Gold(Utility.RandomMinMax(100, 400)));
            chest.DropItem(new Arrow(10));
            chest.DropItem(new Bolt(10));

            if (Utility.RandomDouble() < 0.8)
            {
                switch (Utility.Random(4))
                {
                    case 0: chest.DropItem(new LesserCurePotion()); break;
                    case 1: chest.DropItem(new LesserExplosionPotion()); break;
                    case 2: chest.DropItem(new LesserHealPotion()); break;
                    case 3: chest.DropItem(new LesserPoisonPotion()); break;
                }
            }

            if (Utility.RandomDouble() < 0.5)
            {
                Item item = Loot.RandomArmorOrShieldOrWeapon();

                if (item is BaseWeapon)
                    BaseRunicTool.ApplyAttributesTo((BaseWeapon)item, false, 0, Utility.RandomMinMax(1, 5), 10, 100);
                else if (item is BaseArmor)
                    BaseRunicTool.ApplyAttributesTo((BaseArmor)item, false, 0, Utility.RandomMinMax(1, 5), 10, 100);

                chest.DropItem(item);
            }

            AddItem(chest, 1, 1, 1);

            // Brigands
            AddMobile(new Brigand(), 15, 0, -2, 0);
            AddMobile(new Brigand(), 15, 0, 1, 0);
            AddMobile(new Brigand(), 15, 0, -1, 0);
            AddMobile(new Brigand(), 15, 0, 0, 0);
            AddMobile(new Brigand(), 15, 0, -1, 0);
            AddMobile(new Brigand(), 15, 0, 0, 0);

            // prisioner
            switch (Utility.Random(2))
            {
                case 0: m_Prisoner = new Noble(); break;
                case 1: m_Prisoner = new SeekerOfAdventure(); break;
            }

            bc = (BaseCreature)m_Prisoner;
            bc.IsPrisoner = true;
            m_Prisoner.YellHue = Utility.RandomList(0x57, 0x67, 0x77, 0x87, 0x117);

            AddMobile(m_Prisoner, 2, -2, 0, 0);
        }

        public override void OnEnter(Mobile m)
        {
            base.OnEnter(m);

            if (m.Player && m_Prisoner != null)
            {
                m_Prisoner.Yell(Utility.RandomMinMax(502261, 502268));
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Prisoner);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Prisoner = reader.ReadMobile();
        }
    }
}
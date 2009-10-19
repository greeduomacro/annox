using System;
using Server;
using Server.ContextMenus;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Misc;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{
    [CorpseName("BonBon's Corpse")]
    public class BonBon : BaseCreature
    {
        [Constructable]
        public BonBon()
            : base(AIType.AI_Animal, FightMode.Closest, 10, 5, 0.175, 0.75)
        {
            Name = "BonBon";
            Title = "The Bunny";
            Body = 205;
            Hue = 0x481;
            BaseSoundID = 0;

            SetStr(45, 55);
            SetDex(45, 55);
            SetInt(31, 43);

            SetHits(100, 200);

            SetDamage(11, 20);

            SetDamageType(ResistanceType.Physical, 5);
            SetDamageType(ResistanceType.Fire, 0);
            SetDamageType(ResistanceType.Cold, 0);
            SetDamageType(ResistanceType.Energy, 0);
            SetDamageType(ResistanceType.Poison, 0);

            SetResistance(ResistanceType.Physical, 8, 18);
            SetResistance(ResistanceType.Fire, 18, 21);
            SetResistance(ResistanceType.Cold, 13, 23);
            SetResistance(ResistanceType.Energy, 0, 5);
            SetResistance(ResistanceType.Poison, 11, 23);

            SetSkill(SkillName.Parry, 25, 45);
            SetSkill(SkillName.Wrestling, 80, 95);

            Fame = 500;
            Karma = 100;

            VirtualArmor = 15;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 11.1;

            Container pack = Backpack;

            if (pack != null)
                pack.Delete();

            pack = new StrongBackpack();
            pack.Movable = false;

            AddItem(pack);

            double gschance = Utility.RandomDouble();

            //If the random generated number is higher then 70, or exacly 70, a staff will drop.
            //Meaning: there's a 30% chance that one will drop.

            if (gschance <= 0.7)
            {
                Item BonBonPickaxe = new BonBonPickaxe();
                AddItem(BonBonPickaxe);
            }
        }

        public override int Meat { get { return 3; } }
        public override int Hides { get { return 10; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public override void GenerateLoot()
        {
            switch (Utility.Random(1))
            {
                case 0: AddLoot(LootPack.Average);
                    AddLoot(LootPack.Poor);
                    break;

            }
        }

        private static bool m_InHere;

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (from != null && from != this && !m_InHere)
            {
                m_InHere = true;
                AOS.Damage(from, this, Utility.RandomMinMax(5, 15), 100, 0, 0, 0, 0);

                MovingEffect(from, 0x2808, 10, 0, false, false, 0, 0);
                PlaySound(0x238);

                //I think this is set too low, actually it's do a random twice, so delete this one.
                //if (0.05 > Utility.RandomDouble())
                Timer.DelayCall(TimeSpan.FromSeconds(1.0), new TimerStateCallback(ThrowEgg_Callback), from);

                m_InHere = false;
            }
        }

        public virtual void ThrowEgg_Callback(object state)
        {
            Mobile from = (Mobile)state;
            Map map = from.Map;

            if (map == null)
                return;

            int count = Utility.RandomMinMax(1, 2);

            for (int i = 0; i < count; ++i)
            {
                int x = from.X + Utility.RandomMinMax(-1, 1);
                int y = from.Y + Utility.RandomMinMax(-1, 1);
                int z = from.Z;

                if (!map.CanFit(x, y, z, 16, false, true))
                {
                    z = map.GetAverageZ(x, y);

                    if (z == from.Z || !map.CanFit(x, y, z, 16, false, true))
                        continue;
                }

                BonBonEgg egg = new BonBonEgg();

                egg.Name = "an Explosive BonBon Egg";
                egg.ItemID = (0x2808);

                egg.MoveToWorld(new Point3D(x, y, z), map);
            }
        }

        public BonBon(Serial serial)
            : base(serial)
        {
        }

        #region Pack Animal Methods
        public override bool OnBeforeDeath()
        {
            if (!base.OnBeforeDeath())
                return false;

            PackAnimal.CombineBackpacks(this);

            return true;
        }

        public override DeathMoveResult GetInventoryMoveResultFor(Item item)
        {
            return DeathMoveResult.MoveToCorpse;
        }

        public override bool IsSnoop(Mobile from)
        {
            if (PackAnimal.CheckAccess(this, from))
                return false;

            return base.IsSnoop(from);
        }

        public override bool OnDragDrop(Mobile from, Item item)
        {
            if (CheckFeed(from, item))
                return true;

            if (PackAnimal.CheckAccess(this, from))
            {
                AddToBackpack(item);
                return true;
            }

            return base.OnDragDrop(from, item);
        }

        public override bool CheckNonlocalDrop(Mobile from, Item item, Item target)
        {
            return PackAnimal.CheckAccess(this, from);
        }

        public override bool CheckNonlocalLift(Mobile from, Item item)
        {
            return PackAnimal.CheckAccess(this, from);
        }

        public override void OnDoubleClick(Mobile from)
        {
            PackAnimal.TryPackOpen(this, from);
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            PackAnimal.GetContextMenuEntries(this, from, list);
        }
        #endregion

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
    }
}
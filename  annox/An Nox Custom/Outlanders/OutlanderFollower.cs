// Created by Script Creator

using System;
using Server.Items;
using System.Collections;
using Server.Network;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Misc;
using Server.Engines.BulkOrders;
using Server.Regions;
using Server.Factions;

namespace Server.Mobiles
{

    [CorpseName("an outlander corpse")]
    public class OutlanderFollower : BaseCreature
    {
        [Constructable]
        public OutlanderFollower()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Team = 2;

            SetStr(41, 71);
            SetDex(47, 77);
            SetInt(27, 57);

            SetHits(27, 41);
            SetMana(0);

            SetDamage(5, 9);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 25);
            SetResistance(ResistanceType.Cold, 5, 10);

            SetSkill(SkillName.MagicResist, 26.8, 44.5);
            SetSkill(SkillName.Tactics, 29.8, 47.5);
            SetSkill(SkillName.Wrestling, 29.8, 47.5);

            Title = "an outlander follower";

            Fame = 10000;
            Karma = -10000;

            Container pack = new Backpack();
            pack.DropItem(new OutlanderHead());
            PackItem(pack);

            SpeechHue = Utility.RandomDyedHue();

            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");

                switch (Utility.Random(2))
                {
                    case 0:
                        AddItem(new LeatherSkirt());
                        break;
                    case 1:
                        AddItem(new LeatherShorts());
                        break;
                }

                switch (Utility.Random(5))
                {
                    case 0:
                        AddItem(new FemaleLeatherChest());
                        break;
                    case 1:
                        AddItem(new FemaleStuddedChest());
                        break;
                    case 2:
                        AddItem(new LeatherBustierArms());
                        break;
                    case 3:
                        AddItem(new StuddedBustierArms());
                        break;
                    case 4:
                        AddItem(new FemalePlateChest());
                        break;
                }
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");


                switch (Utility.Random(3))
                {
                    case 0:
                        AddItem(new Doublet(Utility.RandomNondyedHue()));
                        break;
                    case 1:
                        AddItem(new Tunic(Utility.RandomNondyedHue()));
                        break;
                    case 2:
                        AddItem(new BodySash(Utility.RandomNondyedHue()));
                        break;
                }
            }

            Item hair = new Item(Utility.RandomList(0x203B, 0x203C, 0x203D, 0x2044, 0x2045, 0x2047, 0x2049, 0x204A));

            hair.Hue = Utility.RandomHairHue();
            hair.Layer = Layer.Hair;
            hair.Movable = false;

            AddItem(hair);

            if (Utility.RandomBool() && !this.Female)
            {
                Item beard = new Item(Utility.RandomList(0x203E, 0x203F, 0x2040, 0x2041, 0x204B, 0x204C, 0x204D));

                beard.Hue = hair.Hue;
                beard.Layer = Layer.FacialHair;
                beard.Movable = false;

                AddItem(beard);
            }

            //Clothes
            switch (Utility.Random(3))
            {
                case 0: AddItem(new FancyShirt(GetRandomHue())); break;
                case 1: AddItem(new Doublet(GetRandomHue())); break;
                case 2: AddItem(new Shirt(GetRandomHue())); break;
            }

            switch (Utility.Random(4))
            {
                case 0: AddItem(new Shoes(GetShoeHue())); break;
                case 1: AddItem(new Boots(GetShoeHue())); break;
                case 2: AddItem(new Sandals(GetShoeHue())); break;
                case 3: AddItem(new ThighBoots(GetShoeHue())); break;
            }
            switch (Utility.Random(2))
            {
                case 0: AddItem(new LongPants(GetRandomHue())); break;
                case 1: AddItem(new ShortPants(GetRandomHue())); break;
            }

            Skills[SkillName.Anatomy].Base = Utility.RandomMinMax(30, 100);
            Skills[SkillName.Tactics].Base = Utility.RandomMinMax(30, 100);
            Skills[SkillName.Swords].Base = Utility.RandomMinMax(30, 100);
            Skills[SkillName.MagicResist].Base = Utility.RandomMinMax(30, 100);
            Skills[SkillName.Wrestling].Base = Utility.RandomMinMax(30, 100);
        }
        public virtual int GetRandomHue()
        {
            switch (Utility.Random(5))
            {
                default:
                case 0: return Utility.RandomBlueHue();
                case 1: return Utility.RandomGreenHue();
                case 2: return Utility.RandomRedHue();
                case 3: return Utility.RandomYellowHue();
                case 4: return Utility.RandomNeutralHue();
            }
        }

        public virtual int GetShoeHue()
        {
            if (0.1 > Utility.RandomDouble())
                return 0;

            return Utility.RandomNeutralHue();
        }

        public virtual VendorShoeType ShoeType
        {
            get { return VendorShoeType.Shoes; }
        }

        public override bool AlwaysMurderer { get { return true; } }

        public OutlanderFollower(Serial serial)
            : base(serial)
        {
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
    }
}


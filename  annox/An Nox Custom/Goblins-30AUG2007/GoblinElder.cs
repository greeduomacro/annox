// 30AUG2007 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a goblin elder corpse")]
    public class GoblinElder : BaseCreature
    {
        [Constructable]
        public GoblinElder()
            : base(AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a goblin elder";
            Body = 255;
            BaseSoundID = 0x45A;
            Hue = Utility.RandomMinMax(1437, 1445);

            SetStr(30);
            SetDex(15);
            SetInt(5);

            SetHits(18);
            SetMana(0);

            SetDamage(1, 4);

            SetDamage(1, 4);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 5, 15);

            SetSkill(SkillName.MagicResist, 5.5);
            SetSkill(SkillName.Tactics, 5.5);
            SetSkill(SkillName.Wrestling, 5.5);

            Fame = 300;
            Karma = 0;

            VirtualArmor = Utility.RandomMinMax(10, 20);

            Tamable = false;
            ControlSlots = 1;
            MinTameSkill = 11.1;

            if (Core.AOS && Utility.Random(1000) == 0) // 0.1% chance to have mad goblin elders
                FightMode = FightMode.Closest;
        }

        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public override void OnCarve(Mobile from, Corpse corpse)
        {
            if (corpse.Carved == false)
            {
                base.OnCarve(from, corpse);

                new Blood(Utility.RandomMinMax(4650, 4655)).MoveToWorld(corpse.Location, corpse.Map);
                new GoblinEars().MoveToWorld(corpse.Location, corpse.Map);
                corpse.Delete();
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            int random = Utility.Random(100);

            if (random < 5)
                Tip();
            else if (random < 20)
                PlaySound(120);
            else if (random < 40)
                PlaySound(121);
        }

        public void Tip()
        {
            PlaySound(121);
            //Animate( 8, 0, 3, true, false, 0 );
        }

        public GoblinElder(Serial serial)
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
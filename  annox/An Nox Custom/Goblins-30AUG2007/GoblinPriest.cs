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
    [CorpseName("a goblin priest corpse")]
    public class GoblinPriest : BaseCreature
    {
        [Constructable]
        public GoblinPriest()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a goblin priest";
            Body = 253;
            BaseSoundID = 0x45A;
            Hue = Utility.RandomMinMax(2001, 2006);

            SetStr(32, 74);
            SetDex(46, 65);
            SetInt(16, 30);

            SetHits(26, 39);
            SetMana(0);

            SetDamage(4, 8);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 15, 20);
            SetResistance(ResistanceType.Fire, 5, 10);
            SetResistance(ResistanceType.Poison, 25, 35);

            SetSkill(SkillName.MagicResist, 25.1, 30.0);
            SetSkill(SkillName.Tactics, 29.3, 44.0);
            SetSkill(SkillName.Wrestling, 29.3, 44.0);

            Fame = 300;
            Karma = -300;

            VirtualArmor = Utility.RandomMinMax(10, 20);

            Tamable = false;
            ControlSlots = 1;
            MinTameSkill = 29.1;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
            AddLoot(LootPack.Gems, 1);
        }

        public override FoodType FavoriteFood { get { return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies | FoodType.Eggs; } }

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

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (0.1 > Utility.RandomDouble())
            {
                /* Maniacal laugh
                 * Cliloc: 1070840
                 * Effect: Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x37B9" ItemIdName: "glow" FromLocation: "(884 715, 10)" ToLocation: "(884 715, 10)" Speed: "10" Duration: "5" FixedDirection: "True" Explode: "False"
                 * Paralyzes for 4 seconds, or until hit
                 */

                defender.FixedEffect(0x37B9, 10, 5);
                defender.SendLocalizedMessage(1070840); // You are frozen as the creature laughs maniacally.

                defender.Paralyze(TimeSpan.FromSeconds(4.0));
            }
        }

        public GoblinPriest(Serial serial)
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
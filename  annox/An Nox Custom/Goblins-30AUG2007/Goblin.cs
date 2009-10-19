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
    [CorpseName("a goblin corpse")]
    public class Goblin : BaseCreature
    {
        [Constructable]
        public Goblin()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "a goblin";
            Body = 245;
            BaseSoundID = 0x45A;
            Hue = Utility.RandomMinMax(1267, 1272);
            //NOTE:  use 12589 or 12590 (0x312d or 0x312e) for orc ears.

            SetStr(5);
            SetDex(15);
            SetInt(5);

            SetHits(3);
            SetMana(0);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 1, 5);

            SetSkill(SkillName.MagicResist, 4.0);
            SetSkill(SkillName.Tactics, 5.0);
            SetSkill(SkillName.Wrestling, 5.0);

            Fame = 150;
            Karma = 0;

            VirtualArmor = VirtualArmor = Utility.RandomMinMax(2, 4);

            Tamable = false;
            ControlSlots = 1;
            MinTameSkill = -0.9;
        }

        public override FoodType FavoriteFood { get { return FoodType.GrainsAndHay; } }

        public override bool CanRummageCorpses { get { return true; } }

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

        public Goblin(Serial serial)
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
// 06APR2006 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using Server.Mobiles;

namespace Server.C
{
    [CorpseName("an exploded rabbit corpse")]
    [TypeAlias("Server.Mobiles.Explodingrabbit")]
    public class ExplodingRabbit : BaseCreature
    {
        [Constructable]
        public ExplodingRabbit()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "rabbit";
            Body = 0xCD;
            Hue = 0x1BB;

            SetStr(15);
            SetDex(25);
            SetInt(5);

            SetHits(9);
            SetMana(0);

            SetDamage(1, 2);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 2, 5);

            SetSkill(SkillName.MagicResist, 5.0);
            SetSkill(SkillName.Tactics, 5.0);
            SetSkill(SkillName.Wrestling, 5.0);

            Fame = 150;
            Karma = 0;

            VirtualArmor = 4;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = -18.9;
        }

        public override int Meat { get { return 1; } }
        public override int Hides { get { return 1; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies; } }

        public ExplodingRabbit(Serial serial)
            : base(serial)
        {
        }

        public override int GetAttackSound()
        {
            return 0xC9;
        }

        public override int GetHurtSound()
        {
            return 0xCA;
        }

        public override int GetDeathSound()
        {
            return 0xCB;
        }
        public override bool OnBeforeDeath() //this sets up the death command
        {
            Effects.SendLocationEffect(Location, Map, 0x3709, 30);//Burn Player
            PlaySound(0x54);

            return true;  //this is need for the "public override bool" true=dead false=alive
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
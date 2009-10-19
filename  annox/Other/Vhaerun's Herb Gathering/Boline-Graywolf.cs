using System;
using Server.Items;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{
    [FlipableAttribute(0xEC5, 0xEC4)]
    public class Boline : BaseAxe
    {
        public override HarvestSystem HarvestSystem { get { return HerbGathering.System; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ShadowStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Disarm; } }

        public override int AosStrengthReq { get { return 10; } }
        public override int AosMinDamage { get { return 6; } }
        public override int AosMaxDamage { get { return 8; } }
        public override int AosSpeed { get { return 56; } }

        public override int OldStrengthReq { get { return 1; } }
        public override int OldMinDamage { get { return 3; } }
        public override int OldMaxDamage { get { return 15; } }
        public override int OldSpeed { get { return 55; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 40; } }

        public override SkillName DefSkill { get { return SkillName.Fencing; } }
        public override WeaponType DefType { get { return WeaponType.Piercing; } }
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public Boline()
            : base(0xEC5)
        {
            Name = "Boline (herb gathering)";
            Hue = 64;
            Weight = 3.0;
            UsesRemaining = 100;
            ShowUsesRemaining = true;
        }

        public Boline(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            ShowUsesRemaining = true;
        }
    }
}
using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x26C1, 0x26CB)]
    public class BladeofPower : BaseSword
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.WhirlwindAttack; } }

        public override int ArtifactRarity { get { return 55; } }
        public override int AosStrengthReq { get { return 55; } }
        public override int AosMinDamage { get { return 11; } }
        public override int AosMaxDamage { get { return 14; } }
        public override int AosSpeed { get { return 47; } }

        public override int OldStrengthReq { get { return 55; } }
        public override int OldMinDamage { get { return 11; } }
        public override int OldMaxDamage { get { return 14; } }
        public override int OldSpeed { get { return 47; } }

        public override int DefHitSound { get { return 0x23B; } }
        public override int DefMissSound { get { return 0x23A; } }

        public override int InitMinHits { get { return 51; } }
        public override int InitMaxHits { get { return 80; } }

        [Constructable]
        public BladeofPower()
            : base(0x26C1)
        {
            LootType = LootType.Blessed;
            Attributes.SpellChanneling = 1;
            WeaponAttributes.HitFireball = 50;
            WeaponAttributes.HitLightning = 50;
            WeaponAttributes.HitDispel = 50;
            Name = "Blade of Power";
            Hue = 1281;
            Weight = 1.0;
        }

        public BladeofPower(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
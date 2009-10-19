using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class ThunderRod : BaseElementalWeapon
    {
        public override int EffectID { get { return 14239; } }
        public override Type AmmoType { get { return typeof(EnergyOrb); } }
        public override Item Ammo { get { return new EnergyOrb(); } }

        public override SkillName DefSkill { get { return SkillName.Magery; } }


        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ParalyzingBlow; } }

        public override int AosStrengthReq { get { return 70; } }
        public override int AosMinDamage { get { return 11; } }
        public override int AosMaxDamage { get { return 21; } }
        public override int AosSpeed { get { return 41; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 8; } }

        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootXBow; } }

        [Constructable]
        public ThunderRod()
            : base(3568)
        {
            Weight = 4.0;
            Name = "Rod Of Thunder";
            Layer = Layer.TwoHanded;
            MissSound = 1307;
            WeaponAttributes.HitEnergyArea = 100;
            Attributes.SpellChanneling = 1;
            HitSound = 756;
            WeaponAttributes.ResistEnergyBonus = 20;
            Hue = 1174;

        }


        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            cold = 0;
            nrgy = 100;

            pois = fire = phys = 0;
        }

        public ThunderRod(Serial serial)
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

            if (Weight == 5.0)
                Weight = 4.0;
        }
    }
}
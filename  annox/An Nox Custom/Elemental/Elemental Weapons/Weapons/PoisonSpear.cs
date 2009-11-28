using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class PoisonSpear : BaseElementalWeapon
    {
        public override int EffectID { get { return 0x26BE; } }
        public override Type AmmoType { get { return typeof(PoisonOrb); } }
        public override Item Ammo { get { return new PoisonOrb(); } }

        public override SkillName DefSkill { get { return SkillName.Fencing; } }


        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.ParalyzingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.InfectiousStrike; } }

        public override int AosStrengthReq { get { return 70; } }
        public override int AosMinDamage { get { return 17; } }
        public override int AosMaxDamage { get { return 17; } }
        public override int AosSpeed { get { return 47; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 1; } }

        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce2H; } }

        [Constructable]
        public PoisonSpear()
            : base(0x26BE)
        {
            Weight = 4.0;
            Name = "Spear Of Toxins";
            Layer = Layer.TwoHanded;
            MissSound = 1307;
            WeaponAttributes.HitFireArea = 100;
            Attributes.WeaponSpeed = 20;
            HitSound = 1140;
            WeaponAttributes.ResistPoisonBonus = 20;
            Hue = 68;

        }


        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            cold = 0;
            pois = 100;

            fire = nrgy = phys = chaos = direct = 0;
        }

        public PoisonSpear(Serial serial)
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
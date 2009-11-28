using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class WaterTrident : BaseElementalWeapon
    {
        public override int EffectID { get { return 3719; } }
        public override Type AmmoType { get { return typeof(WaterOrb); } }
        public override Item Ammo { get { return new WaterOrb(); } }

        public override SkillName DefSkill { get { return SkillName.Fencing; } }


        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.BleedAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return 70; } }
        public override int AosMinDamage { get { return 19; } }
        public override int AosMaxDamage { get { return 20; } }
        public override int AosSpeed { get { return 40; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 1; } }

        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Pierce2H; } }

        [Constructable]
        public WaterTrident()
            : base(0x3719)
        {
            Weight = 4.0;
            Name = "Trident Of Tides";
            Layer = Layer.TwoHanded;
            MissSound = 1307;
            WeaponAttributes.HitColdArea = 100;
            Attributes.AttackChance = 25;
            HitSound = 18;
            WeaponAttributes.ResistColdBonus = 20;
            Hue = 6;

        }


        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            cold = 100;
            pois = 0;

            fire = nrgy = phys = chaos = direct = 0;
        }

        public WaterTrident(Serial serial)
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
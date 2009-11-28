using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class FireAxe : BaseElementalWeapon
    {
        public override int EffectID { get { return 0xF45; } }
        public override Type AmmoType { get { return typeof(FireOrb); } }
        public override Item Ammo { get { return new FireOrb(); } }

        public override SkillName DefSkill { get { return SkillName.Swords; } }


        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.BleedAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.MortalStrike; } }

        public override int AosStrengthReq { get { return 70; } }
        public override int AosMinDamage { get { return 17; } }
        public override int AosMaxDamage { get { return 23; } }
        public override int AosSpeed { get { return 37; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 41; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 1; } }

        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash2H; } }

        [Constructable]
        public FireAxe()
            : base(0xF45)
        {
            Weight = 4.0;
            Name = "Axe Of Flames";
            Layer = Layer.TwoHanded;
            MissSound = 1307;
            WeaponAttributes.HitFireArea = 100;
            Attributes.WeaponDamage = 40;
            HitSound = 838;
            WeaponAttributes.ResistFireBonus = 20;
            Hue = 37;

        }


        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            cold = 0;
            fire = 100;

            pois = nrgy = phys = chaos = direct = 0;
        }

        public FireAxe(Serial serial)
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
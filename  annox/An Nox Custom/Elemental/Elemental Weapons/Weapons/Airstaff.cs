using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class AirStaff : BaseElementalWeapon
    {
        public override int EffectID { get { return 0xE89; } }
        public override Type AmmoType { get { return typeof(AirOrb); } }
        public override Item Ammo { get { return new AirOrb(); } }

        public override SkillName DefSkill { get { return SkillName.Macing; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ConcussionBlow; } }

        public override int AosStrengthReq { get { return 70; } }
        public override int AosMinDamage { get { return 16; } }
        public override int AosMaxDamage { get { return 18; } }
        public override int AosSpeed { get { return 54; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 1; } }

        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Bash2H; } }

        [Constructable]
        public AirStaff()
            : base(0xE89)
        {
            Weight = 4.0;
            Name = "Staff Of Winds";
            Layer = Layer.TwoHanded;
            MissSound = 1307;
            WeaponAttributes.HitEnergyArea = 100;
            WeaponAttributes.HitLowerDefend = 30;
            HitSound = 265;
            WeaponAttributes.ResistEnergyBonus = 20;
            Hue = 1159;

        }


        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            nrgy = 100;
            pois = 0;

            fire = cold = phys = chaos = direct = 0;
        }

        public AirStaff(Serial serial)
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
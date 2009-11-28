using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13B2, 0x13B1)]
    public class IceHammer : BaseElementalWeapon
    {
        public override int EffectID { get { return 0x1439; } }
        public override Type AmmoType { get { return typeof(IceOrb); } }
        public override Item Ammo { get { return new IceOrb(); } }

        public override SkillName DefSkill { get { return SkillName.Macing; } }


        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.CrushingBlow; } }

        public override int AosStrengthReq { get { return 70; } }
        public override int AosMinDamage { get { return 21; } }
        public override int AosMaxDamage { get { return 26; } }
        public override int AosSpeed { get { return 34; } }

        public override int OldStrengthReq { get { return 20; } }
        public override int OldMinDamage { get { return 9; } }
        public override int OldMaxDamage { get { return 33; } }
        public override int OldSpeed { get { return 20; } }

        public override int DefMaxRange { get { return 1; } }

        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }

        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Bash2H; } }

        [Constructable]
        public IceHammer()
            : base(0x1439)
        {
            Weight = 4.0;
            Name = "Icy Hammer";
            Layer = Layer.TwoHanded;
            MissSound = 1307;
            WeaponAttributes.HitColdArea = 100;
            Attributes.BonusStr = 25;
            HitSound = 479;
            WeaponAttributes.ResistColdBonus = 20;
            Hue = 1152;

        }


        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct)
        {
            cold = 100;
            pois = 0;

            fire = nrgy = phys = chaos = direct = 0;
        }

        public IceHammer(Serial serial)
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
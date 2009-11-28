// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class BloodStrike : BladedStaff
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 120; } }
        [Constructable]
        public BloodStrike()
        {
            Name = "Blood Strike";
            Hue = 0x485;
            Attributes.WeaponDamage = 120;
            WeaponAttributes.HitEnergyArea = 30;
            WeaponAttributes.HitHarm = 30;
            WeaponAttributes.HitLowerAttack = 30;
            WeaponAttributes.LowerStatReq = 45;
            WeaponAttributes.ResistColdBonus = 35;
            WeaponAttributes.ResistPoisonBonus = 35;
            WeaponAttributes.ResistFireBonus = 35;
            WeaponAttributes.SelfRepair = 50;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 40;
            StrRequirement = 20;
            LootType = LootType.Blessed;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
            chaos = direct = 0;
        }
        public BloodStrike(Serial serial)
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

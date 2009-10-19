// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class HandScythe : BoneHarvester
    {
        public override int InitMinHits { get { return 75; } }
        public override int InitMaxHits { get { return 75; } }
        [Constructable]
        public HandScythe()
        {
            Name = "Hand Scythe";

            WeaponAttributes.HitEnergyArea = 20;
            WeaponAttributes.HitHarm = 20;
            WeaponAttributes.HitLightning = 50;
            WeaponAttributes.HitMagicArrow = 50;
            WeaponAttributes.ResistColdBonus = 30;
            WeaponAttributes.ResistPhysicalBonus = 40;
            WeaponAttributes.ResistPoisonBonus = 25;
            WeaponAttributes.ResistFireBonus = 36;
            WeaponAttributes.SelfRepair = 25;
            Attributes.BonusHits = 50;
            Attributes.SpellChanneling = 1;
            Attributes.BonusMana = 100;
            SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            Attributes.CastSpeed = 2;
            Attributes.CastRecovery = 2;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellDamage = 30;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public HandScythe(Serial serial)
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

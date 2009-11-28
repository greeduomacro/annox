// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MagesForce : WarMace
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public MagesForce()
        {
            Name = "Mages Force";
            WeaponAttributes.HitLightning = 60;
            WeaponAttributes.HitMagicArrow = 30;
            Hue = 0x7a7;
            WeaponAttributes.ResistColdBonus = 70;
            Attributes.CastRecovery = 2;
            WeaponAttributes.ResistEnergyBonus = 70;
            WeaponAttributes.ResistPoisonBonus = 70;
            WeaponAttributes.ResistFireBonus = 70;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 30;
            Attributes.BonusMana = 100;
            Attributes.CastSpeed = 3;
            Attributes.SpellChanneling = 1;
            SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
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
        public MagesForce(Serial serial)
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

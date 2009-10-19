// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class ButchersCleaver : Cleaver
    {
        public override int InitMinHits { get { return 50; } }
        public override int InitMaxHits { get { return 50; } }
        [Constructable]
        public ButchersCleaver()
        {
            Name = "Butchers Cleaver";

            Hue = 0x78D;
            WeaponAttributes.HitLowerAttack = 50;
            WeaponAttributes.HitMagicArrow = 10;
            WeaponAttributes.HitPhysicalArea = 50;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 75;
            Attributes.BonusMana = 50;
            Attributes.CastSpeed = 3;
            Attributes.SpellChanneling = 1;
            SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            Attributes.CastRecovery = 2;
            Attributes.SpellDamage = 35;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 150;
            IntRequirement = 100;
            LootType = LootType.Blessed;
            Slayer = SlayerName.BloodDrinking;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public ButchersCleaver(Serial serial)
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

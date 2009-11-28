// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class ArcaneSanctum : Tessen
    {
        public override int InitMinHits { get { return 75; } }
        public override int InitMaxHits { get { return 75; } }
        [Constructable]
        public ArcaneSanctum()
        {
            Name = "Arcane Sanctum";
            Attributes.WeaponDamage = 35;

            WeaponAttributes.HitEnergyArea = 25;
            WeaponAttributes.HitLightning = 25;
            WeaponAttributes.HitMagicArrow = 25;
            WeaponAttributes.ResistColdBonus = 25;
            WeaponAttributes.ResistPoisonBonus = 25;
            WeaponAttributes.ResistFireBonus = 25;
            this.Layer = Layer.OneHanded;
            Attributes.BonusHits = 20;
            Attributes.CastSpeed = 2;
            Attributes.BonusMana = 50;
            Attributes.CastSpeed = 3;
            Attributes.CastRecovery = 2;
            Attributes.SpellChanneling = 1;
            SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            Attributes.SpellDamage = 35;
            Attributes.WeaponSpeed = 35;
            LootType = LootType.Blessed;

            SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
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
        public ArcaneSanctum(Serial serial)
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

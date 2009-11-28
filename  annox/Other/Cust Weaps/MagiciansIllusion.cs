// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MagiciansIllusion : DoubleBladedStaff
    {
        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public MagiciansIllusion()
        {
            Name = "Magicians Illusion";
            Attributes.WeaponDamage = 50;
            WeaponAttributes.HitDispel = 15;
            WeaponAttributes.HitLeechHits = 10;
            WeaponAttributes.HitLeechMana = 10;

            WeaponAttributes.HitLightning = 15;
            WeaponAttributes.HitLowerAttack = 15;
            Attributes.CastSpeed = 2;
            Attributes.CastRecovery = 5;
            WeaponAttributes.HitMagicArrow = 15;
            WeaponAttributes.HitPhysicalArea = 15;
            WeaponAttributes.ResistColdBonus = 70;
            WeaponAttributes.ResistEnergyBonus = 20;
            WeaponAttributes.ResistPhysicalBonus = 40;
            WeaponAttributes.ResistPoisonBonus = 70;
            WeaponAttributes.ResistFireBonus = 50;
            WeaponAttributes.SelfRepair = 20;
            Attributes.BonusHits = 50;
            SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            Attributes.BonusMana = 50;
            this.Layer = Layer.OneHanded;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 20;
            Attributes.WeaponSpeed = 50;
            IntRequirement = 150;
            LootType = LootType.Blessed;
            //Slayer = SlayerName.vacuum;
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
        public MagiciansIllusion(Serial serial)
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

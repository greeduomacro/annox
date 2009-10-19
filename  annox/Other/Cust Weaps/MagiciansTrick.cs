// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MagiciansTrick : Dagger
    {
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        [Constructable]
        public MagiciansTrick()
        {
            Name = "Magicians Trick";

            Hue = 0x9ad;
            WeaponAttributes.HitColdArea = 5;
            WeaponAttributes.HitEnergyArea = 5;
            WeaponAttributes.HitHarm = 5;
            WeaponAttributes.HitLightning = 5;
            WeaponAttributes.HitLowerAttack = 75;
            WeaponAttributes.HitMagicArrow = 5;
            WeaponAttributes.HitPhysicalArea = 5;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 20;
            WeaponAttributes.ResistPhysicalBonus = 20;
            WeaponAttributes.ResistPoisonBonus = 20;
            WeaponAttributes.ResistFireBonus = 20;
            Attributes.SpellChanneling = 1;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.CastRecovery = 2;
            Attributes.BonusHits = 25;
            Attributes.SpellDamage = 45;
            Attributes.BonusMana = 75;
            Attributes.CastSpeed = 5;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Ophidian;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public MagiciansTrick(Serial serial)
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

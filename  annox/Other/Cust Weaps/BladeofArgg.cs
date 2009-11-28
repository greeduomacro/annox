// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class BladeofArgg : Scimitar
    {
        public override int InitMinHits { get { return 80; } }
        public override int InitMaxHits { get { return 80; } }
        [Constructable]
        public BladeofArgg()
        {
            Name = "Blade of Argg";
            Attributes.WeaponDamage = 99;

            Hue = 0x9aa;
            WeaponAttributes.HitEnergyArea = 20;
            WeaponAttributes.HitMagicArrow = 20;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 20;
            WeaponAttributes.ResistPoisonBonus = 20;
            WeaponAttributes.ResistFireBonus = 20;
            WeaponAttributes.SelfRepair = 10;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 50;
            Attributes.BonusMana = 50;
            Attributes.CastSpeed = 1;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 33;
            DexRequirement = 120;
            StrRequirement = 120;
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
        public BladeofArgg(Serial serial)
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

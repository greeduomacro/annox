// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class HoradricStaff : GnarledStaff
    {
        public override int InitMinHits { get { return 40; } }
        public override int InitMaxHits { get { return 40; } }
        [Constructable]
        public HoradricStaff()
        {
            Name = "Horadric Staff";
            WeaponAttributes.HitLightning = 60;
            WeaponAttributes.HitMagicArrow = 40;
            WeaponAttributes.ResistColdBonus = 30;
            WeaponAttributes.ResistEnergyBonus = 40;
            WeaponAttributes.ResistPhysicalBonus = 46;
            WeaponAttributes.ResistPoisonBonus = 36;
            WeaponAttributes.ResistFireBonus = 36;
            WeaponAttributes.SelfRepair = 50;

            Attributes.CastSpeed = 2;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 20;
            LootType = LootType.Blessed;
            this.Layer = Layer.OneHanded;
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
        public HoradricStaff(Serial serial)
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

// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class DoubleSlice : Lajatang
    {
        public override int InitMinHits { get { return 250; } }
        public override int InitMaxHits { get { return 250; } }
        [Constructable]
        public DoubleSlice()
        {
            Name = "Double Slice";
            Attributes.WeaponDamage = 200;
            WeaponAttributes.HitColdArea = 15;
            WeaponAttributes.HitDispel = 15;

            WeaponAttributes.HitEnergyArea = 15;
            WeaponAttributes.HitLeechHits = 20;
            WeaponAttributes.HitLeechMana = 20;
            WeaponAttributes.HitLightning = 15;
            WeaponAttributes.HitLowerAttack = 15;
            WeaponAttributes.HitMagicArrow = 15;
            WeaponAttributes.HitPhysicalArea = 15;
            WeaponAttributes.ResistColdBonus = 35;
            WeaponAttributes.ResistEnergyBonus = 55;
            WeaponAttributes.ResistPhysicalBonus = 25;
            WeaponAttributes.ResistPoisonBonus = 45;
            WeaponAttributes.ResistFireBonus = 65;
            Attributes.BonusHits = 200;
            this.Layer = Layer.OneHanded;
            Attributes.BonusMana = 75;
            Attributes.CastSpeed = 15;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 100;
            LootType = LootType.Blessed;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public DoubleSlice(Serial serial)
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

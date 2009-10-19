// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class FlameThang : Halberd
    {
        public override int InitMinHits { get { return 140; } }
        public override int InitMaxHits { get { return 140; } }
        [Constructable]
        public FlameThang()
        {
            Name = "FlameThang";
            WeaponAttributes.HitLightning = 25;
            WeaponAttributes.HitMagicArrow = 100;
            WeaponAttributes.MageWeapon = 1;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 13;
            WeaponAttributes.ResistPoisonBonus = 32;
            WeaponAttributes.ResistFireBonus = 42;
            WeaponAttributes.SelfRepair = 75;

            Attributes.BonusHits = 100;
            Attributes.NightSight = 1;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 175;
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
        public FlameThang(Serial serial)
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

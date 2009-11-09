// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class BowoftheConstantine : Crossbow
    {
        public override int InitMinHits { get { return 140; } }
        public override int InitMaxHits { get { return 140; } }
        [Constructable]
        public BowoftheConstantine()
        {
            Name = "Bow of the Constantine";

            WeaponAttributes.HitColdArea = 20;
            WeaponAttributes.HitDispel = 30;
            WeaponAttributes.HitEnergyArea = 30;
            WeaponAttributes.HitLightning = 50;
            WeaponAttributes.HitLowerAttack = 25;
            WeaponAttributes.HitMagicArrow = 50;
            WeaponAttributes.HitPhysicalArea = 20;
            WeaponAttributes.MageWeapon = 1;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 13;
            WeaponAttributes.ResistPoisonBonus = 32;
            WeaponAttributes.ResistFireBonus = 42;
            WeaponAttributes.SelfRepair = 75;
            Attributes.BonusMana = 25;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 200;
            Attributes.WeaponDamage = 35;
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
        public BowoftheConstantine(Serial serial)
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
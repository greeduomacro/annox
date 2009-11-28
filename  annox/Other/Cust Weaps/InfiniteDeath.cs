// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class InfiniteDeath : CrescentBlade
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 120; } }
        [Constructable]
        public InfiniteDeath()
        {
            Name = "Infinite Death";

            Attributes.WeaponDamage = 150;
            WeaponAttributes.HitColdArea = 70;
            WeaponAttributes.HitDispel = 30;
            WeaponAttributes.HitEnergyArea = 30;
            WeaponAttributes.HitHarm = 25;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLeechMana = 25;
            WeaponAttributes.HitLightning = 35;
            WeaponAttributes.HitMagicArrow = 60;
            WeaponAttributes.HitPhysicalArea = 30;
            WeaponAttributes.MageWeapon = 1;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 13;
            WeaponAttributes.ResistPoisonBonus = 32;
            WeaponAttributes.ResistFireBonus = 42;
            WeaponAttributes.SelfRepair = 75;
            Attributes.BonusHits = 140;
            Attributes.BonusMana = 20;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 105;
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
        public InfiniteDeath(Serial serial)
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

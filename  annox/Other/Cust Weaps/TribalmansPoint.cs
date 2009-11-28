// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class TribalmansPoint : TribalSpear
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 120; } }
        [Constructable]
        public TribalmansPoint()
        {
            Name = "Tribalmans Point";

            Attributes.WeaponDamage = 30;
            WeaponAttributes.HitColdArea = 100;
            WeaponAttributes.HitDispel = 40;
            WeaponAttributes.HitEnergyArea = 40;
            WeaponAttributes.HitHarm = 60;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLeechMana = 25;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitMagicArrow = 55;
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
            Attributes.WeaponSpeed = 30;
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
        public TribalmansPoint(Serial serial)
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

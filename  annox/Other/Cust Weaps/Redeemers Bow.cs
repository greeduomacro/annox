// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class ReedemersBow : Crossbow
    {
        public override int InitMinHits { get { return 140; } }
        public override int InitMaxHits { get { return 140; } }

        [Constructable]
        public ReedemersBow()
        {
            Name = "Reedemers Bow";

            WeaponAttributes.HitColdArea = 25;
            WeaponAttributes.HitDispel = 25;
            WeaponAttributes.HitEnergyArea = 25;
            WeaponAttributes.HitLightning = 35;
            WeaponAttributes.HitFireball = 35;
            WeaponAttributes.HitLowerAttack = 25;
            WeaponAttributes.HitMagicArrow = 35;
            WeaponAttributes.HitPhysicalArea = 35;
            WeaponAttributes.MageWeapon = 1;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 13;
            WeaponAttributes.ResistPoisonBonus = 32;
            WeaponAttributes.ResistFireBonus = 42;
            WeaponAttributes.SelfRepair = 100;
            Attributes.BonusMana = 50;
            Attributes.BonusHits = 50;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 25;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 200;
            Attributes.WeaponDamage = 100;
            LootType = LootType.Blessed;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 50;
            cold = 50;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public ReedemersBow(Serial serial)
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

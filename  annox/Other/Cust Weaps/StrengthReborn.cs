// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class StrengthReborn : TwoHandedAxe
    {
        public override int InitMinHits { get { return 140; } }
        public override int InitMaxHits { get { return 140; } }
        [Constructable]
        public StrengthReborn()
        {
            Name = "Stregth Reborn";

            Attributes.WeaponDamage = 200;
            WeaponAttributes.HitDispel = 30;
            WeaponAttributes.HitHarm = 25;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLeechMana = 25;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitLowerAttack = 25;
            WeaponAttributes.HitMagicArrow = 60;
            WeaponAttributes.MageWeapon = 1;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 13;
            WeaponAttributes.ResistPoisonBonus = 32;
            WeaponAttributes.ResistFireBonus = 42;
            WeaponAttributes.SelfRepair = 75;
            Attributes.BonusHits = 60;
            this.Layer = Layer.OneHanded;
            Attributes.BonusMana = 50;
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
        public StrengthReborn(Serial serial)
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

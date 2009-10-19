// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SpearofDivinity : ShortSpear
    {
        public override int InitMinHits { get { return 75; } }
        public override int InitMaxHits { get { return 75; } }
        [Constructable]
        public SpearofDivinity()
        {
            Name = "Spear of Divinity";
            Attributes.WeaponDamage = 200;
            WeaponAttributes.HitDispel = 30;
            WeaponAttributes.HitEnergyArea = 25;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLeechMana = 25;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitMagicArrow = 35;
            WeaponAttributes.MageWeapon = 1;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 13;
            WeaponAttributes.ResistPoisonBonus = 32;
            WeaponAttributes.ResistFireBonus = 42;
            WeaponAttributes.SelfRepair = 75;
            Attributes.BonusHits = 160;
            this.Layer = Layer.OneHanded;
            Attributes.CastSpeed = 3;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 20;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
            Attributes.WeaponSpeed = 20;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public SpearofDivinity(Serial serial)
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

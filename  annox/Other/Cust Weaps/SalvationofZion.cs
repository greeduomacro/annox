// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SalvationofZion : Bardiche
    {
        public override int InitMinHits { get { return 250; } }
        public override int InitMaxHits { get { return 250; } }
        [Constructable]
        public SalvationofZion()
        {
            Name = "Salvation of Zion";
            Attributes.WeaponDamage = 150;
            Attributes.AttackChance = 25;
            Attributes.DefendChance = 25;
            WeaponAttributes.HitLeechHits = 35;
            WeaponAttributes.HitLightning = 50;
            WeaponAttributes.HitMagicArrow = 50;
            WeaponAttributes.ResistColdBonus = 25;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 50;
            WeaponAttributes.ResistPoisonBonus = 25;
            WeaponAttributes.ResistFireBonus = 25;
            WeaponAttributes.SelfRepair = 300;
            Attributes.BonusDex = 10;
            Attributes.BonusHits = 100;
            Attributes.BonusMana = 50;
            Attributes.Luck = 150;
            Attributes.RegenMana = 25;
            Attributes.RegenStam = 50;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 75;
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
        public SalvationofZion(Serial serial)
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

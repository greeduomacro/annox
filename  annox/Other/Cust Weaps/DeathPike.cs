// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class DeathPike : Pike
    {
        public override int InitMinHits { get { return 125; } }
        public override int InitMaxHits { get { return 125; } }
        [Constructable]
        public DeathPike()
        {
            Name = "Death Pike";
            Attributes.WeaponDamage = 200;
            Attributes.AttackChance = 25;
            Attributes.DefendChance = 35;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitMagicArrow = 100;
            WeaponAttributes.ResistColdBonus = 75;
            WeaponAttributes.ResistEnergyBonus = 75;
            WeaponAttributes.ResistPhysicalBonus = 75;
            WeaponAttributes.ResistPoisonBonus = 75;
            WeaponAttributes.ResistFireBonus = 75;
            WeaponAttributes.SelfRepair = 180;
            Attributes.BonusDex = 5;
            Attributes.BonusHits = 75;
            Attributes.BonusStam = 50;
            Attributes.ReflectPhysical = 20;
            Attributes.RegenHits = 40;
            Attributes.RegenMana = 45;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 50;
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
        public DeathPike(Serial serial)
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

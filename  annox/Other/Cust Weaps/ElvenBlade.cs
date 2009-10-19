// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class ElvenBlade : DoubleBladedStaff
    {
        [Constructable]
        public ElvenBlade()
        {
            Name = "Elven Blade";
            Attributes.WeaponDamage = 75;
            Attributes.AttackChance = 50;
            Attributes.DefendChance = 25;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLightning = 50;
            WeaponAttributes.HitMagicArrow = 50;
            WeaponAttributes.ResistColdBonus = 50;
            WeaponAttributes.ResistPoisonBonus = 100;
            Attributes.BonusDex = 20;
            Attributes.BonusHits = 50;
            Attributes.Luck = 200;
            Attributes.ReflectPhysical = 20;
            Attributes.RegenHits = 25;
            Attributes.RegenMana = 50;
            Attributes.WeaponSpeed = 125;
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
        public ElvenBlade(Serial serial)
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

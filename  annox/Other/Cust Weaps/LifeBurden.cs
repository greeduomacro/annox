// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class LifeBurden : Katana
    {
        [Constructable]
        public LifeBurden()
        {
            Name = "Life Burden";
            Attributes.AttackChance = 100;
            WeaponAttributes.HitLeechMana = 75;
            Attributes.BonusDex = 25;
            Attributes.BonusInt = 50;
            Attributes.BonusHits = -100;
            Attributes.Luck = 700;
            Attributes.RegenMana = 45;
            Attributes.RegenMana = -50;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 40;
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
        public LifeBurden(Serial serial)
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

// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class CriticalShot : Crossbow
    {
        public override int InitMinHits { get { return 99; } }
        public override int InitMaxHits { get { return 99; } }
        [Constructable]
        public CriticalShot()
        {
            Name = "Critical Shot";
            Hue = 0xae6;
            Attributes.WeaponDamage = 75;
            WeaponAttributes.HitHarm = 100;
            WeaponAttributes.HitLeechStam = 40;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 120;
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
        public CriticalShot(Serial serial)
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

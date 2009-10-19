// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MidnightBlade : Katana
    {
        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public MidnightBlade()
        {
            Name = "Midnight Blade";
            Attributes.WeaponDamage = 75;
            WeaponAttributes.HitLightning = 40;
            WeaponAttributes.HitMagicArrow = 20;
            WeaponAttributes.SelfRepair = 60;
            Attributes.ReflectPhysical = 20;
            Attributes.WeaponSpeed = 140;
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
        public MidnightBlade(Serial serial)
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

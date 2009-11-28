// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class FastShot : RepeatingCrossbow
    {
        public override int InitMinHits { get { return 200; } }
        public override int InitMaxHits { get { return 200; } }
        [Constructable]
        public FastShot()
        {
            Name = "Fast Shot";
            WeaponAttributes.HitLightning = 50;
            WeaponAttributes.HitMagicArrow = 15;
            Attributes.WeaponSpeed = 200;
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
        public FastShot(Serial serial)
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

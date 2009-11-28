// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SamuraiBlade : Bokuto
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 120; } }
        [Constructable]
        public SamuraiBlade()
        {
            Name = "Samurai Blade";

            Attributes.WeaponDamage = 185;
            WeaponAttributes.HitEnergyArea = 20;
            WeaponAttributes.HitLightning = 20;
            WeaponAttributes.HitMagicArrow = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 75;
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
        public SamuraiBlade(Serial serial)
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

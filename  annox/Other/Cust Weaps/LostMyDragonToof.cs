// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class LostMyDragonToof : Kryss
    {
        public override int InitMinHits { get { return 75; } }
        public override int InitMaxHits { get { return 75; } }
        [Constructable]
        public LostMyDragonToof()
        {
            Name = "Lost meh FFFront TooffF";
            WeaponAttributes.HitLightning = 42;
            WeaponAttributes.HitMagicArrow = 100;

            WeaponAttributes.SelfRepair = 10;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 200;
            LootType = LootType.Blessed;
            Slayer = SlayerName.DragonSlaying;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public LostMyDragonToof(Serial serial)
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

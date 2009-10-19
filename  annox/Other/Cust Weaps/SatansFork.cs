// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SatansFork : Pitchfork
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 120; } }
        [Constructable]
        public SatansFork()
        {
            Name = "Satans Fork";

            Attributes.WeaponDamage = 200;
            WeaponAttributes.HitColdArea = 15;
            WeaponAttributes.HitEnergyArea = 15;
            WeaponAttributes.HitLightning = 15;
            WeaponAttributes.HitMagicArrow = 15;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistPoisonBonus = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = -25;
            LootType = LootType.Blessed;
            // Slayer = SlayerName.ArachnidDoon;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public SatansFork(Serial serial)
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

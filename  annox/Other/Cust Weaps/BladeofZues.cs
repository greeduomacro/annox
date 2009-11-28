// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class BladeofZues : VikingSword
    {
        public override int InitMinHits { get { return 100; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public BladeofZues()
        {
            Name = "Blade of Zeus";

            Hue = 0x7af;
            Attributes.WeaponDamage = 250;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitPhysicalArea = 20;
            Attributes.BonusHits = 25;
            StrRequirement = 130;
            Slayer = SlayerName.DragonSlaying;
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
        public BladeofZues(Serial serial)
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

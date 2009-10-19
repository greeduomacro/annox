// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class NorseVikingSword : VikingSword
    {
        public override int InitMinHits { get { return 100; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public NorseVikingSword()
        {
            Name = "Norse Viking Sword";


            Attributes.WeaponDamage = 150;
            Attributes.WeaponSpeed = 20;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitPhysicalArea = 30;
            Attributes.BonusHits = 60;
            StrRequirement = 130;
            Slayer = SlayerName.DragonSlaying;
            Attributes.BonusMana = 50;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 40;
            cold = 0;
            fire = 20;
            nrgy = 40;
            pois = 0;
        }
        public NorseVikingSword(Serial serial)
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

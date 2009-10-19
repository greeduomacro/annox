// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class Fortress : MetalKiteShield
    {
        public override int InitMinHits { get { return 2000; } }
        public override int InitMaxHits { get { return 2000; } }
        [Constructable]
        public Fortress()
        {
            Name = "Fortress";
            ColdBonus = 50;
            EnergyBonus = 50;
            PhysicalBonus = 50;
            PoisonBonus = 50;
            FireBonus = 50;
            Attributes.BonusDex = 5;
            Attributes.BonusHits = 175;
            Attributes.BonusStam = 200;
            Attributes.BonusStr = 25;
            Attributes.CastSpeed = 1;
            Attributes.LowerManaCost = 50;
            Attributes.LowerRegCost = 50;
            Attributes.ReflectPhysical = 50;
            Attributes.RegenHits = 75;
            Attributes.RegenStam = 50;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
        }
        public Fortress(Serial serial)
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

// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class InfiniteMana : QuarterStaff
    {
        public override int InitMinHits { get { return 200; } }
        public override int InitMaxHits { get { return 200; } }
        [Constructable]
        public InfiniteMana()
        {
            Name = "Infinite Mana";
            WeaponAttributes.SelfRepair = 150;
            Attributes.BonusMana = 1000;
            Attributes.CastSpeed = 1;
            Attributes.RegenMana = 100;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 20;
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
        public InfiniteMana(Serial serial)
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

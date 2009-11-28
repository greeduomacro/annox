// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class Dumbfounded : Kryss
    {
        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public Dumbfounded()
        {
            Name = "Dumbfounded";
            Attributes.DefendChance = 25;
            WeaponAttributes.SelfRepair = 400;
            Attributes.BonusDex = 50;
            Attributes.BonusInt = 50;
            Attributes.CastSpeed = 20;
            Attributes.Luck = 200;
            Attributes.ReflectPhysical = 20;
            Attributes.RegenHits = 35;
            Attributes.RegenMana = 50;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 35;


            Attributes.WeaponSpeed = 100;
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
        public Dumbfounded(Serial serial)
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

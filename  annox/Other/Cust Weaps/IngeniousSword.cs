// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class IngeniousSword : Scimitar
    {
        public override int InitMinHits { get { return 125; } }
        public override int InitMaxHits { get { return 125; } }
        [Constructable]
        public IngeniousSword()
        {
            Name = "Ingenious Sword";
            WeaponAttributes.SelfRepair = 180;
            Attributes.BonusInt = 100;
            Attributes.BonusMana = 115;
            Attributes.Luck = 150;
            Attributes.ReflectPhysical = 25;
            Attributes.RegenHits = 75;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 45;
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
        public IngeniousSword(Serial serial)
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

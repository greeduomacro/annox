// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SpellMaster : Scepter
    {
        [Constructable]
        public SpellMaster()
        {
            Name = "Spell Master";
            Attributes.DefendChance = 45;
            Attributes.BonusHits = 60;
            Attributes.BonusInt = 150;
            Attributes.BonusMana = 200;
            Attributes.BonusStam = 50;
            Attributes.CastSpeed = 2;
            Attributes.Luck = 1337;
            Attributes.RegenHits = 25;
            Attributes.RegenMana = 50;
            Attributes.RegenStam = 200;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 60;
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
        public SpellMaster(Serial serial)
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

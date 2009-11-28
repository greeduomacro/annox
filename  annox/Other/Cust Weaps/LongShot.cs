// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class LongShot : CompositeBow
    {
        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public LongShot()
        {
            Name = "Long Shot";

            Attributes.WeaponDamage = 200;
            Attributes.AttackChance = 35;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitMagicArrow = 50;
            WeaponAttributes.SelfRepair = 200;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 300;
            Attributes.NightSight = 1;
            Attributes.RegenHits = 30;
            Attributes.SpellChanneling = 1;
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
        public LongShot(Serial serial)
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

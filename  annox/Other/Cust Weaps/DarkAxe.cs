// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class DarkAxe : LargeBattleAxe
    {
        public override int InitMinHits { get { return 200; } }
        public override int InitMaxHits { get { return 200; } }
        [Constructable]
        public DarkAxe()
        {
            Name = "Dark Axe";
            Attributes.WeaponDamage = 110;
            WeaponAttributes.HitLightning = 20;
            WeaponAttributes.HitMagicArrow = 20;
            WeaponAttributes.SelfRepair = 100;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 15;
            Attributes.BonusMana = 20;
            Attributes.BonusStam = 100;
            Attributes.Luck = 50;
            Attributes.NightSight = 1;
            Attributes.RegenHits = 10;
            Attributes.RegenStam = 35;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 40;
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
        public DarkAxe(Serial serial)
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

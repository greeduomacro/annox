// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class EvilSlayer : NoDachi
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 120; } }
        [Constructable]
        public EvilSlayer()
        {
            Name = "Evil Slayer";
            Attributes.WeaponDamage = 100;
            Attributes.AttackChance = 35;
            WeaponAttributes.HitHarm = 15;
            WeaponAttributes.HitMagicArrow = 15;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusDex = 5;
            Attributes.BonusHits = 60;
            Attributes.BonusMana = 35;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 20;
            Attributes.RegenHits = 25;
            Attributes.RegenMana = 15;
            Attributes.RegenStam = 15;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 100;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Exorcism;

        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public EvilSlayer(Serial serial)
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

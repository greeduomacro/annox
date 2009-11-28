// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class DeathClaw : WarFork
    {
        public override int InitMinHits { get { return 500; } }
        public override int InitMaxHits { get { return 600; } }
        [Constructable]
        public DeathClaw()
        {
            Name = "Death Claw";
            Attributes.WeaponDamage = 75;
            Attributes.AttackChance = 25;
            Attributes.DefendChance = 35;
            WeaponAttributes.HitLightning = 20;
            WeaponAttributes.HitMagicArrow = 20;
            WeaponAttributes.SelfRepair = 100;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusDex = 5;
            Attributes.BonusHits = 50;
            Attributes.CastSpeed = 1;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 20;
            Attributes.RegenHits = 40;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 50;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Silver;

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
        public DeathClaw(Serial serial)
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

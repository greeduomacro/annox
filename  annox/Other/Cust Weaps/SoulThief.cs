// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SoulThief : BoneHarvester
    {
        public override int InitMinHits { get { return 350; } }
        public override int InitMaxHits { get { return 350; } }
        [Constructable]
        public SoulThief()
        {
            Name = "Soul Thief";
            WeaponAttributes.HitColdArea = 20;
            WeaponAttributes.HitDispel = 50;
            WeaponAttributes.HitEnergyArea = 20;
            WeaponAttributes.HitHarm = 20;
            WeaponAttributes.HitLightning = 20;
            WeaponAttributes.HitLowerAttack = 20;
            WeaponAttributes.HitMagicArrow = 20;
            WeaponAttributes.HitPhysicalArea = 20;
            WeaponAttributes.SelfRepair = 250;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 25;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 15;
            Attributes.RegenHits = 15;
            Attributes.RegenStam = 100;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Repond;
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
        public SoulThief(Serial serial)
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

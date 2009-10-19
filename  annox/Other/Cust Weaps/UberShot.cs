// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class UberShot : Bow
    {
        public override int InitMinHits { get { return 200; } }
        public override int InitMaxHits { get { return 200; } }
        [Constructable]
        public UberShot()
        {
            Name = "Uber Shot";
            Attributes.WeaponDamage = 75;
            Attributes.AttackChance = 20;
            Attributes.DefendChance = 20;
            WeaponAttributes.HitColdArea = 100;
            WeaponAttributes.HitDispel = 100;
            WeaponAttributes.HitLeechHits = 35;
            WeaponAttributes.HitLeechMana = 35;
            WeaponAttributes.HitLightning = 25;
            WeaponAttributes.HitMagicArrow = 25;
            WeaponAttributes.LowerStatReq = 30;
            WeaponAttributes.SelfRepair = 75;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusDex = 10;
            Attributes.BonusHits = 30;
            Attributes.BonusInt = 20;
            Attributes.BonusMana = 20;
            Attributes.BonusStam = 75;
            Attributes.Luck = 75;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 15;
            Attributes.RegenHits = 20;
            Attributes.RegenMana = 20;
            Attributes.RegenStam = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 25;
            LootType = LootType.Blessed;
            Slayer = SlayerName.OrcSlaying;

        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public UberShot(Serial serial)
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

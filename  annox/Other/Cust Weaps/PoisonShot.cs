// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class PoisonShot : HeavyCrossbow
    {
        public override int InitMinHits { get { return 65; } }
        public override int InitMaxHits { get { return 65; } }
        [Constructable]
        public PoisonShot()
        {
            Name = "Poison Shot";
            Attributes.WeaponDamage = 45;
            WeaponAttributes.HitColdArea = 15;
            WeaponAttributes.HitDispel = 8;
            WeaponAttributes.HitEnergyArea = 5;
            WeaponAttributes.HitHarm = 8;
            Hue = 0xb5b;
            WeaponAttributes.HitLeechHits = 10;
            WeaponAttributes.HitLeechMana = 7;
            WeaponAttributes.HitLeechStam = 7;
            WeaponAttributes.HitLightning = 5;
            WeaponAttributes.HitLowerAttack = 5;
            WeaponAttributes.HitMagicArrow = 9;
            WeaponAttributes.HitPhysicalArea = 5;
            WeaponAttributes.HitPoisonArea = 50;
            WeaponAttributes.LowerStatReq = 5;
            WeaponAttributes.ResistColdBonus = 5;
            WeaponAttributes.ResistEnergyBonus = 5;
            WeaponAttributes.SelfRepair = 2;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 70;
            Attributes.BonusMana = 68;
            Attributes.ReflectPhysical = 5;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 10;
            Attributes.WeaponSpeed = 40;
            DexRequirement = 5;
            IntRequirement = 24;
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
        public PoisonShot(Serial serial)
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

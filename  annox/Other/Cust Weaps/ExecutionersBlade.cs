// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class ExecutionersBlade : ExecutionersAxe
    {
        public override int InitMinHits { get { return 90; } }
        public override int InitMaxHits { get { return 90; } }
        [Constructable]
        public ExecutionersBlade()
        {
            Name = "Executioners Blade";

            Attributes.WeaponDamage = 200;
            WeaponAttributes.HitColdArea = 10;
            this.Layer = Layer.OneHanded;
            WeaponAttributes.HitDispel = 10;
            WeaponAttributes.HitEnergyArea = 10;
            WeaponAttributes.HitLeechHits = 20;
            WeaponAttributes.HitLightning = 10;
            WeaponAttributes.HitLowerAttack = 10;
            WeaponAttributes.HitMagicArrow = 10;
            WeaponAttributes.HitPhysicalArea = 10;
            WeaponAttributes.HitPoisonArea = 10;
            Attributes.WeaponSpeed = -50;
            WeaponAttributes.ResistColdBonus = 40;
            WeaponAttributes.ResistEnergyBonus = 40;
            WeaponAttributes.ResistPhysicalBonus = 30;
            WeaponAttributes.ResistPoisonBonus = 40;
            WeaponAttributes.ResistFireBonus = 20;
            WeaponAttributes.SelfRepair = 25;
            Attributes.BonusHits = 170;
            Attributes.BonusMana = 100;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 25;
            StrRequirement = 150;
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
        public ExecutionersBlade(Serial serial)
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

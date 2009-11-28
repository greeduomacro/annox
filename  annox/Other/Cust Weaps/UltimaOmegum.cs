// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class UltimaOmegum : CrescentBlade
    {
        public override int InitMinHits { get { return 75; } }
        public override int InitMaxHits { get { return 75; } }

        [Constructable]
        public UltimaOmegum()
        {
            Name = "Ultima Omegum";

            Attributes.WeaponDamage = 200;
            WeaponAttributes.HitLeechHits = 50;
            WeaponAttributes.HitLeechMana = 50;
            WeaponAttributes.HitLightning = 75;
            this.Layer = Layer.OneHanded;
            WeaponAttributes.HitMagicArrow = 75;
            WeaponAttributes.HitFireball = 75;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 13;
            WeaponAttributes.ResistPoisonBonus = 32;
            WeaponAttributes.ResistFireBonus = 42;
            WeaponAttributes.SelfRepair = 75;
            Attributes.BonusHits = 160;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 150;
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
        public UltimaOmegum(Serial serial)
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

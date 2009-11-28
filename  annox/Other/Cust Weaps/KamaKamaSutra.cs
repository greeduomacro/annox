// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class KamaKamaSutra : Kama
    {
        public override int InitMinHits { get { return 129; } }
        public override int InitMaxHits { get { return 130; } }
        [Constructable]
        public KamaKamaSutra()
        {
            Name = "Kama, Kama Sutra";
            Attributes.WeaponDamage = 50;
            WeaponAttributes.HitColdArea = 15;
            Hue = 0x7aa;
            WeaponAttributes.HitEnergyArea = 15;
            WeaponAttributes.HitHarm = 15;
            WeaponAttributes.HitLeechHits = 10;
            WeaponAttributes.HitLightning = 15;
            Attributes.CastRecovery = 7;
            WeaponAttributes.ResistColdBonus = 25;
            WeaponAttributes.ResistPoisonBonus = 30;
            WeaponAttributes.SelfRepair = 50;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.ReflectPhysical = 30;
            Attributes.SpellChanneling = 1;
            IntRequirement = 30;
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
        public KamaKamaSutra(Serial serial)
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

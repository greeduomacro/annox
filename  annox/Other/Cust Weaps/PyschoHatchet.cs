// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class PsychoHatchet : Hatchet
    {
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }
        [Constructable]
        public PsychoHatchet()
        {
            Name = "Psycho Hatchet";

            Hue = 0x481;
            this.Layer = Layer.OneHanded;
            Attributes.WeaponDamage = 150;
            WeaponAttributes.HitColdArea = 20;
            WeaponAttributes.HitPhysicalArea = 20;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPoisonBonus = 50;
            WeaponAttributes.ResistFireBonus = 70;
            WeaponAttributes.SelfRepair = 50;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 100;
            Attributes.WeaponSpeed = 100;
            StrRequirement = 130;
            WeaponAttributes.HitFireball = 20;
            WeaponAttributes.HitLightning = 40;
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
        public PsychoHatchet(Serial serial)
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

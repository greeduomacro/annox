// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class BerzerkingAxe : WarAxe
    {
        [Constructable]
        public BerzerkingAxe()
        {
            Name = "Berzerking Axe";


            Hue = 0x9ab;
            Attributes.WeaponDamage = 175;
            WeaponAttributes.HitColdArea = 5;
            WeaponAttributes.HitEnergyArea = 5;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLeechStam = 25;
            WeaponAttributes.HitLightning = 35;
            WeaponAttributes.HitPhysicalArea = 75;
            WeaponAttributes.ResistFireBonus = 70;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 150;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 40;
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
        public BerzerkingAxe(Serial serial)
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

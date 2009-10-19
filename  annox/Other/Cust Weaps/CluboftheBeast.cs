// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class CluboftheBeast : Club
    {
        public override int InitMinHits { get { return 150; } }
        public override int InitMaxHits { get { return 150; } }
        [Constructable]
        public CluboftheBeast()
        {
            Name = "Club of the Beast";

            Attributes.WeaponDamage = 180;
            WeaponAttributes.HitColdArea = 15;
            WeaponAttributes.HitDispel = 15;
            WeaponAttributes.HitEnergyArea = 15;
            WeaponAttributes.HitHarm = 15;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLeechMana = 25;
            WeaponAttributes.HitLightning = 15;
            WeaponAttributes.HitLowerAttack = 15;
            WeaponAttributes.HitMagicArrow = 15;
            WeaponAttributes.HitPhysicalArea = 15;
            WeaponAttributes.ResistColdBonus = 30;
            WeaponAttributes.ResistEnergyBonus = 15;
            WeaponAttributes.ResistPhysicalBonus = 30;
            WeaponAttributes.ResistPoisonBonus = 20;
            WeaponAttributes.ResistFireBonus = 5;
            WeaponAttributes.SelfRepair = 30;
            Attributes.BonusHits = 150;
            Attributes.BonusMana = 50;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 35;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 50;
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
        public CluboftheBeast(Serial serial)
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

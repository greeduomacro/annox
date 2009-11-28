// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class BloodLust : DoubleBladedStaff
    {
        public override int InitMinHits { get { return 125; } }
        public override int InitMaxHits { get { return 125; } }
        [Constructable]
        public BloodLust()
        {
            Name = "Blood Lust";
            Attributes.WeaponDamage = 60;
            Attributes.AttackChance = 30;
            Attributes.DefendChance = 25;
            WeaponAttributes.HitLeechHits = 35;
            WeaponAttributes.HitMagicArrow = 35;
            WeaponAttributes.SelfRepair = 35;
            Attributes.BonusDex = 15;
            Attributes.RegenHits = 35;
            Attributes.WeaponSpeed = 50;
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
        public BloodLust(Serial serial)
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

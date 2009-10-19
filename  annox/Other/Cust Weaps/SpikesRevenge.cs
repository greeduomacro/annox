// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SpikesRevenge : LargeBattleAxe
    {
        public override int InitMinHits { get { return 502; } }
        public override int InitMaxHits { get { return 502; } }
        [Constructable]
        public SpikesRevenge()
        {
            Name = "Spikes Revenge";
            Attributes.WeaponDamage = 50;
            Attributes.AttackChance = 25;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitMagicArrow = 50;
            WeaponAttributes.SelfRepair = 100;
            Attributes.BonusDex = 10;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 75;
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
        public SpikesRevenge(Serial serial)
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

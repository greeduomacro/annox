// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MinersPickaxe : HammerPick
    {
        public override int InitMinHits { get { return 1337; } }
        public override int InitMaxHits { get { return 1337; } }
        [Constructable]
        public MinersPickaxe()
        {
            Name = "Miners Pickaxe";
            Attributes.WeaponDamage = 125;
            Attributes.AttackChance = 25;
            Attributes.DefendChance = 35;
            WeaponAttributes.HitDispel = 35;
            WeaponAttributes.HitLightning = 35;
            WeaponAttributes.HitLowerAttack = 35;
            WeaponAttributes.HitMagicArrow = 35;
            WeaponAttributes.SelfRepair = 200;
            Attributes.BonusHits = 75;
            Attributes.Luck = 500;
            Attributes.ReflectPhysical = 15;
            Attributes.RegenHits = 35;
            Attributes.WeaponSpeed = 20;
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
        public MinersPickaxe(Serial serial)
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

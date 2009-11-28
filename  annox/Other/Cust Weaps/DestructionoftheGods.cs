// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class DestructionoftheGods : VikingSword
    {
        public override int InitMinHits { get { return 175; } }
        public override int InitMaxHits { get { return 175; } }
        [Constructable]
        public DestructionoftheGods()
        {
            Name = "Destruction of the Gods";
            Attributes.WeaponDamage = 150;
            Attributes.AttackChance = 40;
            Attributes.DefendChance = 35;
            WeaponAttributes.HitDispel = 25;
            WeaponAttributes.HitHarm = 50;
            WeaponAttributes.HitLeechHits = 40;
            WeaponAttributes.HitLeechMana = 40;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitFireball = 60;
            WeaponAttributes.HitMagicArrow = 100;
            WeaponAttributes.HitLowerAttack = 50;
            WeaponAttributes.ResistColdBonus = 50;
            WeaponAttributes.ResistEnergyBonus = 50;
            WeaponAttributes.ResistPhysicalBonus = 50;
            WeaponAttributes.ResistPoisonBonus = 50;
            WeaponAttributes.ResistFireBonus = 50;
            WeaponAttributes.SelfRepair = 175;
            Attributes.BonusDex = 15;
            Attributes.CastSpeed = 1;
            Attributes.ReflectPhysical = 40;
            Attributes.RegenHits = 40;
            Attributes.WeaponSpeed = 100;
            LootType = LootType.Blessed;

        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 25;
            cold = 25;
            fire = 0;
            nrgy = 50;
            pois = 0;
            chaos = direct = 0;
        }
        public DestructionoftheGods(Serial serial)
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

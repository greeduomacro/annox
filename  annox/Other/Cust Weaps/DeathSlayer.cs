// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class DeathSlayer : BattleAxe
    {
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }
        [Constructable]
        public DeathSlayer()
        {
            Name = "Death Slayer";
            Attributes.WeaponDamage = 50;
            Attributes.AttackChance = 25;
            Attributes.DefendChance = 10;
            WeaponAttributes.HitFireArea = 10;
            WeaponAttributes.HitLightning = 75;
            WeaponAttributes.HitMagicArrow = 25;
            WeaponAttributes.ResistColdBonus = 25;
            WeaponAttributes.ResistPhysicalBonus = 25;
            WeaponAttributes.SelfRepair = 125;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusDex = 5;
            Attributes.Luck = 700;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 15;
            Attributes.RegenHits = 15;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 50;
            LootType = LootType.Blessed;
            Slayer = SlayerName.DragonSlaying;

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
        public DeathSlayer(Serial serial)
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

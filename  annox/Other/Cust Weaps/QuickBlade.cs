// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class QuickBlade : Katana
    {
        public override int InitMinHits { get { return 50; } }
        public override int InitMaxHits { get { return 100; } }
        [Constructable]
        public QuickBlade()
        {

            Name = "QuickBlade";
            WeaponAttributes.HitHarm = 10;
            WeaponAttributes.HitLeechHits = 25;
            WeaponAttributes.HitLowerAttack = 10;
            WeaponAttributes.MageWeapon = 1;
            WeaponAttributes.ResistFireBonus = 30;
            WeaponAttributes.SelfRepair = 10;
            Attributes.BonusHits = 50;
            Attributes.ReflectPhysical = 10;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 20;
            Attributes.WeaponSpeed = 150;
            LootType = LootType.Blessed;
            Slayer = SlayerName.DragonSlaying;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 50;
            cold = 0;
            fire = 50;
            nrgy = 0;
            pois = 0;
        }
        public QuickBlade(Serial serial)
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

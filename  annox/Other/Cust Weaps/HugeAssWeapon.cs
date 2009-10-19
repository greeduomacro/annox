// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class HugeAssWeapon : Lance
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 100; } }
        [Constructable]
        public HugeAssWeapon()
        {
            Name = "Huge Ass Weapon";

            Attributes.WeaponDamage = 300;
            WeaponAttributes.ResistColdBonus = 30;
            WeaponAttributes.ResistPoisonBonus = 42;
            WeaponAttributes.ResistFireBonus = 36;
            WeaponAttributes.SelfRepair = 20;
            Attributes.BonusHits = 100;
            Attributes.ReflectPhysical = 15;
            Attributes.SpellChanneling = 1;
            LootType = LootType.Blessed;
            Slayer = SlayerName.SpidersDeath;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public HugeAssWeapon(Serial serial)
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

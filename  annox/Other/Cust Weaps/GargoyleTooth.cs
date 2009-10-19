// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class GargoyleTooth : ShortSpear
    {
        public override int InitMinHits { get { return 75; } }
        public override int InitMaxHits { get { return 75; } }
        [Constructable]
        public GargoyleTooth()
        {
            Name = "Gargoyle Tooth";

            Attributes.WeaponDamage = 75;
            WeaponAttributes.HitEnergyArea = 100;
            WeaponAttributes.HitHarm = 100;
            WeaponAttributes.HitLeechHits = 30;
            WeaponAttributes.HitLeechMana = 30;
            WeaponAttributes.ResistColdBonus = 30;
            this.Layer = Layer.OneHanded;
            WeaponAttributes.ResistPoisonBonus = 30;
            WeaponAttributes.ResistFireBonus = 30;
            WeaponAttributes.SelfRepair = 75;
            Attributes.NightSight = 1;
            Attributes.ReflectPhysical = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 100;
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
        public GargoyleTooth(Serial serial)
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

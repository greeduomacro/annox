// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class DeathSword : NoDachi
    {
        public override int InitMinHits { get { return 85; } }
        public override int InitMaxHits { get { return 85; } }
        [Constructable]
        public DeathSword()
        {
            Name = "Death Sword";

            Attributes.WeaponDamage = 130;
            WeaponAttributes.HitLightning = 60;
            WeaponAttributes.HitMagicArrow = 60;
            WeaponAttributes.ResistFireBonus = 65;
            WeaponAttributes.SelfRepair = 10;
            Attributes.BonusHits = 70;
            Attributes.BonusMana = 20;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 80;
            LootType = LootType.Blessed;
            this.Layer = Layer.OneHanded;
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
        public DeathSword(Serial serial)
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

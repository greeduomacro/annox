// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class SharpBow : Bow
    {
        public override int InitMinHits { get { return 120; } }
        public override int InitMaxHits { get { return 120; } }
        [Constructable]
        public SharpBow()
        {
            Name = "Sharp Bow";
            Attributes.WeaponDamage = 85;
            WeaponAttributes.HitHarm = 50;
            WeaponAttributes.HitLowerAttack = 50;
            WeaponAttributes.ResistColdBonus = 50;
            WeaponAttributes.ResistFireBonus = 100;
            WeaponAttributes.SelfRepair = 10;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.CastSpeed = 2;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 75;
            StrRequirement = 10;
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
        public SharpBow(Serial serial)
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

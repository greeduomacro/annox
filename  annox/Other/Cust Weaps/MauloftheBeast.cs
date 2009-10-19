// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MauloftheBeast : WarHammer
    {
        public override int InitMinHits { get { return 220; } }
        public override int InitMaxHits { get { return 220; } }
        [Constructable]
        public MauloftheBeast()
        {
            Name = "Maul of the Beast";

            Attributes.WeaponDamage = 70;
            WeaponAttributes.HitHarm = 100;
            WeaponAttributes.HitMagicArrow = 100;
            WeaponAttributes.ResistColdBonus = 35;
            WeaponAttributes.ResistPoisonBonus = 35;
            WeaponAttributes.SelfRepair = 25;
            Attributes.BonusHits = 50;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 70;
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
        public MauloftheBeast(Serial serial)
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

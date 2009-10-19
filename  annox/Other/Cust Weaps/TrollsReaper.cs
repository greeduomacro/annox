// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class TrollsReaper : Scythe
    {
        public override int InitMinHits { get { return 180; } }
        public override int InitMaxHits { get { return 180; } }
        [Constructable]
        public TrollsReaper()
        {
            Name = "Trolls Reaper";

            Hue = 0x7CA;
            Attributes.WeaponDamage = 666;
            WeaponAttributes.HitHarm = 100;
            WeaponAttributes.HitLeechHits = 100;
            WeaponAttributes.ResistColdBonus = 70;
            WeaponAttributes.ResistEnergyBonus = 30;
            WeaponAttributes.ResistPhysicalBonus = 20;
            WeaponAttributes.ResistFireBonus = 20;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 75;
            Attributes.BonusMana = 75;
            Attributes.SpellChanneling = 1;
            IntRequirement = 10;
            Attributes.WeaponSpeed = -200;
            StrRequirement = 80;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Exorcism;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public TrollsReaper(Serial serial)
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

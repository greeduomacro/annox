// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class StaffofMoses : BlackStaff
    {
        public override int InitMinHits { get { return 20; } }
        public override int InitMaxHits { get { return 20; } }
        [Constructable]
        public StaffofMoses()
        {
            Name = "Staff Of Moses";
            Hue = 0x984;
            WeaponAttributes.ResistColdBonus = 70;
            WeaponAttributes.ResistFireBonus = 70;
            WeaponAttributes.SelfRepair = 100;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 120;
            Attributes.BonusMana = 50;
            Attributes.CastRecovery = 5;
            Attributes.CastSpeed = 3;
            SkillBonuses.SetValues(0, SkillName.Magery, 30.0);
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 35;
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
        public StaffofMoses(Serial serial)
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

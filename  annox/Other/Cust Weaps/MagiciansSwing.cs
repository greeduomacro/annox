// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MagiciansSwing : Nunchaku
    {
        public override int InitMinHits { get { return 50; } }
        public override int InitMaxHits { get { return 50; } }
        [Constructable]
        public MagiciansSwing()
        {
            Name = "Magicians Swing";
            WeaponAttributes.HitLeechMana = 50;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitMagicArrow = 100;
            WeaponAttributes.SelfRepair = 100;
            Attributes.BonusMana = 100;
            Attributes.CastSpeed = 2;

            SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
            Attributes.CastRecovery = 5;
            Attributes.SpellChanneling = 1;
            Attributes.SpellDamage = 40;
            LootType = LootType.Blessed;
            // Slayer = SlayerName.ReptilianDeather;
        }
        public override void GetDamageTypes(Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy)
        {
            phys = 100;
            cold = 0;
            fire = 0;
            nrgy = 0;
            pois = 0;
        }
        public MagiciansSwing(Serial serial)
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

// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class GiantBone : ShortSpear
    {
        public override int InitMinHits { get { return 240; } }
        public override int InitMaxHits { get { return 240; } }
        [Constructable]
        public GiantBone()
        {
            Name = "Giant Bone";
            Attributes.WeaponDamage = 200;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitMagicArrow = 100;
            WeaponAttributes.SelfRepair = 260;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusDex = 15;
            Attributes.BonusHits = 75;
            Attributes.NightSight = 1;
            Attributes.RegenHits = 40;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 75;
            LootType = LootType.Blessed;
            Slayer = SlayerName.OgreTrashing;

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
        public GiantBone(Serial serial)
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

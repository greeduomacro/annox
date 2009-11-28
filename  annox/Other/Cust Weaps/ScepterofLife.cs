// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class ScepterofLife : Scepter
    {
        public override int InitMinHits { get { return 750; } }
        public override int InitMaxHits { get { return 750; } }
        [Constructable]
        public ScepterofLife()
        {
            Name = "Scepter of Life";
            Attributes.WeaponDamage = 20;
            WeaponAttributes.HitLeechHits = 50;
            WeaponAttributes.HitLightning = 50;
            WeaponAttributes.HitMagicArrow = 50;
            WeaponAttributes.SelfRepair = 180;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 150;
            Attributes.NightSight = 1;
            Attributes.RegenHits = 35;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 25;
            LootType = LootType.Blessed;
            Slayer = SlayerName.DragonSlaying;

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
        public ScepterofLife(Serial serial)
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

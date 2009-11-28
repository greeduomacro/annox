// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class ToothPick : ThinLongsword
    {
        public override int InitMinHits { get { return 10; } }
        public override int InitMaxHits { get { return 10; } }
        [Constructable]
        public ToothPick()
        {
            Name = "Tooth Pick";
            Attributes.WeaponDamage = 50;

            Hue = 0x494;
            WeaponAttributes.HitColdArea = 50;
            WeaponAttributes.ResistColdBonus = 20;
            WeaponAttributes.ResistPoisonBonus = 20;
            Attributes.SpellChanneling = 1;
            WeaponAttributes.SelfRepair = 5;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.CastRecovery = 2;
            Attributes.WeaponSpeed = 150;
            StrRequirement = 75;
            Slayer = SlayerName.Terathan;
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
        public ToothPick(Serial serial)
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

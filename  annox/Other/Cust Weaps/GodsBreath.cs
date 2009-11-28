// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class GodsBreath : RepeatingCrossbow
    {
        public override int InitMinHits { get { return 100; } }
        public override int InitMaxHits { get { return 100; } }
        [Constructable]
        public GodsBreath()
        {
            Name = "Gods Breath";
            Attributes.WeaponDamage = 50;
            WeaponAttributes.HitHarm = 20;
            Hue = 0x8b8;
            WeaponAttributes.HitLeechMana = 10;
            WeaponAttributes.HitLeechStam = 20;
            WeaponAttributes.HitPhysicalArea = 75;
            WeaponAttributes.LowerStatReq = 100;
            WeaponAttributes.ResistColdBonus = 30;
            WeaponAttributes.ResistPhysicalBonus = 40;
            WeaponAttributes.SelfRepair = 25;
            WeaponAttributes.UseBestSkill = 1;
            Attributes.BonusHits = 50;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 75;
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
        public GodsBreath(Serial serial)
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

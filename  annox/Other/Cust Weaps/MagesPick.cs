// Created by Script Creator
// From Aries at Revenge of the Gods
using System;
using Server;
namespace Server.Items
{
    public class MagesPick : HammerPick
    {
        public override int InitMinHits { get { return 75; } }
        public override int InitMaxHits { get { return 75; } }
        [Constructable]
        public MagesPick()
        {
            Name = "Mages Pick";
            WeaponAttributes.HitHarm = 20;
            WeaponAttributes.ResistColdBonus = 50;
            WeaponAttributes.ResistPoisonBonus = 70;
            WeaponAttributes.SelfRepair = 75;
            Attributes.BonusMana = 50;
            Attributes.CastSpeed = 1;
            Attributes.Luck = 200;
            Attributes.ReflectPhysical = 25;
            Attributes.RegenHits = 50;
            Attributes.SpellDamage = 40;
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
        public MagesPick(Serial serial)
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

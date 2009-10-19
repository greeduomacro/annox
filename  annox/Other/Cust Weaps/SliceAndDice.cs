using System;
using Server;

namespace Server.Items
{
    public class SliceAndDice : Katana
    {
        public override int ArtifactRarity { get { return 65; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public SliceAndDice()
        {
            Name = "Slice And Dice";
            Hue = 0x4F2;
            WeaponAttributes.HitLeechHits = 100;
            WeaponAttributes.HitLeechStam = 100;
            Attributes.BonusDex = 15;
            Attributes.RegenStam = 15;
            Attributes.WeaponSpeed = 85;
            Attributes.WeaponDamage = 150;
        }

        public SliceAndDice(Serial serial)
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
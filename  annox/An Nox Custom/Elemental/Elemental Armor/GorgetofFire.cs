using System;
using Server;

namespace Server.Items
{
    public class GorgetofFire : PlateGorget
    {
        public override int LabelNumber { get { return 1061594; } } // Gauntlets of Nobility 
        public override int ArtifactRarity { get { return 11; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public GorgetofFire()
        {
            Weight = 6.0;
            Name = "Gorget of Fire";
            Hue = 1161;
            ArmorAttributes.SelfRepair = 5;
            // TODO: Night Sight 
            Attributes.ReflectPhysical = 15;
            PhysicalBonus = 20;
            FireBonus = 30;
        }
        public GorgetofFire(Serial serial)
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
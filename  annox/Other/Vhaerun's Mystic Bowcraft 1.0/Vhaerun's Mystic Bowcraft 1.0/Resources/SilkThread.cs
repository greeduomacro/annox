using System;

namespace Server.Items
{
    public class SilkThread : Item
    {
        [Constructable]
        public SilkThread()
            : base(0xFA1)
        {
            Weight = 0.2;
            Stackable = true;
            Name = "Silk Thread";
            Hue = 0x482;

        }

        public SilkThread(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }
    }
}
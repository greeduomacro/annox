// 06APR2006 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;

namespace Server.Items
{
    public class WhiteFlowersLeft : Item
    {
        [Constructable]
        public WhiteFlowersLeft()
            : base(0x0C8B)
        {
            Weight = 1000;
            Movable = false;
        }

        public WhiteFlowersLeft(Serial serial)
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
    public class WhiteFlowerRight : Item
    {
        [Constructable]
        public WhiteFlowerRight()
            : base(0x0C8C)
        {
            Weight = 1000;
            Movable = false;
        }

        public WhiteFlowerRight(Serial serial)
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
    public class WhitePoppies : Item
    {
        [Constructable]
        public WhitePoppies()
            : base(0x0C8D)
        {
            Weight = 1000;
            Movable = false;
        }

        public WhitePoppies(Serial serial)
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
    public class Snowdrops : Item
    {
        [Constructable]
        public Snowdrops()
            : base(0x0C88)
        {
            Weight = 1000;
            Movable = false;
        }

        public Snowdrops(Serial serial)
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
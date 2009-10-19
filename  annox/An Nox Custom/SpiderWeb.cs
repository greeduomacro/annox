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
    public class SmallWebEast : Item
    {
        [Constructable]
        public SmallWebEast()
            : base(0x10D2)
        {
            Weight = 1000;
        }

        public SmallWebEast(Serial serial)
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
    public class SmallWebWest : Item
    {
        [Constructable]
        public SmallWebWest()
            : base(0x10D3)
        {
            Weight = 1000;
        }

        public SmallWebWest(Serial serial)
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
    public class SmallWebNorth : Item
    {
        [Constructable]
        public SmallWebNorth()
            : base(0x10D4)
        {
            Weight = 1000;
        }

        public SmallWebNorth(Serial serial)
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
    public class SmallWebSouth : Item
    {
        [Constructable]
        public SmallWebSouth()
            : base(0x10D5)
        {
            Weight = 1000;
        }

        public SmallWebSouth(Serial serial)
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
    public class SmallWebLeft : Item
    {
        [Constructable]
        public SmallWebLeft()
            : base(0x10D6)
        {
            Weight = 1000;
        }

        public SmallWebLeft(Serial serial)
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
    public class SmallWebRight : Item
    {
        [Constructable]
        public SmallWebRight()
            : base(0x10D7)
        {
            Weight = 1000;
        }

        public SmallWebRight(Serial serial)
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
    public class SmallWebHole : Item
    {
        [Constructable]
        public SmallWebHole()
            : base(0x10DD)
        {
            Weight = 1000;
        }

        public SmallWebHole(Serial serial)
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
    public class Cocoon : Item
    {
        [Constructable]
        public Cocoon()
            : base(0x10DA)
        {
            Weight = 1000;
        }

        public Cocoon(Serial serial)
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
    public class EggCaseWeb : Item
    {
        [Constructable]
        public EggCaseWeb()
            : base(0x10D9)
        {
            Weight = 1000;
        }

        public EggCaseWeb(Serial serial)
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
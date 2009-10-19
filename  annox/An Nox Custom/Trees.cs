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
    public class OakTreeBare : Item
    {
        [Constructable]
        public OakTreeBare()
            : base(0x224D)
        {
            Weight = 1000;
        }

        public OakTreeBare(Serial serial)
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
    public class OakTreeBareWide : Item
    {
        [Constructable]
        public OakTreeBareWide()
            : base(0x0CDD)
        {
            Weight = 1000;
        }

        public OakTreeBareWide(Serial serial)
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
    public class WarmBrownTreeBare : Item
    {
        [Constructable]
        public WarmBrownTreeBare()
            : base(0x0CD0)
        {
            Weight = 1000;
        }

        public WarmBrownTreeBare(Serial serial)
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
    public class GreyNoFoilage : Item
    {
        [Constructable]
        public GreyNoFoilage()
            : base(0x0CCD)
        {
            Weight = 1000;
        }

        public GreyNoFoilage(Serial serial)
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
    public class WalnutTreeBare : Item
    {
        [Constructable]
        public WalnutTreeBare()
            : base(0x0CCD)
        {
            Weight = 1000;
        }

        public WalnutTreeBare(Serial serial)
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
    public class WillowTreeBare : Item
    {
        [Constructable]
        public WillowTreeBare()
            : base(0x0CCD)
        {
            Weight = 1000;
        }

        public WillowTreeBare(Serial serial)
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
    public class GoldenWillowTreeBare : Item
    {
        [Constructable]
        public GoldenWillowTreeBare()
            : base(0x224B)
        {
            Weight = 1000;
        }

        public GoldenWillowTreeBare(Serial serial)
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
    public class AppleTreeBare : Item
    {
        [Constructable]
        public AppleTreeBare()
            : base(0x0D98)
        {
            Weight = 1000;
        }

        public AppleTreeBare(Serial serial)
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
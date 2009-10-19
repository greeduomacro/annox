using System;

namespace Server.Items
{
    [Furniture]
    [Flipable(0x1E61, 0X1E689)]
    public class MountedTropheyStag : Item
    {
        [Constructable]
        public MountedTropheyStag()
            : base(0x1E61)
        {
            Weight = 20.0;
        }

        public MountedTropheyStag(Serial serial)
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

    [Furniture]
    [Flipable(0x1E62, 0X1E69)]
    public class MountedTropheyFish : Item
    {
        [Constructable]
        public MountedTropheyFish()
            : base(0x1E62)
        {
            Weight = 20.0;
        }

        public MountedTropheyFish(Serial serial)
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

    [Furniture]
    [Flipable(0x1E63, 0X1E6A)]
    public class MountedTropheyOrge : Item
    {
        [Constructable]
        public MountedTropheyOrge()
            : base(0x1E63)
        {
            Weight = 20.0;
        }

        public MountedTropheyOrge(Serial serial)
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

    [Furniture]
    [Flipable(0x1E64, 0X1E6B)]
    public class MountedTropheyOrc : Item
    {
        [Constructable]
        public MountedTropheyOrc()
            : base(0x1E64)
        {
            Weight = 20.0;
        }

        public MountedTropheyOrc(Serial serial)
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

    [Furniture]
    [Flipable(0x1E65, 0X1E6C)]
    public class MountedTropheyPolarBear : Item
    {
        [Constructable]
        public MountedTropheyPolarBear()
            : base(0x1E65)
        {
            Weight = 20.0;
        }

        public MountedTropheyPolarBear(Serial serial)
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

    [Furniture]
    [Flipable(0x1E66, 0X1E6D)]
    public class MountedTropheyTroll : Item
    {
        [Constructable]
        public MountedTropheyTroll()
            : base(0x1E66)
        {
            Weight = 20.0;
        }

        public MountedTropheyTroll(Serial serial)
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

    [Furniture]
    [Flipable(0x2A71, 0X2A72)]
    public class MountedTropheyPixieYellow : Item
    {
        [Constructable]
        public MountedTropheyPixieYellow()
            : base(0x2A71)
        {
            Weight = 20.0;
        }

        public MountedTropheyPixieYellow(Serial serial)
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

    [Furniture]
    [Flipable(0x2A73, 0X2A74)]
    public class MountedTropheyPixieOrange : Item
    {
        [Constructable]
        public MountedTropheyPixieOrange()
            : base(0x2A73)
        {
            Weight = 20.0;
        }

        public MountedTropheyPixieOrange(Serial serial)
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

    [Furniture]
    [Flipable(0x2A75, 0X2A76)]
    public class MountedTropheyPixieBlue : Item
    {
        [Constructable]
        public MountedTropheyPixieBlue()
            : base(0x2A75)
        {
            Weight = 20.0;
        }

        public MountedTropheyPixieBlue(Serial serial)
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

    [Furniture]
    [Flipable(0x2A77, 0X2A78)]
    public class MountedTropheyPixieGreen : Item
    {
        [Constructable]
        public MountedTropheyPixieGreen()
            : base(0x2A77)
        {
            Weight = 20.0;
        }

        public MountedTropheyPixieGreen(Serial serial)
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

    [Furniture]
    [Flipable(0x2A79, 0X2A7A)]
    public class MountedTropheyPixiePink : Item
    {
        [Constructable]
        public MountedTropheyPixiePink()
            : base(0x2A79)
        {
            Weight = 20.0;
        }

        public MountedTropheyPixiePink(Serial serial)
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

    [Furniture]
    [Flipable(0x3159, 0X3158)]
    public class MountedTropheyDreadHorn : Item
    {
        [Constructable]
        public MountedTropheyDreadHorn()
            : base(0x3159)
        {
            Weight = 20.0;
        }

        public MountedTropheyDreadHorn(Serial serial)
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

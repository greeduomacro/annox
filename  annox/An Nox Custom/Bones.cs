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
    public class BonePile1 : Item
    {
        [Constructable]
        public BonePile1()
            : base(0x1B09)
        {
            Weight = 1000;
            Movable = false;
        }

        public BonePile1(Serial serial)
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
    public class BonePile2 : Item
    {
        [Constructable]
        public BonePile2()
            : base(0x1B0A)
        {
            Weight = 1000;
            Movable = false;
        }

        public BonePile2(Serial serial)
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
    public class BonePile3 : Item
    {
        [Constructable]
        public BonePile3()
            : base(0x1B0b)
        {
            Weight = 1000;
            Movable = false;
        }

        public BonePile3(Serial serial)
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
    public class BonePile4 : Item
    {
        [Constructable]
        public BonePile4()
            : base(0x1B0C)
        {
            Weight = 1000;
            Movable = false;
        }

        public BonePile4(Serial serial)
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
    public class BonePile5 : Item
    {
        [Constructable]
        public BonePile5()
            : base(0x1B0D)
        {
            Weight = 1000;
            Movable = false;
        }

        public BonePile5(Serial serial)
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
    public class Bones1 : Item
    {
        [Constructable]
        public Bones1()
            : base(0x0ECA)
        {
            Weight = 1000;
            Movable = false;
        }

        public Bones1(Serial serial)
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
    public class Bones2 : Item
    {
        [Constructable]
        public Bones2()
            : base(0x0ECB)
        {
            Weight = 1000;
            Movable = false;
        }

        public Bones2(Serial serial)
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
    public class Bones3 : Item
    {
        [Constructable]
        public Bones3()
            : base(0x0ECC)
        {
            Weight = 1000;
            Movable = false;
        }

        public Bones3(Serial serial)
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
    public class Bones4 : Item
    {
        [Constructable]
        public Bones4()
            : base(0x0ECD)
        {
            Weight = 1000;
            Movable = false;
        }

        public Bones4(Serial serial)
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
    public class Bones5 : Item
    {
        [Constructable]
        public Bones5()
            : base(0x0ECE)
        {
            Weight = 1000;
            Movable = false;
        }

        public Bones5(Serial serial)
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
    public class PelvisBone : Item
    {
        [Constructable]
        public PelvisBone()
            : base(0x1B15)
        {
            Weight = 1000;
            Movable = false;
        }

        public PelvisBone(Serial serial)
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
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BagOfWeapons : Bag
    {
        [Constructable]
        public BagOfWeapons()
            : this(1)
        {
            Name = "Bag of Weapons";
        }

        [Constructable]
        public BagOfWeapons(int amount)
        {
            DropItem(new Kryss());
            DropItem(new ShortSpear());
            DropItem(new Spear());
            DropItem(new Katana());
            DropItem(new Longsword());
            DropItem(new Dagger());
            DropItem(new CrescentBlade());
        }

        public BagOfWeapons(Serial serial)
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
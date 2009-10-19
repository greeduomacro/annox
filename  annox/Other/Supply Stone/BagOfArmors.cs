using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BagOfArmors : Bag
    {
        [Constructable]
        public BagOfArmors()
            : this(1)
        {
            Name = "Bag of Amror";
        }

        [Constructable]
        public BagOfArmors(int amount)
        {
            DropItem(new LeatherCap());
            DropItem(new LeatherChest());
            DropItem(new LeatherLegs());
            DropItem(new LeatherGorget());
            DropItem(new LeatherGloves());
            DropItem(new LeatherArms());
            DropItem(new Shoes());
        }

        public BagOfArmors(Serial serial)
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
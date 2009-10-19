using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BagOfArrowsAndBolts : Bag
    {
        [Constructable]
        public BagOfArrowsAndBolts()
            : this(1)
        {
            Name = "Bag of Arrows and Bolts";
        }

        [Constructable]
        public BagOfArrowsAndBolts(int amount)
        {
            DropItem(new Arrow(100));
            DropItem(new Bolt(100));
        }

        public BagOfArrowsAndBolts(Serial serial)
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
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BagOfTools : Bag
    {
        [Constructable]
        public BagOfTools()
            : this(1)
        {
            Name = "Bag of Tools";
        }

        [Constructable]
        public BagOfTools(int amount)
        {
            DropItem(new SmithHammer());
            DropItem(new SewingKit());
            DropItem(new MortarPestle());
            DropItem(new Scissors());
            DropItem(new Dagger());
            DropItem(new ScribesPen());
            DropItem(new Pickaxe());
            DropItem(new Shovel());
        }

        public BagOfTools(Serial serial)
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
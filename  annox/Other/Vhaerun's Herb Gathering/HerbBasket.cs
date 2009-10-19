using System;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;

namespace Server.Items
{
    public class HerbBasket : BaseContainer, IDyable
    {
        [Constructable]
        public HerbBasket()
            : base(0x194f)
        {
            Weight = 2.0;
            Name = "Herb Basket";
        }

        public HerbBasket(Serial serial)
            : base(serial)
        {
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted) return false;

            Hue = sender.DyedHue;

            return true;
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
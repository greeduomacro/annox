using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
    public class SoulstoneDeed : Item
    {
        [Constructable]
        public SoulstoneDeed() : this(null)
        {
        }

        [Constructable]
        public SoulstoneDeed(string name) : base(0x14F0)
        {
            Name = "Soulstone Deed";
            LootType = LootType.Blessed;
        }

        public SoulstoneDeed(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001);
            }
            else
            {
                from.SendGump(new SoulstoneDeedGump(from, this));
            }
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
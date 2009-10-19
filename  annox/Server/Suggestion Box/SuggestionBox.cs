//GM Arthanys - Mystara Shard: www.mystara.com.br
using System;
using Server.Items;
using Server.Gumps;
using Server.Accounting;

namespace Server.Items
{
    [Flipable(0x9A8, 0xE80)]
    public class SuggestionBox : Item
    {
        [Constructable]
        public SuggestionBox()
            : base(0x9A8)
        {
            Movable = false;
            Hue = 1281;
            Name = "Suggestion Box";
        }

        public override void OnDoubleClick(Mobile from)
        {
            //Fix for crash when 2 gumps opened simultainously
            if (from.HasGump(typeof(Suggestion)))
            {
                from.SendMessage("You already have a suggestion open, please finish with that one before opening a new one!");
                return;
            }
            //End fix for crash
            from.SendGump(new Suggestion());
        }

        public SuggestionBox(Serial serial)
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

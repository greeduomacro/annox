using System;
using System.Collections;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;

using Server.Commands;

namespace Server.Scripts.Commands
{
    public class Donate
    {
        public static void Initialize()
        {
            CommandSystem.Register("Donate", AccessLevel.Player, new CommandEventHandler(Donate_OnCommand));
        }

        [Usage("Donate")]
        [Description("Brings Up Tithing Gump")]
        private static void Donate_OnCommand(CommandEventArgs e)
        {

            if (!e.Mobile.HasGump(typeof(TithingGump)))
            {
                e.Mobile.SendGump(new TithingGump(e.Mobile, 0));
            }
        }
    }

    [FlipableAttribute(0x1947, 0x1948, 0x1949, 0x194A)]
    public class TithingStone : Item
    {
        [Constructable]
        public TithingStone()
            : base()
        {
            Movable = false;
            //Hue = 0x1268;
            Name = "a Tithing Stone";
        }


        public override void OnDoubleClick(Mobile from)
        {
            if (!from.HasGump(typeof(TithingGump)))
            {
                from.SendGump(new TithingGump(from, 0));
            }
        }
        public TithingStone(Serial serial)
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

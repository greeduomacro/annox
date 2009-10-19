using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;
using Server.Targeting;
using Server.Misc;

using Server.Items;
using Server.Gumps;
using Server.Accounting;

namespace Server.Items
{

    public class ForeTellingStone : Item
    {
        [Constructable]
        public ForeTellingStone()
            : base(0xE2D)
        {
            Name = "a Fore Telling Stone";
            Hue = Utility.RandomSlimeHue();
        }

        public override void OnDoubleClick(Mobile from)
        {

            bool IsFound = false;
            Map map = from.Map;

            IPooledEnumerable eable = map.GetMobilesInRange(from.Location, 50);
            foreach (Mobile p in eable)
            {
                if (p is Blacksmith) // Check for a NPC within 300 Tiles
                {
                    IsFound = true;
                    from.SendMessage(11, "The closest {0} is in {1} ({2}.{3}.{4})", p.Title, p.Region.Name == "" ? "Unknown area" : p.Region.Name, p.X, p.Y, p.Z);
                    //(int)(p.X * .75);

                    //Now where am I at?
                    from.SendMessage(11, "You are at {0} {1} {2} in {3}.", from.X, from.Y, from.Z, map);

                    from.SendGump(new ForeTellingGump((int)(p.X * .50), (int)(p.Y * .50), (int)(from.X * .50), (int)(from.Y * .50)));
                    break;
                }
            }

            if (IsFound == false)
                from.SendMessage(11, "There is no one near by."); // you are to far away from the asked for npc

        }

        public ForeTellingStone(Serial serial)
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
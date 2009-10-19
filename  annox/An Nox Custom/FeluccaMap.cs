// 08FEB2008 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using System.Collections;

using Server;
using Server.Items;
using Server.Mobiles;
using Server.Multis;
using Server.Targeting;

namespace Server.Items
{

    public class FeluccaMap : Item
    {
        [Constructable]
        public FeluccaMap()
            : base(0x14EB)
        {
            Name = "a Felucca Map";
            Hue = Utility.RandomSlimeHue();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Map == Map.Trammel)
            {
                //Now where am I at?
                //from.SendMessage(11, "You are at {0} {1} {2} in {3}.", from.X, from.Y, from.Z, from.Map);

                from.SendLocalizedMessage(1005680); //teleporting to Felucca
                from.MoveToWorld(from.Location, Map.Felucca);
            }
            else
                if (from.Map == Map.Felucca)
                {
                    from.SendLocalizedMessage(502353); //Strange, that did not seem to work.

                    //To switch from Trammel to Felucca, remove the above line and add the two lines below.
                    //from.SendLocalizedMessage(1005681); //teleporting to Trammel
                    //from.MoveToWorld(from.Location, Map.Trammel);
                    //502353); //Strange, that did not seem to work.
                    //502369); //You hesitate, and decide to start again.
                }
                else
                {
                    from.SendLocalizedMessage(1042766); //Waaaaaaah!  I am lost!
                    //1010217);	 //I'm lost!
                    //1042766);  //Waaaaaaah!  I am lost!
                    //10495430); //You decide against traveling to Felucca while you are still young.
                    //501816);	 //You are too far away to do that.
                }
        }

        public FeluccaMap(Serial serial)
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
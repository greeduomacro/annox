// 06APR2006 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

// 
//    Name:     Moon Ring
//    Version:  1.0
//    Author:   RavonTUS
//
//    Play at An Nox the cure for the UO addiction
//    http://annox.no-ip.com      RavonTUS@Yahoo.com
//
//    Description:  This ring will let you know what phase the moon is in.
//                  There are 24 phases, each lasting an hour.  The purpose
//                  is for script writers or admins to schedule events at
//                  a certain moon phase so more people will attend the event.
//
//    Distribution: This script can be freely distributed, as long as the 
//                  credit notes are left intact.	This script can also be     
//                  modified, as long as the credit notes are left intact. 
//
//    Installation: Copy this file to your Custom directory.
//                  Restart your server.
//                  [add MoonRing

using System;

namespace Server.Items
{
    public class MoonRing : BaseRing
    {
        [Constructable]
        public MoonRing()
            : base(0x1F09)
        {
            Weight = 0.1;
            Name = "Moon Ring";
            Hue = 1099;
        }

        public MoonRing(Serial serial)
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
        public override void OnDoubleClick(Mobile from)
        {
            DateTime now = DateTime.Now;
            from.SendMessage("The moon is in phase " + now.Hour + " of 24.");

        }
    }
}
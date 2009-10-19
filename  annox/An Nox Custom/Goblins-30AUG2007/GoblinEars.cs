// 30AUG2007 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;

namespace Server.Items
{
    public class GoblinEars : BaseEarrings
    {
        [Constructable]
        public GoblinEars()
            : base(0x312D) //or 0x312e
        {
            Name = "Severed Orc Ears";
            Weight = 0.1;
            Hue = Utility.RandomMinMax(162, 180);
        }

        public GoblinEars(Serial serial)
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
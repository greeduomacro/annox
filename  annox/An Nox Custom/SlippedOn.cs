// 28FEB2008 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

//use [add SlippedOn
//use [flip 

#define SlippedOn

using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    [Flipable(0x10EE, 0x122D, 0x171D, 0x171E, 0xF3B, 0xDAE)] //Different UOArt of Bannanas
    public class SlippedOn : Item
    {
        [Constructable]
        public SlippedOn()
            : base(0x171D)
        {
            Movable = false; //leave it where it lies
            Name = "a banana peel";
        }

        public override bool HandlesOnMovement { get { return true; } }

        public override void OnMovement(Mobile from, Point3D oldLocation)
        {
            if (from.InRange(this, 3) && from is PlayerMobile) //chooses the area around the bannana
            {
                from.PlaySound(from.Female ? 791 : 1063); //sound
                from.Say("*slipped on " + Name + "*"); //message
                if (!from.Mounted)  //if not on a horse do the following...
                {
                    from.Freeze(TimeSpan.FromSeconds(4.0)); //stops player from running
                    from.Animate(22, 5, 1, true, false, 0); //show the player falling
                    from.Freeze(TimeSpan.FromSeconds(4.0)); //stops the player just a bit longer.
                }
            }
        }

        public override void OnDoubleClick(Mobile from) //testing to make sure it works.
        {
            if (from.InRange(this, 3) && from is PlayerMobile)
            {
                from.PlaySound(from.Female ? 791 : 1063);
                from.Say("*slipped on " + Name + "*");
                if (!from.Mounted)
                {
                    from.Freeze(TimeSpan.FromSeconds(4.0));
                    from.Animate(22, 5, 1, true, false, 0);
                    from.Freeze(TimeSpan.FromSeconds(4.0));
                }
            }
        }

        public SlippedOn(Serial serial)
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




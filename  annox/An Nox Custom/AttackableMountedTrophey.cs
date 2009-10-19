// 14JUL2008 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

//     
//    Name:    Attacking Mounted Trophey
//    Version: 14JUL2008
//    Author:  RavonTUS
//
//    Play at An Nox the cure for the UO addiction
//    http://annox.no-ip.com      RavonTUS@Yahoo.com
//
//    Description: These Trophey's will transform into living creates when touched.
//
//    Installation: Copy this file to your Custom director and restart your server.
//                  [add AttackableMountedTropheyStag to add the mount.
//                  [add AttackableMountedTropheyOrge to add the mount.
//                  [add AttackableMountedTropheyOrc  to add the mount.
//                  [flip to change east or west facing 
//
using System;
using System.Collections;
using Server.Mobiles;

namespace Server.Items
{
    [Furniture]                                                             //Classification
    [Flipable(0x1E61, 0X1E689)]                                             //East and West Facing art work use [FLIP
    public class AttackableMountedTropheyStag : Item
    {
        private static bool DeleteMount = true;                             //Will the mount delete after being clicked true=Yes/false=No

        [Constructable]
        public AttackableMountedTropheyStag()
            : base(0x1E61)                                                  //Use this art work
        {
            Name = "a mounted stag trophey (do not touch)";                 //Let's give it a better name
            Weight = 20.0;
            Movable = false;                                                //Wouldn't want some to take it.
        }

        public override bool HandlesOnMovement { get { return true; } }     //Required to use OnMovement below
        public override void OnMovement(Mobile from, Point3D oldLocation)   //Looks for players when they walk by
        {
            if (from.InRange(this, 3) && from is PlayerMobile)              //Player is close, with in 3 spaces
            {
                switch (Utility.Random(4))                                  //Picks one of the following sayings
                {
                    case 0:
                        {
                            this.SendLocalizedMessageTo(from, 1045135);	//Ah!  Thanks for the goods!  Would you help me out?
                            break;
                        }
                    case 1:
                        {
                            this.SendLocalizedMessageTo(from, 1046000); //Help! These savages wish to end my life!
                            break;
                        }
                    case 2:
                        {
                            this.SendLocalizedMessageTo(from, 1046005); //What have I gotten myself in to this time...
                            break;
                        }
                    case 3:
                        {
                            this.SendLocalizedMessageTo(from, 1046010); //I would help thee... but alas, I am stuck in here...
                            break;
                        }
                }
            }
        }

        public override void OnDoubleClick(Mobile from)     //Start here when someone clicks on it
        {
            if (from.InRange(GetWorldLocation(), 3))        //Player is with in 3 steps, hop off the mount.
            {
                this.SendLocalizedMessageTo(from, 1046017); //Thank you kind stranger! You have freed me.  I knew you could do it.
                Effects.SendLocationEffect(Location, Map, 0x3728, 20, 10); //A little distraction of smoke.
                Effects.PlaySound(Location, Map, 0x11C);    //Some sound FXs now.
                new GreatHart().MoveToWorld(Location, Map); //Creates GreatHart.
                if (DeleteMount == true)                    //Delete the mount? is it set to true or false?
                {
                    Delete();                               //Delete the mount.
                }
            }
            else                                            //Player is too far away, lets taunt our player to come closer.
            {
                this.SendLocalizedMessageTo(from, 1007061); //Barely a flesh wound. Canst thou not do better?
            }
        }

        public AttackableMountedTropheyStag(Serial serial)
            : base(serial)
        {
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


    [Furniture]
    [Flipable(0x1E63, 0X1E6A)]
    public class AttackableMountedTropheyOrge : Item
    {
        private static bool DeleteMount = true;                             //Will the mount delete after being clicked true=Yes/false=No

        [Constructable]
        public AttackableMountedTropheyOrge()
            : base(0x1E63)
        {
            Name = "a mounted orge trophey (do not touch)";                 //Let's give it a better name
            Weight = 20.0;
            Movable = false;                                                //Wouldn't want some to take it.
        }

        public override bool HandlesOnMovement { get { return true; } }     //Required to use OnMovement below
        public override void OnMovement(Mobile from, Point3D oldLocation)   //Looks for player to walk by
        {
            if (from.InRange(this, 3) && from is PlayerMobile)              //Player is within 3 spaces
            {
                switch (Utility.Random(4))                                  //Pick one of the following
                {
                    case 0:
                        {
                            this.SendLocalizedMessageTo(from, 1045135); //Ah!  Thanks for the goods!  Would you help me out?
                            break;
                        }
                    case 1:
                        {
                            this.SendLocalizedMessageTo(from, 1046000); //Help! These savages wish to end my life!
                            break;
                        }
                    case 2:
                        {
                            this.SendLocalizedMessageTo(from, 1046005); //What have I gotten myself in to this time...
                            break;
                        }
                    case 3:
                        {
                            this.SendLocalizedMessageTo(from, 1046010); //I would help thee... but alas, I am stuck in here...
                            break;
                        }
                }
            }
        }

        public override void OnDoubleClick(Mobile from)     //Start here when someone clicks on it
        {
            if (from.InRange(GetWorldLocation(), 3))        //Player is close, hop off the mount.
            {
                this.SendLocalizedMessageTo(from, 1046017); //Thank you kind stranger! You have freed me.  I knew you could do it.
                Effects.SendLocationEffect(Location, Map, 0x3728, 20, 10); //A little distraction of smoke.
                Effects.PlaySound(Location, Map, 0x11C);    //Some sound FXs now.
                new Ogre().MoveToWorld(Location, Map);      //Creates Orge.
                if (DeleteMount == true)                    //Delete the mount? is it set to true or false?
                {
                    Delete();                               //Delete the mount.
                }

            }
            else                                            //Lets taunt our player to come closer.
            {
                this.SendLocalizedMessageTo(from, 1007061); //Barely a flesh wound. Canst thou not do better?
            }
        }

        public AttackableMountedTropheyOrge(Serial serial)
            : base(serial)
        {
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


    [Furniture]
    [Flipable(0x1E64, 0X1E6B)]
    public class AttackableMountedTropheyOrc : Item
    {
        private static bool DeleteMount = true;                             //Will the mount delete after being clicked true=Yes/false=No

        [Constructable]
        public AttackableMountedTropheyOrc()
            : base(0x1E64)
        {
            Name = "a mounted orc trophey (do not touch)";                  //Let's give it a better name
            Weight = 20.0;
            Movable = false;                                                //Wouldn't want some to take it.
        }

        public override bool HandlesOnMovement { get { return true; } }     //Required to use OnMovement below
        public override void OnMovement(Mobile from, Point3D oldLocation)   //Looks for player to walk by
        {
            if (from.InRange(this, 3) && from is PlayerMobile)              //Player is within 3 spaces
            {
                switch (Utility.Random(4))                                  //Pick one of the following
                {
                    case 0:
                        {
                            this.SendLocalizedMessageTo(from, 1045135); //Ah!  Thanks for the goods!  Would you help me out?
                            break;
                        }
                    case 1:
                        {
                            this.SendLocalizedMessageTo(from, 1046000); //Help! These savages wish to end my life!
                            break;
                        }
                    case 2:
                        {
                            this.SendLocalizedMessageTo(from, 1046005); //What have I gotten myself in to this time...
                            break;
                        }
                    case 3:
                        {
                            this.SendLocalizedMessageTo(from, 1046010); //I would help thee... but alas, I am stuck in here...
                            break;
                        }
                }
            }
        }

        public override void OnDoubleClick(Mobile from)     //Start here when someone clicks on it
        {
            if (from.InRange(GetWorldLocation(), 3))        //Player is close, hop off the mount.
            {
                this.SendLocalizedMessageTo(from, 1046017); //Thank you kind stranger! You have freed me.  I knew you could do it.
                Effects.SendLocationEffect(Location, Map, 0x3728, 20, 10); //A little distraction of smoke.
                Effects.PlaySound(Location, Map, 0x11C);    //Some sound FXs now.
                new Orc().MoveToWorld(Location, Map);       //Creates Orc.
                if (DeleteMount == true)                    //Delete the mount? is it set to true or false?
                {
                    Delete();                               //Delete the mount.
                }
            }
            else                                            //Lets taunt our player to come closer.
            {
                this.SendLocalizedMessageTo(from, 1007061); //Barely a flesh wound. Canst thou not do better?
            }
        }

        public AttackableMountedTropheyOrc(Serial serial)
            : base(serial)
        {
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

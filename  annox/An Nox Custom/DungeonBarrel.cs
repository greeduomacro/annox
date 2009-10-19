// 06APR2006 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

//     
//    Name:    Dungeon Barrel  (aka Diablo Type Barrel)
//    Version: 1.01
//    Author:  RavonTUS
//
//    Play at An Nox the cure for the UO addiction
//    http://annox.no-ip.com      RavonTUS@Yahoo.com
//
//    Description: These barrels will only open if they are chopped up.
//                 You may get gold, mana, health, or you may get poisoned,
//                 blown up, or just an old broken barrel.
//
//    Distribution: This script can be freely distributed, as long as the 
//                  credit notes are left intact.	This script can also be     
//                  modified, as long as the credit notes are left intact. 
//
//    Installation: Copy this file to your Custom director and restart your server.
//                  [add DungeonBarrel to add the barrel or add it using a spawn.
//
//    Thanks to:    Joeku, Geezer & Axle for giving me a few pointers on my first script.
//
//    Change Log:   X-SirSly-X gave me the close barrel ID

using System;
using System.Collections;
using Server.Multis;

namespace Server.Items
{
    public class DungeonBarrel : Container, IChopable //,TrapableContainer
    {
        //public override int LabelNumber{ get{ return 1041064; } } // a trash barrel

        public override int DefaultMaxWeight { get { return 0; } } // A value of 0 signals unlimited weight

        //trying to kept it closed
        //public override void OnDoubleClick(Mobile from)
        //{
        //    from.SendLocalizedMessage(501747); // It appears to be locked.
        //}

        public override int DefaultGumpID { get { return 0x3E; } }
        public override int DefaultDropSound { get { return 0x42; } }

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(33, 36, 109, 112); }
        }

        [Constructable]
        public DungeonBarrel()
            : base(0xFAE) //0xE77 )  
        {
            Name = "Dungeon Barrel";  //change the name
            Hue = 0x02c;             //set the color
            //Locked = true; 
            Movable = false;
        }

        public DungeonBarrel(Serial serial)
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

        //public void OnAttack(Mobile from)
        public override void OnDoubleClick(Mobile from)
        //public override void OnDoubleClick(Mobile from) I'd rather had this work, oh well.
        {
            if (!from.InRange(GetWorldLocation(), 2))
            {
                from.SendLocalizedMessage(500446); // That is too far away. 
            }
            else
            {
                Effects.SendLocationEffect(Location, Map, 0x3728, 20, 10); //smoke or dust
                Effects.PlaySound(Location, Map, 0x11C);

                switch (Utility.Random(10))  //picks one of the following
                {
                    case 0:
                        Effects.SendLocationEffect(from, from.Map, 0x113A, 20, 10); //Posion Player
                        from.PlaySound(0x231);
                        from.ApplyPoison(from, Poison.Regular);
                        break;
                    case 1:
                        Effects.SendLocationEffect(from, from.Map, 0x3709, 30);//Burn Player
                        from.PlaySound(0x54);
                        AOS.Damage(from, from, Utility.RandomMinMax(10, 40), 0, 100, 0, 0, 0);
                        break;
                    case 2:
                        new BarrelLid().MoveToWorld(Location, Map);
                        break;
                    case 3:
                        new BarrelHoops().MoveToWorld(Location, Map);
                        break;
                    case 4:
                        new BarrelStaves().MoveToWorld(Location, Map);
                        break;
                    case 5:
                        Gold g = new Gold(Utility.Random(500)); //Random amount of gold 0 - 500
                        g.MoveToWorld(Location, Map);
                        break;
                    case 6:
                        new CurePotion().MoveToWorld(Location, Map);
                        break;
                    case 7:
                        new GreaterCurePotion().MoveToWorld(Location, Map);
                        break;
                    case 8:
                        new HealPotion().MoveToWorld(Location, Map);
                        break;
                    case 9:
                        new GreaterHealPotion().MoveToWorld(Location, Map);
                        break;
                }
                Destroy();
            }
        }
        public void OnChop(Mobile from)
        //public override void OnDoubleClick(Mobile from) I'd rather had this work, oh well.
        {
            if (!from.InRange(GetWorldLocation(), 2))
            {
                from.SendLocalizedMessage(500446); // That is too far away. 
            }
            else
            {
                Effects.SendLocationEffect(Location, Map, 0x3728, 20, 10); //smoke or dust
                Effects.PlaySound(Location, Map, 0x11C);

                switch (Utility.Random(10))  //picks one of the following
                {
                    case 0:
                        Effects.SendLocationEffect(from, from.Map, 0x113A, 20, 10); //Posion Player
                        from.PlaySound(0x231);
                        from.ApplyPoison(from, Poison.Regular);
                        break;
                    case 1:
                        Effects.SendLocationEffect(from, from.Map, 0x3709, 30);//Burn Player
                        from.PlaySound(0x54);
                        AOS.Damage(from, from, Utility.RandomMinMax(10, 40), 0, 100, 0, 0, 0);
                        break;
                    case 2:
                        new BarrelLid().MoveToWorld(Location, Map);
                        break;
                    case 3:
                        new BarrelHoops().MoveToWorld(Location, Map);
                        break;
                    case 4:
                        new BarrelStaves().MoveToWorld(Location, Map);
                        break;
                    case 5:
                        Gold g = new Gold(Utility.Random(500)); //Random amount of gold 0 - 500
                        g.MoveToWorld(Location, Map);
                        break;
                    case 6:
                        new CurePotion().MoveToWorld(Location, Map);
                        break;
                    case 7:
                        new GreaterCurePotion().MoveToWorld(Location, Map);
                        break;
                    case 8:
                        new HealPotion().MoveToWorld(Location, Map);
                        break;
                    case 9:
                        new GreaterHealPotion().MoveToWorld(Location, Map);
                        break;
                }
                Destroy();
            }
        }
    }
}

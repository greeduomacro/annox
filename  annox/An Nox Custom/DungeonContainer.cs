// 06APR2006 written by RavonTUS
// 12OCT2006 updated to do random items with more stuff by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

//     
//    Name:    Dungeon Container  (aka Diablo Type Barrel)
//    Version: 1.01
//    Author:  RavonTUS
//
//    Play at An Nox the cure for the UO addiction
//    http://annox.no-ip.com      RavonTUS@Yahoo.com
//
//    Description: These containers will only open if they are chopped up.
//                 You may get gold, mana, health, or you may get poisoned,
//                 blown up, or just an old broken barrel.
//
//    Distribution: This script can be freely distributed, as long as the 
//                  credit notes are left intact.	This script can also be     
//                  modified, as long as the credit notes are left intact. 
//
//    Installation: Copy this file to your Custom director and restart your server.
//                  [add DungeonContainer to add the barrel or add it using a spawn.
//
//    Thanks to:    Joeku, Geezer & Axle for giving me a few pointers on my first script.
//
//    Change Log:   X-SirSly-X gave me the close barrel ID & Random ID's.

using System;
using System.Collections;
using Server.Multis;

namespace Server.Items
{
    public class DungeonContainer : Container, IChopable //,TrapableContainer
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
        public DungeonContainer()
            : base(0xFAE) //0xE77 )  
        {
            switch (Utility.Random(9))
            {
                case 0: ItemID = 0xE7F; Name = "Dungeon Keg"; break;
                case 1: ItemID = 0x9AA; Name = "Dungeon Box"; break;
                case 2: ItemID = 0x9A9; Name = "Dungeon Small Create"; break;
                case 3: ItemID = 0xE3F; Name = "Dungeon Medium Create"; break;
                case 4: ItemID = 0xFAE; Name = "Dungeon Barrel"; break;
                case 5: ItemID = 0xB46; Name = "Dungeon Vase"; break;
                case 6: ItemID = 0xB45; Name = "Dungeon Large Vase"; break;
                case 7: ItemID = 0x11C6; Name = "Dungeon Small Pot"; break;
                case 8: ItemID = 0x11C7; Name = "Dungeon Large Pot"; break;
            }
            //Name = "Dungeon Barrel";  //change the name
            //Hue = 0x02c;             //set the color
            //Locked = true; 
            Movable = false;
        }

        public DungeonContainer(Serial serial)
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

                switch (Utility.Random(16))  //picks one of the following
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
                        new Kindling().MoveToWorld(Location, Map);
                        break;
                    case 6:
                        new WoodDebris().MoveToWorld(Location, Map);
                        break;
                    case 7:
                        Gold g = new Gold(Utility.Random(500)); //Random amount of gold 0 - 500
                        g.MoveToWorld(Location, Map);
                        break;
                    case 8:
                        new CurePotion().MoveToWorld(Location, Map);
                        break;
                    case 9:
                        new GreaterCurePotion().MoveToWorld(Location, Map);
                        break;
                    case 10:
                        new HealPotion().MoveToWorld(Location, Map);
                        break;
                    case 11:
                        new GreaterHealPotion().MoveToWorld(Location, Map);
                        break;
                    case 12:
                        new RefreshPotion().MoveToWorld(Location, Map);
                        break;
                    case 13:
                        new StrengthPotion().MoveToWorld(Location, Map);
                        break;
                    case 14:
                        new GreaterStrengthPotion().MoveToWorld(Location, Map);
                        break;
                    case 15:
                        new AgilityPotion().MoveToWorld(Location, Map);
                        break;
                }
                Destroy();
            }
        }
    }
}

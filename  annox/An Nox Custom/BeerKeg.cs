// 06APR2006 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using Server;
using Server.Items;
using System.Collections;
using Server.Multis;


namespace Server.Items
{
    public class BeerKeg : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x3E; } }
        public override int DefaultDropSound { get { return 0x42; } }

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(33, 36, 109, 112); }
        }

        [Constructable]
        public BeerKeg()
            : base(0x1AD6)
        {
            Name = "Free Ale";  //change the name
            //Hue = 0x02c;             //set the color
            Movable = false; Weight = 15.0;
            Movable = false;
        }

        public BeerKeg(Serial serial)
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
            if (!from.InRange(GetWorldLocation(), 2))
            {
                from.SendLocalizedMessage(500446); // That is too far away. 
            }
            else
            {
                DateTime now = DateTime.Now;
                //if (now.Hour != 20)  //Set the time you wish this to at.  Current 8:00 p.m.
                //{
                //    from.SendMessage("The stone only works on the 20th phase of the moons.");

                //}

                //else
                {
                    Item item = from.Backpack.FindItemByType(typeof(Pitcher));

                    if (item == null)// if is not item is found
                    {
                        //check to see if they have a mug.
                        switch (Utility.Random(4))  //picks one of the following
                        {
                            case 0:
                                Effects.PlaySound(Location, Map, 0x44A);
                                from.SendMessage("The bar tender yells, 'Get a pitcher!'");
                                break;
                            case 1:
                                Effects.PlaySound(Location, Map, 0x41F);
                                from.SendMessage("Your tongue gets stuck in the tap.  You wish you had used a pitcher.");
                                //freeze player to 5 sec.
                                break;
                            case 2:
                                Effects.PlaySound(Location, Map, 0x03E);
                                from.SendMessage("The waitres throws a pitcher at you.");
                                break;
                            case 3:
                                Effects.PlaySound(Location, Map, 0x174);
                                from.SendMessage("The other paterns, holding pitchers, frown at you as you try to drink directly from the keg.");
                                break;
                        }
                    }
                    else
                    {//give user a drink. Use MugAle or GlassMug
                        //Destroy();       <-- delete keg 
                        item.Delete();  // <-- delete pitcher
                        Effects.PlaySound(Location, Map, 0x04E);



                        switch (Utility.Random(7))  //picks one of the following
                        {
                            case 0: //good
                                {
                                    Pitcher p = new Pitcher();
                                    p.Content = BeverageType.Water;
                                    p.Quantity = 5;

                                    from.Backpack.AddItem(p);
                                    break;
                                }
                            case 2:  //good
                                {
                                    Pitcher p = new Pitcher();
                                    p.Content = BeverageType.Ale;
                                    p.Quantity = 5;

                                    from.Backpack.AddItem(p);
                                    break;
                                }
                            case 3:  //good
                                {
                                    Pitcher p = new Pitcher();
                                    p.Content = BeverageType.Cider;
                                    p.Quantity = 5;

                                    from.Backpack.AddItem(p);
                                    break;
                                }
                            case 4:  //good
                                {
                                    Pitcher p = new Pitcher();
                                    p.Content = BeverageType.Liquor;
                                    p.Quantity = 5;

                                    from.Backpack.AddItem(p);
                                    break;
                                }
                            case 5:
                                {
                                    Pitcher p = new Pitcher();
                                    p.Content = BeverageType.Milk;
                                    p.Quantity = 5;

                                    from.Backpack.AddItem(p);
                                    break;
                                }
                            case 6:
                                {
                                    Pitcher p = new Pitcher();
                                    p.Content = BeverageType.Wine;
                                    p.Quantity = 5;

                                    from.Backpack.AddItem(p);
                                    break;
                                }
                        }
                    }

                }
            }
        }
    }
}
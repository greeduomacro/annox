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
using Server.Multis.Deeds;
using Server.Accounting;
using Server.Targeting;

namespace Server.Items
{
    public class FreeHouse : Item
    {

        [Constructable]
        public FreeHouse()
            : base(0x12D8)
        {
            Movable = false;
            Hue = 0x2D1;
            Name = "a free house stone";
        }

        public override void OnDoubleClick(Mobile from)
        {
            //FreeHouse p;
            //FreeHouse = new FreeHouse();

            //Car myCar;
            //myCar = new Car();
            if (!from.InRange(GetWorldLocation(), 2))
            {
                from.SendLocalizedMessage(500446); // That is too far away. 
            }
            else
            {
                DateTime now = DateTime.Now;

                if (now.DayOfWeek.ToString() != "Friday") //Error: System.DateTime does not contain a definition for 'GetDayOfWeek'
                //   Friday is not equal to Friday go to else if
                {
                    from.SendMessage("It's Free House Friday and today is not Friday.");
                    //from.SendMessage(now.DayOfWeek.ToString());
                }

                //else if (now.Hour <= 19)  //Set the time you wish this to at.  Current 8:00 p.m.
                //{
                //    from.SendMessage("The stone only works after the 20th phase of the moons.");
                //}

                else
                {
                    //from.SendMessage("Add script here.");

                    Account acct = (Account)from.Account;
                    bool agreed = Convert.ToBoolean(acct.GetTag("FreeHouse")); // See if the player has already read and agreed to the TOS.
                    if (!agreed)
                    {
                        from.SendMessage("You get a house.");
                        from.Backpack.AddItem(new HousePlacementTool());


                        //add random house start
                        switch (Utility.Random(4))  //picks one of the following
                        {
                            case 0:
                                {
                                    from.Backpack.AddItem(new StonePlasterHouseDeed());
                                    break;
                                }
                            case 1:
                                {
                                    from.Backpack.AddItem(new FieldStoneHouseDeed());
                                    break;
                                }
                            case 2:
                                {
                                    from.Backpack.AddItem(new SmallBrickHouseDeed());
                                    break;
                                }
                            case 3:
                                {
                                    from.Backpack.AddItem(new WoodHouseDeed());
                                    break;
                                }
                            case 4:
                                {
                                    from.Backpack.AddItem(new WoodPlasterHouseDeed());
                                    break;
                                }
                        }

                        //add random house end

                        acct.SetTag("FreeHouse", "true");
                    }
                    else
                    {
                        from.SendMessage("You have a house.");
                    }

                }

            }
        }

        public FreeHouse(Serial serial)
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
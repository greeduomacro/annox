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
using Server.Mobiles;


namespace Server.Items
{
    public class FreeMount : Item
    {

        [Constructable]
        public FreeMount()
            : base(0x12D8)
        {
            Movable = false;
            Hue = 0x2D1;
            Name = "a free sword stone";
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
                ////.GetDayOfWeek
                if (now.DayOfWeek.ToString() != "Monday") //Choose Day of Week
                {
                    from.SendMessage("It's Mega Mount Monday and today is not Monday.");
                }
                else
                {
                    Account acct = (Account)from.Account;
                    string agreed = "";
                    agreed = acct.GetTag("FreeMount");

                    if (agreed != now.Hour.ToString())
                    {
                        from.SendMessage("You get a Mega Mount.");

                        #region Randomly pick armor
                        switch (Utility.Random(51))  //picks one of the following
                        {
                            case 0:
                                { from.Backpack.AddItem(new MegaEtherealHorse()); break; }
                            case 1:
                                { from.Backpack.AddItem(new MegaEtherealLlama()); break; }
                            case 2:
                                { from.Backpack.AddItem(new MegaEtherealOstard()); break; }
                            case 3:
                                { from.Backpack.AddItem(new MegaEtherealRidgeback()); break; }
                            case 4:
                                { from.Backpack.AddItem(new MegaEtherealUnicorn()); break; }
                            case 5:
                                { from.Backpack.AddItem(new MegaEtherealBeetle()); break; }
                            case 6:
                                { from.Backpack.AddItem(new MegaEtherealKirin()); break; }
                            case 7:
                                { from.Backpack.AddItem(new MegaEtherealSwampDragon()); break; }
                            case 8:
                                { from.Backpack.AddItem(new MegaEtherealChargeroftheFallen()); break; }
                            case 9:
                                { from.Backpack.AddItem(new MegaEtherealChimera()); break; }
                            case 10:
                                { from.Backpack.AddItem(new MegaEtherealCuSidhe()); break; }
                            case 11:
                                { from.Backpack.AddItem(new MegaEtherealHiryu()); break; }
                            case 12:
                                { from.Backpack.AddItem(new MegaEtherealHellsteed()); break; }
                            case 13:
                                { from.Backpack.AddItem(new MegaEtherealArmoredSwampDragon()); break; }
                            case 14:
                                { from.Backpack.AddItem(new MegaEtherealForestOstard()); break; }
                            case 15:
                                { from.Backpack.AddItem(new MegaEtherealFrenziedOstard()); break; }
                            case 16:
                                { from.Backpack.AddItem(new MegaEtherealSavageRidgeback()); break; }
                            case 17:
                                { from.Backpack.AddItem(new MegaEtherealPolarBear()); break; }
                            case 18:
                                { from.Backpack.AddItem(new MegaEtherealSeaHorse()); break; }
                            case 19:
                                { from.Backpack.AddItem(new MegaMagicHorse()); break; }
                            case 20:
                                { from.Backpack.AddItem(new MegaMagicLlama()); break; }
                            case 21:
                                { from.Backpack.AddItem(new MegaMagicOstard()); break; }
                            case 22:
                                { from.Backpack.AddItem(new MegaMagicForestOstard()); break; }
                            case 23:
                                { from.Backpack.AddItem(new MegaMagicFrenziedOstard()); break; }
                            case 24:
                                { from.Backpack.AddItem(new MegaMagicRidgeback()); break; }
                            case 25:
                                { from.Backpack.AddItem(new MegaMagicSavageRidgeback()); break; }
                            case 26:
                                { from.Backpack.AddItem(new MegaMagicUnicorn()); break; }
                            case 27:
                                { from.Backpack.AddItem(new MegaMagicBeetle()); break; }
                            case 28:
                                { from.Backpack.AddItem(new MegaMagicFireBeetle()); break; }
                            case 29:
                                { from.Backpack.AddItem(new MegaMagicKirin()); break; }
                            case 30:
                                { from.Backpack.AddItem(new MegaMagicSwampDragon()); break; }
                            case 31:
                                { from.Backpack.AddItem(new MegaMagicArmoredSwampDragon()); break; }
                            case 32:
                                { from.Backpack.AddItem(new MegaMagicChimera()); break; }
                            case 33:
                                { from.Backpack.AddItem(new MegaMagicCuSidhe()); break; }
                            case 34:
                                { from.Backpack.AddItem(new MegaMagicLesserHiryu()); break; }
                            case 35:
                                { from.Backpack.AddItem(new MegaMagicHiryu()); break; }
                            case 36:
                                { from.Backpack.AddItem(new MegaMagicPolarBear()); break; }
                            case 37:
                                { from.Backpack.AddItem(new MegaChargeroftheFallen()); break; }
                            case 38:
                                { from.Backpack.AddItem(new MegaMagicSeaHorse()); break; }
                            case 39:
                                { from.Backpack.AddItem(new MegaMagicSkeletalsteed()); break; }
                            case 40:
                                { from.Backpack.AddItem(new MegaMagicSilverSteed()); break; }
                            case 41:
                                { from.Backpack.AddItem(new MegaMagicDarkSteed()); break; }
                            case 42:
                                { from.Backpack.AddItem(new MegaMagicCoMWarHorse()); break; }
                            case 43:
                                { from.Backpack.AddItem(new MegaMagicMinaxWarHorse()); break; }
                            case 44:
                                { from.Backpack.AddItem(new MegaMagicTBWarHorse()); break; }
                            case 45:
                                { from.Backpack.AddItem(new MegaMagicSLWarHorse()); break; }
                            case 46:
                                { from.Backpack.AddItem(new MegaMagicFireSteed()); break; }
                            case 47:
                                { from.Backpack.AddItem(new MegaMagicNightmare()); break; }
                            case 48:
                                { from.Backpack.AddItem(new MegaMagicRend()); break; }
                            case 49:
                                { from.Backpack.AddItem(new MegaMagicRedDeath()); break; }
                            case 50:
                                { from.Backpack.AddItem(new MegaMagicIceBeetle()); break; }
                        }
                        #endregion
                        //add random house end

                        acct.SetTag("FreeMount", now.Hour.ToString());
                    }
                    else
                    {
                        from.SendMessage("The stone must re-charge, please try again later.");
                    }
                }
            }
        }

        public FreeMount(Serial serial)
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
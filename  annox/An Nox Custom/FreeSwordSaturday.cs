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
    public class FreeSword : Item
    {

        [Constructable]
        public FreeSword()
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
                if (now.DayOfWeek.ToString() != "Saturday") //Choose Day of Week
                {
                    from.SendMessage("It's Super Sword Saturday and today is not Saturday.");
                }
                else
                {
                    Account acct = (Account)from.Account;
                    string agreed = "";
                    agreed = acct.GetTag("FreeSword");

                    if (agreed != now.Hour.ToString())
                    {
                        from.SendMessage("You get a super sword.");

                        #region Randomly Weapon 2008
                        switch (Utility.Random(11))  //picks one of the following
                        {
                            //from.Backpack.AddItem(new

                            case 0:
                                { from.Backpack.AddItem(new VenomBoneHarvester()); break; }
                            case 1:
                                { from.Backpack.AddItem(new VenomBroadSword()); break; }
                            case 2:
                                { from.Backpack.AddItem(new VenomCrescentBlade()); break; }
                            case 3:
                                { from.Backpack.AddItem(new VenomCutlass()); break; }
                            case 4:
                                { from.Backpack.AddItem(new VenomKatana()); break; }
                            case 5:
                                { from.Backpack.AddItem(new VenomKryss()); break; }
                            case 6:
                                { from.Backpack.AddItem(new VenomLance()); break; }
                            case 7:
                                { from.Backpack.AddItem(new VenomLongSword()); break; }
                            case 8:
                                { from.Backpack.AddItem(new VenomScimitar()); break; }
                            case 9:
                                { from.Backpack.AddItem(new VenomVikingSword()); break; }
                            case 10:
                                { from.Backpack.AddItem(new VenomWeaponDeed()); break; }
                        }
                        #endregion

                        #region 2007 Random Swords
                        //add random house start
                        //for (int i = 1; i <= 5; i++)  //repeats 5 times.
                        //#region Randomly pick armor
                        //switch (Utility.Random(69))  //picks one of the following
                        //{
                        //    //from.Backpack.AddItem(new

                        //    case 0:
                        //    { from.Backpack.AddItem(new ArcaneSanctum()); break; }
                        //    case 1:
                        //    { from.Backpack.AddItem(new BerzerkingAxe()); break; }
                        //    case 2:
                        //    { from.Backpack.AddItem(new BladeofArgg()); break; }
                        //    case 3:
                        //    { from.Backpack.AddItem(new BladeofZues()); break; }
                        //    case 4:
                        //    { from.Backpack.AddItem(new BloodLust()); break; }
                        //    case 5:
                        //    { from.Backpack.AddItem(new BloodStrike()); break; }
                        //    case 6:
                        //    { from.Backpack.AddItem(new BowoftheConstantine()); break; }
                        //    case 7:
                        //    { from.Backpack.AddItem(new ButchersCleaver()); break; }
                        //    case 8:
                        //    { from.Backpack.AddItem(new CluboftheBeast()); break; }
                        //    case 9:
                        //    { from.Backpack.AddItem(new CriticalShot()); break; }
                        //    case 10:
                        //    { from.Backpack.AddItem(new DaemonDeath()); break; }
                        //    case 11:
                        //    { from.Backpack.AddItem(new DarkAxe()); break; }
                        //    case 12:
                        //    { from.Backpack.AddItem(new DeathClaw()); break; }
                        //    case 13:
                        //    { from.Backpack.AddItem(new DeathDealer()); break; }
                        //    case 14:
                        //    { from.Backpack.AddItem(new DeathPike()); break; }
                        //    case 15:
                        //    { from.Backpack.AddItem(new DeathSlayer()); break; }
                        //    case 16:
                        //    { from.Backpack.AddItem(new DeathSword()); break; }
                        //    case 17:
                        //    { from.Backpack.AddItem(new DestructionoftheGods()); break; }
                        //    case 18:
                        //    { from.Backpack.AddItem(new DoubleSlice()); break; }
                        //    case 19:
                        //    { from.Backpack.AddItem(new Dumbfounded()); break; }
                        //    case 20:
                        //    { from.Backpack.AddItem(new ElvenBlade()); break; }
                        //    case 21:
                        //    { from.Backpack.AddItem(new EvilSlayer()); break; }
                        //    case 22:
                        //    { from.Backpack.AddItem(new ExecutionersBlade()); break; }
                        //    case 23:
                        //    { from.Backpack.AddItem(new FaceoftheDead()); break; }
                        //    case 24:
                        //    { from.Backpack.AddItem(new FastShot()); break; }
                        //    case 25:
                        //    { from.Backpack.AddItem(new FenceMeOff()); break; }
                        //    case 26:
                        //    { from.Backpack.AddItem(new FlameThang()); break; }
                        //    case 27:
                        //    { from.Backpack.AddItem(new Fortress()); break; }
                        //    case 28:
                        //    { from.Backpack.AddItem(new GargoyleTooth()); break; }
                        //    case 29:
                        //    { from.Backpack.AddItem(new GiantBone()); break; }
                        //    case 30:
                        //    { from.Backpack.AddItem(new GodsBreath()); break; }
                        //    case 31:
                        //    { from.Backpack.AddItem(new HandScythe()); break; }
                        //    case 32:
                        //    { from.Backpack.AddItem(new HoradricStaff()); break; }
                        //    case 33:
                        //    { from.Backpack.AddItem(new HugeAssWeapon()); break; }
                        //    case 34:
                        //    { from.Backpack.AddItem(new InfiniteDeath()); break; }
                        //    case 35:
                        //    { from.Backpack.AddItem(new InfiniteMana()); break; }
                        //    case 36:
                        //    { from.Backpack.AddItem(new IngeniousSword()); break; }
                        //    case 37:
                        //    { from.Backpack.AddItem(new KamaKamaSutra()); break; }
                        //    case 38:
                        //    { from.Backpack.AddItem(new LifeBurden()); break; }
                        //    case 39:
                        //    { from.Backpack.AddItem(new Lajatang()); break; }
                        //    case 40:
                        //    { from.Backpack.AddItem(new UberShot()); break; }
                        //    case 41:
                        //    { from.Backpack.AddItem(new LongShot()); break; }
                        //    case 42:
                        //    { from.Backpack.AddItem(new LostMyDragonToof()); break; }
                        //    case 43:
                        //    { from.Backpack.AddItem(new MagesForce()); break; }
                        //    case 44:
                        //    { from.Backpack.AddItem(new MagesPick()); break; }
                        //    case 45:
                        //    { from.Backpack.AddItem(new MagiciansIllusion()); break; }
                        //    case 46:
                        //    { from.Backpack.AddItem(new MagiciansSwing()); break; }
                        //    case 47:
                        //    { from.Backpack.AddItem(new MagiciansTrick()); break; }
                        //    case 48:
                        //    { from.Backpack.AddItem(new MauloftheBeast()); break; }
                        //    case 49:
                        //    { from.Backpack.AddItem(new MidnightBlade()); break; }
                        //    case 50:
                        //    { from.Backpack.AddItem(new MinersPickaxe()); break; }
                        //    case 51:
                        //    { from.Backpack.AddItem(new ToothPick()); break; }
                        //    case 52:
                        //    { from.Backpack.AddItem(new NorseVikingSword()); break; }
                        //    case 53:
                        //    { from.Backpack.AddItem(new PoisonShot()); break; }
                        //    case 54:
                        //    { from.Backpack.AddItem(new TribalmansPoint()); break; }
                        //    case 55:
                        //    { from.Backpack.AddItem(new QuickBlade()); break; }
                        //    case 56:
                        //    { from.Backpack.AddItem(new TrollsReaper()); break; }
                        //    case 57:
                        //    { from.Backpack.AddItem(new SalvationofZion()); break; }
                        //    case 58:
                        //    { from.Backpack.AddItem(new SamuraiBlade()); break; }
                        //    case 59:
                        //    { from.Backpack.AddItem(new UltimaOmegum()); break; }
                        //    case 60:
                        //    { from.Backpack.AddItem(new SatansFork()); break; }
                        //    case 61:
                        //    { from.Backpack.AddItem(new ScepterofLife()); break; }
                        //    case 62:
                        //    { from.Backpack.AddItem(new SharpBow()); break; }
                        //    case 63:
                        //    { from.Backpack.AddItem(new SliceAndDice()); break; }
                        //    case 64:
                        //    { from.Backpack.AddItem(new SoulThief()); break; }
                        //    case 65:
                        //    { from.Backpack.AddItem(new SpearofDivinity()); break; }
                        //    case 66:
                        //    { from.Backpack.AddItem(new SpellMaster()); break; }
                        //    case 67:
                        //    { from.Backpack.AddItem(new SpikesRevenge()); break; }
                        //    case 68:
                        //    { from.Backpack.AddItem(new StaffofMoses()); break; }
                        //    case 69:
                        //    { from.Backpack.AddItem(new StrengthReborn()); break; }
                        //}
                        //#endregion
                        //add random house end
                        #endregion

                        acct.SetTag("FreeSword", now.Hour.ToString());
                    }
                    else
                    {
                        from.SendMessage("You have several swords already.");
                    }
                }
            }
        }

        public FreeSword(Serial serial)
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
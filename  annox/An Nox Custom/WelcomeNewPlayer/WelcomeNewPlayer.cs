//20MAR2008 WelcomeNewPlayer written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using System.Collections;
using Server;
using Server.Accounting;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;

namespace Server.Items
{
    public class WelcomeNewPlayer : Item
    {
        private const bool m_Enabled = true;  //Turn system on (true) or off (flase)
        public static bool Enabled { get { return m_Enabled; } }

        public static void Initialize()
        {
            if (Enabled)
                EventSink.CharacterCreated += new CharacterCreatedEventHandler(EventSink_CharacterCreated);
        }

        private static void EventSink_CharacterCreated(CharacterCreatedEventArgs args)
        {
            Mobile from = args.Mobile;

            //from.SendMessage("Welcome to our shard.");
            Account acct = from.Account as Account;
            TimeSpan time = acct.TotalGameTime; //TotalGameTime from Account file.
            Console.WriteLine("WelcomeNewPlayer: Time: {0}", time.Minutes);

            if (time.Minutes <= 1) //test to see if this their first character.
            {
                foreach (NetState ns in NetState.Instances)
                {
                    Mobile m = ns.Mobile;

                    if (m != null && m.AccessLevel >= AccessLevel.Counselor) // && m.AutoPageNotify && m.LastMoveTime >= (DateTime.Now - TimeSpan.FromMinutes(10.0)))
                    {
                        m.SendMessage("Welcome {0} to our shard.", from.Name);
                        m.SendGump(new WelcomeNewPlayerGump(from.Name));
                    }
                }
            }
        }

        public WelcomeNewPlayer(Serial serial)
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
#region WelcomeNewPlayerGump
namespace Server.Gumps
{
    public class WelcomeNewPlayerGump : Gump
    {
        public WelcomeNewPlayerGump(string Name)
            : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;

            AddPage(0);
            AddImage(70, 20, 2080);
            AddImage(88, 56, 2081);
            AddImage(87, 108, 2083);
            AddImage(98, 60, 57);
            AddLabel(137, 59, 55, @"Welcome New Player");
            AddImage(306, 58, 59);
            AddLabel(143, 83, 268, @"" + Name);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
        }
    }
}
#endregion



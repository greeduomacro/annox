using System;
using System.Collections;
using Server.Network;

namespace Server
{
    public class Announce
    {
        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(World_Login);
            EventSink.Logout += new LogoutEventHandler(World_Logout);
            EventSink.PlayerDeath += new PlayerDeathEventHandler(OnDeath);
        }

        private static void World_Login(LoginEventArgs args)
        {
            Mobile m = args.Mobile;

            if (args.Mobile.AccessLevel < AccessLevel.Administrator)//Edit AccessLevel to show its set for GameMaster
            {
                World.Broadcast(0x35, true, "{0} has logged into the world.", args.Mobile.Name);//Edit Message
            }
        }

        private static void World_Logout(LogoutEventArgs args)
        {
            Mobile m = args.Mobile;

            if (args.Mobile.AccessLevel < AccessLevel.GameMaster)//Edit AccessLevel to show its set for GameMaster
            {
                World.Broadcast(0x35, true, "{0} has logged out of the world.", args.Mobile.Name);//Edit Message
            }
        }

        public static void OnDeath(PlayerDeathEventArgs args)
        {
            Mobile m = args.Mobile;

            if (args.Mobile.AccessLevel < AccessLevel.GameMaster)//Edit AccessLevel to show its set for GameMaster
            {
                args.Mobile.PlaySound(256);
                World.Broadcast(0x35, true, "{0} Has been sent to the netherworld!!!", args.Mobile.Name);//Edit Message
            }
        }
    }
}
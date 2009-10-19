//
// Brought to you by Mark01970 of the RunUO forums
// The Unexpected Shard - A private invitation only shard
//

using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Misc;
using Server.Factions;

using Server.Commands;

namespace Server.Scripts.Commands
{
    public class pray
    {
        public static void Initialize()
        {
            CommandSystem.Register("Pray", AccessLevel.Player, new CommandEventHandler(pray_OnCommand));
        }

        [Usage("Pray")]
        [Description("Pray to the Gods!")]

        public static void pray_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendMessage("You begin praying to the Gods for help...");
            if (e.Mobile.Karma < 1000) { e.Mobile.SendMessage("You lack the Karma to pray for assistance!"); }
            else if (!(e.Mobile.Alive))
            {
                e.Mobile.SendMessage("The Gods grant you the gift of life at the cost of Karma!");
                e.Mobile.Karma = e.Mobile.Karma - 500;
                e.Mobile.SendMessage("You lost 500 Karma.");
                e.Mobile.Resurrect();
            }
            else { e.Mobile.SendMessage("You aren't dead dummy!"); }
        }
    }
}

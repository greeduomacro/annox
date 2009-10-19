using System;
using System.IO;
using Server;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Server.Accounting;
using Server.Mobiles;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Menus.ItemLists;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Targets;
using Server.Gumps;
using Server.Commands.Generic;
using Server.Diagnostics;

namespace Server.Commands
{
    public class WhereAmI
    {
        public static void Initialize()
        {
            CommandSystem.Register("WhereAmI", AccessLevel.Player, new CommandEventHandler(WhereAmI_OnCommand));
        }

        [Usage("WhereAmI")]
        [Description("Tells the commanding player his coordinates, region, and facet.")]

        public static void WhereAmI_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            Map map = from.Map;

            from.SendMessage("You are near {0} ({1} {2} in {3}).", from.Region.Name, from.X, from.Y, from.Z, map);

            if (map != null)
            {
                Region reg = from.Region;

                if (!reg.IsDefault)
                {
                    StringBuilder builder = new StringBuilder();

                    builder.Append(reg.ToString());
                    reg = reg.Parent;

                    while (reg != null)
                    {
                        builder.Append(" <- " + reg.ToString());
                        reg = reg.Parent;
                    }

                    from.SendMessage("Your region is {0}.", builder.ToString());
                }
            }
        }
    }
}

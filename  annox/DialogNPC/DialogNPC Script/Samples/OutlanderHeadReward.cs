using System;
using System.Collections;

using Server;

namespace Arya.DialogEditor
{
    /// <summary>
    /// Holds functions for the Casanova DialogNPC sample.
    /// Delete this file if you don't want to use the Casanova NPC
    /// </summary>
    public class OutlanderHeadReward
    {
        private static ArrayList m_Received = new ArrayList();


        public static void GiveOutlanderRewardTo(Mobile m, DialogNPC npc)
        {
            Item reward = new Server.Items.Gold(50);
            //rose.Hue = 37;
            //rose.Name = "Casanova's Rose";

            if (m.AddToBackpack(reward))
            {
                npc.SayTo(m, "Thank you.");
                m_Received.Add(m);
            }
            else
            {
                npc.SayTo(m, "I wish I could grant you a reward, but I don't think you could carry its weight...");
            }
        }
    }
    public class GilwiremarHeadReward
    {
        private static ArrayList m_Received = new ArrayList();


        public static void GiveGilwiremarRewardTo(Mobile m, DialogNPC npc)
        {
            Item reward = new Server.Items.Gold(500);
            //rose.Hue = 37;
            //rose.Name = "Casanova's Rose";

            if (m.AddToBackpack(reward))
            {
                npc.SayTo(m, "Thank you.");
                m_Received.Add(m);
            }
            else
            {
                npc.SayTo(m, "I wish I could grant you a reward, but I don't think you could carry its weight...");
            }
        }

    }
}
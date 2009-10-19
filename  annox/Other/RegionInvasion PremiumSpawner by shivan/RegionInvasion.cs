using System;
using System.Collections;
using Server.Network;
using Server.Gumps;
using System.IO;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    public class RegionInvasionLeader : BaseCreature
    {
        private static int range = 1000;// This is the maximum range from the leader that the scritp checks for spawners.
        private double msgevery = 15.0; // How much time is "xxx is still under..." msgs(in minutes). 0 for disable.

        private bool init = false; // dont change this
        private bool restoreguards = false; // dont change this
        public override bool BardImmune { get { return true; } }
        private DateTime m_NextMsgTime;

        public RegionInvasionLeader(AIType AI, FightMode fm, int a, int b, double c, double d)
            : base(AI, fm, a, b, c, d)
        {
        }

        private void Start()
        {
            m_NextMsgTime = DateTime.Now + TimeSpan.FromMinutes(msgevery);

            foreach (Item ps in this.GetItemsInRange(range))
            {
                if (ps != null && ps is PremiumSpawner)
                {
                    PremiumSpawner sp = (PremiumSpawner)ps;
                    if (ps.Hue == 5)
                    {
                        sp.Running = true;
                        sp.Respawn();
                    }
                    if (ps.Hue == 10)
                    {
                        sp.Running = false;
                    }
                }
            }

            Regions.GuardedRegion reg = (Regions.GuardedRegion)this.Region.GetRegion(typeof(Regions.GuardedRegion));
            if (reg !=null && !(reg.Disabled))
            {
                restoreguards = true;
                reg.Disabled = true;
            }

            string meg = this.Region.Name + " is under attack by forces of " + this.Name + "!!!";
            BroadcastMessage(34,meg,true);
            init = true;
        }

        private void End()
        {
            foreach (Item ps in this.GetItemsInRange(range))
            {
                if (ps != null && ps is PremiumSpawner)
                {
                    PremiumSpawner sp = (PremiumSpawner)ps;
                    if (ps.Hue == 5)
                    {
                        sp.Running = false;
                    }
                }
            }

            FinalStone stone = new FinalStone();
            if (restoreguards)
            {
                stone.Weight = 1.0;
            }
            stone.Hue = range;
            stone.MoveToWorld(this.Location, this.Map);

            string meg = this.Name + " has fallen !!! " + this.Region.Name + " has been liberated.";
            BroadcastMessage(77, meg, true);
        }

        public override void OnThink()
        {
            if (init == false)
                Start();

            if (msgevery != 0 && DateTime.Now >= m_NextMsgTime)
            {
                string meg = this.Region.Name + " is still under control by forces of " + this.Name + ".";
                BroadcastMessage(34, meg, false);
                m_NextMsgTime = DateTime.Now + TimeSpan.FromMinutes(msgevery);
            }
        }

        public override bool OnBeforeDeath()
        {
            End();
            return base.OnBeforeDeath();
        }

        public static void BroadcastMessage(int hue, string message, bool con)
        {
            foreach (NetState state in NetState.Instances)
            {
                Mobile m = state.Mobile;
                if (m != null)
                    m.SendMessage(hue, message);
            }

            if (con)
            {
                Utility.PushColor(ConsoleColor.Green);
                Console.WriteLine(message);
                Utility.PopColor();
            }
        }

        public RegionInvasionLeader(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write(init);
            writer.Write(restoreguards);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            init = reader.ReadBool();
            restoreguards = reader.ReadBool();
        }
    }
}
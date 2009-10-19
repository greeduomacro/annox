using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Network;

namespace Server.Items
{
    public class FinalStone : Item
    {
        [Constructable]
        public FinalStone()
            : base()
        {
            ItemID = 5154;
            Name = "Final Stone(Timer)";
            Movable = false;
            Visible = false;
            Weight = 0;

            StopTimer(this);
            Timer t = new InternalTimer(this);
            m_Timers[this] = t;
            t.Start();
        }

        private static Hashtable m_Timers = new Hashtable();

        public static bool StopTimer(Item m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
            }

            return (t != null);
        }

        private class InternalTimer : Timer
        {
            private Item m_Owner;

            public InternalTimer(Item owner)
                : base(TimeSpan.FromMinutes(15.0))
            {
                m_Owner = owner;

                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                foreach (Item ps in m_Owner.GetItemsInRange(m_Owner.Hue))
                {
                    if (ps != null && ps is PremiumSpawner)
                    {
                        PremiumSpawner sp = (PremiumSpawner)ps;
                        if (ps.Hue == 10)
                        {
                            sp.Running = true;
                        }
                    }
                }

                if (m_Owner.Weight == 1.0)
                {
                    Orc orc = new Orc();
                    orc.MoveToWorld(m_Owner.Location, m_Owner.Map);
                    orc.Hidden = true;
                    Regions.GuardedRegion reg = (Regions.GuardedRegion)orc.Region.GetRegion(typeof(Regions.GuardedRegion));
                    if (reg != null && reg.Disabled)
                        reg.Disabled = false;

                    orc.Delete();
                }

                StopTimer(m_Owner);
                m_Owner.Delete();
            }
        }

        public FinalStone(Serial serial)
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
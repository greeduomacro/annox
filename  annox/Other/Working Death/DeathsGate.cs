using System;
using System.Collections;
using Server.Commands;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
    public class DeathsGate : Item
    {

        [Constructable]
        public DeathsGate()
            : base(0xF6C)
        {
            Weight = 2.0;
            Hue = 0x4B4;
            Name = "Death's Gate";
            Movable = false;
            new DeleteTimer(this).Start();
        }

        public override bool OnMoveOver(Mobile m)
        {
            m.CloseGump(typeof(HealerLocationGump));
            m.SendGump(new HealerLocationGump(m, m.Map, 2));

            return false;
        }

        private class DeleteTimer : Timer
        {
            private Item gate;

            public DeleteTimer(Item m_gate)
                : base(TimeSpan.FromSeconds(10.0))
            {
                gate = m_gate;
            }

            protected override void OnTick()
            {
                gate.Delete();
                Stop();
            }

        }

        public DeathsGate(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
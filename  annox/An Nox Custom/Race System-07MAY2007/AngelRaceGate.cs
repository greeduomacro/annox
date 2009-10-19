//27APR2007 Updated and improved upon by RavonTUS@yahoo.com
//Play at An Nox, the cure for the UO addiction.
//http://annox.no-ip.com
//Created By Cassius for Order of The Red Dragon

using System;

namespace Server.Items
{
    public class AngelRaceGate : Item
    {
        [Constructable]
        public AngelRaceGate()
            : base(0xF6C)
        {
            Movable = false;
            Light = LightType.Circle300;
            Hue = 1161;
            Name = "Angel Race Gate";
        }

        public override bool OnMoveOver(Mobile m)
        {
            if (m.BodyValue == 0x190 || m.BodyValue == 0x191 || m.BodyValue == 0x25D || m.BodyValue == 0x25E)
            {
                if (m.BodyMod ==  0)
                {
                    m.SendMessage("You are Now an Angel");
                    m.BodyMod = 123;
                    m.HueMod = 1161;
                    m.Title = "The Angel";
                    m.AddToBackpack(new AngelShiftTalisman());
                    m.Location = new Point3D(m.X + 2, m.Y + 2, m.Z);
                    World.Broadcast(0x35, true, "{0} see's the light and joins the Angels.", m.Name);

                    m.PlaySound(535);
                    Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
                    Effects.SendLocationParticles(EffectItem.Create(new Point3D(m.X + 2, m.Y + 2, m.Z), m.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);
                }
                m.SendMessage("Your race has already been choosen.");
            }
            return false;
        }

        public AngelRaceGate(Serial serial)
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

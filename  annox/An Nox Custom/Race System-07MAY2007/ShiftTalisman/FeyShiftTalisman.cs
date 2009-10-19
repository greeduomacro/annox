//27APR2007 Updated and improved upon by RavonTUS@yahoo.com
//Play at An Nox, the cure for the UO addiction.
//http://annox.no-ip.com

using System;
using Server.Items;

namespace Server.Items
{
    public class FeyShiftTalisman : Item
    {
        [Constructable]
        public FeyShiftTalisman()
            : base(0x207C)
        {
            Movable = true;
            Hue = 1378;
            Name = "A Fey Shapeshift Talisman";
            LootType = LootType.Blessed;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 2))
            {
                from.SendLocalizedMessage(500446); // That is too far away. 
            }
            else
            {
                if (from.Mounted == true)
                {
                    from.SendLocalizedMessage(1042561);
                }
                else
                {
                    if (from.BodyValue == 0x190 || from.BodyValue == 0x191 || from.BodyValue == 0x25D || from.BodyValue == 0x25E)
                    {
                        from.BodyMod = 176;
                        from.Title = "The Fey";
                        from.HueMod = 1378;

                        from.PlaySound(535);
                        Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
                        Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z), from.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);
                    }
                    else
                    {
                        from.BodyMod = 0x0;
                        from.HueMod = 1378;

                        from.PlaySound(586);
                        Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x376A, 1, 29, 0x47D, 2, 9962, 0);
                        Effects.SendLocationParticles(EffectItem.Create(new Point3D(from.X, from.Y, from.Z), from.Map, EffectItem.DefaultDuration), 0x37C4, 1, 29, 0x47D, 2, 9502, 0);
                    }
                }
            }
        }
        public FeyShiftTalisman(Serial serial)
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

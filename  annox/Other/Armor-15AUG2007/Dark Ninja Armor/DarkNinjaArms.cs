using System;
using Server.Items;

namespace Server.Items
{
    public class DarkNinjaArms : LeatherArms
    {
        public override int ArtifactRarity { get { return 10; } }

        public override int InitMinHits { get { return 30; } }
        public override int InitMaxHits { get { return 40; } }

        public override ArmorMeditationAllowance DefMedAllowance { get { return ArmorMeditationAllowance.All; } }

        [Constructable]
        public DarkNinjaArms()
        {
            Name = "Dark Ninja Arms";
            Hue = 1;
            Movable = false;
            Attributes.BonusHits = 10;
            PhysicalBonus = 30;
            ColdBonus = 30;
            FireBonus = 30;
            EnergyBonus = 30;
            Weight = 1.0;
        }

        public DarkNinjaArms(Serial serial)
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

        public override void OnDoubleClick(Mobile m)
        {
            Item g = m.FindItemOnLayer(Layer.Gloves);
            if (g != null) // Did we find an item?
            {
                g.Delete();
            }

            Item h = m.FindItemOnLayer(Layer.Helm);
            if (h != null) // Did we find an item?
            {
                h.Delete();
            }

            Item a = m.FindItemOnLayer(Layer.Arms);
            if (a != null) // Did we find an item?
            {
                a.Delete();
            }

            Item n = m.FindItemOnLayer(Layer.Neck);
            if (n != null) // Did we find an item?
            {
                n.Delete();
            }

            Item l = m.FindItemOnLayer(Layer.Pants);
            if (l != null) // Did we find an item?
            {
                l.Delete();
            }

            Item d = m.FindItemOnLayer(Layer.InnerTorso);
            if (d != null) // Did we find an item?
            {
                d.Delete();
            }

            Item f = m.FindItemOnLayer(Layer.FirstValid);
            if (f != null) // Did we find an item?
            {
                f.Delete();
            }
            m.AddToBackpack(new DarkNinjaArmor());
        }
    }
}
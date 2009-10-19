using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class ClawsOfTheBeast : Tekagi
    {
        public override int ArtifactRarity { get { return 15; } }

        public override int InitMinHits { get { return 35; } }
        public override int InitMaxHits { get { return 60; } }

        [Constructable]
        public ClawsOfTheBeast()
        {
            Name = "The Claws Of The Beast";
            Hue = 1;
            Movable = false;
            LootType = LootType.Blessed;
            WeaponAttributes.HitLightning = 50;
            Attributes.RegenHits = 10;
            Attributes.WeaponSpeed = 40;
            Attributes.WeaponDamage = 100;
            Attributes.AttackChance = 35;
            Attributes.DefendChance = 35;
            Attributes.Luck = 100;
            Attributes.BonusStr = 40;
            Attributes.BonusHits = 30;
            Weight = 1.0;
            Layer = Layer.FirstValid;
        }
        public override void OnDoubleClick(Mobile m)
        {
            Item g = m.FindItemOnLayer(Layer.Gloves);
            if (g != null) // Did we find an item?
            {
                g.Delete();
            }

            Item f = m.FindItemOnLayer(Layer.FirstValid);
            if (f != null) // Did we find an item?
            {
                f.Delete();
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

            m.AddToBackpack(new DarkNinjaArmor());
        }
        public ClawsOfTheBeast(Serial serial)
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
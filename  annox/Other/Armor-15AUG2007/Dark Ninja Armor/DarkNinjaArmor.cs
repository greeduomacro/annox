using System;
using Server;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{

    public class DarkNinjaArmor : Item
    {
        [Constructable]
        public DarkNinjaArmor()
            : this(null)
        {
        }

        [Constructable]
        public DarkNinjaArmor(string name)
            : base(0x13E0)
        {
            Name = "A Glowing Dark Ninja Statue";
            LootType = LootType.Blessed;
            Hue = 1;
            ItemID = 8454;
        }

        public DarkNinjaArmor(Serial serial)
            : base(serial)
        {
        }


        public override void OnDoubleClick(Mobile m)
        {
            Effects.PlaySound(m.Location, m.Map, 362);

            Item o = m.FindItemOnLayer(Layer.Helm);
            if (o != null && o is DarkNinjaHood)
            {
                o.Delete();
            }

            Item f = m.FindItemOnLayer(Layer.FirstValid);
            if (f != null && f is ClawsOfTheBeast)
            {
                f.Delete();
            }

            Item v = m.FindItemOnLayer(Layer.Gloves);
            if (v != null && v is DarkNinjaMitts)
            {
                v.Delete();
            }

            Item k = m.FindItemOnLayer(Layer.Arms);
            if (k != null && k is DarkNinjaArms)
            {
                k.Delete();
            }

            Item y = m.FindItemOnLayer(Layer.Neck);
            if (y != null && y is VoiceOfTheDarkNinja)
            {
                y.Delete();
            }

            Item t = m.FindItemOnLayer(Layer.Pants);
            if (t != null && t is DarkNinjaPants)
            {
                t.Delete();
            }

            Item b = m.FindItemOnLayer(Layer.InnerTorso);
            if (b != null && b is DarkNinjaJacket)
            {
                b.Delete();
            }

            Item h = m.FindItemOnLayer(Layer.Helm);
            if (h != null) // Did we find an item?
            {
                m.AddToBackpack(h); //put the item in their backpack (unequip it) 
            }

            Item g = m.FindItemOnLayer(Layer.Gloves);
            if (g != null) // Did we find an item?
            {
                m.AddToBackpack(g); //put the item in their backpack (unequip it) 
            }

            Item a = m.FindItemOnLayer(Layer.Arms);
            if (a != null) // Did we find an item?
            {
                m.AddToBackpack(a); //put the item in their backpack (unequip it) 
            }

            Item n = m.FindItemOnLayer(Layer.Neck);
            if (n != null) // Did we find an item?
            {
                m.AddToBackpack(n); //put the item in their backpack (unequip it) 
            }

            Item l = m.FindItemOnLayer(Layer.OuterLegs);
            if (l != null) // Did we find an item?
            {
                m.AddToBackpack(l); //put the item in their backpack (unequip it) 
            }

            Item i = m.FindItemOnLayer(Layer.InnerLegs);
            if (i != null) // Did we find an item?
            {
                m.AddToBackpack(i); //put the item in their backpack (unequip it) 
            }

            Item r = m.FindItemOnLayer(Layer.InnerTorso);
            if (r != null) // Did we find an item?
            {
                m.AddToBackpack(r); //put the item in their backpack (unequip it) 
            }

            Item d = m.FindItemOnLayer(Layer.MiddleTorso);
            if (d != null) // Did we find an item?
            {
                m.AddToBackpack(d); //put the item in their backpack (unequip it) 
            }

            Item s = m.FindItemOnLayer(Layer.Shoes);
            if (s != null) // Did we find an item?
            {
                m.AddToBackpack(s); //put the item in their backpack (unequip it) 
            }

            Item w = m.FindItemOnLayer(Layer.Waist);
            if (w != null) // Did we find an item?
            {
                m.AddToBackpack(w); //put the item in their backpack (unequip it) 
            }

            Item c = m.FindItemOnLayer(Layer.Pants);
            if (c != null) // Did we find an item?
            {
                m.AddToBackpack(c); //put the item in their backpack (unequip it) 
            }

            m.EquipItem(new DarkNinjaHood());
            m.EquipItem(new DarkNinjaMitts());
            m.EquipItem(new DarkNinjaJacket());
            m.EquipItem(new VoiceOfTheDarkNinja());
            m.EquipItem(new DarkNinjaPants());
            m.EquipItem(new DarkNinjaArms());
            m.EquipItem(new ClawsOfTheBeast());

            Delete();

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
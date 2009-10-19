using System;

namespace Server.Items
{
    public class EarthOrb : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} EarthOrb" : "{0} EarthOrb", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public EarthOrb()
            : this(1)
        {
        }

        [Constructable]
        public EarthOrb(int amount)
            : base(3630)
        {
            Stackable = false;
            Hue = 1818;
            Name = "Orb Of Earth";
            Weight = 0.1;
            Amount = amount;
        }

        public EarthOrb(Serial serial)
            : base(serial)
        {
        }

        //public override Item Dupe(int amount)
        //{
        //    return base.Dupe(new Arrow(amount), amount);
        //}

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
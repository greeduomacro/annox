using System;

namespace Server.Items
{
    public class WaterOrb : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} WaterOrb" : "{0} WaterOrbs", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public WaterOrb()
            : this(1)
        {
        }

        [Constructable]
        public WaterOrb(int amount)
            : base(3630)
        {
            Stackable = false;
            Hue = 6;
            Name = "Orb Of Tides";
            Weight = 0.1;
            Amount = amount;
        }

        public WaterOrb(Serial serial)
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
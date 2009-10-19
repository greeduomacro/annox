using System;

namespace Server.Items
{
    public class AirOrb : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} AirOrb" : "{0} AirOrbs", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public AirOrb()
            : this(1)
        {
        }

        [Constructable]
        public AirOrb(int amount)
            : base(3630)
        {
            Stackable = false;
            Hue = 1159;
            Name = "Orb Of Winds";
            Weight = 0.1;
            Amount = amount;
        }

        public AirOrb(Serial serial)
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
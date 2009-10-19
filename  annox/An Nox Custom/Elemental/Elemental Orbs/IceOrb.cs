using System;

namespace Server.Items
{
    public class IceOrb : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} IceOrb" : "{0} IceOrbs", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public IceOrb()
            : this(1)
        {
        }

        [Constructable]
        public IceOrb(int amount)
            : base(3630)
        {
            Stackable = false;
            Hue = 1151;
            Name = "Orb Of Ice";
            Weight = 0.1;
            Amount = amount;
        }

        public IceOrb(Serial serial)
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
using System;

namespace Server.Items
{
    public class FireOrb : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} FireOrb" : "{0} FireOrbs", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public FireOrb()
            : this(1)
        {
        }

        [Constructable]
        public FireOrb(int amount)
            : base(3630)
        {
            Stackable = false;
            Hue = 37;
            Name = "Orb Of Flames";
            Weight = 0.1;
            Amount = amount;
        }

        public FireOrb(Serial serial)
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
using System;

namespace Server.Items
{
    public class PoisonOrb : Item, ICommodity
    {
        string ICommodity.Description
        {
            get
            {
                return String.Format(Amount == 1 ? "{0} PoisonOrb" : "{0} PoisonOrbs", Amount);
            }
        }

        int ICommodity.DescriptionNumber { get { return LabelNumber; } }

        [Constructable]
        public PoisonOrb()
            : this(1)
        {
        }

        [Constructable]
        public PoisonOrb(int amount)
            : base(3630)
        {
            Stackable = false;
            Hue = 68;
            Name = "Orb Of Toxins";
            Weight = 0.1;
            Amount = amount;
        }

        public PoisonOrb(Serial serial)
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
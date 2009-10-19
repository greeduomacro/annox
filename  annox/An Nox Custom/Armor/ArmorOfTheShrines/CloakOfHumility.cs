using System;

namespace Server.Items
{
    [Flipable(0x2B04, 0x2B05)]
    public class CloakOfHumility : BaseCloak
    {
        [Constructable]
        public CloakOfHumility()
            : base(0x2B04)
        {
            Name = "Cloak of Humility";
            Weight = 4.0;
        }

        public CloakOfHumility(Serial serial)
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
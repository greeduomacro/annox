//03APR2007 Armor of the Shrines by RavonTUS.  Play at An Nox, the cure for the UO addiction.
//Values are that of Bone Armor, if you know the correct values please pass them along.

using System;
using Server;

namespace Server.Items
{
    [Flipable(0x2B01, 0x2B02)]
    public class DupresShield : BaseShield, IDyable
    {
        public override int BasePhysicalResistance { get { return 0; } }
        public override int BaseFireResistance { get { return 0; } }
        public override int BaseColdResistance { get { return 0; } }
        public override int BasePoisonResistance { get { return 0; } }
        public override int BaseEnergyResistance { get { return 1; } }

        public override int InitMinHits { get { return 45; } }
        public override int InitMaxHits { get { return 60; } }

        public override int AosStrReq { get { return 45; } }

        public override int ArmorBase { get { return 16; } }

        [Constructable]
        public DupresShield()
            : base(0x2B01)
        {
            Name = "Dupres Shield";
            Weight = 7.0;
        }

        public DupresShield(Serial serial)
            : base(serial)
        {
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            Hue = sender.DyedHue;

            return true;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (Weight == 5.0)
                Weight = 7.0;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
}

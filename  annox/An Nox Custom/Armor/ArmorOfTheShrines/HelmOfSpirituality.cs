//03APR2007 Armor of the Shrines by RavonTUS.  Play at An Nox, the cure for the UO addiction.
//Values are that of Bone Armor, if you know the correct values please pass them along.

using System;
using Server;

namespace Server.Items
{
    [FlipableAttribute(0x2B10, 0x2B11)]
    public class HelmOfSpirituality : BaseArmor
    {
        public override int BasePhysicalResistance { get { return 3; } }
        public override int BaseFireResistance { get { return 3; } }
        public override int BaseColdResistance { get { return 4; } }
        public override int BasePoisonResistance { get { return 2; } }
        public override int BaseEnergyResistance { get { return 4; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 20; } }
        public override int OldStrReq { get { return 40; } }

        public override int ArmorBase { get { return 30; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }

        [Constructable]
        public HelmOfSpirituality()
            : base(0x2B10)
        {
            Name = "Name of Spirituality";
            Weight = 3.0;
        }

        public HelmOfSpirituality(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            if (Weight == 1.0)
                Weight = 3.0;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
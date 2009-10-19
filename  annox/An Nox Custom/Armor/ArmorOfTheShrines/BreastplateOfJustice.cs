//03APR2007 Armor of the Shrines by RavonTUS.  Play at An Nox, the cure for the UO addiction.
//Values are that of Bone Armor, if you know the correct values please pass them along.

using System;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x2B08, 0x2B09)]
    public class BreastplateOfJustice : BaseArmor
    {
        public override int BasePhysicalResistance { get { return 3; } }
        public override int BaseFireResistance { get { return 3; } }
        public override int BaseColdResistance { get { return 4; } }
        public override int BasePoisonResistance { get { return 2; } }
        public override int BaseEnergyResistance { get { return 4; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 60; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -6; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 11; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public BreastplateOfJustice()
            : base(0x2B08)
        {
            Name = "Breastplate of Justice";
            Weight = 6.0;
        }

        public BreastplateOfJustice(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            if (Weight == 1.0)
                Weight = 6.0;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
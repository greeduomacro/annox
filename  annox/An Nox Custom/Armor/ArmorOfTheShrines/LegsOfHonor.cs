//03APR2007 Armor of the Shrines by RavonTUS.  Play at An Nox, the cure for the UO addiction.
//Values are that of Bone Armor, if you know the correct values please pass them along.

using System;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x2B06, 0x2B07)]
    public class LegsOfHonor : BaseArmor
    {
        public override int BasePhysicalResistance { get { return 3; } }
        public override int BaseFireResistance { get { return 3; } }
        public override int BaseColdResistance { get { return 4; } }
        public override int BasePoisonResistance { get { return 2; } }
        public override int BaseEnergyResistance { get { return 4; } }

        public override int InitMinHits { get { return 25; } }
        public override int InitMaxHits { get { return 30; } }

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -4; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 7; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LegsOfHonor()
            : base(0x2B06)
        {
            Name = "Legs of Honor";
            Weight = 3.0;
        }

        public LegsOfHonor(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
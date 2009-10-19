using System;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x1450, 0x1455)]
    public class DaemonMetalGloves : BaseArmor
    {
        public override int ArtifactRarity { get { return 69; } }
        public override int BasePhysicalResistance { get { return 70; } }
        public override int BaseFireResistance { get { return 70; } }
        public override int BaseColdResistance { get { return 70; } }
        public override int BasePoisonResistance { get { return 70; } }
        public override int BaseEnergyResistance { get { return 70; } }

        public override int InitMinHits { get { return 561; } }
        public override int InitMaxHits { get { return 561; } }

        private ArmorDurabilityLevel m_Indestructible;
        private ArmorProtectionLevel m_Invulnerability;

        public override int AosStrReq { get { return 55; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -1; } }

        public override int ArmorBase { get { return 46; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        public override int LabelNumber { get { return 1041373; } } // daemon metal gloves

        [Constructable]
        public DaemonMetalGloves()
            : base(0x1450)
        {
            LootType = LootType.Blessed;
            Name = "Daemon Metal Gloves";
            Weight = 2.0;
            Hue = 1645;
        }

        public DaemonMetalGloves(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            if (Weight == 1.0)
                Weight = 2.0;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
using System;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x144f, 0x1454)]
    public class DaemonMetalChest : BaseArmor
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

        public override int AosStrReq { get { return 60; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -6; } }

        public override int ArmorBase { get { return 46; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        public override int LabelNumber { get { return 1041372; } } // daemon metal armor

        [Constructable]
        public DaemonMetalChest()
            : base(0x144F)
        {
            LootType = LootType.Blessed;
            Name = "Daemon Metal Chest";
            Hue = 1645;
            Weight = 6.0;
            Hue = 0x648;
        }

        public DaemonMetalChest(Serial serial)
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
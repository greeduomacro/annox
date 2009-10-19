using System;
using Server;

namespace Server.Items
{
    [FlipableAttribute(0x1451, 0x1456)]
    public class DaemonMetalHelm : BaseArmor
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

        public override int LabelNumber { get { return 1041374; } } // daemon metal helmet

        [Constructable]
        public DaemonMetalHelm()
            : base(0x1451)
        {
            LootType = LootType.Blessed;
            Name = "Daemon Metal Helm";
            Hue = 1645;
            Weight = 3.0;
        }

        public DaemonMetalHelm(Serial serial)
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

            if (Weight == 1.0)
                Weight = 3.0;
        }
    }
}
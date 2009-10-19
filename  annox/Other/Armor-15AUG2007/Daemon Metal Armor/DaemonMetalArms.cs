using System;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x1410, 0x1417)]
    public class DaemonMetalArms : BaseArmor
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

        public override int AosStrReq { get { return 80; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 40; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }

        [Constructable]
        public DaemonMetalArms()
            : base(0x1410)
        {
            LootType = LootType.Blessed;
            Name = "Daemon Metal Arms";
            Hue = 1645;
            Weight = 5.0;
        }

        public DaemonMetalArms(Serial serial)
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
                Weight = 5.0;
        }
    }
}
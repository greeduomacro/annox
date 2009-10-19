using System;
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute(0x13cc, 0x13d3)]
    public class ArmorOfTheOrcsArms : BaseArmor
    {
        public override int ArtifactRarity { get { return 15; } }
        public override int BasePhysicalResistance { get { return 0; } }
        public override int BaseFireResistance { get { return 0; } }
        public override int BaseColdResistance { get { return 0; } }
        public override int BasePoisonResistance { get { return 0; } }
        public override int BaseEnergyResistance { get { return 0; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override int AosStrReq { get { return 60; } }
        public override int OldStrReq { get { return 60; } }

        public override int ArmorBase { get { return 20; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }


        public override ArmorMeditationAllowance DefMedAllowance { get { return ArmorMeditationAllowance.All; } }

        [Constructable]
        public ArmorOfTheOrcsArms()
            : base(0x13CD)
        {
            Weight = 6.0;
            Hue = 2212;

            ArmorAttributes.SelfRepair = 10;
            Attributes.RegenMana = 10;
            Attributes.LowerRegCost = 20;
            Attributes.Luck = 100;

            Attributes.BonusInt = 5;

            PhysicalBonus = 20;
            PoisonBonus = 20;
            EnergyBonus = 20;
            FireBonus = 20;




        }

        public ArmorOfTheOrcsArms(Serial serial)
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
                Weight = 6.0;
        }
    }
}

//Base Armor Template....Made by Gold Draco 13.
//Just remove the // before the lines you want to allow on weapon.
//Replace the nn with your values.
//If you have problems please visit my site at www.81x.com/golddraco13/dragons_of_pern and use email link there.
using System;
using Server;

namespace Server.Items
{
    public class FrostTunic : ChainChest // Your Armor name(no spaces) : Name of base Armor ie: PlateChest (remember to capitalize both names)
    {
        public override int ArtifactRarity { get { return 8; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        [Constructable]
        public FrostTunic()
        {
            Weight = 2.2;
            Name = "Tunic Of Frost";
            Hue = 1154;

            //Attributes.AttackChance = nn;
            //Attributes.BonusDex = nn;
            //Attributes.BonusHits = nn;
            //Attributes.BonusInt = nn;
            //Attributes.BonusMana = nn;
            //Attributes.BonusStam = nn;
            //Attributes.BonusStr = nn;
            //Attributes.CastRecovery = nn;
            Attributes.CastSpeed = 1;
            //Attributes.DefendChance = nn;
            //Attributes.EnhancePotions = nn;
            Attributes.LowerManaCost = 5;
            //Attributes.LowerRegCost = nn;
            //Attributes.Luck = nn;
            //Attributes.Nightsight = 1;
            //Attributes.ReflectPhysical = nn;
            //Attributes.RegenHits = nn;
            //Attributes.RegenMana = nn;
            //Attributes.RegenStam = nn;
            //Attributes.SpellChanneling = 1;
            //Attributes.SpellDamage = nn;
            Attributes.WeaponDamage = 5;
            //Attributes.WeaponSpeed = nn;

            //ArmorAttributes.DurabilityBonus = nn;
            //ArmorAttributes.LowerStatReq = nn;
            ArmorAttributes.MageArmor = 1;
            //ArmorAttributes.SelfRepair = nn;

            ColdBonus = 15;
            //DexBonus = nn;
            //DexRequirement = nn;
            EnergyBonus = 10;
            FireBonus = 2;
            //IntBonus = nn;
            //IntRequirement = nn;
            PhysicalBonus = 8;
            PoisonBonus = 2;
            //StrBonus = nn;
            //StrRequirement = nn;

            //LootType = LootType.nn; //Blessed, Newbied or Cursed

        }

        public FrostTunic(Serial serial)
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

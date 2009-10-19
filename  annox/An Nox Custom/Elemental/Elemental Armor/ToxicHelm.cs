//Base Armor Template....Made by Gold Draco 13.
//Just remove the // before the lines you want to allow on weapon.
//Replace the nn with your values.
//If you have problems please visit my site at www.81x.com/golddraco13/dragons_of_pern and use email link there.
using System;
using Server;

namespace Server.Items
{
    public class ToxicHelm : PlateHelm // Your Armor name(no spaces) : Name of base Armor ie: PlateChest (remember to capitalize both names)
    {
        public override int ArtifactRarity { get { return 8; } }

        //public override int InitMinHits{ get{ return nn; } }
        //public override int InitMaxHits{ get{ return nn; } }

        [Constructable]
        public ToxicHelm()
        {
            Weight = 2.2;
            Name = "Helm Of Toxin";
            Hue = 70;

            //Attributes.AttackChance = nn;
            //Attributes.BonusDex = nn;
            //Attributes.BonusHits = nn;
            //Attributes.BonusInt = nn;
            //Attributes.BonusMana = nn;
            //Attributes.BonusStam = nn;
            //Attributes.BonusStr = nn;
            //Attributes.CastRecovery = nn;
            //Attributes.CastSpeed = nn;
            Attributes.DefendChance = 10;
            Attributes.EnhancePotions = 10;
            //Attributes.LowerManaCost = nn;
            //Attributes.LowerRegCost = nn;
            //Attributes.Luck = nn;
            //Attributes.Nightsight = 1;
            //Attributes.ReflectPhysical = nn;
            Attributes.RegenHits = 1;
            //Attributes.RegenMana = nn;
            //Attributes.RegenStam = nn;
            //Attributes.SpellChanneling = 1;
            //Attributes.SpellDamage = nn;
            //Attributes.WeaponDamage = nn;
            //Attributes.WeaponSpeed = nn;

            //ArmorAttributes.DurabilityBonus = nn;
            //ArmorAttributes.LowerStatReq = nn;
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.SelfRepair = 2;

            ColdBonus = 2;
            //DexBonus = nn;
            //DexRequirement = nn;
            EnergyBonus = 2;
            FireBonus = 8;
            //IntBonus = nn;
            //IntRequirement = nn;
            PhysicalBonus = 12;
            PoisonBonus = 16;
            StrBonus = 2;
            //StrRequirement = nn;

            //LootType = LootType.nn; //Blessed, Newbied or Cursed

        }

        public ToxicHelm(Serial serial)
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

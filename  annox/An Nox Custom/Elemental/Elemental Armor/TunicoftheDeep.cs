//Base Armor Template....Made by Gold Draco 13.
//Just remove the // before the lines you want to allow on weapon.
//Replace the nn with your values.
//If you have problems please visit my site at www.81x.com/golddraco13/dragons_of_pern and use email link there.
using System;
using Server;

namespace Server.Items
{
    public class TunicOfTheDeep : PlateChest // Your Armor name(no spaces) : Name of base Armor ie: PlateChest (remember to capitalize both names)
    {
        public override int ArtifactRarity { get { return 8; } }

        public override int InitMinHits { get { return 200; } }
        public override int InitMaxHits { get { return 200; } }

        [Constructable]
        public TunicOfTheDeep()
        {
            Weight = 1.5;
            Name = "Tunic Of The Deep";
            Hue = 1176;

            //Attributes.AttackChance = nn;
            //Attributes.BonusDex = nn;
            //Attributes.BonusHits = nn;
            //Attributes.BonusInt = nn;
            //Attributes.BonusMana = nn;
            //Attributes.BonusStam = nn;
            //Attributes.BonusStr = nn;
            //Attributes.CastRecovery = nn;
            //Attributes.CastSpeed = nn;
            //Attributes.DefendChance = nn;
            //Attributes.EnhancePotions = nn;
            //Attributes.LowerManaCost = nn;
            //Attributes.LowerRegCost = nn;
            //Attributes.Luck = nn;
            //Attributes.Nightsight = 1;
            //Attributes.ReflectPhysical = nn;
            //Attributes.RegenHits = nn;
            Attributes.RegenMana = 3;
            //Attributes.RegenStam = nn;
            //Attributes.SpellChanneling = 1;
            //Attributes.SpellDamage = nn;
            //Attributes.WeaponDamage = nn;
            //Attributes.WeaponSpeed = nn;

            //ArmorAttributes.DurabilityBonus = nn;
            //ArmorAttributes.LowerStatReq = nn;
            ArmorAttributes.MageArmor = 1;
            ArmorAttributes.SelfRepair = 2;

            ColdBonus = 15;
            //DexBonus = nn;
            //DexRequirement = nn;
            EnergyBonus = 2;
            FireBonus = 2;
            IntBonus = 10;
            //IntRequirement = nn;
            PhysicalBonus = 10;
            PoisonBonus = 6;
            //StrBonus = nn;
            //StrRequirement = nn;



        }

        public TunicOfTheDeep(Serial serial)
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

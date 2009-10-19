using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class AncientRepeatingCrossbow : RepeatingCrossbow
	{
	 	public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }

		public override int InitMinHits{ get{ return 200; } }
	 	public override int InitMaxHits{ get{ return 200; } }
	 	[Constructable]
	 	public AncientRepeatingCrossbow()
	 	{
	 	 	Name = "Ancient Repeating Crossbow";
	 	 	LootType = LootType.Blessed;
	 	 	Attributes.AttackChance = 20;
	 	 	Attributes.WeaponDamage = 30;
	 	 	Attributes.WeaponSpeed = 10;
			Hue = 1150;	 	 	
	 	}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.BeginTarget( 2, false, TargetFlags.None, new TargetCallback( OnTarget ) );
				from.SendMessage( "Select the Ancient Forge you wish to dip the weapon in." );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		public void OnTarget( Mobile from, object obj )
		{								
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}

			MightForgeAddon mightforge = obj as MightForgeAddon;

				if ( mightforge == null && obj is AddonComponent )
					mightforge = ((AddonComponent)obj).Addon as MightForgeAddon;

			FireForgeAddon fireforge = obj as FireForgeAddon;

				if ( fireforge == null && obj is AddonComponent )
					fireforge = ((AddonComponent)obj).Addon as FireForgeAddon;

			IceForgeAddon iceforge = obj as IceForgeAddon;

				if ( iceforge == null && obj is AddonComponent )
					iceforge = ((AddonComponent)obj).Addon as IceForgeAddon;

			EnergyForgeAddon energyforge = obj as EnergyForgeAddon;

				if ( energyforge == null && obj is AddonComponent )
					energyforge = ((AddonComponent)obj).Addon as EnergyForgeAddon;

			PoisonForgeAddon poisonforge = obj as PoisonForgeAddon;

				if ( poisonforge == null && obj is AddonComponent )
					poisonforge = ((AddonComponent)obj).Addon as PoisonForgeAddon;			
						
			if ( mightforge != null )
			{
				Name = "Ancient Repeating Crossbow of Might";
				WeaponAttributes.ResistPhysicalBonus = 20;
				WeaponAttributes.HitPhysicalArea = 50;
				WeaponAttributes.ResistFireBonus = 0;
				WeaponAttributes.HitFireArea = 0;
				WeaponAttributes.ResistColdBonus = 0;
				WeaponAttributes.HitColdArea = 0;
				WeaponAttributes.ResistEnergyBonus = 0;
				WeaponAttributes.HitEnergyArea = 0;
				WeaponAttributes.ResistPoisonBonus = 0;
				WeaponAttributes.HitPoisonArea = 0;
				Attributes.WeaponDamage = 60;
				Attributes.WeaponSpeed = 20;
				Attributes.SpellChanneling = 1;
				Attributes.ReflectPhysical = 10;
				Attributes.SpellDamage = 0;
				Attributes.RegenMana = 0;
				Attributes.BonusDex = 0;
	 	 		Attributes.BonusHits = 15;
				Attributes.RegenHits = 2;
				Attributes.Luck = 70;
	 	 		Attributes.AttackChance = 35;
				Hue = 1328;
				from.SendMessage ("You dip the weapon into the Ancient Forge of Might, imbuing the weapon with the Essence of Might.");
			}			
			
			else if ( fireforge != null )
			{
				Name = "Ancient Repeating Crossbow of Fire";
				WeaponAttributes.ResistPhysicalBonus = 0;
				WeaponAttributes.HitPhysicalArea = 0;
				WeaponAttributes.ResistFireBonus = 20;
				WeaponAttributes.HitFireArea = 50;
				WeaponAttributes.ResistColdBonus = 0;
				WeaponAttributes.HitColdArea = 0;
				WeaponAttributes.ResistEnergyBonus = 0;
				WeaponAttributes.HitEnergyArea = 0;
				WeaponAttributes.ResistPoisonBonus = 0;
				WeaponAttributes.HitPoisonArea = 0;
				Attributes.WeaponDamage = 50;
				Attributes.WeaponSpeed = 25;
				Attributes.SpellChanneling = 1;
				Attributes.ReflectPhysical = 0;
				Attributes.SpellDamage = 20;
				Attributes.RegenMana = 2;
				Attributes.BonusDex = 0;
	 	 		Attributes.BonusHits = 0;
				Attributes.RegenHits = 0;
				Attributes.Luck = 70;
	 	 		Attributes.AttackChance = 35;
				Hue = 1260;
				from.SendMessage ("You dip the weapon into the Ancient Forge of Fire, imbuing the weapon with the Essence of Fire.");
			}

			else if ( iceforge != null )
			{
				Name = "Ancient Repeating Crossbow of Ice";
				WeaponAttributes.ResistPhysicalBonus = 0;
				WeaponAttributes.HitPhysicalArea = 0;
				WeaponAttributes.ResistFireBonus = 0;
				WeaponAttributes.HitFireArea = 0;
				WeaponAttributes.ResistColdBonus = 20;
				WeaponAttributes.HitColdArea = 50;
				WeaponAttributes.ResistEnergyBonus = 0;
				WeaponAttributes.HitEnergyArea = 0;
				WeaponAttributes.ResistPoisonBonus = 0;
				WeaponAttributes.HitPoisonArea = 0;
				Attributes.WeaponDamage = 50;
				Attributes.WeaponSpeed = 25;
				Attributes.SpellChanneling = 1;
				Attributes.ReflectPhysical = 0;
				Attributes.SpellDamage = 20;
				Attributes.RegenMana = 2;
				Attributes.BonusDex = 0;
	 	 		Attributes.BonusHits = 0;
				Attributes.RegenHits = 0;
				Attributes.Luck = 70;
	 	 		Attributes.AttackChance = 35;
				Hue = 1266;
				from.SendMessage ("You dip the weapon into the Ancient Forge of Ice, imbuing the weapon with the Essence of Ice.");
			}

			else if ( energyforge != null )
			{
				Name = "Ancient Repeating Crossbow of Energy";
				WeaponAttributes.ResistPhysicalBonus = 0;
				WeaponAttributes.HitPhysicalArea = 0;
				WeaponAttributes.ResistFireBonus = 0;
				WeaponAttributes.HitFireArea = 0;
				WeaponAttributes.ResistColdBonus = 0;
				WeaponAttributes.HitColdArea = 0;
				WeaponAttributes.ResistEnergyBonus = 20;
				WeaponAttributes.HitEnergyArea = 50;
				WeaponAttributes.ResistPoisonBonus = 0;
				WeaponAttributes.HitPoisonArea = 0;
				Attributes.WeaponDamage = 40;
				Attributes.WeaponSpeed = 35;
				Attributes.SpellChanneling = 1;
				Attributes.ReflectPhysical = 0;
				Attributes.SpellDamage = 0;
				Attributes.RegenMana = 0;
				Attributes.BonusDex = 20;
	 	 		Attributes.BonusHits = 0;
				Attributes.RegenHits = 1;
				Attributes.Luck = 100;
	 	 		Attributes.AttackChance = 35;
				Hue = 1278;
				from.SendMessage ("You dip the weapon into the Ancient Forge of Energy, imbuing the weapon with the Essence of Energy.");
			}

			else if ( poisonforge != null )
			{
				Name = "Ancient Repeating Crossbow of Poison";
				WeaponAttributes.ResistPhysicalBonus = 0;
				WeaponAttributes.HitPhysicalArea = 0;
				WeaponAttributes.ResistFireBonus = 0;
				WeaponAttributes.HitFireArea = 0;
				WeaponAttributes.ResistColdBonus = 0;
				WeaponAttributes.HitColdArea = 0;
				WeaponAttributes.ResistEnergyBonus = 0;
				WeaponAttributes.HitEnergyArea = 0;
				WeaponAttributes.ResistPoisonBonus = 20;
				WeaponAttributes.HitPoisonArea = 50;
				Attributes.WeaponDamage = 45;
				Attributes.WeaponSpeed = 30;
				Attributes.SpellChanneling = 1;
				Attributes.ReflectPhysical = 0;
				Attributes.SpellDamage = 0;
				Attributes.RegenMana = 0;
				Attributes.BonusDex = 15;
	 	 		Attributes.BonusHits = 0;
				Attributes.RegenHits = 1;
				Attributes.Luck = 85;
	 	 		Attributes.AttackChance = 40;
				Hue = 1272;
				from.SendMessage ("You dip the weapon into the Ancient Forge of Poison, imbuing the weapon with the Essence of Poison.");
			}

			else
			{
				from.SendMessage( "Nothing happens." );
			}
		}		

	 	public AncientRepeatingCrossbow(Serial serial) : base( serial )
	 	{
	 	}

	 	public override void Serialize( GenericWriter writer )
	 	{
	 	 	base.Serialize( writer );

	 	 	writer.Write( (int) 0 );
	 	}
	 	public override void Deserialize(GenericReader reader)
	 	{
	 	 	base.Deserialize( reader );

	 	 	int version = reader.ReadInt();
	 	}
	}
}

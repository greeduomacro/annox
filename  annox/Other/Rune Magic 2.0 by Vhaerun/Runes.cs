using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;
using Server.Targeting;
using Server.Misc;

namespace Server.Items
{
	public abstract class RuneStone : Item
	{
		public RuneStone() : base( 0x1F14 )
		{
			Weight = 0.2;  // ?
		}

		public override void OnDoubleClick( Mobile from ) 
		{
			double minSkill = 70.0;
		 
			PlayerMobile pm = from as PlayerMobile;
		
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}

			else if ( pm == null || from.Skills[SkillName.Magery].Base < 70.0 )
			{
				from.SendMessage( "You are not skilled enough in magery to attempt runic enhancements." );
			}

		        else if( from.InRange( this.GetWorldLocation(), 1 ) ) 
		        {
				double maxSkill = minSkill + 40.0;

				if ( !from.CheckSkill( SkillName.Magery, minSkill, maxSkill ) )
				{
					from.SendMessage( "The runic enhancement has failed." );
					from.PlaySound( 0x1F6 );
					Delete();
					return;
				}
				else
				{
					from.SendMessage( "Select the item to enhance." );
					from.Target = new InternalTarget( this );
				}
		        } 

		        else 
		        { 
		        	from.SendLocalizedMessage( 500446 ); // That is too far away. 
		        } 
		} 
		
		private class InternalTarget : Target 
		{
			private RuneStone m_RuneStone;

			public InternalTarget( RuneStone runeaug ) : base( 1, false, TargetFlags.None )
			{
				m_RuneStone = runeaug;
			}

		 	protected override void OnTarget( Mobile from, object targeted ) 
		 	{ 
				int scalar;
				double mageSkill = from.Skills[SkillName.Magery].Value;

				if ( mageSkill >= 100.0 )
					scalar = 3;
				else if ( mageSkill >= 90.0 )
					scalar = 2;
				else
					scalar = 1;

			    	if ( targeted is BaseWeapon ) 
				{ 
			       		BaseWeapon Weapon = targeted as BaseWeapon; 

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 1 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}

					else
		       			{
						int DestroyChance = Utility.Random( 10 );

						if ( DestroyChance > 0 ) // Success
						{
							int augment = ( ( Utility.Random( 3 ) ) * scalar ) + 1;
							int augmentper = ( ( Utility.Random( 5 ) ) * scalar ) + 5;

							switch ( Utility.Random( 9 ) )
							{
								case 0: Weapon.Attributes.AttackChance += augmentper; from.SendMessage( "A true weapon strikes true wounds." ); break;
								case 1: Weapon.Attributes.BonusMana += augment; from.SendMessage( "The spirit rises within." ); break;
								case 2: Weapon.Attributes.WeaponDamage += augmentper; from.SendMessage( "A warrior is only as good as his best weapon." ); break;
								case 3: Weapon.Attributes.SpellChanneling = 1; from.SendMessage( "The mage's best ally." ); break;
								case 4: Weapon.WeaponAttributes.HitDispel += augmentper; from.SendMessage( "The bane of demons, the unsummoner." ); break;
								case 5: Weapon.WeaponAttributes.HitFireball += augmentper; from.SendMessage( "What the blade leaves alive, the fire purifies." ); break;
								case 6: Weapon.WeaponAttributes.HitHarm += augmentper; from.SendMessage( "Sometimes the sting can be worse." ); break;
								case 7: Weapon.WeaponAttributes.HitLightning += augmentper; from.SendMessage( "The power of the storm is called to strike." ); break;
								case 8: Weapon.Attributes.WeaponSpeed += augmentper; from.SendMessage( "What can beat speed but more speed?" ); break;
							}

				                  	from.PlaySound( 0x1F5 );
			        	          	m_RuneStone.Delete();
			          		}

						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the weapon!" );
							from.SendMessage( "The weapon is damaged beyond repair!" );
							from.PlaySound( 0x1F8 );
						  	Weapon.Delete();
							m_RuneStone.Delete();
				  		}
					}
				}

			    	else if ( targeted is BaseArmor ) 
				{ 
			       		BaseArmor Armor = targeted as BaseArmor; 

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 1 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}

		       			else
		       			{
						int DestroyChance = Utility.Random( 10 );
		               	  
						if ( DestroyChance > 0 ) // Success
						{
							int augment = ( ( Utility.Random( 3 ) ) * scalar ) + 1;
							int augmentper = ( ( Utility.Random( 5 ) ) * scalar ) + 5;

							switch ( Utility.Random( 12 ) )
							{
								case 0: Armor.Attributes.BonusHits += augment; from.SendMessage( "Even pierced, the armor protects." ); break;
								case 1: Armor.Attributes.NightSight = 1; from.SendMessage( "In the darkest night, your path can be seen." ); break;
								case 2: Armor.Attributes.Luck += augment; from.SendMessage( "The unluckiest always get the biggest breaks." ); break;
								case 3: Armor.Attributes.LowerManaCost += augment; from.SendMessage( "The power of the spirit can be harnessed by metal." ); break;
								case 4: Armor.ArmorAttributes.DurabilityBonus += augmentper; from.SendMessage( "Metal lasts longer than flesh." ); break;
								case 5: Armor.ArmorAttributes.MageArmor = 1; from.SendMessage( "Channels of magic aren't held back." ); break;
								case 6: Armor.ArmorAttributes.SelfRepair += augment; from.SendMessage( "The weapon that strikes mends the metal." ); break;
								case 7: Armor.PhysicalBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 8: Armor.FireBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 9: Armor.ColdBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 10: Armor.PoisonBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 11: Armor.EnergyBonus += augment; from.SendMessage( "Armor focus renews." ); break;
							}

				                  	from.PlaySound( 0x1F5 );
			        	          	m_RuneStone.Delete();
			          		}

						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the armor!" );
							from.SendMessage( "The armor is damaged beyond repair!" );
							from.PlaySound( 0x1F8 );
							Armor.Delete();
							m_RuneStone.Delete();
				  		}
					}
				}

			    	else if ( targeted is BaseShield ) 
				{ 
			       		BaseShield Shield = targeted as BaseShield; 

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 1 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}

					else
		       			{
						int DestroyChance = Utility.Random( 10 );
		               	  
						if ( DestroyChance > 0 ) // Success
						{
							int augment = ( ( Utility.Random( 3 ) ) * scalar ) + 1;
							int augmentper = ( ( Utility.Random( 5 ) ) * scalar ) + 5;

							switch ( Utility.Random( 12 ) )
							{
								case 0: Shield.Attributes.BonusStam += augment; from.SendMessage( "Sometimes the warrior's best friend is his shield." ); break;
								case 1: Shield.Attributes.DefendChance += augment; from.SendMessage( "The shield's purpose is to defend." ); break;
								case 2: Shield.Attributes.ReflectPhysical += augment; from.SendMessage( "Turn the attack against the attacker." ); break;
								case 3: Shield.Attributes.SpellChanneling = 1; from.SendMessage( "Sometimes even mages carry shields." ); break;
								case 4: Shield.Attributes.CastRecovery += augment; from.SendMessage( "The shield supports when the warrior leans upon it." ); break;
								case 5: Shield.ArmorAttributes.SelfRepair += augment; from.SendMessage( "The sword mends, the mace fixes." ); break;
								case 6: Shield.ArmorAttributes.DurabilityBonus += augmentper; from.SendMessage( "Time cannot rust a trusted companion." ); break;
								case 7: Shield.PhysicalBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 8: Shield.FireBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 9: Shield.ColdBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 10: Shield.PoisonBonus += augment; from.SendMessage( "Armor focus renews." ); break;
								case 11: Shield.EnergyBonus += augment; from.SendMessage( "Armor focus renews." ); break;
							}

				                  	from.PlaySound( 0x1F5 );
			        	          	m_RuneStone.Delete();
			          		}

						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the shield!" );
							from.SendMessage( "The shield is damaged beyond repair!" );
							from.PlaySound( 0x1F8 );
						  	Shield.Delete();
							m_RuneStone.Delete();
				  		}
					}
				}

			    	else if ( targeted is BaseClothing ) 
				{ 
			       		BaseClothing Clothing = targeted as BaseClothing; 

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 1 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}

					else
		       			{
						int DestroyChance = Utility.Random( 10 );
		               	  
						if ( DestroyChance > 0 ) // Success
						{
							int augment = ( ( Utility.Random( 3 ) ) * scalar ) + 1;

							switch ( Utility.Random( 9 ) )
							{
								case 0: Clothing.Attributes.RegenHits += augment; from.SendMessage( "Sturdy clothes help everyone." ); break;
								case 1: Clothing.Attributes.RegenStam += augment; from.SendMessage( "Light clothes mean less of a burden." ); break;
								case 2: Clothing.Attributes.RegenMana += augment; from.SendMessage( "Meditation is easier when one is comfortable." ); break;
								case 3: Clothing.Attributes.Luck += augment; from.SendMessage( "Everyone should have at least one lucky piece of clothing." ); break;
								case 4: Clothing.Resistances.Physical += augment; from.SendMessage( "Cotton or flax, it is now stronger." ); break;
								case 5: Clothing.Resistances.Fire += augment; from.SendMessage( "Cotton or flax, it is now stronger." ); break;
								case 6: Clothing.Resistances.Cold += augment; from.SendMessage( "Cotton or flax, it is now stronger." ); break;
								case 7: Clothing.Resistances.Poison += augment; from.SendMessage( "Cotton or flax, it is now stronger." ); break;
								case 8: Clothing.Resistances.Energy += augment; from.SendMessage( "Cotton or flax, it is now stronger." ); break;
							}

				                  	from.PlaySound( 0x1F5 );
			        	          	m_RuneStone.Delete();
			          		}

						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the clothing!" );
							from.SendMessage( "The clothing is damaged beyond repair!" );
							from.PlaySound( 0x1F8 );
						  	Clothing.Delete();
							m_RuneStone.Delete();
				  		}
					}
				}

			    	else if ( targeted is BaseJewel ) 
				{ 
			       		BaseJewel Jewel = targeted as BaseJewel; 

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 1 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}

					else
		       			{
						int DestroyChance = Utility.Random( 10 );
		               	  
						if ( DestroyChance > 0 ) // Success
						{
							int augment = ( ( Utility.Random( 3 ) ) * scalar ) + 1;

							switch ( Utility.Random( 16 ) )
							{
								case 0: Jewel.Attributes.BonusDex += augment; from.SendMessage( "The light of the gem speeds the wearer's feet." ); break;
								case 1: Jewel.Attributes.BonusInt += augment; from.SendMessage( "The spirit of the gem helps concentration." ); break;
								case 2: Jewel.Attributes.BonusStr += augment; from.SendMessage( "The strength of the gem resonates in the muscles." ); break;
								case 3: Jewel.Attributes.Luck += augment; from.SendMessage( "Gifts will rain while the gem is worn." ); break;
								case 4: Jewel.Attributes.SpellDamage += augment; from.SendMessage( "Mana focuses into a stronger form." ); break;
								case 5: Jewel.Attributes.NightSight = 1; from.SendMessage( "The gem lights the way." ); break;
								case 6: Jewel.Resistances.Physical += augment; from.SendMessage( "The fortitude of the gem grows even stronger." ); break;
								case 7: Jewel.Resistances.Fire += augment; from.SendMessage( "The fortitude of the gem grows even stronger." ); break;
								case 8: Jewel.Resistances.Cold += augment; from.SendMessage( "The fortitude of the gem grows even stronger." ); break;
								case 9: Jewel.Resistances.Poison += augment; from.SendMessage( "The fortitude of the gem grows even stronger." ); break;
								case 10: Jewel.Resistances.Energy += augment; from.SendMessage( "The fortitude of the gem grows even stronger." ); break;
								case 11: Jewel.Attributes.AttackChance += augment; from.SendMessage( "The gem glows a deep red." ); break;
								case 12: Jewel.Attributes.DefendChance += augment; from.SendMessage( "The gem glows a faint yellow." ); break;
								case 13: Jewel.Attributes.LowerManaCost += augment; from.SendMessage( "The gem glows an undulating blue." ); break;
								case 14: Jewel.Attributes.ReflectPhysical += augment; from.SendMessage( "The gem glows a bright orange." ); break;
								case 15: Jewel.Attributes.WeaponSpeed += augment; from.SendMessage( "The gem glows an eery green." ); break;
							}

				                  	from.PlaySound( 0x1F5 );
			        	          	m_RuneStone.Delete();
			          		}

						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the jewelery!" );
							from.SendMessage( "The jewelery is damaged beyond repair!" );
							from.PlaySound( 0x1F8 );
						  	Jewel.Delete();
							m_RuneStone.Delete();
				  		}
					}
				}

		    		else 
		    		{ 
		       			from.SendMessage( "You can not enhance that." );
		    		} 
		  	}
		
		}

		public override bool DisplayLootType{ get{ return false; } }  // ha ha!

		public RuneStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class An : RuneStone
	{
		[Constructable]
		public An() : base()
		{
			Name = "An rune stone";
			Hue = Utility.RandomSlimeHue();
		}
	
		public An( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Bal : RuneStone
	{
		[Constructable]
		public Bal() : base()
		{
			Name = "Bal rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public Bal( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Bet : RuneStone
	{
		[Constructable]
		public Bet() : base()
		{
			Name = "Bet rune stone";
			Hue = Utility.RandomSnakeHue();
		}
	
		public Bet( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class CharRune : RuneStone
	{
		[Constructable]
		public CharRune() : base()
		{
			Name = "Char rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public CharRune( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Corp : RuneStone
	{
		[Constructable]
		public Corp() : base()
		{
			Name = "Corp rune stone";
			Hue = Utility.RandomRedHue();
		}
	
		public Corp( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Des : RuneStone
	{
		[Constructable]
		public Des() : base()
		{
			Name = "Des rune stone";
			Hue = Utility.RandomMetalHue();
		}
	
		public Des( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Ex : RuneStone
	{
		[Constructable]
		public Ex() : base()
		{
			Name = "Ex rune stone";
			Hue = Utility.RandomYellowHue();
		}
	
		public Ex( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}


	public class Flam : RuneStone
	{
		[Constructable]
		public Flam() : base()
		{
			Name = "Flam rune stone";
			switch ( Utility.Random( 1, 2 ) )
			{
				case 1:
				Hue = Utility.RandomRedHue();
				break;

				case 2:
				Hue = Utility.RandomYellowHue();
				break;
			}
		}
	
		public Flam( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Grav : RuneStone
	{
		[Constructable]
		public Grav() : base()
		{
			Name = "Grav rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public Grav( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Hur : RuneStone
	{
		[Constructable]
		public Hur() : base()
		{
			Name = "Hur rune stone";
			Hue = Utility.RandomBlueHue();
		}
	
		public Hur( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class In : RuneStone
	{
		[Constructable]
		public In() : base()
		{
			Name = "In rune stone";
			Hue = Utility.RandomAnimalHue();
		}
	
		public In( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Jux : RuneStone
	{
		[Constructable]
		public Jux() : base()
		{
			Name = "Jux rune stone";
			Hue = Utility.RandomRedHue();
		}
	
		public Jux( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Kal : RuneStone
	{
		[Constructable]
		public Kal() : base()
		{
			Name = "Kal rune stone";
			Hue = Utility.RandomBirdHue();
		}
	
		public Kal( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Lor : RuneStone
	{
		[Constructable]
		public Lor() : base()
		{
			Name = "Lor rune stone";
			Hue = Utility.RandomYellowHue();
		}
	
		public Lor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Mani : RuneStone
	{
		[Constructable]
		public Mani() : base()
		{
			Name = "Mani rune stone";
			Hue = Utility.RandomPinkHue();
		}

		public Mani( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Nox : RuneStone
	{
		[Constructable]
		public Nox() : base()
		{
			Name = "Nox rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public Nox( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Agle : RuneStone
	{
		[Constructable]
		public Agle() : base()
		{
			Name = "Agle rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public Agle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Ort : RuneStone
	{
		[Constructable]
		public Ort() : base()
		{
			Name = "Ort rune stone";
			Hue = Utility.RandomBlueHue();
		}
	
		public Ort( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Pas : RuneStone
	{
		[Constructable]
		public Pas() : base()
		{
			Name = "Pas rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public Pas( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Por : RuneStone
	{
		[Constructable]
		public Por() : base()
		{
			Name = "Por rune stone";
			Hue = Utility.RandomPinkHue();
		}
	
		public Por( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Quas : RuneStone
	{
		[Constructable]
		public Quas() : base()
		{
			Name = "Quas rune stone";
			Hue = Utility.RandomBlueHue();
		}
	
		public Quas( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Rel : RuneStone
	{
		[Constructable]
		public Rel() : base()
		{
			Name = "Rel rune stone";
			Hue = Utility.RandomSlimeHue();
		}
	
		public Rel( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Sanct : RuneStone
	{
		[Constructable]
		public Sanct() : base()
		{
			Name = "Sanct rune stone";
			Hue = Utility.RandomMetalHue();
		}
	
		public Sanct( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Sar : RuneStone
	{
		[Constructable]
		public Sar() : base()
		{
			Name = "Sar rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public Sar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Tym : RuneStone
	{
		[Constructable]
		public Tym() : base()
		{
			Name = "Tym rune stone";
			Hue = Utility.RandomRedHue();
		}
	
		public Tym( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Um : RuneStone
	{
		[Constructable]
		public Um() : base()
		{
			Name = "Um rune stone";
			Hue = Utility.RandomGreenHue();
		}
	
		public Um( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Uus : RuneStone
	{
		[Constructable]
		public Uus() : base()
		{
			Name = "Uus rune stone";
			Hue = Utility.RandomMetalHue();
		}
	
		public Uus( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Vas : RuneStone
	{
		[Constructable]
		public Vas() : base()
		{
			Name = "Vas rune stone";
			Hue = Utility.RandomRedHue();
		}
	
		public Vas( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Wis : RuneStone
	{
		[Constructable]
		public Wis() : base()
		{
			Name = "Wis rune stone";
			Hue = Utility.RandomBlueHue();
		}
	
		public Wis( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Xen : RuneStone
	{
		[Constructable]
		public Xen() : base()
		{
			Name = "Xen rune stone";
			Hue = Utility.RandomAnimalHue();
		}
	
		public Xen( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Ylem : RuneStone
	{
		[Constructable]
		public Ylem() : base()
		{
			Name = "Ylem rune stone";
			Hue = Utility.RandomBirdHue();
		}
	
		public Ylem( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class Zu : RuneStone
	{
		[Constructable]
		public Zu() : base()
		{
			Name = "Zu rune stone";
			Hue = Utility.RandomMetalHue();
		}
	
		public Zu( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class VenomRepeatingCrossbow : RepeatingCrossbow
	{
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		private int m_Charges;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set
			{
				if ( value > this.MaxCharges ) m_Charges = this.MaxCharges;
				else if ( value <= 0 ) m_Charges = 0;
				else m_Charges = value;
				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int MaxCharges{ get{ return 20; } }

		[Constructable]
		public VenomRepeatingCrossbow()
		{
			Name = "Venom Repeating Crossbow";
			Attributes.SpellChanneling = 1;
			Hue = 2373;
			Charges = Utility.RandomMinMax(0,20);
		}

		public override void OnHit(Mobile attacker, Mobile defender, double damageBonus)
		{
			if ( this.Charges >= 1 && Utility.RandomDouble() <= .2 && defender.Poisoned == false)
			{
				int poisontype = 0;
				poisontype += (int)( (attacker.Skills.Poisoning.Value / 50) - (defender.Skills.Poisoning.Value / 100) );
				if ( poisontype < 0 ) poisontype = 0;
				if ( poisontype > 4 ) poisontype = 4;
				switch(poisontype)
				{
					case 0: default: Poison = Poison.Lesser; break;
					case 1 :Poison = Poison.Regular; break;
					case 2: Poison = Poison.Greater; break;
					case 3: Poison = Poison.Deadly; break;
					case 4: Poison = Poison.Lethal; break;
				}
				defender.ApplyPoison(attacker, Poison);
				attacker.SendMessage("Venom Strikes! {0}", Convert.ToString(Poison) );
				this.Charges -= 1;
				attacker.Karma -= 25;
			}
			base.OnHit(attacker, defender, damageBonus);
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( 1060741, m_Charges.ToString() );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( !this.IsChildOf( from.Backpack ) ) { from.SendMessage( "This must be in your backpack to use" ); }
			else if ( Charges >= 20 ) from.SendMessage( "This is all ready full of poison!!!!" );
			else { from.SendMessage("Target the poison potion you wish to add"); from.Target = new PoisonTarget( this ); }
		}

		private class PoisonTarget : Target
		{
			private VenomRepeatingCrossbow i_Std;
			private int m_Charges;
			public PoisonTarget( VenomRepeatingCrossbow std ) : base( -1, false, TargetFlags.None ) { i_Std = std; }

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( !(targeted is Item) ) { from.SendMessage("You can only target poison potions"); return; }
				if ( i_Std.Deleted ) return;
				Item item = (Item)targeted;
				if ( item is BasePoisonPotion )
				{
					if( i_Std.Charges >= 20 ) { from.SendMessage( "There is only room for 20 potions" ); }
					else
					{
						i_Std.Charges = i_Std.Charges + 1;
						item.Delete();
						from.Karma -= 25;
						from.SendMessage( "The Weapon draws the poison and stores it" );
						from.AddToBackpack( new Bottle() );
					}
				}
				else from.SendMessage( "You can only charge this with poison potions" );
			}
		}

		public VenomRepeatingCrossbow( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); writer.Write( (int) m_Charges ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); m_Charges = reader.ReadInt(); }
	}
}
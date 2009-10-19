using System;
using System.Collections;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
//using Server.SpellCrafting.Items;
//using Server.SpellCrafting;

namespace Server.Items
{
	public class TreasureMessageChest : WoodenChest
	{
		[Constructable]
		public TreasureMessageChest( int low, int high ) : this( Utility.RandomMinMax( low < 15 ? 15 : low, high < low ? low : high ) )
		{
		}

		[Constructable]
		public TreasureMessageChest() : this( 1200, 2000 )
		{
		}

		[Constructable]
		public TreasureMessageChest( int amount ) : base()
		{
			Weight = 5.0;
			Name = "treasure chest";

			switch ( Utility.Random( 3 ) )  // modify as necessary
			{
				case 0: TrapType = TrapType.None; break;
				case 1: TrapType = TrapType.None; break;
				case 2: TrapType = TrapType.ExplosionTrap; break;
			}

			TrapPower = amount < 100 ? Utility.RandomMinMax( amount - 15, amount ) : 100;
					
			Locked = true;
			LockLevel = amount < 100 ? Utility.RandomMinMax( amount - 15, amount ) : 100;
			MaxLockLevel = amount;

			DropItem( new Gold( amount ) );

			switch ( Utility.Random( 9 ))
			{
				case 0: DropItem( new StarSapphire() ); break;
				case 1: DropItem( new Emerald() ); break;
				case 2: DropItem( new Sapphire() ); break;
				case 3: DropItem( new Ruby() ); break;
				case 4: DropItem( new Citrine() ); break;
				case 5: DropItem( new Amethyst() ); break;
				case 6: DropItem( new Tourmaline() ); break;
				case 7: DropItem( new Amber() ); break;
				case 8: DropItem( new Diamond() ); break;
			}

		}

		public TreasureMessageChest( Serial serial ) : base( serial )
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
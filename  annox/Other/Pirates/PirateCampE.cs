using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
	public class PirateCampE : BaseCamp
	{
		[Constructable]
		public PirateCampE() : base( 0x4011 )
		{
		}

		public override void AddComponents()
		{

			Item tiller = new PirateTillerManE();
			tiller.Movable = false;

			Item hatch = new HatchE();
			hatch.Movable = false;

			Item leftplank = new LeftPlankE();
			leftplank.Movable = false;

			Item rightplank = new RightPlankE();
			rightplank.Movable = false;
			
			AddItem( tiller, -5, 0, 0 );
			AddItem( hatch, 5, 0, 0 );
			AddItem( leftplank, 1, -2, 0 );
			AddItem( rightplank, 1, 2, 0 );
		
			AddMobile( new Pirate(), 4, 0,  0, 0 );
			AddMobile( new Pirate(), 4,  0, -1, 0 );
			AddMobile( new Brigand(), 4, -3, 0, 0 );
			AddMobile( new PirateCaptain(), 1, -4, 0, 0 );
		}

		public PirateCampE( Serial serial ) : base( serial )
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

	public class PirateTillerManE : Item
	{
		public PirateTillerManE() : base( 0x3E53 )
		{
		}

		public PirateTillerManE( Serial serial ) : base( serial )
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

	public class LeftPlankE : Item
	{
		public LeftPlankE() : base( 0x3E8A )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( this.ItemID == 0x3E8A )
				this.ItemID = 0x3E89;
			else
				this.ItemID = 0x3E8A;
		}

		public LeftPlankE( Serial serial ) : base( serial )
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

	public class RightPlankE : Item
	{

		public RightPlankE() : base( 0x3E85 )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( this.ItemID == 0x3E85 )
				this.ItemID = 0x3E84;
			else
				this.ItemID = 0x3E85;
		}

		public RightPlankE( Serial serial ) : base( serial )
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

	public class HatchE : BaseContainer
	{
		public override int DefaultGumpID{ get{ return 0x4C; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 44, 65, 142, 94 ); }
		}
		
		public HatchE() : base( 0x3E65 )
		{
		}
		
		public HatchE( Serial serial ) : base( serial )
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
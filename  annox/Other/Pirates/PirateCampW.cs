using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
	public class PirateCampW : BaseCamp
	{
		[Constructable]
		public PirateCampW() : base( 0x4013 )
		{
		}

		public override void AddComponents()
		{

			Item tiller = new PirateTillerManW();
			tiller.Movable = false;

			Item hatch = new HatchW();
			hatch.Movable = false;

			Item leftplank = new LeftPlankW();
			leftplank.Movable = false;

			Item rightplank = new RightPlankW();
			rightplank.Movable = false;
			
			AddItem( tiller, 5, 0, 0 );
			AddItem( hatch, -5, 0, 0 );
			AddItem( leftplank, -1, 2, 0 );
			AddItem( rightplank, -1, -2, 0 );
		
			AddMobile( new Pirate(), 4, 0,  0, 0 );
			AddMobile( new Pirate(), 4,  0, -1, 0 );
			AddMobile( new Brigand(), 4, -3, 0, 0 );
			AddMobile( new PirateCaptain(), 1, 4, 0, 0 );
		}

		public PirateCampW( Serial serial ) : base( serial )
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

	public class PirateTillerManW : Item
	{
		public PirateTillerManW() : base( 0x3E50 )
		{
		}

		public PirateTillerManW( Serial serial ) : base( serial )
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

	public class LeftPlankW : Item
	{
		public LeftPlankW() : base( 0x3E85 )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( this.ItemID == 0x3E85 )
				this.ItemID = 0x3E84;
			else
				this.ItemID = 0x3E85;
		}

		public LeftPlankW( Serial serial ) : base( serial )
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

	public class RightPlankW : Item
	{

		public RightPlankW() : base( 0x3E8A )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( this.ItemID == 0x3E8A )
				this.ItemID = 0x3E89;
			else
				this.ItemID = 0x3E8A;
		}

		public RightPlankW( Serial serial ) : base( serial )
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

	public class HatchW : BaseContainer
	{
		public override int DefaultGumpID{ get{ return 0x4C; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 44, 65, 142, 94 ); }
		}
		
		public HatchW() : base( 0x3E93 )
		{
		}
		
		public HatchW( Serial serial ) : base( serial )
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
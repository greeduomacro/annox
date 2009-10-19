using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
	public class PirateCampS : BaseCamp
	{
		[Constructable]
		public PirateCampS() : base( 0x4012 )
		{
		}

		public override void AddComponents()
		{

			Item tiller = new PirateTillerManS();
			tiller.Movable = false;

			Item hatch = new HatchS();
			hatch.Movable = false;

			Item leftplank = new LeftPlankS();
			leftplank.Movable = false;

			Item rightplank = new RightPlankS();
			rightplank.Movable = false;
			
			AddItem( tiller, 0, -5, 0 );
			AddItem( hatch, 0, 5, 0 );
			AddItem( leftplank, 2, 1, 0 );
			AddItem( rightplank, -2, 1, 0 );
		
			AddMobile( new Pirate(), 4, 0,  2, 0 );
			AddMobile( new Pirate(), 4,  0, 0, 0 );
			AddMobile( new Brigand(), 4, 0, -3, 0 );
			AddMobile( new PirateCaptain(), 1, 0, -4, 0 );
		}

		public PirateCampS( Serial serial ) : base( serial )
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

	public class PirateTillerManS : Item
	{
		public PirateTillerManS() : base( 0x3E4B )
		{
		}

		public PirateTillerManS( Serial serial ) : base( serial )
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

	public class LeftPlankS : Item
	{
		public LeftPlankS() : base( 0x3EB2 )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
			if( this.ItemID == 0x3EB2 )
				this.ItemID = 0x3ED4;
			else
				this.ItemID = 0x3EB2;
		}

		public LeftPlankS( Serial serial ) : base( serial )
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

	public class RightPlankS : Item
	{

		public RightPlankS() : base( 0x3EB1 )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
			if( this.ItemID == 0x3EB1 )
				this.ItemID = 0x3ED5;
			else
				this.ItemID = 0x3EB1;
		}

		public RightPlankS( Serial serial ) : base( serial )
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

	public class HatchS : BaseContainer
	{
		public override int DefaultGumpID{ get{ return 0x4C; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 44, 65, 142, 94 ); }
		}
		
		public HatchS() : base( 0x3EB9 )
		{
		}
		
		public HatchS( Serial serial ) : base( serial )
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
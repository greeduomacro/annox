using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
	public class PirateCampN : BaseCamp
	{
		[Constructable]
		public PirateCampN() : base( 0x4010 )
		{
		}

		public override void AddComponents()
		{

			Item tiller = new PirateTillerManN();
			tiller.Movable = false;

			Item hatch = new HatchN();
			hatch.Movable = false;

			Item leftplank = new LeftPlankN();
			leftplank.Movable = false;

			Item rightplank = new RightPlankN();
			rightplank.Movable = false;
			
			AddItem( tiller, 1, 5, 0 );
			AddItem( hatch, 0, -5, 0 );
			AddItem( leftplank, -2, -1, 0 );
			AddItem( rightplank, 2, -1, 0 );
		
			AddMobile( new Pirate(), 4, 0,  2, 0 );
			AddMobile( new Pirate(), 4,  0, 0, 0 );
			AddMobile( new Brigand(), 4, 0,-3, 0 );
			AddMobile( new PirateCaptain(), 1, 0, 4, 0 );
		}

		public PirateCampN( Serial serial ) : base( serial )
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

	public class PirateTillerManN : Item
	{
		public PirateTillerManN() : base( 0x3E4E )
		{
		}

		public PirateTillerManN( Serial serial ) : base( serial )
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

	public class LeftPlankN : Item
	{
		public LeftPlankN() : base( 0x3EB1 )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
			if( this.ItemID == 0x3EB1 )
				this.ItemID = 0x3ED5;
			else
				this.ItemID = 0x3EB1;
		}

		public LeftPlankN( Serial serial ) : base( serial )
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

	public class RightPlankN : Item
	{

		public RightPlankN() : base( 0x3EA9 )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
			if( this.ItemID == 0x3EA9 )
				this.ItemID = 0x3ED3;
			else
				this.ItemID = 0x3EA9;
		}

		public RightPlankN( Serial serial ) : base( serial )
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

	public class HatchN : BaseContainer
	{
		public override int DefaultGumpID{ get{ return 0x4C; } }
		public override int DefaultDropSound{ get{ return 0x42; } }

		public override Rectangle2D Bounds
		{
			get{ return new Rectangle2D( 44, 65, 142, 94 ); }
		}
		
		public HatchN() : base( 0x3EAE )
		{
		}
		
		public HatchN( Serial serial ) : base( serial )
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
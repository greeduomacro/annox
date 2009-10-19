using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
	public class PirateCamp : BaseCamp
	{
		[Constructable]
		public PirateCamp() : base( 0x1F6 )
		{
		}

		public override void AddComponents()
		{
			AddMobile( new Pirate(), 4, -4,  3, 7 );
			AddMobile( new Pirate(), 5,  4, -2, 0 );
			AddMobile( new Brigand(), 3, -4, 1, 7 );
			AddMobile( new PirateCaptain(), 2, 4, -1, 0 );
		}

		public PirateCamp( Serial serial ) : base( serial )
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
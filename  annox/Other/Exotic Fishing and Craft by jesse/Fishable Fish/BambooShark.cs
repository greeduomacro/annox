using System;
using Server;
using Server.Misc;
using System.Collections;
using Server.Network;


namespace Server.Items
{
	public class BambooShark : Food
	{
		[Constructable]
		public BambooShark() : this( 1 )
		{
		}

		[Constructable]
		public BambooShark( int amount ) : base( amount, 15113 )
		{
			Weight = 0.1;
			FillFactor = 3;
			Name = "Bamboo Shark";
		}

		public BambooShark( Serial serial ) : base( serial )
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
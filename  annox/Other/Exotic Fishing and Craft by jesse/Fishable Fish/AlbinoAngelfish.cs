using System;
using Server;
using Server.Misc;
using System.Collections;
using Server.Network;


namespace Server.Items
{
	public class AlbinoAngelfish : Food
	{
		[Constructable]
		public AlbinoAngelfish() : this( 1 )
		{
		}

		[Constructable]
		public AlbinoAngelfish( int amount ) : base( amount, 15108 )
		{
			Weight = 0.1;
			FillFactor = 3;
			Name = "Albino Angelfish";
		}

		public AlbinoAngelfish( Serial serial ) : base( serial )
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
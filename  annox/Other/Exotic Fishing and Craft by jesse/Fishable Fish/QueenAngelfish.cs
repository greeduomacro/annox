using System;
using Server;
using Server.Misc;
using System.Collections;
using Server.Network;


namespace Server.Items
{
	public class QueenAngelfish : Food
	{
		[Constructable]
		public QueenAngelfish() : this( 1 )
		{
		}

		[Constructable]
		public QueenAngelfish( int amount ) : base( amount, 15106 )
		{
			Weight = 0.1;
			FillFactor = 3;
			Name = "Queen Angelfish";
		}

		public QueenAngelfish( Serial serial ) : base( serial )
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
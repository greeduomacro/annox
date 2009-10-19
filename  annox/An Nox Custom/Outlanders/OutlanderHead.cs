using System;
using Server;

namespace Server.Items
{
	public class OutlanderHead : Item
	{
		[Constructable]
		public OutlanderHead() : this( null )
		{
		}

		[Constructable]
		public OutlanderHead( string name ) : base( 0x1DA0 )
		{
			Name = "Outlander Head";
			Weight = 1.0;
		}

		public OutlanderHead( Serial serial ) : base( serial )
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
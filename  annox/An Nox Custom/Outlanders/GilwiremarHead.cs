using System;
using Server;

namespace Server.Items
{
	public class GilwiremarHead : Item
	{
		[Constructable]
		public GilwiremarHead() : this( null )
		{
		}

		[Constructable]
		public GilwiremarHead( string name ) : base( 0x1DA0 )
		{
            Name = "Head of Gilwiremar";
			Weight = 1.0;
		}

		public GilwiremarHead( Serial serial ) : base( serial )
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
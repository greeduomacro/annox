using System;

namespace Server.Items
{
	public class GuardedPortcullisNS : BaseGuardedDoor
	{
		public override bool UseChainedFunctionality{ get{ return true; } }

		[Constructable]
		public GuardedPortcullisNS() : base( 0x6F5, 0x6F5, 0xF0, 0xEF, new Point3D( 0, 0, 20 ) )
		{
		}

		public GuardedPortcullisNS( Serial serial ) : base( serial )
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

	public class GuardedPortcullisEW : BaseGuardedDoor
	{
		public override bool UseChainedFunctionality{ get{ return true; } }

		[Constructable]
		public GuardedPortcullisEW() : base( 0x6F6, 0x6F6, 0xF0, 0xEF, new Point3D( 0, 0, 20 ) )
		{
		}

		public GuardedPortcullisEW( Serial serial ) : base( serial )
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
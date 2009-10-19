using System;
using Server;

namespace Server.Items
{
	public enum MountedPixieFacing
	{
		North,
		West
	}

	public enum MountedPixieType
	{
		YellowMountedPixie,
		OrganMountedPixie,
		BlueMountedPixie,
		GreenMountedPixie,
		PinkMountedPixie
	}

    public class MountedPixie : BaseSign
	{
		[Constructable]
		public MountedPixie( MountedPixieType type, MountedPixieFacing facing ) : base( ( 0x2a71 + (2 * (int)type) ) + (int)facing )
		{
		}

		[Constructable]
		public MountedPixie( int itemID ) : base( itemID )
		{
		}

		public MountedPixie( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
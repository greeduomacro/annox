using System;

namespace Server.Items
{


	public class GuardedMetalDoor : BaseGuardedDoor
	{
		[Constructable]
		public GuardedMetalDoor( DoorFacing facing ) : base( 0x675 + (2 * (int)facing), 0x676 + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset( facing ) )
		{
		}

		public GuardedMetalDoor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
using System;
using Server;

namespace Server.Items
{
	public class IceForgeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new IceForgeDeed(); } }		

		[Constructable]
		public IceForgeAddon()
		{
			AddComponent( new IceForge( 0XFB1 ), 0, 0, 0 );
			Name = "Ancient Forge of Ice";
			Hue = 1266;
		}		

		public IceForgeAddon( Serial serial ) : base( serial )
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

	public class IceForge : AddonComponent
	{
		[Constructable]
		public IceForge() : this( 0XFB1 )
		{
			Name = "Ancient Forge of Ice";
			Hue = 1266;
		}

		[Constructable]
		public IceForge( int itemid ) : base( itemid )
		{
			Name = "Ancient Forge of Ice";
			Hue = 1266;
		}

		public IceForge( Serial serial ) : base( serial )
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

	public class IceForgeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new IceForgeAddon(); } }		

		[Constructable]
		public IceForgeDeed()
		{
			Name = "Forge of Ice";
		}

		public IceForgeDeed( Serial serial ) : base( serial )
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
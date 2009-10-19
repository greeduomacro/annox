using System;
using Server;

namespace Server.Items
{
	public class MightForgeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new MightForgeDeed(); } }		

		[Constructable]
		public MightForgeAddon()
		{
			Name = "Ancient Forge of Might";
			AddComponent( new MightForge( 0XFB1 ), 0, 0, 0 );			
			Hue = 1328;
		}		

		public MightForgeAddon( Serial serial ) : base( serial )
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

	public class MightForge : AddonComponent
	{
		[Constructable]
		public MightForge() : this( 0XFB1 )
		{
			Name = "Ancient Forge of Might";
			Hue = 1328;
		}

		[Constructable]
		public MightForge( int itemid ) : base( itemid )
		{
			Name = "Ancient Forge of Might";
			Hue = 1328;
		}

		public MightForge( Serial serial ) : base( serial )
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

	public class MightForgeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new MightForgeAddon(); } }		

		[Constructable]
		public MightForgeDeed()
		{
			Name = "Forge of Might";
		}

		public MightForgeDeed( Serial serial ) : base( serial )
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
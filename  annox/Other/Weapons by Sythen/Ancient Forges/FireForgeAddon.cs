using System;
using Server;

namespace Server.Items
{
	public class FireForgeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new FireForgeDeed(); } }		

		[Constructable]
		public FireForgeAddon()
		{
			AddComponent( new FireForge( 0XFB1 ), 0, 0, 0 );
			Name = "Ancient Forge of Fire";
			Hue = 1260;
		}		

		public FireForgeAddon( Serial serial ) : base( serial )
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

	public class FireForge : AddonComponent
	{
		[Constructable]
		public FireForge() : this( 0XFB1 )
		{
			Name = "Ancient Forge of Fire";
			Hue = 1260;
		}

		[Constructable]
		public FireForge( int itemid ) : base( itemid )
		{
			Name = "Ancient Forge of Fire";
			Hue = 1260;
		}

		public FireForge( Serial serial ) : base( serial )
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

	public class FireForgeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new FireForgeAddon(); } }		

		[Constructable]
		public FireForgeDeed()
		{
			Name = "Forge of Fire";
		}

		public FireForgeDeed( Serial serial ) : base( serial )
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
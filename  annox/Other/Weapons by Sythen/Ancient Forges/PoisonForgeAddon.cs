using System;
using Server;

namespace Server.Items
{
	public class PoisonForgeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new PoisonForgeDeed(); } }		

		[Constructable]
		public PoisonForgeAddon()
		{
			AddComponent( new PoisonForge( 0XFB1 ), 0, 0, 0 );
			Name = "Ancient Forge of Poison";
			Hue = 1272;
		}		

		public PoisonForgeAddon( Serial serial ) : base( serial )
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

	public class PoisonForge : AddonComponent
	{
		[Constructable]
		public PoisonForge() : this( 0XFB1 )
		{
			Name = "Ancient Forge of Poison";
			Hue = 1272;
		}

		[Constructable]
		public PoisonForge( int itemid ) : base( itemid )
		{
			Name = "Ancient Forge of Poison";
			Hue = 1272;
		}

		public PoisonForge( Serial serial ) : base( serial )
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

	public class PoisonForgeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new PoisonForgeAddon(); } }		

		[Constructable]
		public PoisonForgeDeed()
		{
			Name = "Forge of Poison";
		}

		public PoisonForgeDeed( Serial serial ) : base( serial )
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
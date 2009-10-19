using System;
using Server;

namespace Server.Items
{
	public class EnergyForgeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new EnergyForgeDeed(); } }		

		[Constructable]
		public EnergyForgeAddon()
		{
			AddComponent( new EnergyForge( 0XFB1 ), 0, 0, 0 );
			Name = "Ancient Forge of Energy";
			Hue = 1278;
		}		

		public EnergyForgeAddon( Serial serial ) : base( serial )
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

	public class EnergyForge : AddonComponent
	{
		[Constructable]
		public EnergyForge() : this( 0XFB1 )
		{
			Name = "Ancient Forge of Energy";
			Hue = 1278;
		}

		[Constructable]
		public EnergyForge( int itemid ) : base( itemid )
		{
			Name = "Ancient Forge of Energy";
			Hue = 1278;
		}

		public EnergyForge( Serial serial ) : base( serial )
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

	public class EnergyForgeDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new EnergyForgeAddon(); } }		

		[Constructable]
		public EnergyForgeDeed()
		{
			Name = "Forge of Energy";
		}

		public EnergyForgeDeed( Serial serial ) : base( serial )
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
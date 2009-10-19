using System;
using System.Collections;
using Server.Targeting;
using Server.Items;
using Server.Engines.Harvest;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class ExoticFishingPole : Item
	{
		[Constructable]
		public ExoticFishingPole() : base( 0x0DC0 )
		{
			Name = "Exotic Fishing Pole";
			Hue = 1150;
			Layer = Layer.OneHanded;
			Weight = 8.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			ExoticFishing.System.BeginHarvesting( from, this );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			BaseHarvestTool.AddContextMenuEntries( from, this, list, ExoticFishing.System );
		}

		public ExoticFishingPole( Serial serial ) : base( serial )
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
// 15AUG2007 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class PillowSewingKit : BaseTool
	{
        public override CraftSystem CraftSystem { get { return DefPillowCraft.CraftSystem; } }

		[Constructable]
		public PillowSewingKit() : base( 0xF9D )
		{
			Weight = 2.0;
		}

		[Constructable]
		public PillowSewingKit( int uses ) : base( uses, 0xF9D )
		{
			Weight = 2.0;
		}

		public PillowSewingKit( Serial serial ) : base( serial )
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
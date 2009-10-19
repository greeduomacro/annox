/*
Special thanks to Ryan.
With RunUO we now have the ability to become our own Richard Garriott.
All Spells System created by x-SirSly-x, Admin of Land of Obsidian.
All Spells System 4.0 created & supported by Lucid Nagual, Admin of The Conjuring.
All Spells System 5.0 created by A_li_N.
    _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2005 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \     lucidnagual@gmail.com     \
    \_     ===================      \
     \   -Admin of "The Conjuring"-  \
      \_     ===================     ~\
       )       All Spells System       )
      /~      Version [5].0.1        _/
    _/_______________________________/
 -=(_)_______________________________)=-
 */
using System;
using Server.Items;

namespace Server.Items
{
	public class NecroRegStone : Item
	{
		[Constructable]
		public NecroRegStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 68;
			Name = "a necro reagent stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  //Large Bag of Holding---1400 Gold
		   	Item[] Token = from.Backpack.FindItemsByType( typeof( Gold ) );
		   	if ( from.Backpack.ConsumeTotal( typeof( Gold ), 1400 ) )
		{
         	   	BagOfNecroReagents BagOfNecroReagents = new BagOfNecroReagents( 50 );
		   	from.AddToBackpack( BagOfNecroReagents );
			from.SendMessage( "1400 gold has been removed from your pack." );
		}
		   	else
		   	{
		   		from.SendMessage( "You do not have enough funds for that." );
		   	}
					
		}

		public NecroRegStone( Serial serial ) : base( serial )
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

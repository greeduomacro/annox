using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
   public class RandomArmorBag : Bag 
   { 
		[Constructable] 
		public RandomArmorBag() : this( 1 ) 
		{ 
			Movable = true; 
			Hue = 1985; 
			Name = "Bag Of Random Armor";
		}
		[Constructable]
		public RandomArmorBag( int amount )
		{
			DropItem( new RandomGloves() );
			DropItem( new RandomHelmet() );
			DropItem( new RandomTunic() );
			DropItem( new RandomArms() );
			DropItem( new RandomGorget() );
			DropItem( new RandomLegs() );
			DropItem( new RandomShield() );
			DropItem( new RandomBlade() );
			DropItem( new RandomRing() );
			DropItem( new RandomBrace() );
		}

      public RandomArmorBag( Serial serial ) : base( serial ) 
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

using System; 
using Server; 
using Server.Gumps; 
using Server.Network; 
using Server.Menus; 
using Server.Menus.Questions; 

namespace Server.Items 
{ 
   public class SilverSupplyStone : Item 
   { 
      [Constructable] 
      public SilverSupplyStone() : base( 4483 ) 
      { 
         Hue = 1154; 
         Movable = false; 
         Name = "Supply Stone";
	 LootType = LootType.Regular; 
      } 

      public SilverSupplyStone( Serial serial ) : base( serial ) 
      { 
      } 

      public override void OnDoubleClick( Mobile from )
	  { 
         from.SendGump( new SilverSupplyStoneGump( from ) ); 
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
using System;
using Server;


namespace Server.Items
{

public class RandomHelmet : PlateHelm
{
		public override int InitMinHits{ get{ return 110; } }
		public override int InitMaxHits{ get{ return 110; } }
		
		public override int ArtifactRarity{ get{ return 2005; } }


		[Constructable]
		public RandomHelmet() 
		{
			Name = "The Random Helmet";
			Hue = 1985;
			
			ArmorAttributes.MageArmor = 1;
	
			#region ItemID Of Armor
			switch ( Utility.Random( 20 ) )
			{
            	case 0: 
           	 	{
					ItemID = 5132;
            	}
            	
            	break;
				
            	case 1: 
            	{
					ItemID = 5128;
            	}
            	
            	break;
				
            	case 2: 
           		{
					ItemID = 5130;
            	} 
            	
            	break;
				
            	case 3: 
            	{
					ItemID = 5134;
            	} 
            	
            	break;
				
            	case 4: 
           	 	{
					ItemID = 5138;
            	} 
            	
            	break;
				
            	case 5: 
            	{
					ItemID = 7609;
            	} 
            	
            	break;
			}
			#endregion
			
			#region Armor Attributes
			int x_Rand;
			x_Rand = Utility.Random(20);
			Attributes.LowerRegCost = x_Rand; 
	
			int x_Rand1;
			x_Rand1 = Utility.Random(7);
			Attributes.LowerManaCost = x_Rand1;

			int x_Rand2;
			x_Rand2 = Utility.Random(2);
			Attributes.RegenMana = x_Rand2;
	
			int x_Rand3;
			x_Rand3 = Utility.Random(5);
			Attributes.RegenHits = x_Rand3;
		
			int x_Rand4;
			x_Rand4 = Utility.Random(5);
			Attributes.BonusMana = x_Rand4;
	
			int x_Rand5;
			x_Rand5 = Utility.Random(8);
			Attributes.BonusHits = x_Rand5;
			
			int x_Rand6;
			x_Rand6 = Utility.Random(8);
			ColdBonus = x_Rand6;
			
			int x_Rand7;
			x_Rand7 = Utility.Random(8);
			EnergyBonus = x_Rand7;
			
			int x_Rand8;
			x_Rand8 = Utility.Random(8);
			FireBonus = x_Rand8;
			
			int x_Rand9;
			x_Rand9 = Utility.Random(8);
			PhysicalBonus = x_Rand9;
			
			int x_Rand10;
			x_Rand10 = Utility.Random(8);
			PoisonBonus = x_Rand10;
			
			#endregion
	}

		public RandomHelmet( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 );
		}
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
   		}
	}
}

using System;
using Server;


namespace Server.Items
{

	public class RandomBlade : BladedStaff
	{
		[Constructable]
		public RandomBlade()
		{
			Name = "The Random Blade";
			
			Hue = 1985;
			
			Layer = Layer.OneHanded;
			
			WeaponAttributes.UseBestSkill = 1;
	
			Attributes.SpellChanneling = 1;
			
			switch ( Utility.Random( 20 ) )
			{
            case 0: 
            {
            	ItemID = 5182;
            }
            break;
				
            case 1: 
            {
				ItemID = 9918;
            } 
            break;
				
            case 2: 
            {
				ItemID = 3937;
            }
            break;
				
            case 3: 
            {
				ItemID = 5048;
            } 
            break;
				
            case 4: 
            {
				ItemID = 9921;
            } 
            break;
				
            case 5: 
            {
				ItemID = 9917;
            } 
            break;
				
            case 6: 
            {
				ItemID = 9919;
            }
            break;
            case 7: 
            {
				ItemID = 3934;
            } 
            break;
				
            case 8: 
            {
				ItemID = 5049;
            } 
            break;
				
            case 9: 
            {
				ItemID = 5121;
            }
            break;
				
            case 10: 
            {
				ItemID = 5046;
            } 
            break;
				
            case 11: 
            {
				ItemID = 9915;
            } break;
				
            case 12: 
            {
				ItemID = 5119;
            } 
            break;	
				
            case 13: 
            {
				ItemID = 9914;
            } 
            break;
				
            case 14: 
            {
				ItemID = 5125;
            } 
            break;
				
            case 15: 
            {
				ItemID = 3932;
            }
            break;
				
            case 16: 
            {
				ItemID = 5127;
            }
            break;
				
            case 17: 
            {
				ItemID = 5123;
            }
            break;
				
            case 18: 
            {
				ItemID = 5115;
            } 
            break;
				
            case 19: 
            {
				ItemID = 5179;
            }
            break;
		}
		
		int x_Rand;
		x_Rand = Utility.Random(15);
		Attributes.AttackChance = x_Rand; 

		int x_Rand1;
		x_Rand1 = Utility.Random(25);
		Attributes.WeaponSpeed = x_Rand1;

		int x_Rand2;
		x_Rand2 = Utility.Random(25);
		Attributes.WeaponDamage = x_Rand2;
	
		int x_Rand3;
		x_Rand3 = Utility.Random(25);
		WeaponAttributes.HitFireball = x_Rand3;
	
		int x_Rand4;
		x_Rand4 = Utility.Random(25);
		WeaponAttributes.HitLightning = x_Rand4;
		}
		
		public RandomBlade( Serial serial ) : base( serial )
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

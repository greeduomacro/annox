using System;
using Server;


namespace Server.Items
{


	public class RandomRing : GoldRing
	{
		
		[Constructable]
		public RandomRing() 
		{
	
			Name = "The Random Ring";
			Hue = 1985;

			int x_Rand;
			x_Rand = Utility.Random(4);
			Attributes.CastRecovery = x_Rand; 

			int x_Rand1;
			x_Rand1 = Utility.Random(7);
			Attributes.LowerManaCost = x_Rand1;

			int x_Rand2;
			x_Rand2 = Utility.Random(20);
			Attributes.LowerRegCost = x_Rand2;
			
			int x_Rand3;
			x_Rand3 = Utility.Random(4);
			Attributes.CastSpeed = x_Rand3;

	}
	
		public RandomRing( Serial serial ) : base( serial )
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

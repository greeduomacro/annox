////Coded by kaball //////
////feel free to edit ////
using Server.Gumps;

namespace Server.Items
{
	public class WebGate : Item
	{
		[Constructable]
		public WebGate() : base( 6907 )
		{
			Movable = false;
			Hue = 1166;
			Name = "Visit our Website"; 
			Light = LightType.Circle300;
		}

		public WebGate( Serial serial ) : base( serial )
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m.Alive )
			{
				m.PlaySound( 0x214 );
				m.FixedEffect( 0x376A, 10, 16 );

				int i = 0;
				
				while (i < 52)
				{
					///
				i++;
				}
                                  m.LaunchBrowser( "annox.no-ip.com" ); 
           }
			else
			{
				//m.SendLocalizedMessage(2, "Your dead and can't use this" ); 
			}

			return true;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); 
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

using System;
using Server;
using Server.Accounting; 
using Server.Network; 

namespace Server.Items 
{ 
	public class questIcon : Item 
	{ 
		[Constructable] 
		public questIcon() : base( 0x2088 ) 
		{
			Name = "quest Icon";
			Hue = 0xbaa;
		} 

		public override bool OnDragLift( Mobile from )
		{
			from.SendMessage ("You are unable to lift the item, try using it");
			return false;
		}

		public questIcon( Serial serial ) : base( serial ) 
		{ 
		} 

		// This is the main part 

		public override void OnDoubleClick( Mobile m ) 
		{ 
			m.PlaySound( 0x214 ); 
			m.FixedEffect( 0x376A, 10, 16 ); 
			int cmpVal; 
			string str1 = ((Account)m.Account).GetTag("questIcon"); 
			string str2 = "by Greywolf"; 
			cmpVal=str2.CompareTo(str1); 

			if ( cmpVal != 0 )
			{ 
				((Account)m.Account).SetTag("questIcon", "by Greywolf");
				///Prizes added here
				m.SendMessage( "You have been Rewarded for your effort! " ); 
				m.AddToBackpack(new Gold( 3000 ));
				{
					this.Delete();
				} 
			}
			else
			{ 
 				m.SendMessage( "Sorry but you can only do this quest once per account." ); 
			}
		} 


		// And that's all already. :-) 

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
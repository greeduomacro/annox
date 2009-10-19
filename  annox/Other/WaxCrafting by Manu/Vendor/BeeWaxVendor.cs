using System; 
using System.Collections; 
using Server; 

namespace Server.Mobiles 
{ 
	public class BeeWaxVendor : BaseVendor 
	{ 
		private ArrayList m_SBInfos = new ArrayList(); 
		protected override ArrayList SBInfos{ get { return m_SBInfos; } } 

		[Constructable]
        public BeeWaxVendor()
            : base("the bee wax vendor") 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBBeeWaxVendor() ); 
		}

		public override VendorShoeType ShoeType{ get{ return VendorShoeType.Boots; } }

		public BeeWaxVendor( Serial serial ) : base( serial ) 
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
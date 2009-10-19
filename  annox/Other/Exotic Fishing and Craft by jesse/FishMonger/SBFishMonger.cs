using System; 
using System.Collections; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBFishMonger : SBInfo 
	{ 
		private ArrayList m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBFishMonger() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override ArrayList BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : ArrayList 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( RawFishSteak ), 3, 20, 0x97A, 0 ) );
				Add( new GenericBuyInfo( typeof( ExoticFishingPole ), 50, 20, 0xDC0, 1150 ) );
				Add( new GenericBuyInfo( typeof( FishtankKit ), 5000, 20, 0x102C, 444 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( RawFishSteak ), 1 );
				Add( typeof( Fish ), 1 );
				Add( typeof( ExoticFishingPole ), 25 );
				Add( typeof( FishtankKit ), 2000 );	
			} 
		} 
	} 
}
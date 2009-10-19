using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElvenHelmetArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElvenHelmetArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public int m_Cost;
            public int m_Quantity;

            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo("Circlet", typeof(Circlet), RandomCost(), RandomQuantity(), 0x2B6E, 0));
                Add(new GenericBuyInfo("Raven Helmet", typeof(RavenHelm), RandomCost(), RandomQuantity(), 0x2B71, 0));
                Add(new GenericBuyInfo("Royal Circlet", typeof(RoyalCirclet), RandomCost(), RandomQuantity(), 0x2B6F, 0));
                Add(new GenericBuyInfo("Vulture Helmet", typeof(VultureHelm), RandomCost(), RandomQuantity(), 0x2B72, 0));
                Add(new GenericBuyInfo("Winged Helmet", typeof(WingedHelm), RandomCost(), RandomQuantity(), 0x2B73, 0));
                Add(new GenericBuyInfo("Gemmed Circlet", typeof(GemmedCirclet), RandomCost(), RandomQuantity(), 0x2B70, 0));
            }

            public int RandomCost()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }

            public int RandomQuantity()
            {
                int m_Quantity = (Utility.RandomMinMax(1, 10));
                return (m_Quantity);
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public int m_Cost;

            public InternalSellInfo()
            {
                Add(typeof(Circlet), RandomPrice());
                Add(typeof(RavenHelm), RandomPrice());
                Add(typeof(RoyalCirclet), RandomPrice());
                Add(typeof(VultureHelm), RandomPrice());
                Add(typeof(WingedHelm), RandomPrice());
                Add(typeof(GemmedCirclet), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

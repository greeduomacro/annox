using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElementalOrbDealer : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElementalOrbDealer()
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
                Add(new GenericBuyInfo("AirOrb", typeof(AirOrb), RandomCost(), RandomQuantity(), 0x2B6E, 0));
                Add(new GenericBuyInfo("EarthOrb", typeof(EarthOrb), RandomCost(), RandomQuantity(), 0x2FCA, 0));
                Add(new GenericBuyInfo("EnergyOrb", typeof(EnergyOrb), RandomCost(), RandomQuantity(), 0x2FC6, 0));
                Add(new GenericBuyInfo("FireOrb", typeof(FireOrb), RandomCost(), RandomQuantity(), 0x2FC8, 0));
                Add(new GenericBuyInfo("IceOrb", typeof(IceOrb), RandomCost(), RandomQuantity(), 0x2FCB, 0));
                Add(new GenericBuyInfo("PoisonOrb", typeof(PoisonOrb), RandomCost(), RandomQuantity(), 0x2B6C, 0));
                Add(new GenericBuyInfo("WaterOrb", typeof(WaterOrb), RandomCost(), RandomQuantity(), 0x2FC9, 0));
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
                Add(typeof(AirOrb), RandomPrice());
                Add(typeof(EarthOrb), RandomPrice());
                Add(typeof(EnergyOrb), RandomPrice());
                Add(typeof(FireOrb), RandomPrice());
                Add(typeof(IceOrb), RandomPrice());
                Add(typeof(PoisonOrb), RandomPrice());
                Add(typeof(WaterOrb), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElvenWoodArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElvenWoodArmor()
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

                Add(new GenericBuyInfo("Woodland Arms", typeof(WoodlandArms), RandomCost(), RandomQuantity(), 0x2B6C, 0));
                Add(new GenericBuyInfo("Woodland Chest", typeof(WoodlandChest), RandomCost(), RandomQuantity(), 0x2B67, 0));
                Add(new GenericBuyInfo("Woodland Gloves", typeof(WoodlandGloves), RandomCost(), RandomQuantity(), 0x2B6D, 0));
                Add(new GenericBuyInfo("Woodland Gorget", typeof(WoodlandGorget), RandomCost(), RandomQuantity(), 0x2B6A, 0));
                Add(new GenericBuyInfo("Woodland Legs", typeof(WoodlandLegs), RandomCost(), RandomQuantity(), 0x2B69, 0));
                Add(new GenericBuyInfo("Woodland Belt", typeof(WoodlandBelt), RandomCost(), RandomQuantity(), 0x2B69, 0));
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
                Add(typeof(WoodlandArms), RandomPrice());
                Add(typeof(WoodlandChest), RandomPrice());
                Add(typeof(WoodlandGloves), RandomPrice());
                Add(typeof(WoodlandGorget), RandomPrice());
                Add(typeof(WoodlandLegs), RandomPrice());
                Add(typeof(WoodlandBelt), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

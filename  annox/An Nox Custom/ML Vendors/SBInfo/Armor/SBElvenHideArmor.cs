using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElvenHideArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElvenHideArmor()
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
                Add(new GenericBuyInfo("Hide Chest Female", typeof(HideFemaleChest), RandomCost(), RandomQuantity(), 0x2B79, 0));
                Add(new GenericBuyInfo("Hide Chest", typeof(HideChest), RandomCost(), RandomQuantity(), 0x2B74, 0));
                Add(new GenericBuyInfo("Hide Gloves", typeof(HideGloves), RandomCost(), RandomQuantity(), 0x2B75, 0));
                Add(new GenericBuyInfo("Hide Gorget", typeof(HideGorget), RandomCost(), RandomQuantity(), 0x2B76, 0));
                Add(new GenericBuyInfo("Hide Pauldrons", typeof(HidePauldrons), RandomCost(), RandomQuantity(), 0x2B77, 0));
                Add(new GenericBuyInfo("Hide Pants", typeof(HidePants), RandomCost(), RandomQuantity(), 0x2B78, 0));
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
                Add(typeof(HideFemaleChest), RandomPrice());
                Add(typeof(HideChest), RandomPrice());
                Add(typeof(HideGloves), RandomPrice());
                Add(typeof(HideGorget), RandomPrice());
                Add(typeof(HidePauldrons), RandomPrice());
                Add(typeof(HidePants), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElvenLTArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElvenLTArmor()
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
                Add(new GenericBuyInfo("Leaf Tonlet Arms", typeof(LeafArms), RandomCost(), RandomQuantity(), 0x2FCA, 0));
                Add(new GenericBuyInfo("Leaf Tonlet Armor Chest", typeof(LeafChest), RandomCost(), RandomQuantity(), 0x2FC5, 0));
                Add(new GenericBuyInfo("Leaf Tonlet Armor Gloves", typeof(LeafGloves), RandomCost(), RandomQuantity(), 0x2FC6, 0));
                Add(new GenericBuyInfo("Leaf Tonlet Armor Gorget", typeof(LeafGorget), RandomCost(), RandomQuantity(), 0x2FC7, 0));
                Add(new GenericBuyInfo("Leaf Tonlet Armor Legs", typeof(LeafLegs), RandomCost(), RandomQuantity(), 0x2FC8, 0));
                Add(new GenericBuyInfo("Leaf Tonlet", typeof(LeafTonlet), RandomCost(), RandomQuantity(), 0x2FC9, 0));
                Add(new GenericBuyInfo("Leaf Tonlet Female Armor Chest", typeof(FemaleLeafChest), RandomCost(), RandomQuantity(), 0x2FCB, 0));
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
                Add(typeof(LeafArms), RandomPrice());
                Add(typeof(LeafChest), RandomPrice());
                Add(typeof(LeafGloves), RandomPrice());
                Add(typeof(LeafGorget), RandomPrice());
                Add(typeof(LeafLegs), RandomPrice());
                Add(typeof(LeafTonlet), RandomPrice());
                Add(typeof(FemaleLeafChest), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

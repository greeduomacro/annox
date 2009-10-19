using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElvenTailor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElvenTailor()
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
                Add(new GenericBuyInfo("Elven Boots", typeof(ElvenBoots), RandomCost(), RandomQuantity(), 0x2FC4, 0));
                Add(new GenericBuyInfo("Elven Male Robe", typeof(MaleElvenRobe), RandomCost(), RandomQuantity(), 0x2FB9, 0));
                Add(new GenericBuyInfo("Elven Femal Robe", typeof(FemaleElvenRobe), RandomCost(), RandomQuantity(), 0x2FB9, 0));
                Add(new GenericBuyInfo("Elven Dark Shirt", typeof(ElvenDarkShirt), RandomCost(), RandomQuantity(), 0x3176, 0));
                Add(new GenericBuyInfo("Elven Shirt", typeof(ElvenShirt), RandomCost(), RandomQuantity(), 0x3175, 0));
                Add(new GenericBuyInfo("Elven Pants", typeof(ElvenPants), RandomCost(), RandomQuantity(), 0x2FC3, 0));
                //Add(new GenericBuyInfo("Elven Quiver", typeof(ElvenQuiver), RandomCost, RandomQuantity, 0x2FB7, 0));
                //Add(new GenericBuyInfo("Elven Glasses", typeof(ElvenGlasses), RandomCost, RandomQuantity, 0x2FB8, 0));

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
                Add(typeof(ElvenBoots), RandomPrice());
                Add(typeof(MaleElvenRobe), RandomPrice());
                Add(typeof(FemaleElvenRobe), RandomPrice());
                Add(typeof(ElvenDarkShirt), RandomPrice());
                Add(typeof(ElvenShirt), RandomPrice());
                Add(typeof(ElvenPants), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class SBNastArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBNastArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(ArmsofNast), 80, 20, 0x1410, 0));
                Add(new GenericBuyInfo(typeof(ChestofNast), 101, 20, 0x1415, 0));
                Add(new GenericBuyInfo(typeof(GlovesofNast), 60, 20, 0x1414, 0));
                Add(new GenericBuyInfo(typeof(NeckofNast), 74, 20, 0x1413, 0));
                Add(new GenericBuyInfo(typeof(LegsofNast), 80, 20, 0x1411, 0));
                Add(new GenericBuyInfo(typeof(HeadofNast), 10, 20, 0x1451, 0));

                Add(new GenericBuyInfo(typeof(BladeofNast), 74, 20, 0x26BB, 0));
                Add(new GenericBuyInfo(typeof(NastsBracelet), 80, 20, 0x13cb, 0));
                Add(new GenericBuyInfo(typeof(ShieldofLordNast), 10, 20, 0x1BC4, 0));



            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(ArmsofNast), 40);
                Add(typeof(ChestofNast), 52);
                Add(typeof(GlovesofNast), 30);
                Add(typeof(NeckofNast), 37);
                Add(typeof(LeatherLegs), 40);
                Add(typeof(HeadofNast), 5);


                Add(typeof(BladeofNast), 18);
                Add(typeof(NastsBracelet), 25);
                Add(typeof(ShieldofLordNast), 14);
            }
        }
    }
}

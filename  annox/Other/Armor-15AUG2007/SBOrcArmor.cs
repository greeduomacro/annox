using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class SBOrcArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBOrcArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(ArmorOfTheOrcsArms), 80, 20, 0x13CD, 0));
                Add(new GenericBuyInfo(typeof(ArmorOfTheOrcsChest), 101, 20, 0x13CC, 0));
                Add(new GenericBuyInfo(typeof(ArmorOfTheOrcsGloves), 60, 20, 0x13C6, 0));
                Add(new GenericBuyInfo(typeof(ArmorOfTheOrcsGorget), 74, 20, 0x13C7, 0));
                Add(new GenericBuyInfo(typeof(ArmorOfTheOrcsLegs), 80, 20, 0x13cb, 0));

                //Add(new GenericBuyInfo(typeof(OrcAxe), 116, 20, 0x1C06, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(ArmorOfTheOrcsArms), 40);
                Add(typeof(ArmorOfTheOrcsChest), 52);
                Add(typeof(ArmorOfTheOrcsGloves), 30);
                Add(typeof(ArmorOfTheOrcsGorget), 37);
                Add(typeof(ArmorOfTheOrcsLegs), 40);

                //Add(typeof(OrcAxe), 18);
            }
        }
    }
}

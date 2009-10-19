using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class SBDaemonArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBDaemonArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(DaemonMetalArms), 80, 20, 0x1410, 0));
                Add(new GenericBuyInfo(typeof(DaemonMetalChest), 101, 20, 0x144f, 0));
                Add(new GenericBuyInfo(typeof(DaemonMetalGloves), 60, 20, 0x1450, 0));
                //Add(new GenericBuyInfo(typeof(LeatherGorget), 74, 20, 0x13C7, 0));
                Add(new GenericBuyInfo(typeof(DaemonMetalLeggings), 80, 20, 0x1411, 0));
                Add(new GenericBuyInfo(typeof(DaemonMetalHelm), 10, 20, 0x1451, 0));

                Add(new GenericBuyInfo(typeof(BladeofPower), 116, 20, 0x26C1, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(DaemonMetalArms), 40);
                Add(typeof(DaemonMetalChest), 52);
                Add(typeof(DaemonMetalGloves), 30);
                //Add(typeof(LeatherGorget), 37);
                Add(typeof(DaemonMetalLeggings), 40);
                Add(typeof(DaemonMetalHelm), 5);


                Add(typeof(BladeofPower), 18);
            }
        }
    }
}

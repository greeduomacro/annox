using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class SBRandomArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBRandomArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(RandomArms), 80, 20, 0x13CD, 0));
                Add(new GenericBuyInfo(typeof(RandomTunic), 101, 20, 0x13CC, 0));
                Add(new GenericBuyInfo(typeof(RandomGloves), 60, 20, 0x13C6, 0));
                Add(new GenericBuyInfo(typeof(RandomGorget), 74, 20, 0x13C7, 0));
                Add(new GenericBuyInfo(typeof(RandomLegs), 80, 20, 0x13cb, 0));
                Add(new GenericBuyInfo(typeof(RandomHelmet), 10, 20, 0x1DB9, 0));

                Add(new GenericBuyInfo(typeof(RandomShield), 116, 20, 0x1C06, 0));
                Add(new GenericBuyInfo(typeof(RandomBlade), 97, 20, 0x1C0A, 0));
                Add(new GenericBuyInfo(typeof(RandomBrace), 86, 20, 0x1C00, 0));
                Add(new GenericBuyInfo(typeof(RandomRing), 87, 20, 0x1C08, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(RandomArms), 40);
                Add(typeof(RandomTunic), 52);
                Add(typeof(RandomGloves), 30);
                Add(typeof(RandomGorget), 37);
                Add(typeof(RandomLegs), 40);
                Add(typeof(RandomHelmet), 5);


                Add(typeof(RandomShield), 18);
                Add(typeof(RandomBlade), 25);
                Add(typeof(RandomBrace), 14);
                Add(typeof(RandomRing), 11);
            }
        }
    }
}

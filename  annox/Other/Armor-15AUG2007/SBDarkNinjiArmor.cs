using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class SBDarkNinjiArmor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBDarkNinjiArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(DarkNinjaArms), 80, 20, 0x13E0, 0));
                Add(new GenericBuyInfo(typeof(DarkNinjaArmor), 101, 20, 0x13CC, 0));
                Add(new GenericBuyInfo(typeof(DarkNinjaMitts), 60, 20, 0x13C6, 0));
                Add(new GenericBuyInfo(typeof(VoiceOfTheDarkNinja), 74, 20, 0x13C7, 0));
                Add(new GenericBuyInfo(typeof(DarkNinjaPants), 80, 20, 0x13cb, 0));
                Add(new GenericBuyInfo(typeof(DarkNinjaHood), 10, 20, 0x1DB9, 0));
                Add(new GenericBuyInfo(typeof(DarkNinjaJacket), 116, 20, 0x1C06, 0));

                Add(new GenericBuyInfo(typeof(ClawsOfTheBeast), 97, 20, 0x1C0A, 0));

            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(DarkNinjaArms), 40);
                Add(typeof(DarkNinjaArmor), 52);
                Add(typeof(DarkNinjaMitts), 30);
                Add(typeof(VoiceOfTheDarkNinja), 37);
                Add(typeof(DarkNinjaPants), 40);
                Add(typeof(DarkNinjaHood), 5);
                Add(typeof(DarkNinjaJacket), 18);

                Add(typeof(ClawsOfTheBeast), 25);
            }
        }
    }
}

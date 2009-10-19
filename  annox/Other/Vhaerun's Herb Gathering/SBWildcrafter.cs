using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class SBWildcrafter : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBWildcrafter()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Boline), 20, 20, 0xC3D, 0));

                Add(new GenericBuyInfo(typeof(Sage), 3, 20, 0xC3D, 0));
                Add(new GenericBuyInfo(typeof(Acacia), 3, 20, 0xDE1, 0));
                Add(new GenericBuyInfo(typeof(Anise), 3, 20, 0xF2C, 0));
                Add(new GenericBuyInfo(typeof(Basil), 3, 20, 0xC3E, 0));
                Add(new GenericBuyInfo(typeof(BayLeaf), 5, 20, 0xF78, 0));
                Add(new GenericBuyInfo(typeof(Chamomile), 8, 20, 0xF8D, 0));
                Add(new GenericBuyInfo(typeof(Caraway), 5, 20, 0xF29, 0));

                Add(new GenericBuyInfo(typeof(Cilantro), 3, 20, 0x1020, 0));
                Add(new GenericBuyInfo(typeof(Cinnamon), 3, 20, 0xF80, 0));
                Add(new GenericBuyInfo(typeof(Clove), 3, 20, 0xF8E, 0));
                Add(new GenericBuyInfo(typeof(Copal), 3, 20, 0xF21, 0));
                Add(new GenericBuyInfo(typeof(Coriander), 5, 20, 0xF15, 0));
                Add(new GenericBuyInfo(typeof(Dill), 8, 20, 0xF1B, 0));
                Add(new GenericBuyInfo(typeof(Dragonsblood), 5, 20, 0xF8F, 0));

                Add(new GenericBuyInfo(typeof(Frankincense), 3, 20, 0xC3B, 0));
                Add(new GenericBuyInfo(typeof(Marjoram), 3, 20, 0xC3E, 0));
                Add(new GenericBuyInfo(typeof(Meadowsweet), 3, 20, 0xF88, 0));
                Add(new GenericBuyInfo(typeof(Mint), 3, 20, 0xC41, 0));
                Add(new GenericBuyInfo(typeof(Mugwort), 5, 20, 0xC42, 0));
                Add(new GenericBuyInfo(typeof(Mustard), 8, 20, 0xF2C, 0));
                Add(new GenericBuyInfo(typeof(Myrrh), 5, 20, 0xF7B, 0));

                Add(new GenericBuyInfo(typeof(Olive), 3, 20, 0xF8D, 0));
                Add(new GenericBuyInfo(typeof(Oregano), 3, 20, 0xC3D, 0));
                Add(new GenericBuyInfo(typeof(Orris), 3, 20, 0xF85, 0));
                Add(new GenericBuyInfo(typeof(Patchouli), 3, 20, 0x18E4, 0));
                Add(new GenericBuyInfo(typeof(Peppercorn), 5, 20, 0xF87, 0));
                Add(new GenericBuyInfo(typeof(RoseHerb), 8, 20, 0xC3D, 0));
                Add(new GenericBuyInfo(typeof(Rosemary), 5, 20, 0x1020, 0));

                Add(new GenericBuyInfo(typeof(Saffron), 3, 20, 0xC3C, 0));
                Add(new GenericBuyInfo(typeof(Sandelwood), 3, 20, 0x979, 0));
                Add(new GenericBuyInfo(typeof(SlipperyElm), 3, 20, 0xF89, 0));
                Add(new GenericBuyInfo(typeof(Thyme), 3, 20, 0xC3D, 0));
                Add(new GenericBuyInfo(typeof(Valerian), 5, 20, 0xF86, 0));
                Add(new GenericBuyInfo(typeof(WillowBark), 8, 20, 0xF79, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Boline), 10);

                Add(typeof(Sage), 3);
                Add(typeof(Acacia), 2);
                Add(typeof(Anise), 2);
                Add(typeof(Basil), 2);
                Add(typeof(BayLeaf), 2);
                Add(typeof(Chamomile), 3);
                Add(typeof(Caraway), 4);

                Add(typeof(Cilantro), 3);
                Add(typeof(Cinnamon), 2);
                Add(typeof(Clove), 2);
                Add(typeof(Copal), 2);
                Add(typeof(Coriander), 2);
                Add(typeof(Dill), 3);
                Add(typeof(Dragonsblood), 4);

                Add(typeof(Frankincense), 3);
                Add(typeof(Marjoram), 2);
                Add(typeof(Meadowsweet), 2);
                Add(typeof(Mint), 2);
                Add(typeof(Mugwort), 2);
                Add(typeof(Mustard), 3);
                Add(typeof(Myrrh), 4);

                Add(typeof(Olive), 3);
                Add(typeof(Oregano), 2);
                Add(typeof(Orris), 2);
                Add(typeof(Patchouli), 2);
                Add(typeof(Peppercorn), 2);
                Add(typeof(RoseHerb), 3);
                Add(typeof(Rosemary), 4);

                Add(typeof(Saffron), 3);
                Add(typeof(Sandelwood), 2);
                Add(typeof(SlipperyElm), 2);
                Add(typeof(Thyme), 2);
                Add(typeof(Valerian), 2);
                Add(typeof(WillowBark), 3);
            }
        }
    }
}
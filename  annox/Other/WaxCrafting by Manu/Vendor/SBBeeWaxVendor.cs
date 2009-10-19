using System;
using System.Collections;
using Server.Items;
using Server.Engines.Apiculture;


namespace Server.Mobiles
{
    public class SBBeeWaxVendor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBBeeWaxVendor()
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
                Add(new GenericBuyInfo(typeof(RawBeeswax), RandomCost(), RandomQuantity(), 0x1422, 0));
                Add(new GenericBuyInfo(typeof(Slumgum), RandomCost(), RandomQuantity(), 5927, 0));//may need to check ID
                Add(new GenericBuyInfo(typeof(apiWaxProcessingPot), RandomCost(), RandomQuantity(), 2532, 0));//may need to check ID
                Add(new GenericBuyInfo(typeof(apiBeeHiveDeed), RandomCost(), RandomQuantity(), 0x14F0, 0));
                Add(new GenericBuyInfo(typeof(HoneyComb), RandomCost(), RandomQuantity(), 0x1762, 0));
                Add(new GenericBuyInfo(typeof(HoneycombProcessingKettle), RandomCost(), RandomQuantity(), 0x9ED, 0));
                Add(new GenericBuyInfo(typeof(WildBeehive), RandomCost(), RandomQuantity(), 0x91A, 0));
                Add(new GenericBuyInfo(typeof(CandleLongColor), RandomCost(), RandomQuantity(), 0x1433, 0));
                Add(new GenericBuyInfo(typeof(CandleShortColor), RandomCost(), RandomQuantity(), 0x142F, 0));
                Add(new GenericBuyInfo(typeof(DippingStick), RandomCost(), RandomQuantity(), 0x1428, 0));
                Add(new GenericBuyInfo(typeof(PileOfBlankCandles), RandomCost(), RandomQuantity(), 0x1BD6, 0));
                Add(new GenericBuyInfo(typeof(RawWaxBust), RandomCost(), RandomQuantity(), 0x12CA, 0));
                Add(new GenericBuyInfo(typeof(SomeBlankCandles), RandomCost(), RandomQuantity(), 0x1BD5, 0));
                Add(new GenericBuyInfo(typeof(BlankCandle), RandomCost(), RandomQuantity(), 0x1433, 0));
                Add(new GenericBuyInfo(typeof(PileOfBlankCandles), RandomCost(), RandomQuantity(), 0x1BD6, 0));
                Add(new GenericBuyInfo(typeof(CandleFitSkull), RandomCost(), RandomQuantity(), 0x1AE3, 0));
                Add(new GenericBuyInfo(typeof(CandleWick), RandomCost(), RandomQuantity(), 0x979, 0));
                Add(new GenericBuyInfo(typeof(EssenceOfLove), RandomCost(), RandomQuantity(), 0x1C18, 0));
                Add(new GenericBuyInfo(typeof(WaxCraftingPot), RandomCost(), RandomQuantity(), 0x142A, 0));
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
                Add(typeof(RawBeeswax), RandomPrice());
                Add(typeof(Slumgum), RandomPrice());
                Add(typeof(apiWaxProcessingPot), RandomPrice());
                Add(typeof(apiBeeHiveDeed), RandomPrice());
                Add(typeof(HoneyComb), RandomPrice());
                Add(typeof(HoneycombProcessingKettle), RandomPrice());
                Add(typeof(WildBeehive), RandomPrice());
                Add(typeof(CandleLongColor), RandomPrice());
                Add(typeof(CandleShortColor), RandomPrice());
                Add(typeof(DippingStick), RandomPrice());
                Add(typeof(PileOfBlankCandles), RandomPrice());
                Add(typeof(RawWaxBust), RandomPrice());
                Add(typeof(SomeBlankCandles), RandomPrice());
                Add(typeof(BlankCandle), RandomPrice());
                Add(typeof(PileOfBlankCandles), RandomPrice());
                Add(typeof(CandleFitSkull), RandomPrice());
                Add(typeof(CandleWick), RandomPrice());
                Add(typeof(EssenceOfLove), RandomPrice());
                Add(typeof(WaxCraftingPot), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}
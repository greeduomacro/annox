using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBMysticBowcraftVendor : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBMysticBowcraftVendor()
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
                Add(new GenericBuyInfo("Mystic Fletcher Tool", typeof(MysticFletcherTools), RandomCost(), RandomQuantity(), 0x1022, 0));
                Add(new GenericBuyInfo("Silk Pile", typeof(SilkPile), RandomCost(), RandomQuantity(), 0xF8D, 0));
                Add(new GenericBuyInfo("Silk Thread", typeof(SilkThread), RandomCost(), RandomQuantity(), 0xFA1, 0));
                Add(new GenericBuyInfo("Yeti Hair", typeof(YetiHair), RandomCost(), RandomQuantity(), 0xE1F, 0));
                Add(new GenericBuyInfo("Sasquatch Hair", typeof(SasquatchHair), RandomCost(), RandomQuantity(), 0xE1F, 0));

                Add(new GenericBuyInfo("Fire Arrow", typeof(FireArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Blood Arrow", typeof(BloodArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Poison Arrow", typeof(PoisonArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Dragon Arrow", typeof(DragonArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Moon Arrow", typeof(MoonArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Falcon Arrows", typeof(FalconArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Sun Arrows", typeof(SunArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Star Arrow", typeof(StarArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Dark Arrow", typeof(DarkArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Zodiac Arrow", typeof(ZodiacArrow), RandomCost(), RandomQuantity(), 0xF3F, 0));
                Add(new GenericBuyInfo("Air Bolt", typeof(AirBolt), RandomCost(), RandomQuantity(), 0x1BFB, 0));
                Add(new GenericBuyInfo("Water Bolt", typeof(WaterBolt), RandomCost(), RandomQuantity(), 0x1BFB, 0));
                Add(new GenericBuyInfo("Death Bolt", typeof(DeathBolt), RandomCost(), RandomQuantity(), 0x1BFB, 0));

                Add(new GenericBuyInfo("Fire Feather", typeof(FireFeather), RandomCost(), RandomQuantity()*50, 0x1020, 0));
                Add(new GenericBuyInfo("Blood Feather", typeof(BloodFeather), RandomCost(), RandomQuantity() * 50, 0x1020, 0));
                Add(new GenericBuyInfo("Posion Feather", typeof(PoisonFeather), RandomCost(), RandomQuantity() * 50, 0x1020, 0));
                Add(new GenericBuyInfo("Dragon Feather", typeof(DragonFeather), RandomCost(), RandomQuantity() * 50, 0x1020, 0));
                Add(new GenericBuyInfo("Air Feather", typeof(AirFeather), RandomCost(), RandomQuantity() * 50, 0x1020, 0));
                Add(new GenericBuyInfo("Water Feather", typeof(WaterFeather), RandomCost(), RandomQuantity() * 50, 0x1020, 0));

            }

            public int RandomCost()
            {
                int m_Cost = Utility.RandomMinMax(10, 100);
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
                Add(typeof(SilkPile), RandomPrice());
                Add(typeof(SilkThread), RandomPrice());
                Add(typeof(YetiHair), RandomPrice());
                Add(typeof(SasquatchHair), RandomPrice());

                Add(typeof(FireArrow), RandomPrice());
                Add(typeof(BloodArrow), RandomPrice());
                Add(typeof(PoisonArrow), RandomPrice());
                Add(typeof(DragonArrow), RandomPrice());
                Add(typeof(MoonArrow), RandomPrice());
                Add(typeof(FalconArrow), RandomPrice());
                Add(typeof(SunArrow), RandomPrice());
                Add(typeof(StarArrow), RandomPrice());
                Add(typeof(DarkArrow), RandomPrice());
                Add(typeof(ZodiacArrow), RandomPrice());
                Add(typeof(AirBolt), RandomPrice());
                Add(typeof(WaterBolt), RandomPrice());
                Add(typeof(DeathBolt), RandomPrice());

                Add(typeof(FireFeather), RandomPrice());
                Add(typeof(BloodFeather), RandomPrice());
                Add(typeof(PoisonFeather), RandomPrice());
                Add(typeof(DragonFeather), RandomPrice());
                //Add(typeof(MoonFeather), RandomPrice());
                //Add(typeof(FalconFeather), RandomPrice());
                //Add(typeof(SunFeather), RandomPrice());
                //Add(typeof(StarFeather), RandomPrice());
                //Add(typeof(DarkFeather), RandomPrice());
                //Add(typeof(ZodiacFeather), RandomPrice());
                Add(typeof(AirFeather), RandomPrice());
                Add(typeof(WaterFeather), RandomPrice());
                //Add(typeof(DeathFeather), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 250);
                return (m_Cost);
            }
        }
    }
}

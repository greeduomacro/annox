using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElementalWeaponsDealer : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElementalWeaponsDealer()
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

                Add(new GenericBuyInfo("Staff of Air", typeof(AirStaff), RandomCost(), RandomQuantity(), 0x0E89, 0));
                Add(new GenericBuyInfo("Earth Cutter", typeof(EarthCutter), RandomCost(), RandomQuantity(), 0x26BA, 0));
                Add(new GenericBuyInfo("Axe of Fire", typeof(FireAxe), RandomCost(), RandomQuantity(), 0x0F45, 0));
                Add(new GenericBuyInfo("Ice Hammer", typeof(IceHammer), RandomCost(), RandomQuantity(), 0x1439, 0));
                Add(new GenericBuyInfo("Elven Spell Blade", typeof(ElvenSpellblade), RandomCost(), RandomQuantity(), 0x2D20, 0));
                Add(new GenericBuyInfo("Spear of Poison", typeof(PoisonSpear), RandomCost(), RandomQuantity(), 0x26BE, 0));
                Add(new GenericBuyInfo("Rod of Thunder", typeof(ThunderRod), RandomCost(), RandomQuantity(), 0x3568, 0));
                Add(new GenericBuyInfo("Water Trident", typeof(WaterTrident), RandomCost(), RandomQuantity(), 0x3719, 0));
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
                Add(typeof(AirStaff), RandomPrice());
                Add(typeof(EarthCutter), RandomPrice());
                Add(typeof(FireAxe), RandomPrice());
                Add(typeof(IceHammer), RandomPrice());
                Add(typeof(ElvenSpellblade), RandomPrice());
                Add(typeof(PoisonSpear), RandomPrice());
                Add(typeof(ThunderRod), RandomPrice());
                Add(typeof(WaterTrident), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

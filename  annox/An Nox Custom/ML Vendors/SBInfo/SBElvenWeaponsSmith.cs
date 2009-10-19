using System;
using System.Collections;
using Server.Items;


namespace Server.Mobiles
{
    public class SBElvenWeaponSmith : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBElvenWeaponSmith()
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
                Add(new GenericBuyInfo("Assassin Spike", typeof(AssassinSpike), RandomCost(), RandomQuantity(), 0x2D21, 0));
                Add(new GenericBuyInfo("Diamond Mace", typeof(DiamondMace), RandomCost(), RandomQuantity(), 0x2D24, 0));
                Add(new GenericBuyInfo("Elven Composite Long Bow", typeof(ElvenCompositeLongbow), RandomCost(), RandomQuantity(), 0x2D1E, 0));
                Add(new GenericBuyInfo("Elven Machete", typeof(ElvenMachete), RandomCost(), RandomQuantity(), 0x2D29, 0));
                Add(new GenericBuyInfo("Elven Spell Blade", typeof(ElvenSpellblade), RandomCost(), RandomQuantity(), 0x2D20, 0));
                Add(new GenericBuyInfo("Leaf Blade", typeof(Leafblade), RandomCost(), RandomQuantity(), 0x2D22, 0));
                Add(new GenericBuyInfo("Magical Short Bow", typeof(MagicalShortbow), RandomCost(), RandomQuantity(), 0x2D1F, 0));
                Add(new GenericBuyInfo("Ornate Axe", typeof(OrnateAxe), RandomCost(), RandomQuantity(), 0x2D28, 0));
                Add(new GenericBuyInfo("Radiant Scimitar", typeof(RadiantScimitar), RandomCost(), RandomQuantity(), 0x2D33, 0));
                Add(new GenericBuyInfo("Rune Blade", typeof(RuneBlade), RandomCost(), RandomQuantity(), 0x2D26, 0));
                Add(new GenericBuyInfo("War Cleaver", typeof(WarCleaver), RandomCost(), RandomQuantity(), 0x2D23, 0));
                Add(new GenericBuyInfo("Wild Staff", typeof(WildStaff), RandomCost(), RandomQuantity(), 0x2D25, 0));
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
                Add(typeof(AssassinSpike), RandomPrice());
                Add(typeof(DiamondMace), RandomPrice());
                Add(typeof(ElvenCompositeLongbow), RandomPrice());
                Add(typeof(ElvenMachete), RandomPrice());
                Add(typeof(ElvenSpellblade), RandomPrice());
                Add(typeof(Leafblade), RandomPrice());
                Add(typeof(MagicalShortbow), RandomPrice());
                Add(typeof(OrnateAxe), RandomPrice());
                Add(typeof(RadiantScimitar), RandomPrice());
                Add(typeof(RuneBlade), RandomPrice());
                Add(typeof(WarCleaver), RandomPrice());
                Add(typeof(WildStaff), RandomPrice());
            }

            public int RandomPrice()
            {
                int m_Cost = Utility.RandomMinMax(50, 500);
                return (m_Cost);
            }
        }
    }
}

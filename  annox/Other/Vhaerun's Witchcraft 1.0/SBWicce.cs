using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class SBWicce : SBInfo
    {
        private ArrayList m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBWicce()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override ArrayList BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : ArrayList
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo("1041072", typeof(MagicWizardsHat), 11, 10, 0x1718, Utility.RandomDyedHue()));
                Add(new GenericBuyInfo("1041072", typeof(WitchCauldron), 11, 10, 0x9ED, Utility.RandomDyedHue()));

                Add(new GenericBuyInfo(typeof(BowyerBerry), 15, 10, 0x9D0, 0));
                Add(new GenericBuyInfo(typeof(HealerPear), 15, 10, 0x994, 0));
                Add(new GenericBuyInfo(typeof(HunterApple), 15, 10, 0x9D0, 0));
                Add(new GenericBuyInfo(typeof(KnightMango), 15, 10, 0x9D2, 0));
                Add(new GenericBuyInfo(typeof(LumberjackCoconut), 15, 10, 0x1726, 0));
                Add(new GenericBuyInfo(typeof(MacerPear), 15, 10, 0x994, 0));
                Add(new GenericBuyInfo(typeof(MageMango), 15, 10, 0x9D2, 0));
                Add(new GenericBuyInfo(typeof(MinerPear), 21, 10, 0x994, 0));

                Add(new GenericBuyInfo(typeof(NecroLime), 5, 20, 0x172A, 0));
                Add(new GenericBuyInfo(typeof(PirateGrapes), 5, 20, 0x9D1, 0));
                Add(new GenericBuyInfo(typeof(RangerGrapes), 3, 20, 0x9D1, 0));
                Add(new GenericBuyInfo(typeof(RogueLemon), 3, 20, 0x1728, 0));
                Add(new GenericBuyInfo(typeof(SageMelon), 3, 20, 0xC5D, 0));
                Add(new GenericBuyInfo(typeof(ScribeLemon), 3, 20, 0x1728, 0));
                Add(new GenericBuyInfo(typeof(ShepherdLime), 3, 20, 0x172A, 0));
                Add(new GenericBuyInfo(typeof(SmithMelon), 3, 20, 0xC5D, 0));

                Add(new GenericBuyInfo(typeof(TacticBerry), 3, 10, 0x9D0, 0));
                Add(new GenericBuyInfo(typeof(TailorPeach), 6, 10, 0x9D2, 0));
                Add(new GenericBuyInfo(typeof(ThiefOrange), 5, 20, 0x9D0, 0));
                Add(new GenericBuyInfo(typeof(TinkerApple), 6, 20, 0x9D0, 0));
                Add(new GenericBuyInfo(typeof(WarriorPeach), 3, 15, 0x9D2, 0));
                Add(new GenericBuyInfo(typeof(WoodworkerApple), 3, 15, 0x9D0, 0));
            }
        }
    }

    public class InternalSellInfo : GenericSellInfo
    {
        public InternalSellInfo()
        {
            Add(typeof(WizardsHat), 15);
            Add(typeof(WitchCauldron), 15);
            Add(typeof(BowyerBerry), 3);
            Add(typeof(HealerPear), 4);
            Add(typeof(MandrakeRoot), 2);
            Add(typeof(HunterApple), 2);
            Add(typeof(LumberjackCoconut), 2);
            Add(typeof(MacerPear), 2);
            Add(typeof(MageMango), 2);
            Add(typeof(MinerPear), 2);
            Add(typeof(NecroLime), 13);
            Add(typeof(PirateGrapes), 25);
            Add(typeof(RangerGrapes), 15);
            Add(typeof(RogueLemon), 3);
            Add(typeof(SageMelon), 4);
            Add(typeof(ScribeLemon), 2);
            Add(typeof(ShepherdLime), 2);
            Add(typeof(SmithMelon), 2);
            Add(typeof(TacticBerry), 2);
            Add(typeof(TailorPeach), 2);
            Add(typeof(ThiefOrange), 2);
            Add(typeof(TinkerApple), 13);
            Add(typeof(WarriorPeach), 25);
            Add(typeof(WoodworkerApple), 25);
        }
    }
}
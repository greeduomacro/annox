using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Menus;
using Server.Menus.Questions;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Prompts;
using Server.Accounting;
using Server.Regions;
using Server.Commands;

namespace Server.Gumps
{
    public class SilverSupplyStoneGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("SilverSupplyStoneGump", AccessLevel.GameMaster, new CommandEventHandler(SilverSupplyStoneGump_OnCommand));
        }

        private static void SilverSupplyStoneGump_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new SilverSupplyStoneGump(e.Mobile));
        }

        public SilverSupplyStoneGump(Mobile owner)
            : base(50, 50)
        {

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            AddPage(0);
            AddBackground(7, 7, 284, 289, 2620);
            AddBackground(14, 16, 270, 23, 9350);
            AddBackground(15, 46, 269, 240, 9350);
            AddLabel(21, 17, 195, @"Supply Stone");
            AddLabel(244, 17, 232, @"v. 1.0");
            AddLabel(21, 65, 60, @"Magery reagents (500sp)");
            AddButton(250, 70, 2361, 2362, 1, GumpButtonType.Reply, 0);
            AddLabel(21, 90, 60, @"Necromancery reagents (500sp)");
            AddButton(250, 95, 2361, 2362, 2, GumpButtonType.Reply, 0);
            AddLabel(21, 115, 60, @"Bag of bandages (150sp)");
            AddButton(250, 120, 2361, 2362, 3, GumpButtonType.Reply, 0);
            AddLabel(21, 140, 60, @"Bag of weapons (200sp)");
            AddButton(250, 145, 2361, 2362, 4, GumpButtonType.Reply, 0);
            AddLabel(21, 165, 60, @"Bag of armors (200sp)");
            AddButton(250, 170, 2361, 2362, 5, GumpButtonType.Reply, 0);
            AddLabel(21, 190, 60, @"Bag of clothing (100sp)");
            AddButton(250, 195, 2361, 2362, 6, GumpButtonType.Reply, 0);
            AddLabel(21, 215, 60, @"Bag of tools (50sp)");
            AddButton(250, 220, 2361, 2362, 7, GumpButtonType.Reply, 0);
            AddImage(259, -16, 10410);
            AddImage(259, 230, 10412);
            AddButton(180, 255, 1276, 1274, 8, GumpButtonType.Reply, 0);

        }

        public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0
                    {
                        //Cancel 
                        from.SendMessage(33, "You decide you dont need anything.");
                        break;
                    }
                case 1: //Magery Reagents
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 500))
                        {
                            BagOfReagents BagOfReagents = new BagOfReagents();
                            from.AddToBackpack(BagOfReagents);
                            from.SendMessage(33, "You bought Bag of Reagents and that costs 500 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the coinage needed.");
                        }
                        break;
                    }
                case 2: //Necro Reagents
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 500))
                        {
                            BagOfNecroReagents BagOfNecroReagents = new BagOfNecroReagents();
                            from.AddToBackpack(BagOfNecroReagents);
                            from.SendMessage(33, "You bought Bag of Necromancer Reagents and that costs 500 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the coinage needed.");
                        }
                        break;
                    }
                case 3: //Bandages
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 150))
                        {
                            BagOfBandages BagOfBandages = new BagOfBandages();
                            from.AddToBackpack(BagOfBandages);
                            from.SendMessage(33, "You bought Bag of Bandages and that costs 150 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the silver coinage needed.");
                        }
                        break;
                    }
                case 4: //Weapons
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 200))
                        {
                            BagOfWeapons BagOfWeapons = new BagOfWeapons();
                            from.AddToBackpack(BagOfWeapons);
                            from.SendMessage(33, "You bought Bag of Weapons and that costs 200 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the coinage needed.");
                        }
                        break;
                    }
                case 5: //Armors
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 200))
                        {
                            BagOfArmors BagOfArmors = new BagOfArmors();
                            from.AddToBackpack(BagOfArmors);
                            from.SendMessage(33, "You bought Bag of Armors and that costs 200 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the coinage needed.");
                        }
                        break;
                    }
                case 6: //Necro Reagents
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 100))
                        {
                            BagOfClothing BagOfClothing = new BagOfClothing();
                            from.AddToBackpack(BagOfClothing);
                            from.SendMessage(33, "You bought Bag of Clothing and that costs 100 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the coinage needed.");
                        }
                        break;
                    }
                case 7: //Necro Reagents
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 500))
                        {
                            BagOfTools BagOfTools = new BagOfTools();
                            from.AddToBackpack(BagOfTools);
                            from.SendMessage(33, "You bought Bag of Tools and that costs 50 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the coinage needed.");
                        }
                        break;
                    }
                case 8: //Hair Restyling
                    {
                        Item[] Silver = from.Backpack.FindItemsByType(typeof(Factions.Silver));
                        if (from.Backpack.ConsumeTotal(typeof(Factions.Silver), 150))
                        {
                            HairRestylingDeed HairRestylingDeed = new HairRestylingDeed();
                            from.AddToBackpack(HairRestylingDeed);
                            from.SendMessage(33, "You bought Hair Restyling Deed and that costs 150 coins");
                        }
                        else
                        {
                            from.SendMessage(33, "You are short the coinage needed.");
                        }
                        break;
                    }
            }
        }
    }
}
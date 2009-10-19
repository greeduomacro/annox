//06FEB2008 Removed Daat Token Section
//06FEB2008 Set currency to Silver
//07FEB2008 Random Price
using System;
using System.IO;
using System.Collections;
using Server.Items;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Targets;

namespace Server.Mobiles
{
    public class TokenVendorType
    {
        public static Type GetType(string name)
        {
            return ScriptCompiler.FindTypeByName(name);
        }
    }
}

namespace Server.Items
{
    public class SilverVendorStone : Item
    {
        private bool m_Blessed;
        private bool m_Bonded;
        private bool m_Hued;
        private int m_BlessedPrice;
        private int m_BondedPrice;
        private int m_HuedPrice;
        private AccessLevel m_AccessLevel;
        private bool m_EditMode;

        private string m_Currency;

        private ArrayList m_Price = new ArrayList();

        private ArrayList m_Item = new ArrayList();

        private ArrayList m_GumpName = new ArrayList();

        private ArrayList m_ItemAmount = new ArrayList();

        private ArrayList m_HueList = new ArrayList();

        private ArrayList m_HuePrices = new ArrayList();

        private bool m_CustomHues;


        public bool Blessed { get { return m_Blessed; } set { m_Blessed = value; } }
        public bool Bonded { get { return m_Bonded; } set { m_Bonded = value; } }
        public bool Hued { get { return m_Hued; } set { m_Hued = value; } }
        public int BlessedPrice { get { return m_BlessedPrice; } set { m_BlessedPrice = value; } }
        public int BondedPrice { get { return m_BondedPrice; } set { m_BondedPrice = value; } }
        public int HuedPrice { get { return m_HuedPrice; } set { m_HuedPrice = value; } }

        public string Currency { get { return m_Currency; } set { m_Currency = value; } }


        public ArrayList Price { get { return m_Price; } set { m_Price = value; } }

        public ArrayList Item { get { return m_Item; } set { m_Item = value; } }

        public ArrayList GumpName { get { return m_GumpName; } set { m_GumpName = value; } }

        public ArrayList ItemAmount { get { return m_ItemAmount; } set { m_ItemAmount = value; } }

        public ArrayList HueList { get { return m_HueList; } set { m_HueList = value; } }

        public ArrayList HuePrices { get { return m_HuePrices; } set { m_HuePrices = value; } }

        public bool CustomHues { get { return m_CustomHues; } set { m_CustomHues = value; } }

        public AccessLevel AccessLevel { get { return m_AccessLevel; } set { m_AccessLevel = value; } }

        public bool EditMode { get { return m_EditMode; } set { m_EditMode = value; } }

        [Constructable]
        public SilverVendorStone()
            : base(3806)
        {
            Movable = false;
            Hue = 1000;
            Name = "Silver Vendor Stone";
            //06FEB2008 Set currency to Silver *** START ***
            Currency = "Silver";
            //06FEB2008 Set currency to Silver *** END   ***
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.AccessLevel >= AccessLevel.Seer)
            {
                from.SendGump(new StaffTokenGump(from, this));
            }
            else
            {
                Hued = false;
                Blessed = false;
                Bonded = false;
                from.SendGump(new TokenGump(from, this));
            }
        }

        public SilverVendorStone(Serial serial)
            : base(serial)
        {
        }

        public static void RemoveHue(SilverVendorStone stone, int hue, int hueprice)
        {
            if (stone.HueList.Contains(hue))
                stone.HueList.Remove(hue);
            if (stone.HuePrices.Contains(hueprice))
                stone.HuePrices.Remove(hueprice);
        }
        public static void RemoveItem(SilverVendorStone stone, string item, string gumpname, int price, int amount)
        {
            if (stone.Item.Contains(item))

                if (stone.Item.Contains(item))
                    stone.Item.Remove(item);
            if (stone.GumpName.Contains(gumpname))
                stone.GumpName.Remove(gumpname);
            if (stone.Price.Contains(price))
                stone.Price.Remove(price);
            if (stone.ItemAmount.Contains(amount))
                stone.ItemAmount.Remove(amount);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version 
            writer.Write((bool)m_CustomHues);
            writer.Write((bool)m_Blessed);
            writer.Write((bool)m_Bonded);
            writer.Write((bool)m_Hued);
            writer.Write((int)m_BlessedPrice);
            writer.Write((int)m_BondedPrice);
            writer.Write((int)m_HuedPrice);
            writer.Write((int)m_AccessLevel);
            writer.Write((string)m_Currency);
            writer.Write((bool)m_EditMode);

            writer.Write(m_Price.Count);
            for (int i = 0; i < m_Price.Count; ++i)
                writer.Write((int)m_Price[i]);

            writer.Write(m_HueList.Count);
            for (int i = 0; i < m_HueList.Count; ++i)
                writer.Write((int)m_HueList[i]);

            writer.Write(m_ItemAmount.Count);
            for (int i = 0; i < m_ItemAmount.Count; ++i)
                writer.Write((int)m_ItemAmount[i]);

            writer.Write(m_Item.Count);
            for (int i = 0; i < m_Item.Count; ++i)
                writer.Write((string)m_Item[i]);

            writer.Write(m_GumpName.Count);
            for (int i = 0; i < m_GumpName.Count; ++i)
                writer.Write((string)m_GumpName[i]);

            writer.Write(m_HuePrices.Count);
            for (int i = 0; i < m_HuePrices.Count; ++i)
                writer.Write((int)m_HuePrices[i]);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_CustomHues = reader.ReadBool();
            m_Blessed = reader.ReadBool();
            m_Bonded = reader.ReadBool();
            m_Hued = reader.ReadBool();
            m_BlessedPrice = reader.ReadInt();
            m_BondedPrice = reader.ReadInt();
            m_HuedPrice = reader.ReadInt();
            m_AccessLevel = (AccessLevel)reader.ReadInt();
            m_Currency = reader.ReadString();
            m_EditMode = reader.ReadBool();

            int size1 = reader.ReadInt();
            m_Price = new ArrayList(size1);
            for (int i = 0; i < size1; ++i)
            {
                int price = reader.ReadInt();
                m_Price.Add(price);
            }

            int size4 = reader.ReadInt();
            m_HueList = new ArrayList(size4);
            for (int i = 0; i < size4; ++i)
            {
                int hue = reader.ReadInt();
                m_HueList.Add(hue);
            }

            int size5 = reader.ReadInt();
            m_ItemAmount = new ArrayList(size5);
            for (int i = 0; i < size5; ++i)
            {
                int itemamount = reader.ReadInt();
                m_ItemAmount.Add(itemamount);
            }

            int size2 = reader.ReadInt();
            m_Item = new ArrayList(size2);
            for (int i = 0; i < size2; ++i)
            {
                string item = reader.ReadString();
                m_Item.Add(item);
            }

            int size3 = reader.ReadInt();
            m_GumpName = new ArrayList(size3);
            for (int i = 0; i < size3; ++i)
            {
                string gumpname = reader.ReadString();
                m_GumpName.Add(gumpname);
            }

            int size6 = reader.ReadInt();
            m_HuePrices = new ArrayList(size6);
            for (int i = 0; i < size6; ++i)
            {
                int hueprices = reader.ReadInt();
                m_HuePrices.Add(hueprices);
            }
        }
    }
}

namespace Server.Gumps
{
    public class TokenGump : Gump
    {
        private SilverVendorStone m_Stone;
        private ArrayList m_SubmitData;

        protected ArrayList SubmitData { get { return m_SubmitData; } }

        private const int AmountPerPage = 20;

        public TokenGump(Mobile from, SilverVendorStone stone)
            : base(25, 25)
        {
            m_Stone = stone;

            m_SubmitData = new ArrayList();

            AddPage(0);

            from.CloseGump(typeof(TokenGump));

            if (m_SubmitData.Count == 0)
            {
                m_SubmitData.Add(m_Stone.Hued);
                m_SubmitData.Add(m_Stone.Blessed);
                m_SubmitData.Add(m_Stone.Bonded);
            }

            AddBackground(0, 0, 530, 480, 5054);
            AddAlphaRegion(10, 10, 510, 460);

            AddImageTiled(10, 40, 510, 5, 2624);
            AddImageTiled(400, 40, 5, 430, 2624);
            AddImageTiled(90, 40, 5, 430, 2624);
            AddImageTiled(310, 40, 5, 430, 2624);
            AddImageTiled(10, 58, 390, 5, 2624);

            AddImageTiled(400, 100, 120, 3, 2624);
            AddImageTiled(400, 123, 120, 3, 2624);
            AddImageTiled(400, 146, 120, 3, 2624);
            AddImageTiled(400, 169, 120, 3, 2624);

            if (m_Stone.Name != null && m_Stone.Name != "")
            {
                AddLabel(235, 20, 1152, m_Stone.Name);
            }
            else
            {
                AddLabel(235, 20, 1152, "!STONE NAME GOES HERE!");
            }

            AddLabel(420, 60, 5, "Stone Currency:");
            if (m_Stone.Currency != null)
            {
                AddLabel(420, 80, 5, m_Stone.Currency);
            }
            else
            {
                AddLabel(420, 80, 33, "None");
            }

            if (!m_Stone.CustomHues)
            {
                if (m_Stone.HuedPrice > 0)
                {
                    AddCheck(405, 103, 0x2342, 0x2343, (bool)m_SubmitData[0], 1);
                    AddLabel(430, 100, 1152, "Hue: " + m_Stone.HuedPrice);
                }
            }
            else
            {
                AddCheck(405, 103, 0x2342, 0x2343, (bool)m_SubmitData[0], 1);
                AddLabel(430, 100, 1152, "Custom Hues");
            }
            if (m_Stone.BlessedPrice > 0)
            {
                AddCheck(405, 126, 0x2342, 0x2343, (bool)m_SubmitData[1], 2);
                AddLabel(430, 123, 1152, "Bless: " + m_Stone.BlessedPrice);
            }
            if (m_Stone.BondedPrice > 0)
            {
                AddCheck(405, 149, 0x2342, 0x2343, (bool)m_SubmitData[2], 3);
                AddLabel(430, 146, 1152, "Bond: " + m_Stone.BondedPrice);
            }

            AddLabel(15, 42, 1152, "Item Amount");
            AddLabel(170, 42, 1152, "Item");
            AddLabel(340, 42, 1152, "Price");

            AddLabel(420, 400, 906, "Created By");
            AddLabel(420, 420, 906, "~Raelis~");

            AddButton(420, 440, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(450, 440, 33, "Close");

            int index = 0;
            int page = 1;

            AddPage(1);

            for (int i = 0; i < m_Stone.Item.Count; ++i)
            {
                if (index >= AmountPerPage)
                {
                    AddButton(420, 365, 0x1196, 0x1196, 1152, GumpButtonType.Page, page + 1);
                    AddLabel(420, 350, 1152, "Next page");

                    ++page;
                    index = 0;

                    AddPage(page);

                    AddButton(420, 315, 0x119a, 0x119a, 1152, GumpButtonType.Page, page - 1);
                    AddLabel(420, 300, 1152, "Previous page");
                }

                int price = (int)m_Stone.Price[i];
                int amount = (int)m_Stone.ItemAmount[i];
                string gumpname = m_Stone.GumpName[i].ToString();

                AddLabel(130, 60 + (index * 20), 1152, gumpname);
                AddLabel(25, 60 + (index * 20), 1152, "" + amount);
                AddLabel(320, 60 + (index * 20), 1152, "" + price);

                AddButton(100, 60 + (index * 20), 4005, 4007, i + 1, GumpButtonType.Reply, 0);

                AddImageTiled(10, 80 + (index * 20), 390, 3, 2624);

                index++;
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (m_Stone.Deleted)
                return;

            m_SubmitData[0] = info.IsSwitched(1);
            m_SubmitData[1] = info.IsSwitched(2);
            m_SubmitData[2] = info.IsSwitched(3);

            m_Stone.Hued = (bool)m_SubmitData[0];
            m_Stone.Blessed = (bool)m_SubmitData[1];
            m_Stone.Bonded = (bool)m_SubmitData[2];

            if (info.ButtonID == 0)
            {
                from.SendMessage("You decide not to buy anything.");
            }

            if (info.ButtonID >= 1)
            {
                if (!m_Stone.EditMode)
                {
                    try
                    {
                        Type currency = TokenVendorType.GetType(m_Stone.Currency);

                        //06FEB2008 Removed Daat Token Section *** START ***
                        //if (m_Stone.Currency == "daat99tokens")
                        //{
                        //    Item[] items = from.Backpack.FindItemsByType(typeof(TokenLedger));

                        //    foreach (TokenLedger tl in items)
                        //    {
                        //        if (tl.Owner == from.Serial)
                        //        {
                        //            int i_price = (int)m_Stone.Price[(info.ButtonID - 1)];
                        //            if (i_price <= tl.Tokens)
                        //            {
                        //                tl.Tokens = (tl.Tokens - i_price);
                        //                try
                        //                {
                        //                    Type type = TokenVendorType.GetType(m_Stone.Item[(info.ButtonID - 1)].ToString());
                        //                    if (type != null)
                        //                    {
                        //                        try
                        //                        {
                        //                            object o = Activator.CreateInstance(type);

                        //                            if (o is Mobile)
                        //                            {
                        //                                Mobile m = (Mobile)o;

                        //                                m.Map = from.Map;
                        //                                m.Location = from.Location;
                        //                                if (m is BaseCreature)
                        //                                {
                        //                                    BaseCreature c = (BaseCreature)m;
                        //                                    c.ControlMaster = from;
                        //                                    c.Controlled = true;
                        //                                    c.ControlOrder = OrderType.Follow;
                        //                                    c.ControlTarget = from;

                        //                                    if (m_Stone.Bonded == true)
                        //                                    {

                        //                                        if ((int)m_Stone.BondedPrice <= tl.Tokens)
                        //                                        {
                        //                                            tl.Tokens = (tl.Tokens - (int)m_Stone.BondedPrice);
                        //                                            c.IsBonded = true;
                        //                                        }
                        //                                        else
                        //                                        {
                        //                                            if (m_Stone.Currency != null)
                        //                                                from.SendMessage("You do not have enough tokens in your ledger to bond the creature.");
                        //                                            else
                        //                                                from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
                        //                                        }
                        //                                    }
                        //                                    if (m_Stone.Hued == true)
                        //                                    {
                        //                                        if (!m_Stone.CustomHues)
                        //                                        {
                        //                                            if ((int)m_Stone.HuedPrice <= tl.Tokens)
                        //                                            {
                        //                                                tl.Tokens = (tl.Tokens - (int)m_Stone.HuedPrice);
                        //                                                from.SendHuePicker(new CreatureHuePicker(c, this));
                        //                                            }
                        //                                            else
                        //                                            {
                        //                                                if (m_Stone.Currency != null)
                        //                                                    from.SendMessage("You do not have enough tokens in your ledger to hue the creature.");
                        //                                                else
                        //                                                    from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
                        //                                            }
                        //                                        }
                        //                                        else
                        //                                        {
                        //                                            from.SendGump(new SilverVendorStoneMobileHueGump(from, m_Stone, c, (string)m_Stone.GumpName[(info.ButtonID - 1)]));
                        //                                        }
                        //                                    }
                        //                                    if (c.Name != null)
                        //                                        from.SendMessage("You have bought " + c.Name + ".");
                        //                                    else
                        //                                        from.SendMessage("You have bought a creature");
                        //                                    from.SendMessage("You have {0} Tokens left in your token ledger", tl.Tokens);
                        //                                }
                        //                                return;
                        //                            }
                        //                            if (o is Item)
                        //                            {
                        //                                Item item = (Item)o;
                        //                                if ((int)m_Stone.ItemAmount[(info.ButtonID - 1)] != 0)
                        //                                    if (item.Stackable)
                        //                                        item.Amount = (int)m_Stone.ItemAmount[(info.ButtonID - 1)];
                        //                                if (m_Stone.Blessed == true)
                        //                                {
                        //                                    if (item.LootType == LootType.Blessed)
                        //                                    {
                        //                                        m_Stone.Blessed = false;
                        //                                        m_Stone.Bonded = false;

                        //                                        from.SendMessage("This item already comes blessed.");
                        //                                    }
                        //                                    else if (item.LootType == LootType.Cursed)
                        //                                    {
                        //                                        from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
                        //                                    }
                        //                                    else if ((int)m_Stone.BlessedPrice <= tl.Tokens)
                        //                                    {
                        //                                        tl.Tokens = (tl.Tokens - (int)m_Stone.BlessedPrice);
                        //                                        item.LootType = LootType.Blessed;
                        //                                    }
                        //                                    else
                        //                                    {
                        //                                        if (m_Stone.Currency != null)
                        //                                            from.SendMessage("You do not have enough tokens in your ledger to bless the item.");
                        //                                        else
                        //                                            from.SendMessage("You do not have enough of this stone's currency to bless the item.");
                        //                                    }
                        //                                }
                        //                                if (m_Stone.Hued == true)
                        //                                {
                        //                                    if (!m_Stone.CustomHues)
                        //                                    {
                        //                                        if ((int)m_Stone.HuedPrice <= tl.Tokens)
                        //                                        {
                        //                                            tl.Tokens = (tl.Tokens - (int)m_Stone.HuedPrice);
                        //                                            from.SendHuePicker(new ItemHuePicker(item, this));
                        //                                        }
                        //                                        else
                        //                                        {
                        //                                            if (m_Stone.Currency != null)
                        //                                                from.SendMessage("You do not have enough tokens in your ledger to hue the item.");
                        //                                            else
                        //                                                from.SendMessage("You do not have enough of this stone's currency to hue the item.");
                        //                                        }
                        //                                    }
                        //                                    else
                        //                                    {
                        //                                        from.SendGump(new SilverVendorStoneItemHueGump(from, m_Stone, item, (string)m_Stone.GumpName[(info.ButtonID - 1)]));
                        //                                    }
                        //                                }
                        //                                from.AddToBackpack(item);

                        //                                if (item.Name != null)
                        //                                    from.SendMessage("You have bought " + item.Name + ".");
                        //                                else
                        //                                    from.SendMessage("You have bought an item.");
                        //                                from.SendMessage("You have {0} Tokens left in your token ledger", tl.Tokens);
                        //                                return;
                        //                            }
                        //                        }
                        //                        catch
                        //                        {
                        //                            from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
                        //                        }
                        //                    }
                        //                }
                        //                catch
                        //                {
                        //                    from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
                        //                }
                        //            }
                        //        }
                        //    }
                        //    from.SendMessage("Please make sure you have enough tokens in the ledger that belong to you and that it is in your backpack.");
                        //}
                        //else
                        //06FEB2008 Removed Daat Token Section *** END   ***

                        if (currency != null)
                        {
                            if (from.Backpack.ConsumeTotal(currency, (int)m_Stone.Price[(info.ButtonID - 1)], true))
                            {
                                try
                                {
                                    Type type = TokenVendorType.GetType(m_Stone.Item[(info.ButtonID - 1)].ToString());
                                    if (type != null)
                                    {
                                        try
                                        {
                                            object o = Activator.CreateInstance(type);

                                            if (o is Mobile)
                                            {
                                                Mobile m = (Mobile)o;

                                                m.Map = from.Map;
                                                m.Location = from.Location;
                                                if (m is BaseCreature)
                                                {
                                                    BaseCreature c = (BaseCreature)m;
                                                    c.ControlMaster = from;
                                                    c.Controlled = true;
                                                    c.ControlOrder = OrderType.Follow;
                                                    c.ControlTarget = from;

                                                    if (c.Name != null)
                                                        from.SendMessage("You have bought " + c.Name + ".");
                                                    else
                                                        from.SendMessage("You have bought a creature");
                                                    if (m_Stone.Bonded == true)
                                                    {
                                                        if (from.Backpack.ConsumeTotal(currency, m_Stone.BondedPrice, true))
                                                        {
                                                            c.IsBonded = true;
                                                        }
                                                        else
                                                        {
                                                            if (m_Stone.Currency != null)
                                                                from.SendMessage("You do not have enough " + m_Stone.Currency + " to bond the creature.");
                                                            else
                                                                from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
                                                        }
                                                    }
                                                    if (m_Stone.Hued == true)
                                                    {
                                                        if (!m_Stone.CustomHues)
                                                        {
                                                            if (from.Backpack.ConsumeTotal(currency, m_Stone.HuedPrice, true))
                                                            {
                                                                from.SendHuePicker(new CreatureHuePicker(c, this));
                                                            }
                                                            else
                                                            {
                                                                if (m_Stone.Currency != null)
                                                                    from.SendMessage("You do not have enough " + m_Stone.Currency + " to hue the creature.");
                                                                else
                                                                    from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            from.SendGump(new SilverVendorStoneMobileHueGump(from, m_Stone, c, (string)m_Stone.GumpName[(info.ButtonID - 1)]));
                                                        }
                                                    }
                                                }
                                            }
                                            if (o is Item)
                                            {
                                                Item item = (Item)o;
                                                if ((int)m_Stone.ItemAmount[(info.ButtonID - 1)] != 0)
                                                    if (item.Stackable)
                                                        item.Amount = (int)m_Stone.ItemAmount[(info.ButtonID - 1)];
                                                if (m_Stone.Blessed == true)
                                                {
                                                    if (item.LootType == LootType.Blessed)
                                                    {
                                                        m_Stone.Blessed = false;
                                                        m_Stone.Bonded = false;

                                                        from.SendMessage("This item already comes blessed.");
                                                    }
                                                    else if (item.LootType == LootType.Cursed)
                                                    {
                                                        from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
                                                    }
                                                    else if (from.Backpack.ConsumeTotal(currency, m_Stone.BlessedPrice, true))
                                                    {
                                                        item.LootType = LootType.Blessed;
                                                    }
                                                    else
                                                    {
                                                        if (m_Stone.Currency != null)
                                                            from.SendMessage("You do not have enough " + m_Stone.Currency + " to bless the item.");
                                                        else
                                                            from.SendMessage("You do not have enough of this stone's currency to bless the item.");
                                                    }
                                                }
                                                if (m_Stone.Hued == true)
                                                {
                                                    if (!m_Stone.CustomHues)
                                                    {
                                                        if (from.Backpack.ConsumeTotal(currency, m_Stone.HuedPrice, true))
                                                        {
                                                            from.SendHuePicker(new ItemHuePicker(item, this));
                                                        }
                                                        else
                                                        {
                                                            if (m_Stone.Currency != null)
                                                                from.SendMessage("You do not have enough " + m_Stone.Currency + " to hue the item.");
                                                            else
                                                                from.SendMessage("You do not have enough of this stone's currency to hue the item.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        from.SendGump(new SilverVendorStoneItemHueGump(from, m_Stone, item, (string)m_Stone.GumpName[(info.ButtonID - 1)]));
                                                    }
                                                }

                                                from.Backpack.DropItem(item);

                                                if (item.Name != null)
                                                    from.SendMessage("You have bought " + item.Name + ".");
                                                else
                                                    from.SendMessage("You have bought an item.");
                                            }
                                        }
                                        catch
                                        {
                                            from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
                                        }
                                    }
                                }
                                catch
                                {
                                    from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
                                }
                            }
                            else if (from.BankBox.ConsumeTotal(currency, (int)m_Stone.Price[(info.ButtonID - 1)], true))
                            {
                                try
                                {
                                    Type type = TokenVendorType.GetType(m_Stone.Item[(info.ButtonID - 1)].ToString());
                                    if (type != null)
                                    {
                                        try
                                        {
                                            object o = Activator.CreateInstance(type);

                                            if (o is Mobile)
                                            {
                                                Mobile m = (Mobile)o;

                                                m.Map = from.Map;
                                                m.Location = from.Location;
                                                if (m is BaseCreature)
                                                {
                                                    BaseCreature c = (BaseCreature)m;
                                                    c.ControlMaster = from;
                                                    c.Controlled = true;
                                                    c.ControlOrder = OrderType.Follow;
                                                    c.ControlTarget = from;

                                                    if (c.Name != null)
                                                        from.SendMessage("You have bought " + c.Name + ".");
                                                    else
                                                        from.SendMessage("You have bought a creature");
                                                    if (m_Stone.Bonded == true)
                                                    {
                                                        if (from.Backpack.ConsumeTotal(currency, m_Stone.BondedPrice, true))
                                                        {
                                                            c.IsBonded = true;
                                                        }
                                                        else
                                                        {
                                                            if (m_Stone.Currency != null)
                                                                from.SendMessage("You do not have enough " + m_Stone.Currency + " to bond the creature.");
                                                            else
                                                                from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
                                                        }
                                                    }
                                                    if (m_Stone.Hued == true)
                                                    {
                                                        if (from.Backpack.ConsumeTotal(currency, m_Stone.HuedPrice, true))
                                                        {
                                                            if (m_Stone.CustomHues)
                                                                from.SendGump(new SilverVendorStoneMobileHueGump(from, m_Stone, c, (string)m_Stone.GumpName[(info.ButtonID - 1)]));
                                                            else
                                                                from.SendHuePicker(new CreatureHuePicker(c, this));
                                                        }
                                                        else
                                                        {
                                                            if (m_Stone.Currency != null)
                                                                from.SendMessage("You do not have enough " + m_Stone.Currency + " to hue the creature.");
                                                            else
                                                                from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
                                                        }
                                                    }
                                                }
                                            }
                                            if (o is Item)
                                            {
                                                Item item = (Item)o;
                                                if ((int)m_Stone.ItemAmount[(info.ButtonID - 1)] != 0)
                                                    if (item.Stackable)
                                                        item.Amount = (int)m_Stone.ItemAmount[(info.ButtonID - 1)];
                                                if (m_Stone.Blessed == true)
                                                {
                                                    if (item.LootType == LootType.Blessed)
                                                    {
                                                        m_Stone.Blessed = false;
                                                        m_Stone.Bonded = false;

                                                        from.SendMessage("This item already comes blessed.");
                                                    }
                                                    else if (item.LootType == LootType.Cursed)
                                                    {
                                                        m_Stone.Blessed = false;
                                                        m_Stone.Bonded = false;

                                                        from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
                                                    }
                                                    else if (from.Backpack.ConsumeTotal(currency, m_Stone.BlessedPrice, true))
                                                    {
                                                        item.LootType = LootType.Blessed;
                                                    }
                                                    else
                                                    {
                                                        if (m_Stone.Currency != null)
                                                            from.SendMessage("You do not have enough " + m_Stone.Currency + " to bless the item.");
                                                        else
                                                            from.SendMessage("You do not have enough of this stone's currency to bless the item.");
                                                    }
                                                }
                                                if (m_Stone.Hued == true)
                                                {
                                                    if (from.Backpack.ConsumeTotal(currency, m_Stone.HuedPrice, true))
                                                    {
                                                        if (m_Stone.CustomHues)
                                                            from.SendGump(new SilverVendorStoneItemHueGump(from, m_Stone, item, (string)m_Stone.GumpName[(info.ButtonID - 1)]));
                                                        else
                                                            from.SendHuePicker(new ItemHuePicker(item, this));
                                                    }
                                                    else
                                                    {
                                                        if (m_Stone.Currency != null)
                                                            from.SendMessage("You do not have enough " + m_Stone.Currency + " to hue the item.");
                                                        else
                                                            from.SendMessage("You do not have enough of this stone's currency to hue the item.");
                                                    }
                                                }

                                                from.Backpack.DropItem(item);

                                                if (item.Name != null)
                                                    from.SendMessage("You have bought " + item.Name + ".");
                                                else
                                                    from.SendMessage("You have bought an item.");
                                            }
                                        }
                                        catch
                                        {
                                            from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
                                        }
                                    }
                                }
                                catch
                                {
                                    from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
                                }
                            }
                            else
                            {
                                if (m_Stone.Currency != null)
                                {
                                    if (m_Stone.GumpName[(info.ButtonID - 1)] != null)
                                        from.SendMessage("You do not have enough " + m_Stone.Currency + " to buy '" + m_Stone.GumpName[(info.ButtonID - 1)].ToString() + "'.");
                                    else
                                        from.SendMessage("You do not have enough " + m_Stone.Currency + " for that.");
                                }
                                else
                                {
                                    if (m_Stone.GumpName[(info.ButtonID - 1)] != null)
                                        from.SendMessage("You do not have enough of this stone's currency to buy '" + m_Stone.GumpName[(info.ButtonID - 1)].ToString() + "'.");
                                    else
                                        from.SendMessage("You do not have enough of this stone's currency for that.");
                                }
                            }
                        }
                    }
                    catch
                    {
                        if (m_Stone.Currency != "daat99tokens")
                            from.SendMessage("That is not a valid currency.");
                    }
                }
                else
                {
                    SilverVendorStone.RemoveItem(m_Stone, (string)m_Stone.Item[(info.ButtonID - 1)], (string)m_Stone.GumpName[(info.ButtonID - 1)], (int)m_Stone.Price[(info.ButtonID - 1)], (int)m_Stone.ItemAmount[(info.ButtonID - 1)]);
                    from.SendMessage("You remove the item.");
                    from.SendGump(new TokenGump(from, m_Stone));
                }
            }
            m_Stone.Hued = false;
            m_Stone.Blessed = false;
            m_Stone.Bonded = false;
        }
        private class ItemHuePicker : HuePickers.HuePicker
        {
            private Item m_Item;
            private TokenGump m_Gump;

            public ItemHuePicker(Item item, TokenGump gump)
                : base(0x1018)
            {
                m_Item = item;
                m_Gump = gump;
            }

            public override void OnResponse(int hue)
            {
                if (m_Item != null)
                    m_Item.Hue = hue;
            }
        }
        private class CreatureHuePicker : HuePickers.HuePicker
        {
            private BaseCreature m_Creature;
            private TokenGump m_Gump;

            public CreatureHuePicker(BaseCreature creature, TokenGump gump)
                : base(0x1018)
            {
                m_Creature = creature;
                m_Gump = gump;
            }

            public override void OnResponse(int hue)
            {
                if (m_Creature != null)
                    m_Creature.Hue = hue;
            }
        }
    }

    public class SilverVendorStoneAddItemGump : Gump
    {
        private Mobile m_Mobile;
        private SilverVendorStone m_Stone;

        public SilverVendorStoneAddItemGump(Mobile mobile, SilverVendorStone stone)
            : base(25, 50)
        {
            Closable = false;
            Dragable = false;

            m_Mobile = mobile;
            m_Stone = stone;
            
            //07FEB2008 Random Price *** START   ***
            int price = Utility.RandomMinMax(5000, 20000);
            int amount = 1;

            AddPage(0);

            AddBackground(25, 10, 420, 270, 5054);

            AddImageTiled(33, 20, 401, 251, 2624);
            AddAlphaRegion(33, 20, 401, 251);

            AddLabel(125, 40, 1152, "Vendor Stone");

            AddLabel(40, 60, 1152, "Add a Mobile or Item:");
            AddTextEntry(40, 80, 225, 15, 5, 0, "Item Here");
            AddLabel(40, 100, 1152, "Gump Name:");
            AddTextEntry(40, 120, 225, 15, 5, 1, "Name Here");
            AddLabel(40, 140, 1152, "Price:");
            //AddTextEntry(40, 160, 225, 15, 5, 2, "0");
            AddTextEntry(40, 160, 225, 15, 5, 2, "" + price);
            AddLabel(40, 180, 1152, "Item Amount:");
            //AddTextEntry(40, 200, 225, 15, 5, 3, "0");
            AddTextEntry(40, 200, 225, 15, 5, 3, ""+ amount);

            AddButton(40, 230, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(70, 233, 1152, "Back");
            AddButton(120, 230, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(150, 233, 1152, "Apply");
            //07FEB2008 Random Price *** END   ***
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from == null)
                return;

            if (info.ButtonID == 0)
            {
                from.SendGump(new StaffTokenGump(from, m_Stone));
            }
            if (info.ButtonID == 1)
            {
                string item = "";
                string gumpname = "";
                int price = 0;
                int amount = 0;

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }

                try { price = (int)uint.Parse(tr[2]); }
                catch { }
                try { amount = (int)uint.Parse(tr[3]); }
                catch { }
                if (tr[0] != null)
                {
                    item = tr[0];
                }
                if (tr[1] != null)
                {
                    gumpname = tr[1];
                }

                if (item != null && gumpname != null)
                {
                    m_Stone.Item.Add(item);
                    m_Stone.GumpName.Add(gumpname);
                    m_Stone.Price.Add(price);
                    m_Stone.ItemAmount.Add(amount);
                    from.SendMessage("Item Added.");
                }
                else
                {
                    from.SendMessage("You must set a property for each one.");
                }

                from.SendGump(new SilverVendorStoneAddItemGump(from, m_Stone));
            }
        }
    }
    public class SilverVendorStoneAddHueGump : Gump
    {
        private Mobile m_Mobile;
        private SilverVendorStone m_Stone;

        public SilverVendorStoneAddHueGump(Mobile mobile, SilverVendorStone stone)
            : base(25, 50)
        {
            Closable = false;
            Dragable = false;

            m_Mobile = mobile;
            m_Stone = stone;

            AddPage(0);

            AddBackground(25, 10, 420, 200, 5054);

            AddImageTiled(33, 20, 401, 181, 2624);
            AddAlphaRegion(33, 20, 401, 181);

            AddLabel(100, 40, 1152, "Vendor Stone");

            AddLabel(40, 60, 1152, "Add A Hue:");
            AddTextEntry(40, 80, 225, 15, 5, 0, "0");
            AddLabel(40, 100, 1152, "Set Hue Price:");
            AddTextEntry(40, 120, 225, 15, 5, 1, "0");

            AddButton(40, 140, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(70, 143, 1152, "Back");
            AddButton(120, 140, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(150, 143, 1152, "Apply");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from == null)
                return;

            if (info.ButtonID == 0)
            {
                from.SendGump(new StaffTokenGump(from, m_Stone));
            }
            if (info.ButtonID == 1)
            {
                int hue = 0;
                int hueprice = 0;

                string[] tr = new string[2];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }

                try { hue = (int)uint.Parse(tr[0]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[1]); }
                catch { }

                m_Stone.HueList.Add(hue);
                m_Stone.HuePrices.Add(hueprice);

                from.SendGump(new SilverVendorStoneAddHueGump(from, m_Stone));
            }
        }
    }
    public class SilverVendorStoneRemoveHueGump : Gump
    {
        private Mobile m_Mobile;
        private SilverVendorStone m_Stone;

        private struct RemoveInfo
        {
            public int Hue;
            public int HuePrice;
            public bool toRemove;

            public RemoveInfo(int hue, int hueprice, bool remove)
            {
                Hue = hue;
                HuePrice = hueprice;
                toRemove = remove;
            }
            public RemoveInfo(int hue, int hueprice)
            {
                Hue = hue;
                HuePrice = hueprice;
                toRemove = false;
            }
        }
        private RemoveInfo[] m_RemoveList;

        private SilverVendorStoneRemoveHueGump(Mobile from, SilverVendorStone stone, RemoveInfo[] removelist)
            : base(25, 25)
        {
            m_RemoveList = removelist;
        }

        public SilverVendorStoneRemoveHueGump(Mobile mobile, SilverVendorStone stone)
            : base(25, 25)
        {
            m_Stone = stone;

            m_RemoveList = new RemoveInfo[m_Stone.HueList.Count];
            for (int i = 0; i < m_Stone.HueList.Count; i++)
            {
                m_RemoveList[i] = new RemoveInfo((int)m_Stone.HueList[i], (int)m_Stone.HuePrices[i]);
            }

            Closable = false;
            Dragable = false;

            m_Mobile = mobile;

            AddPage(0);

            AddBackground(25, 10, 220, 490, 5054);

            AddImageTiled(33, 20, 200, 470, 2624);
            AddAlphaRegion(33, 20, 200, 470);

            AddLabel(100, 40, 1152, "Vendor Stone Hues");

            AddButton(170, 380, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(170, 363, 1152, "Back");
            AddButton(170, 450, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(170, 403, 1152, "Remove");
            AddLabel(170, 418, 1152, "Selected");
            AddLabel(170, 433, 1152, "Hues");

            for (int i = 0; i < m_Stone.HueList.Count; ++i)
            {
                if ((i % 20) == 0)
                {
                    if (i != 0)
                    {
                        AddButton(170, 315, 0x1196, 0x1196, 1152, GumpButtonType.Page, (i / 20) + 1);
                        AddLabel(170, 300, 1152, "Next page");
                    }

                    AddPage((i / 20) + 1);

                    if (i != 0)
                    {
                        AddButton(170, 275, 0x119a, 0x119a, 1152, GumpButtonType.Page, (i / 20));
                        AddLabel(170, 260, 1152, "Previous page");
                    }
                }

                int hue = (int)m_Stone.HueList[i];
                int price = (int)m_Stone.HuePrices[i];

                AddLabel(70, 60 + ((i % 20) * 20), hue - 1, "" + hue);
                AddLabel(120, 60 + ((i % 20) * 20), 1152, "" + price);
                AddCheck(40, 60 + ((i % 20) * 20), 0x2342, 0x2343, m_RemoveList[i].toRemove, i);
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from == null)
                return;

            for (int i = 0; i < m_Stone.HueList.Count; i++)
            {
                if (i >= m_RemoveList.Length) break;
                m_RemoveList[i].toRemove = info.IsSwitched(i);
            }

            if (info.ButtonID == 0)
            {
                from.SendGump(new StaffTokenGump(from, m_Stone));
            }
            if (info.ButtonID == 1)
            {
                int removed = 0;
                for (int i = 0; i < m_RemoveList.Length; i++)
                    if (m_RemoveList[i].toRemove)
                    {
                        SilverVendorStone.RemoveHue(m_Stone, m_RemoveList[i].Hue, m_RemoveList[i].HuePrice);

                        removed += 1;
                    }
                from.SendMessage("{0} hues have been removed.", removed);
                from.SendGump(new SilverVendorStoneRemoveHueGump(from, m_Stone));
            }
        }
    }
    public class SilverVendorStoneItemHueGump : Gump
    {
        private Mobile m_Mobile;
        private SilverVendorStone m_Stone;
        private Item m_Item;
        private string m_GumpName;

        public SilverVendorStoneItemHueGump(Mobile mobile, SilverVendorStone stone, Item item, string gumpname)
            : base(25, 50)
        {
            Closable = false;

            m_Mobile = mobile;
            m_Stone = stone;
            m_Item = item;
            m_GumpName = gumpname;

            AddPage(0);

            AddBackground(25, 10, 220, 480, 5054);

            AddImageTiled(33, 20, 200, 460, 2624);
            AddAlphaRegion(33, 20, 200, 460);

            AddLabel(40, 40, 1152, "Hue Item: " + m_GumpName);

            AddButton(170, 420, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(200, 420, 1152, "Hue");
            AddButton(170, 400, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(200, 400, 33, "Close");

            for (int i = 0; i < m_Stone.HueList.Count; ++i)
            {
                if ((i % 20) == 0)
                {
                    if (i != 0)
                    {
                        AddButton(120, 400, 0x1196, 0x1196, 1152, GumpButtonType.Page, (i / 20) + 1);
                        AddLabel(150, 380, 1152, "Next page");
                    }

                    AddPage((i / 20) + 1);

                    if (i != 0)
                    {
                        AddButton(120, 360, 0x119a, 0x119a, 1152, GumpButtonType.Page, (i / 20));
                        AddLabel(150, 340, 1152, "Previous page");
                    }
                }

                int hue = (int)m_Stone.HueList[i];
                int price = (int)m_Stone.HuePrices[i];

                AddLabel(70, 60 + ((i % 20) * 20), hue - 1, "" + hue);
                AddLabel(120, 60 + ((i % 20) * 20), 1152, "" + price);
                AddRadio(40, 60 + ((i % 20) * 20), 210, 211, false, i);
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from == null || m_Item == null)
                return;

            if (info.ButtonID == 0)
            {
                from.SendMessage("Closed.");
            }
            if (info.ButtonID == 1)
            {
                int[] switches = info.Switches;

                if (switches.Length > 0)
                {
                    int index = switches[0];

                    if (index >= 0 && index < m_Stone.HueList.Count)
                    {
                        try
                        {
                            Type currency = TokenVendorType.GetType(m_Stone.Currency);
                            if (currency != null)
                            {
                                if (from.Backpack.ConsumeTotal(currency, (int)m_Stone.HuePrices[index], true))
                                {
                                    int hue = (int)m_Stone.HueList[index];
                                    m_Item.Hue = hue;
                                }
                                else if (from.BankBox.ConsumeTotal(currency, (int)m_Stone.HuePrices[index], true))
                                {
                                    int hue = (int)m_Stone.HueList[index];
                                    m_Item.Hue = hue;
                                }
                                else
                                {
                                    if (m_Stone.Currency != null)
                                        from.SendMessage("You do not have enough " + m_Stone.Currency + " to hue the creature.");
                                    else
                                        from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
                                }
                            }
                        }
                        catch
                        {
                            from.SendMessage("That is not a valid currency.");
                        }
                    }
                }
                else
                    from.SendGump(new SilverVendorStoneItemHueGump(from, m_Stone, m_Item, m_GumpName));
            }
        }
    }
    public class SilverVendorStoneMobileHueGump : Gump
    {
        private Mobile m_From;
        private SilverVendorStone m_Stone;
        private Mobile m_Mobile;
        private string m_GumpName;

        public SilverVendorStoneMobileHueGump(Mobile from, SilverVendorStone stone, Mobile mobile, string gumpname)
            : base(25, 50)
        {
            Closable = false;

            m_From = from;
            m_Stone = stone;
            m_Mobile = mobile;
            m_GumpName = gumpname;

            AddPage(0);

            AddBackground(25, 10, 220, 480, 5054);

            AddImageTiled(33, 20, 200, 460, 2624);
            AddAlphaRegion(33, 20, 200, 460);

            AddLabel(40, 40, 1152, "Hue Mobile: " + m_GumpName);

            AddButton(200, 420, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(200, 420, 1152, "Hue");
            AddButton(170, 400, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(200, 400, 33, "Close");

            for (int i = 0; i < m_Stone.HueList.Count; ++i)
            {
                if ((i % 20) == 0)
                {
                    if (i != 0)
                    {
                        AddButton(120, 380, 0x1196, 0x1196, 1152, GumpButtonType.Page, (i / 20) + 1);
                        AddLabel(150, 360, 1152, "Next page");
                    }

                    AddPage((i / 20) + 1);

                    if (i != 0)
                    {
                        AddButton(120, 340, 0x119a, 0x119a, 1152, GumpButtonType.Page, (i / 20));
                        AddLabel(150, 320, 1152, "Previous page");
                    }
                }

                int hue = (int)m_Stone.HueList[i];
                int price = (int)m_Stone.HuePrices[i];

                AddLabel(70, 60 + ((i % 20) * 20), hue - 1, "" + hue);
                AddLabel(120, 60 + ((i % 20) * 20), 1152, "" + price);
                AddRadio(40, 60 + ((i % 20) * 20), 210, 211, false, i);

                AddButton(40, 60 + ((i % 20) * 20), 4005, 4007, i, GumpButtonType.Reply, 0);
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from == null || m_Mobile == null)
                return;

            if (info.ButtonID == 0)
            {
                from.SendMessage("Closed.");
            }
            if (info.ButtonID == 1)
            {
                int[] switches = info.Switches;

                if (switches.Length > 0)
                {
                    int index = switches[0];

                    if (index >= 0 && index < m_Stone.HueList.Count)
                    {
                        try
                        {
                            Type currency = TokenVendorType.GetType(m_Stone.Currency);
                            if (currency != null)
                            {
                                if (from.Backpack.ConsumeTotal(currency, (int)m_Stone.HuePrices[index], true))
                                {
                                    int hue = (int)m_Stone.HueList[index];
                                    m_Mobile.Hue = hue;
                                }
                                else if (from.BankBox.ConsumeTotal(currency, (int)m_Stone.HuePrices[index], true))
                                {
                                    int hue = (int)m_Stone.HueList[index];
                                    m_Mobile.Hue = hue;
                                }
                                else
                                {
                                    if (m_Stone.Currency != null)
                                        from.SendMessage("You do not have enough " + m_Stone.Currency + " to hue the creature.");
                                    else
                                        from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
                                }
                            }
                        }
                        catch
                        {
                            from.SendMessage("That is not a valid currency.");
                        }
                    }
                }
                else
                    from.SendGump(new SilverVendorStoneMobileHueGump(from, m_Stone, m_Mobile, m_GumpName));
            }
        }
    }
    public class StaffTokenGump : Gump
    {
        private SilverVendorStone m_Stone;

        public StaffTokenGump(Mobile from, SilverVendorStone stone)
            : base(125, 125)
        {
            m_Stone = stone;

            AddPage(0);

            from.CloseGump(typeof(StaffTokenGump));

            AddBackground(0, 0, 160, 260, 5054);

            AddButton(10, 10, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(40, 10, 1152, "Vendor Gump");
            AddButton(10, 30, 4005, 4007, 2, GumpButtonType.Reply, 0);
            AddLabel(40, 30, 1152, "Add Item");
            AddButton(10, 50, 4005, 4007, 3, GumpButtonType.Reply, 0);
            AddLabel(40, 50, 1152, "Add Hues");
            AddButton(10, 70, 4005, 4007, 4, GumpButtonType.Reply, 0);
            AddLabel(40, 70, 1152, "Remove Hues");
            AddButton(10, 90, 4005, 4007, 5, GumpButtonType.Reply, 0);
            if (m_Stone.CustomHues)
                AddLabel(40, 90, 1152, "Use Custom Hues");
            else
                AddLabel(40, 90, 1152, "Use Normal Hues");

            if (from.AccessLevel == AccessLevel.Administrator)
                AddButton(10, 110, 4005, 4007, 6, GumpButtonType.Reply, 0);
            if (m_Stone.AccessLevel == AccessLevel.Administrator)
                AddLabel(40, 110, 1302, "Administrator");
            else if (m_Stone.AccessLevel == AccessLevel.Seer)
                AddLabel(40, 110, 324, "Seer");
            else if (m_Stone.AccessLevel == AccessLevel.GameMaster)
                AddLabel(40, 110, 33, "Game Master");
            else if (m_Stone.AccessLevel == AccessLevel.Counselor)
                AddLabel(40, 110, 2, "Counselor");
            else if (m_Stone.AccessLevel == AccessLevel.Player)
                AddLabel(40, 110, 88, "Player");

            AddButton(10, 130, 4005, 4007, 7, GumpButtonType.Reply, 0);
            if (m_Stone.EditMode)
                AddLabel(40, 130, 5, "Edit Mode");
            else
                AddLabel(40, 130, 33, "Edit Mode");

            AddLabel(10, 150, 1152, "Bless Price:");
            AddTextEntry(85, 150, 225, 15, 1152, 0, "" + m_Stone.BlessedPrice);
            AddLabel(10, 170, 1152, "Bond Price:");
            AddTextEntry(80, 170, 225, 15, 1152, 1, "" + m_Stone.BondedPrice);
            AddLabel(10, 190, 1152, "Hue Price:");
            AddTextEntry(75, 190, 225, 15, 1152, 2, "" + m_Stone.HuedPrice);

            AddLabel(10, 210, 1152, "Currency:");
            AddTextEntry(70, 210, 225, 15, 1152, 3, m_Stone.Currency);

            AddButton(10, 230, 4005, 4007, 0, GumpButtonType.Reply, 0);
            AddLabel(40, 230, 33, "Close");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (m_Stone.Deleted)
                return;

            if (info.ButtonID == 0)
            {
                from.SendMessage("Closed.");
            }
            if (info.ButtonID == 1)
            {
                m_Stone.Hued = false;
                m_Stone.Blessed = false;
                m_Stone.Bonded = false;

                int blessprice = 0;
                int bondprice = 0;
                int hueprice = 0;
                string currency = "";

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }
                if (tr[3] != null)
                {
                    currency = tr[3];
                }

                try { blessprice = (int)uint.Parse(tr[0]); }
                catch { }
                try { bondprice = (int)uint.Parse(tr[1]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[2]); }
                catch { }

                m_Stone.HuedPrice = hueprice;
                m_Stone.BlessedPrice = blessprice;
                m_Stone.BondedPrice = bondprice;
                m_Stone.Currency = currency;

                from.SendGump(new TokenGump(from, m_Stone));
            }
            if (info.ButtonID == 2)
            {
                int blessprice = 0;
                int bondprice = 0;
                int hueprice = 0;
                string currency = "";

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }
                if (tr[3] != null)
                {
                    currency = tr[3];
                }

                try { blessprice = (int)uint.Parse(tr[0]); }
                catch { }
                try { bondprice = (int)uint.Parse(tr[1]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[2]); }
                catch { }

                m_Stone.HuedPrice = hueprice;
                m_Stone.BlessedPrice = blessprice;
                m_Stone.BondedPrice = bondprice;
                m_Stone.Currency = currency;

                from.SendGump(new SilverVendorStoneAddItemGump(from, m_Stone));
            }
            if (info.ButtonID == 3)
            {
                int blessprice = 0;
                int bondprice = 0;
                int hueprice = 0;
                string currency = "";

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }
                if (tr[3] != null)
                {
                    currency = tr[3];
                }

                try { blessprice = (int)uint.Parse(tr[0]); }
                catch { }
                try { bondprice = (int)uint.Parse(tr[1]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[2]); }
                catch { }

                m_Stone.HuedPrice = hueprice;
                m_Stone.BlessedPrice = blessprice;
                m_Stone.BondedPrice = bondprice;
                m_Stone.Currency = currency;

                from.SendGump(new SilverVendorStoneAddHueGump(from, m_Stone));
            }
            if (info.ButtonID == 4)
            {
                int blessprice = 0;
                int bondprice = 0;
                int hueprice = 0;
                string currency = "";

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }
                if (tr[3] != null)
                {
                    currency = tr[3];
                }

                try { blessprice = (int)uint.Parse(tr[0]); }
                catch { }
                try { bondprice = (int)uint.Parse(tr[1]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[2]); }
                catch { }

                m_Stone.HuedPrice = hueprice;
                m_Stone.BlessedPrice = blessprice;
                m_Stone.BondedPrice = bondprice;
                m_Stone.Currency = currency;

                from.SendGump(new SilverVendorStoneRemoveHueGump(from, m_Stone));
            }
            if (info.ButtonID == 5)
            {
                if (m_Stone.CustomHues)
                    m_Stone.CustomHues = false;
                else
                    m_Stone.CustomHues = true;

                int blessprice = 0;
                int bondprice = 0;
                int hueprice = 0;
                string currency = "";

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }
                if (tr[3] != null)
                {
                    currency = tr[3];
                }

                try { blessprice = (int)uint.Parse(tr[0]); }
                catch { }
                try { bondprice = (int)uint.Parse(tr[1]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[2]); }
                catch { }

                m_Stone.HuedPrice = hueprice;
                m_Stone.BlessedPrice = blessprice;
                m_Stone.BondedPrice = bondprice;
                m_Stone.Currency = currency;

                from.SendGump(new StaffTokenGump(from, m_Stone));
            }
            if (info.ButtonID == 6)
            {
                if (m_Stone.AccessLevel == AccessLevel.Administrator)
                    m_Stone.AccessLevel = AccessLevel.Player;
                else if (m_Stone.AccessLevel == AccessLevel.Seer)
                    m_Stone.AccessLevel = AccessLevel.Administrator;
                else if (m_Stone.AccessLevel == AccessLevel.GameMaster)
                    m_Stone.AccessLevel = AccessLevel.Seer;
                else if (m_Stone.AccessLevel == AccessLevel.Counselor)
                    m_Stone.AccessLevel = AccessLevel.GameMaster;
                else if (m_Stone.AccessLevel == AccessLevel.Player)
                    m_Stone.AccessLevel = AccessLevel.Counselor;

                int blessprice = 0;
                int bondprice = 0;
                int hueprice = 0;
                string currency = "";

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }
                if (tr[3] != null)
                {
                    currency = tr[3];
                }

                try { blessprice = (int)uint.Parse(tr[0]); }
                catch { }
                try { bondprice = (int)uint.Parse(tr[1]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[2]); }
                catch { }

                m_Stone.HuedPrice = hueprice;
                m_Stone.BlessedPrice = blessprice;
                m_Stone.BondedPrice = bondprice;
                m_Stone.Currency = currency;

                from.SendGump(new StaffTokenGump(from, m_Stone));
            }
            if (info.ButtonID == 7)
            {
                if (m_Stone.EditMode)
                    m_Stone.EditMode = false;
                else
                    m_Stone.EditMode = true;

                int blessprice = 0;
                int bondprice = 0;
                int hueprice = 0;
                string currency = "";

                string[] tr = new string[4];
                foreach (TextRelay t in info.TextEntries)
                {
                    tr[t.EntryID] = t.Text;
                }
                if (tr[3] != null)
                {
                    currency = tr[3];
                }

                try { blessprice = (int)uint.Parse(tr[0]); }
                catch { }
                try { bondprice = (int)uint.Parse(tr[1]); }
                catch { }
                try { hueprice = (int)uint.Parse(tr[2]); }
                catch { }

                m_Stone.HuedPrice = hueprice;
                m_Stone.BlessedPrice = blessprice;
                m_Stone.BondedPrice = bondprice;
                m_Stone.Currency = currency;

                from.SendGump(new StaffTokenGump(from, m_Stone));
            }
        }
    }
}
//Modified Date: 1/1/0001 12:00:00 AM
//Modified by:   RavonTUS
//Comment: Installing Shard Pack


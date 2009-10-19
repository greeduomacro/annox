using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Factions;
using Server.PlayerScoreBoard;



namespace Server.Items
{
    [Flipable(0x1E5E, 0x1E5F)]
    public class PlayerScoreBoard : BaseScoreBoard
    {

        public int itemID;

        [Constructable]
        public PlayerScoreBoard()
            : base(0x1E5E)
        {

        }

        public PlayerScoreBoard(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public abstract class BaseScoreBoard : Item
    {
        private string m_BoardName;
        public int hue;
        public Faction m_Faction;


        [CommandProperty(AccessLevel.GameMaster)]
        public string BoardName
        {
            get { return m_BoardName; }
            set { m_BoardName = value; }
        }

        public BaseScoreBoard(int itemID)
            : base(itemID)
        {
            Name = "Top 20 Duelists";
            m_BoardName = "duelist board";
            Movable = false;
            this.hue = 0x0544;
        }

        public virtual void Cleanup()
        {
            List<Item> items = this.Items;

            for (int i = items.Count - 1; i >= 0; --i)
            {
                if (i >= items.Count)
                    continue;

            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (CheckRange(from))
            {
                Cleanup();
                if (!from.InRange(GetWorldLocation(), 2))
                    from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                else
                {
                    from.SendGump(new PlayerScoreGump(from, null, null, 0, null, null));
                }
            }

        }

        public virtual bool CheckRange(Mobile from)
        {
            if (from.AccessLevel >= AccessLevel.GameMaster)
                return true;

            return (from.Map == this.Map && from.InRange(GetWorldLocation(), 2));
        }

        public BaseScoreBoard(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((string)m_BoardName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_BoardName = reader.ReadString();
                        break;
                    }
            }
        }
    }
}
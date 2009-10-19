using System;
using Server;
using System.IO;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Targets;
using Server.Gumps;
using Server.Items;
using Server.Prompts;
using Server.Regions;
using Server.ContextMenus;
using System.Reflection;


namespace Server
{
    public class BestiaryInfo
    {

        public static void Initialize()
        {
            EventSink.Speech += new SpeechEventHandler(Speech_Event);
        }

        public static void Speech_Event(SpeechEventArgs e)
        {
            string keyword = e.Speech;

            switch (keyword)
            {

                case "bestiary":
                    {
                        //If you want to have this controled by a certain skill, edit the line below.
                        //if ( ((PlayerMobile)e.Mobile).Skills[SkillName.Tracking].Base > 80.0 && e.Mobile.Alive)
                        e.Mobile.Target = new BeastTarget();
                        break;
                    }
                case "Bestiary":
                    {
                        //If you want to have this controled by a certain skill, edit the line below.
                        //if ( ((PlayerMobile)e.Mobile).Skills[SkillName.Tracking].Base > 80.0 && e.Mobile.Alive)
                        e.Mobile.Target = new BeastTarget();
                        break;
                    }
            }
        }
    }
}

namespace Server.Targets
{
    public class BeastTarget : Target
    {
        public BeastTarget()
            : base(12, false, TargetFlags.Harmful)
        {
        }
        protected override void OnTarget(Mobile from, object o)
        {
            if (o is Mobile)
            {
                Mobile targ = (Mobile)o;

                if (!targ.InRange(from, 8))
                {
                    from.SendMessage(0x35, "You must be closer to see!");
                    return;
                }
                if (targ is PlayerMobile)
                {
                    from.SendMessage(0x35, "You can not target another player!");
                    return;
                }
                if (targ is BaseVendor)
                {
                    from.SendMessage(0x35, "You can not target a vendor!");
                    return;
                }
                else if (targ is BaseCreature)
                {
                    from.SendGump(new BinfoGump(from, o));
                }
            }
            else
            {
                from.SendMessage(0x35, "You can't do that");
            }
        }
    }
}

namespace Server.Gumps
{
    public class BinfoGump : Gump
    {
        private Mobile m_Mobile;
        private object m_Object;

        public object o
        {
            get { return m_Object; }
            set { m_Object = value; }
        }

        public BinfoGump(Mobile mobile, object o)
            : base(0, 0)
        {
            if (o is Mobile)
            {
                Mobile m_Object = (Mobile)o;
                Mobile m_this = (Mobile)mobile;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddImage(277, 444, 2083);
                AddImage(277, 375, 2082);
                AddImage(277, 307, 2081);
                AddImage(262, 273, 2080);
                AddImage(308, 104, 5010);
                AddImage(384, 81, 4500);
                AddImage(377, 247, 9804);
                AddImage(329, 124, 10460);
                AddImage(459, 125, 10460);
                AddImage(328, 254, 10460);
                AddImage(460, 253, 10460);
                AddImage(391, 443, 2642); //warning light off
                if ((m_Object.RawStr + m_Object.RawInt + m_Object.HitsMax) > (m_this.RawStr + m_this.RawInt + m_this.HitsMax + m_this.SkillsTotal))
                    AddImage(391, 443, 2643); //warning light on
                AddImage(483, 179, 4502);
                AddImage(285, 179, 4508);
                AddImage(230, 210, 10440);
                AddImage(505, 210, 10441);
                AddImage(272, 498, 10556);
                AddImageTiled(300, 498, 221, 62, 10557);
                AddImage(521, 498, 10558);
                AddItem(393, 179, (ShrinkTable.Lookup(m_Object)), (m_Object.Hue));
                AddLabel(298, 303, 33, @"Name: " + m_Object.Name);
                AddLabel(299, 318, 0, @"STR: " + m_Object.RawStr);
                AddLabel(299, 334, 0, @"DEX: " + m_Object.RawDex);
                AddLabel(300, 350, 0, @"INT: " + m_Object.RawInt);
                if (m_Object.Female == false)
                    AddLabel(408, 318, 0, @"SEX: M");
                if (m_Object.Female == true)
                    AddLabel(408, 318, 0, @"SEX: F");
                AddLabel(408, 334, 0, @"AR: " + m_Object.VirtualArmor);
                AddLabel(299, 366, 0, @"HITS: " + m_Object.Hits);
                AddLabel(298, 381, 0, @"MANA: " + m_Object.Mana);
                AddLabel(298, 396, 0, @"STAM: " + m_Object.Stam);
                AddLabel(297, 412, 0, @"WGHT: " + (m_Object.TotalWeight + m_Object.RawStr));
                if (Core.AOS == true)
                {
                    AddImage(410, 355, 2360, 50);
                    AddImage(410, 371, 2360);
                    AddImage(410, 387, 2362);
                    AddImage(410, 403, 2361);
                    AddImage(410, 418, 2360, 17);
                    AddLabel(436, 350, 0, @"" + m_Object.PhysicalResistance);
                    AddLabel(435, 366, 0, @"" + m_Object.FireResistance);
                    AddLabel(435, 382, 0, @"" + m_Object.ColdResistance);
                    AddLabel(435, 398, 0, @"" + m_Object.PoisonResistance);
                    AddLabel(435, 414, 0, @"" + m_Object.EnergyResistance);
                }
                if ((m_Object.RawStr + m_Object.RawInt + m_Object.HitsMax) > (m_this.RawStr + m_this.RawInt + m_this.HitsMax + m_this.SkillsTotal))
                    AddLabel(282, 517, 0, @"This mobile seems to be stronger then you.");
                if ((m_Object.RawStr + m_Object.RawInt + m_Object.HitsMax) < (m_this.RawStr + m_this.RawInt + m_this.HitsMax + m_this.SkillsTotal))
                    AddLabel(282, 517, 0, @"This mobile seems to be weaker then you.");

                AddButton(495, 448, 2640, 2641, 1, GumpButtonType.Reply, 0); //close
                AddButton(297, 448, 2640, 2641, 2, GumpButtonType.Reply, 0); //capture
                AddLabel(464, 452, 0, @"Close");
                AddLabel(327, 452, 0, @"Capture");

                AddLabel(343, 554, 0, @"Designed By : Chinook");
            }
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            PlayerMobile From = from as PlayerMobile;

            From.CloseGump(typeof(BinfoGump));

            if (info.ButtonID == 1)
            {
                From.CloseGump(typeof(BinfoGump));
                return;
            }
            if (info.ButtonID == 2)
            {
                From.Target = new BCaptureTarget();
                From.SendMessage("Please target the same creature to take its picture!");
                return;
            }
        }
    }
}


// 30AUG2007 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    public class GoblinBountyHunter : BaseHealer
    {
        private static bool m_Talked;

        public override bool CanTeach { get { return true; } }

        public override bool CheckTeach(SkillName skill, Mobile from)
        {
            if (!base.CheckTeach(skill, from))
                return false;

            return (skill == SkillName.Anatomy)
                || (skill == SkillName.Camping)
                || (skill == SkillName.Forensics)
                || (skill == SkillName.Healing)
                || (skill == SkillName.SpiritSpeak);
        }

        [Constructable]
        public GoblinBountyHunter()
        {
            Title = "the goblin bounty hunter";

            Body = 0x190;
            Name = NameList.RandomName("male");

            AddItem(new PlateChest());
            AddItem(new PlateArms());
            AddItem(new PlateLegs());
            AddItem(new BodySash(Utility.RandomYellowHue()));
            //DropItem(Robe());

            Utility.AssignRandomHair(this);

            if (Utility.RandomBool())
                Utility.AssignRandomFacialHair(this, HairHue);

            Halberd weapon = new Halberd();

            weapon.Movable = false;
            weapon.Crafter = this;
            weapon.Quality = WeaponQuality.Exceptional;

            AddItem(weapon);

            Container pack = new Backpack();

            pack.Movable = false;

            pack.DropItem(new Factions.Silver(10, 25));

            AddItem(pack);

            Skills[SkillName.Anatomy].Base = 120.0;
            Skills[SkillName.Tactics].Base = 120.0;
            Skills[SkillName.Swords].Base = 120.0;
            Skills[SkillName.MagicResist].Base = 120.0;
            Skills[SkillName.DetectHidden].Base = 100.0;

            SetSkill(SkillName.Camping, 80.0, 100.0);
            SetSkill(SkillName.Forensics, 80.0, 100.0);
            SetSkill(SkillName.SpiritSpeak, 80.0, 100.0);
        }

        public override bool OnDragDrop(Mobile from, Item item)
        {
            if (item is GoblinEars)
            {
                Say(1049368); // You have been rewarded for your dedication to Justice!
                from.Backpack.AddItem(new Factions.Silver(1, 5));
                item.Delete();
                return true;
            }
            else if (item is OutlanderHead)
            {
                Say(1049368); // You have been rewarded for your dedication to Justice!
                from.Backpack.AddItem(new Factions.Silver(10, 50));
                item.Delete();
                return true;
            }
            else if (item is GilwiremarHead)
            {
                Say(1049368); // You have been rewarded for your dedication to Justice!
                from.Backpack.AddItem(new Factions.Silver(100, 500));
                item.Delete();
                return true;
            }
            else
            {
                Say(502816); // You feel that such an action would be inappropriate
                return false;
            }
        }

        public override void OnMovement(Mobile from, Point3D oldLocation)
        {
            if (m_Talked == false)
            {
                if (from.InRange(this, 3) && from is PlayerMobile)
                {
#if PopUp
                    if (!from.HasGump(typeof(PopUpGump)))
                    {
                        from.SendGump(new PopUpGump("The bounty hunter, {0}, will reward thee, if ye bring him the Ears of a goblin.", Name));
#else
                    Say("I will reward thee, if ye bring me the ears of a goblin.");
#endif
                    m_Talked = true;
                    GoblinBountyHunterTimer t = new GoblinBountyHunterTimer();
                    t.Start();
                }
            }
        }

        private class GoblinBountyHunterTimer : Timer
        {
            public GoblinBountyHunterTimer()
                : base(TimeSpan.FromSeconds(30))
            {
                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                m_Talked = false;
            }
        }

        public override bool CheckResurrect(Mobile m)
        {
            if (m.Criminal)
            {
                Say(501222); // Thou art a criminal.  I shall not resurrect thee.
                return false;
            }
            else if (m.Kills >= 5)
            {
                Say(501223); // Thou'rt not a decent and good person. I shall not resurrect thee.
                return false;
            }

            return true;
        }

        public GoblinBountyHunter(Serial serial)
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
}
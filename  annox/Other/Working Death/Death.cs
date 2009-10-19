//03OCT2006 Added stuff to hopefully make him walk again.  (Based on Wanderer.cs)
using System;
using System.Collections;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Regions;
using Server.Items;
using Server.Commands;

namespace Server.Mobiles
{
    [CorpseName("a corpse of a Grim Reaper's Corpse")]
    public class Death : BaseCreature
    {

        [Constructable]
        public Death()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {

            Name = "Death";
            Body = 400;
            NameHue = 11;
            Blessed = true;
            SpeechHue = 33;

            SetStr(500);
            SetDex(500);
            SetInt(500);
            SetHits(10000);
            SetDamage(45);
            SetDamageType(ResistanceType.Physical, 100);

            AddItem(new DeathsRobe());
            AddItem(new Sandals(1));
            AddItem(new DeathsScythe());
            AddItem(new BoneGloves());
            AddItem(new BoneHelm());

            new DeathTimer(this).Start();
            new SpeechTimer(this).Start();
            new FreezeTimer(this).Start();
        }

        public override Poison PoisonImmune { get { return Poison.Deadly; } }
        public override bool BardImmune { get { return true; } }

        public override void OnDeath(Container c)
        {
            c.Delete();
            base.OnDeath(c);
        }

        private class DeathTimer : Timer
        {
            private Mobile m_mobile;

            public DeathTimer(Mobile mob)
                : base(TimeSpan.FromSeconds(10.0))
            {
                m_mobile = mob;
            }

            protected override void OnTick()
            {
                m_mobile.PlaySound(0x1FE);
                m_mobile.Delete();
                Stop();
            }

        }

        private class SpeechTimer : Timer
        {
            private Mobile m_mobile;
            private int m_Count = 0;

            public SpeechTimer(Mobile mob)
                : base(TimeSpan.FromSeconds(4.0))
            {
                m_mobile = mob;
            }
            protected override void OnTick()
            {
                switch (Utility.Random(10))
                {
                    case 0: m_mobile.Say("I'd love to stay and chat, but i have more souls to take."); break;
                    case 1: m_mobile.Say("So many souls... So little time..."); break;
                    case 2: m_mobile.Say("Let me help you out of that body."); break;
                    case 3: m_mobile.Say("It saddens me to do this to you again..."); break;
                    case 4: m_mobile.Say("Some days its better not to get out of bed."); break;
                    case 5: m_mobile.Say("Sometimes I wish all i heard was OoOOooO."); break;
                    case 6: m_mobile.Say("I really hate it when you mortals yell out Ugh! before you die."); break;
                    case 7: m_mobile.Say("...I have to go, somebody else is about to die."); break;
                    case 8: m_mobile.Say(""); break;
                    case 9: m_mobile.Say(""); break;
                }
                //03OCT2006 Added to make him walk again *** START ***
                if ((m_Count++ & 0x3) == 0)
                {
                    m_mobile.Direction = (Direction)(Utility.Random(8) | 0x80);
                }

                m_mobile.Move(m_mobile.Direction);
                //03OCT2006 Added to make him walk again *** START ***
                Stop();
            }

        }

        private class FreezeTimer : Timer
        {
            private Mobile m_mobile;
            private Item gate;


            public FreezeTimer(Mobile mob)
                : base(TimeSpan.FromSeconds(7.0))
            {
                m_mobile = mob;
            }

            protected override void OnTick()
            {
                m_mobile.Frozen = true;
                m_mobile.PlaySound(526);
                Item m = new DeathsGate();
                m.Location = m_mobile.Location;
                m.Map = m_mobile.Map;

                Stop();
            }
        }


        public Death(Serial serial)
            : base(serial)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}

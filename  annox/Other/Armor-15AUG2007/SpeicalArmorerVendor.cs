using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
    public class SpecialArmorer : BaseVendor
    {
        private ArrayList m_SBInfos = new ArrayList();
        protected override ArrayList SBInfos { get { return m_SBInfos; } }

        [Constructable]
        public SpecialArmorer()
            : base("the Special Armorer")
        {
            SetSkill(SkillName.ArmsLore, 64.0, 100.0);
            SetSkill(SkillName.Blacksmith, 60.0, 83.0);
        }

        public override void InitSBInfo()
        {
            switch (Utility.Random(4))
            {
                case 0:
                    {
                        m_SBInfos.Add(new SBDaemonArmor());
                        m_SBInfos.Add(new SBRandomArmor());
                        break;
                    }
                case 1:
                    {
                        m_SBInfos.Add(new SBDarkNinjiArmor());
                        m_SBInfos.Add(new SBRandomArmor());
                        break;
                    }
                case 2:
                    {
                        m_SBInfos.Add(new SBNastArmor());
                        m_SBInfos.Add(new SBRandomArmor());
                        break;
                    }
                case 3:
                    {
                        m_SBInfos.Add(new SBOrcArmor());
                        m_SBInfos.Add(new SBRandomArmor());
                        break;
                    }
            }
        }

        public override VendorShoeType ShoeType
        {
            get { return VendorShoeType.Boots; }
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem(new Server.Items.HalfApron(Utility.RandomYellowHue()));
            AddItem(new Server.Items.Bascinet());
        }

        public SpecialArmorer(Serial serial)
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
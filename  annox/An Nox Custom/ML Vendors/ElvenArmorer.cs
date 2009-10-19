using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    public class ElvenArmorer : BaseVendor
    {
        private ArrayList m_SBInfos = new ArrayList();
        protected override ArrayList SBInfos { get { return m_SBInfos; } }

        [Constructable]
        public ElvenArmorer()
            : base("the Elven Armorer")
        {
            Hue = Utility.RandomSkinHue();

            if (Female = GetGender())
            {
                BodyMod = 605;
                //change "female elf" to "female", if you did not add new elven names to names.xml
                Name = NameList.RandomName("female");
            }
            else
            {
                BodyMod = 606;
                //change "male elf" to "male", if you did not add new elven names to names.xml
                Name = NameList.RandomName("male");
            }
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBElvenHelmetArmor());
            m_SBInfos.Add(new SBElvenHideArmor());
            m_SBInfos.Add(new SBElvenLTArmor());
            m_SBInfos.Add(new SBElvenWoodArmor());
        }

        public override void InitOutfit()
        {
            //AddItem(new Robe(GetRandomHue()));
            switch (Utility.Random(4))  //picks one of the following
            {
                case 0: AddItem(new ElvenShirt(GetRandomHue())); break;
                case 1: AddItem(new ElvenDarkShirt(GetRandomHue())); break;
                case 2: AddItem(new FemaleElvenRobe(GetRandomHue())); break;
                case 3: AddItem(new MaleElvenRobe(GetRandomHue())); break;
            }

            AddItem(new ElvenPants(GetRandomHue()));
            AddItem(new ElvenBoots(GetRandomHue()));

            PackGold(100, 200);
        }

        public ElvenArmorer(Serial serial)
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

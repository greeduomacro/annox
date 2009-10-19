using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
    public class ElementalOrbDealer : BaseVendor
    {
        private ArrayList m_SBInfos = new ArrayList();
        protected override ArrayList SBInfos { get { return m_SBInfos; } }

        [Constructable]
        public ElementalOrbDealer()
            : base("the Elemental Orb Dealer")
        {
            SetSkill(SkillName.Mining, 65.0, 88.0);
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBElementalOrbDealer());
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem(new Server.Items.FancyShirt(0x3E4));
            AddItem(new Server.Items.LongPants(0x192));
            //AddItem( new Server.Items.Pickaxe() );
            AddItem(new Server.Items.ThighBoots(0x283));
        }

        public ElementalOrbDealer(Serial serial)
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

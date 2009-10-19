using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class Mercer : BaseVendor
	{
		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Mercer() : base( "the Mercer" )
		{
			//SetSkill( SkillName.Lumberjacking, 36.0, 68.0 );
			SetSkill( SkillName.Tailoring, 36.0, 68.0 );
			SetSkill( SkillName.ItemID, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBMercer() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return VendorShoeType.Shoes; }
		}

		public override int GetShoeHue()
		{
			return 0;
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.FancyShirt( Utility.RandomNeutralHue() ) );
            AddItem(new Server.Items.Cloak(Utility.RandomNeutralHue()));

		}

		public Mercer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
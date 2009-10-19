using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a thrasher corpse" )]
	public class Thrasher : BaseCreature
	{
		[Constructable]
		public Thrasher() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Thrasher";
			Body = 0xCA;
			BaseSoundID = 660;

			SetStr( 94 );
			SetDex( 235 );
			SetInt( 20 );

			SetHits( 684 );
			SetStam( 46, 65 );
			SetMana( 20 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 26 );
			SetResistance( ResistanceType.Poison, 30 );

			SetSkill( SkillName.MagicResist, 118.8 );
			SetSkill( SkillName.Tactics, 103.3 );
			SetSkill( SkillName.Wrestling, 99.0 );

			Fame = 1000;
			Karma = -1000;

			VirtualArmor = 30;

			Tamable = false;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public Thrasher(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( BaseSoundID == 0x5A )
				BaseSoundID = 660;
		}
	}
}
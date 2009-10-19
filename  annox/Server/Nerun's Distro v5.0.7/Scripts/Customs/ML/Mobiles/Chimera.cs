using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
[CorpseName( "a Chimera corpse" )]
	public class Chimera : BaseMount
	{
		[Constructable]
		public Chimera() : this( "a Chimera" )
		{
		}
		[Constructable]
		public Chimera( string name ) : base( name, 276, 0x3e90, AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x4FB;
			Hue = Utility.RandomList ( 1, 1174, 1153, 1456, 1170, 1360, 1109, 33, 1061, 1072, 1090, 1098, 1100, 1151, 1155, 1171, 1173, 1179 );

			SetStr( 796, 1125 );
			SetDex( 386, 405 );
			SetInt( 286, 325 );

			SetHits( 1298, 1385 );

			SetDamage( 76, 92 );

			SetDamageType( ResistanceType.Physical, 60 );			
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 65, 75 );
			SetResistance( ResistanceType.Cold, 55, 65 );
			SetResistance( ResistanceType.Poison, 55, 65 );
			SetResistance( ResistanceType.Energy, 65, 75 );

			SetSkill( SkillName.EvalInt, 150.4, 200.0 );
			SetSkill( SkillName.Magery, 130.4, 150.0 );
			SetSkill( SkillName.MagicResist, 135.3, 150.0 );
			SetSkill( SkillName.Tactics, 137.6, 158.0 );
			SetSkill( SkillName.Wrestling, 130.5, 152.5 );

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 100;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 119.1;
			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );			
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }		
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.MortalStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}


		public Chimera( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}
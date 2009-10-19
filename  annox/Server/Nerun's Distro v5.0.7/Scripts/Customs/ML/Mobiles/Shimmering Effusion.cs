using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a Shimmering Effusion corpse" )]
	public class ShimmeringEffusion : BaseCreature
	{
		[Constructable]
		public ShimmeringEffusion() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a ShimmeringEffusion";
			Body = 260;			

			SetStr( 471, 600 );
			SetDex( 226, 245 );
			SetInt( 276, 305 );

			SetHits( 403, 520 );

			SetDamage( 34, 46 );

			
			SetDamageType( ResistanceType.Cold, 20 );
			SetDamageType( ResistanceType.Energy, 80 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 55, 65 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.EvalInt, 140.0 );
			SetSkill( SkillName.Magery, 120.1, 150.0 );
			SetSkill( SkillName.Meditation, 95.1, 105.0 );
			SetSkill( SkillName.MagicResist, 120.1, 160.0 );
			SetSkill( SkillName.Tactics, 80.1, 99.0 );

			Fame = 8000;
			Karma = -8000;

			VirtualArmor = 70;
			
			PackItem( new GnarledStaff() );
			PackNecroReg( 15, 25 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 3; } }

		public ShimmeringEffusion( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound()
		{
			return 0x1BF;
		}

		public override int GetAttackSound()
		{
			return 0x1C0;
		}

		public override int GetHurtSound()
		{
			return 0x1C1;
		}

		public override int GetDeathSound()
		{
			return 0x1C2;
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
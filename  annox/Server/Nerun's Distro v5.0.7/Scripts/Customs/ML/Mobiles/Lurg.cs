using System;
using Server;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a lurg corpse" )]
	public class Lurg : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}
		[Constructable]
		public Lurg() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Lurg";
			Body = 267;
			Hue = 1175;
			
			BaseSoundID = 1440;

			SetStr( 638, 648 );
			SetDex( 167, 177 );
			SetInt( 94, 104 );

			SetHits( 3219, 3229 );
			SetStam( 167, 177 );
			SetMana( 94, 104 );

			SetDamage( 20, 32 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 55 );
			SetResistance( ResistanceType.Fire, 44, 49 );
			SetResistance( ResistanceType.Cold, 55, 60 );
			SetResistance( ResistanceType.Poison, 55, 60 );
			SetResistance( ResistanceType.Energy, 55, 60 );

			SetSkill( SkillName.MagicResist, 79.8, 89.8 );
			SetSkill( SkillName.Tactics, 115.8, 125.8 );
			SetSkill( SkillName.Wrestling, 124.2, 134.2 );
			SetSkill( SkillName.Anatomy, 115.5, 125.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 50;

		}
		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Gems );
		}
	
		public override int GetAttackSound()
		{
			return 1441;
		}

		public override int GetAngerSound()
		{
			return 1442;
		}

		public override int GetDeathSound()
		{
			return 1438;
		}

		public override int GetHurtSound()
		{
			return 1439;
		}

		public override int GetIdleSound()
		{
			return 1440;
		}
		public override bool BleedImmune { get { return true; } }
		public override Poison PoisonImmune { get { return Poison.Greater; } }
		public override int TreasureMapLevel { get { return 4; } }
		public Lurg( Serial serial ) : base( serial )
		{
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

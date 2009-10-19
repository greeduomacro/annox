using System;
using Server;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a grobu corpse" )]
	public class Grobu : BaseCreature
	{
		
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}
		[Constructable]
		public Grobu() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Grobu";
			Body = 212;
			Hue = 963;
			BaseSoundID = 0xA3;
			
			SetStr( 638, 648 );
			SetDex( 197, 207 );
			SetInt( 42, 52 );

			SetHits( 1298, 1308 );
			SetStam( 197, 207 );
			SetMana(  0 );

			SetDamage( 20, 32 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 45 );
			SetResistance( ResistanceType.Fire, 35, 40 );
			SetResistance( ResistanceType.Cold, 30, 35 );
			SetResistance( ResistanceType.Poison, 25, 30 );
			SetResistance( ResistanceType.Energy, 20, 25 );

			SetSkill( SkillName.MagicResist, 73.6, 83.6 );
			SetSkill( SkillName.Tactics, 108.4, 118.4 );
			SetSkill( SkillName.Wrestling, 106.8, 116.8 );

			Fame = 10000;
			Karma = -8000;

			VirtualArmor = 35;

		}
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Gems );
		}
	
	
		//public override bool ReaquireOnMovement { get { return true; } }
		
		public override int Meat { get { return 2; } }
		public override int Hides{ get{ return 16; } }
		//public override HideType HideType{ get{ return HideType.Bear; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }
		public override int TreasureMapLevel { get { return 1; } }
		
		public Grobu( Serial serial ) : base( serial )
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

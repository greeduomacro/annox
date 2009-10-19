using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a dread horn corpse" )]
	
	public class DreadHorn : BaseCreature
	{
		
		[Constructable]
		public DreadHorn() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Dread Horn";
			Body = 257;
			BaseSoundID = 0xA8;

			SetStr( 1281, 1305 );
			SetDex( 591, 815 );
			SetInt( 1226, 1250 );

			SetHits( 169, 183 );
			SetStam( 636, 945 );

			SetDamage( 120, 170 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 70, 82 );
			SetResistance( ResistanceType.Fire, 70, 82 );
			SetResistance( ResistanceType.Cold, 70, 82 );
			SetResistance( ResistanceType.Poison, 70, 82 );
			SetResistance( ResistanceType.Energy, 70, 82 );

			SetSkill( SkillName.EvalInt, 155.1, 200.0 );
			SetSkill( SkillName.Magery, 155.1, 200.0 );
			SetSkill( SkillName.MagicResist, 155.1, 200.0 );
			SetSkill( SkillName.Tactics, 155.1, 200.0 );
			SetSkill( SkillName.Wrestling, 155.1, 200.0 );

			Fame = 11500;
			Karma = -11500;

			VirtualArmor = 75;
			
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich );
			AddLoot( LootPack.AosSuperBoss );
		}

		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }                
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }		
		public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }

		public DreadHorn( Serial serial ) : base( serial )
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
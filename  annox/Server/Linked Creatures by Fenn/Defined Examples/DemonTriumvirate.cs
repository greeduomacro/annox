using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a demon corpse" )]
	public class DemonTriumvirate : BaseLinkedCreature
	{
		//NOTE: this is set up so that at least 3, and no more than 3 of these will link up.  They must be
		//killed simultaneously
		
		
		//set this true to allow them to link to any linkable anywhere in the world
		public override bool GlobalScopeLink{ get{ return true; } }
		
		//set this true to allow them to link to other cross-creature linkable types of linkable creatures
		public override bool CrossCreatureLink{ get{ return false; } }
		
		//set this true to link with linkable creatures in an opposite scope ( global vs. local )
		public override bool CrossScopeLink{ get{ return false; } }

		//set this true to disallow pets from damaging the creature
		public override bool BlockPetDamage{ get{ return true; } }
		
		//set this true to slaughter pets on contact
		public override bool KillPets{ get{ return false; } }
		
		public override bool SynchKill{ get{ return true; } }
		
		public override int MinLinkNum{ get{ return 2; } }
		public override int MaxLinkNum{ get{ return 2; } }
		
		[Constructable]
		public DemonTriumvirate() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			
			Name = "Demon Triumvirate";
			Body = 9;
			BaseSoundID = 357;

			SetStr( 1600, 200 );
			SetDex( 200, 300 );
			SetInt( 250, 300 );

			SetHits( 1600, 2300 );

			SetDamage( 30, 50 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 80 );
			SetResistance( ResistanceType.Fire, 60, 80 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 25.1, 50.0 );
			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 95.5, 100.0 );
			SetSkill( SkillName.Meditation, 25.1, 50.0 );
			SetSkill( SkillName.MagicResist, 100.5, 150.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 120.1, 150.0 );

			Fame = 25000;
			Karma = -25000;

			VirtualArmor = 90;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 6; } }
		public override int Meat{ get{ return 1; } }

		public DemonTriumvirate( Serial serial ) : base( serial )
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
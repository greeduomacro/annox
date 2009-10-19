using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "a terathan drone corpse" )]
	public class LinkedTerathanDrone : BaseLinkedCreature
	{
		//NOTE: this will be immune to pets.  For added cruelty, set KillPets true!
		
		//set this true to allow them to link to any linkable anywhere in the world
		public override bool GlobalScopeLink{ get{ return false; } }
		
		//set this true to allow them to link to other cross-creature linkable types of linkable creatures
		public override bool CrossCreatureLink{ get{ return false; } }
		
		//set this true to link with linkable creatures in an opposite scope ( global vs. local )
		public override bool CrossScopeLink{ get{ return false; } }

		//set this true to disallow pets from damaging the creature
		public override bool BlockPetDamage{ get{ return true; } }
		
		//set this true to slaughter pets on contact
		public override bool KillPets{ get{ return false; } }
		
		[Constructable]
		public LinkedTerathanDrone() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a pet-immune terathan drone";
			Body = 71;
			BaseSoundID = 594;

			SetStr( 36, 65 );
			SetDex( 96, 145 );
			SetInt( 21, 45 );

			SetHits( 22, 39 );
			SetMana( 0 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 15, 25 );

			SetSkill( SkillName.Poisoning, 40.1, 60.0 );
			SetSkill( SkillName.MagicResist, 30.1, 45.0 );
			SetSkill( SkillName.Tactics, 30.1, 50.0 );
			SetSkill( SkillName.Wrestling, 40.1, 50.0 );

			Fame = 2000;
			Karma = -2000;

			VirtualArmor = 24;
			
			PackItem( new SpidersSilk( 2 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			// TODO: weapon?
		}

		public override int Meat{ get{ return 4; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public LinkedTerathanDrone( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 589 )
				BaseSoundID = 594;
		}
	}
}
using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a giant rat corpse" )]
	public class LinkedGiantRat : BaseLinkedCreature
	{
		//NOTE: this is set up to link up with other cross-linkable creatures.  This is a good example of
		//making a variety of swarming creatures
		
		//set this true to allow them to link to any linkable anywhere in the world
		public override bool GlobalScopeLink{ get{ return false; } }
		
		//set this true to allow them to link to other cross-creature linkable types of linkable creatures
		public override bool CrossCreatureLink{ get{ return true; } }
		
		//set this true to link with linkable creatures in an opposite scope ( global vs. local )
		public override bool CrossScopeLink{ get{ return false; } }

		//set this true to disallow pets from damaging the creature
		public override bool BlockPetDamage{ get{ return false; } }
		
		//set this true to slaughter pets on contact
		public override bool KillPets{ get{ return false; } }
		
		[Constructable]
		public LinkedGiantRat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			
			Name = "a swarm giant rat";
			Body = 0xD7;
			BaseSoundID = 0x188;

			SetStr( 32, 74 );
			SetDex( 46, 65 );
			SetInt( 16, 30 );

			SetHits( 26, 39 );
			SetMana( 0 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Poison, 25, 35 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.Wrestling, 29.3, 44.0 );

			Fame = 300;
			Karma = -300;

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies | FoodType.Eggs; } }

		public LinkedGiantRat(Serial serial) : base(serial)
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
		}
	}
}
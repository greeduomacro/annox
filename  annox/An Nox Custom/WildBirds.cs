// 06APR2006 written by RavonTUS
//
//   /\\           |\\  ||
//  /__\\  |\\ ||  | \\ ||  /\\  \ //
// /    \\ | \\||  |  \\||  \//  / \\ 
// Play at An Nox, the cure for the UO addiction
// http://annox.no-ip.com  // RavonTUS@Yahoo.com

using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a wild bird corpse" )]
	public class WildBird : BaseCreature
	{
		[Constructable]
        public WildBird()
            : base(AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4)
            //FightMode:
            //Valid FightModes for mobiles.

            //None      : Never focus on others
            //Agressor  : Only attack agressors
            //Strongest : Attack the strongest
            //Weakest   : Attack the weakest
            //Closest   : Attack the closest
            //Evil      : Only attack aggressor -or- negative karma
		{
			if ( Utility.RandomBool() )
			{
				Hue = 0x901;

				switch ( Utility.Random( 3 ) )
				{
					case 0: Name = "a crow"; break;
					case 2: Name = "a raven"; break;
					case 1: Name = "a magpie"; break;
				}
			}
			else
			{
				Hue = Utility.RandomBirdHue();
				Name = NameList.RandomName( "bird" );
			}

			Body = 6;
			BaseSoundID = 0x1B;

			VirtualArmor = Utility.RandomMinMax( 0, 6 );

			SetStr( 10 );
			SetDex( 25, 35 );
			SetInt( 10 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Wrestling, 4.2, 6.4 );
			SetSkill( SkillName.Tactics, 4.0, 6.0 );
			SetSkill( SkillName.MagicResist, 4.0, 5.0 );

			SetFameLevel( 1 );
			SetKarmaLevel( 0 );

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = -6.9;
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public WildBird( Serial serial ) : base( serial )
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

			if ( Hue == 0 )
				Hue = Utility.RandomBirdHue();
		} 
	}

	[CorpseName( "a bird corpse" )]
	public class WildTropicalBird : BaseCreature
	{
		[Constructable]
        public WildTropicalBird()
            : base(AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Hue = Utility.RandomBirdHue();
			Name = "a wild tropical bird";

			Body = 6;
			BaseSoundID = 0xBF;

			VirtualArmor = Utility.RandomMinMax( 0, 6 );

			SetStr( 10 );
			SetDex( 25, 35 );
			SetInt( 10 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Wrestling, 4.2, 6.4 );
			SetSkill( SkillName.Tactics, 4.0, 6.0 );
			SetSkill( SkillName.MagicResist, 4.0, 5.0 );

			SetFameLevel( 1 );
			SetKarmaLevel( 0 );

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = -6.9;
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public WildTropicalBird( Serial serial ) : base( serial )
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
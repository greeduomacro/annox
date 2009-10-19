using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a monster corpse" )]
	public class questmonster : BaseCreature
	{
		[Constructable]
		public questmonster() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a quest monster";
			Body = 14;
			BaseSoundID = 268;
                  Hue = 0x84f;

			SetStr( 226, 255 );
			SetDex( 66, 85 );
			SetInt( 71, 92 );

			SetHits( 76, 93 );

			SetDamage( 9, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 20 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 15, 25 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Tactics, 60.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 34;
			ControlSlots = 2;

			PackGem();
			
			PackItem( new IronOre( 3 ) ); // TODO: Five small iron ore
			PackGold( 100, 150 );
			PackItem( new MandrakeRoot() );
               AddItem(new questIcon() ); 
		}

		public override int TreasureMapLevel{ get{ return 1; } }

		public questmonster( Serial serial ) : base( serial )
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
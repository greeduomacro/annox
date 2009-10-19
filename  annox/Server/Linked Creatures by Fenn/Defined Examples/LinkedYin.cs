using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
	/*
	
	Yin-Yang pairs:  a Yin can link with one and only one Yang, and vice versa.
	
	You cannot use pets
	
	You must kill them simultaneously
	
	*/
	
	[CorpseName( "a yin corpse" )]
	public class LinkedYin : BaseLinkedCreature
	{
		//set this true in an inherited class to allow them to link to any linkable anywhere in the world
		public override bool GlobalScopeLink{ get{ return false; } }
		
		//set this true in an inherited class to allow them to link to other cross-creature linkable types of linkable creatures
		public override bool CrossCreatureLink{ get{ return true; } }
		
		//set this false in an inherited class to disallow them to link with the same class of creature
		public override bool LinkToSameClass{ get{ return false; } }
		
		//set this true in an inherited class to allow the creature to link with linkable creatures in an opposite scope ( global vs. local )
		public override bool CrossScopeLink{ get{ return false; } }

		//set this true in an inherited creature to disallow pets from damaging the creature
		public override bool BlockPetDamage{ get{ return true; } }
		
		//set this true in an inherited creature to slaughter pets on contact
		public override bool KillPets{ get{ return false; } }
		
		//set this higher in an inherited creature to force this number to link before the creatures are attackable
		public override int MinLinkNum{ get{ return 1; } }
		
		//set this in an inherited creature to cap the number to link.  0 means unlimited # of links
		public override int MaxLinkNum{ get{ return 1; } }
		
		//set this true in an inherited creature to force all creatures to be killed at once
		public override bool SynchKill{ get{ return true; } }
		
		
		[Constructable]
		public LinkedYin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a Yin";
			Body = 247;
			BaseSoundID = 0x372;
			Hue = 1;

			SetStr( 301, 375 );
			SetDex( 201, 255 );
			SetInt( 21, 25 );

			SetHits( 351, 430 );

			SetDamage( 12, 17 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Fire, 10 );
			SetDamageType( ResistanceType.Cold, 10 );
			SetDamageType( ResistanceType.Poison, 10 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 50, 70 );
			SetResistance( ResistanceType.Cold, 50, 70 );
			SetResistance( ResistanceType.Poison, 50, 70 );
			SetResistance( ResistanceType.Energy, 40, 60 );

			SetSkill( SkillName.MagicResist, 100.1, 110.0 );
			SetSkill( SkillName.Tactics, 85.1, 95.0 );
			SetSkill( SkillName.Wrestling, 85.1, 95.0 );
			SetSkill( SkillName.Anatomy, 85.1, 95.0 );

			Fame = 9000;
			Karma = -9000;
			
			if ( Utility.RandomDouble() < .33 )
				PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
				
			AddItem( new Tessen() );
			
			if ( 0.02 >= Utility.RandomDouble() )
				PackItem( new OrigamiPaper() );
		}
				
				
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Gems, 2 );
		}
			
		public override bool Uncalmable{ get{ return true; } }

		/* TODO: Repel Magic
		 * 10% chance of repelling a melee attack (why did they call it repel magic anyway?)
		 * Cliloc: 1070844
		 * Effect: damage is dealt to the attacker, no damage is taken by the fan dancer
		 */

		public override void OnDamagedBySpell( Mobile attacker )
		{
			base.OnDamagedBySpell( attacker );

			if ( 0.8 > Utility.RandomDouble() && !attacker.InRange( this, 1 ) )
			{
				/* Fan Throw
				 * Effect: - To: "0x57D4F5B" - ItemId: "0x27A3" - ItemIdName: "Tessen" - FromLocation: "(992 299, 24)" - ToLocation: "(992 308, 22)" - Speed: "10" - Duration: "0" - FixedDirection: "False" - Explode: "False" - Hue: "0x0" - Render: "0x0"
				 * Damage: 50-65
				 */
				Effects.SendPacket( attacker, attacker.Map, new HuedEffect( EffectType.Moving, Serial.Zero, Serial.Zero, 0x27A3, this.Location, attacker.Location, 10, 0, false, false, 0, 0 ) );
				AOS.Damage( attacker, this, Utility.RandomMinMax( 50, 65 ), 100, 0, 0, 0, 0 );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.8 > Utility.RandomDouble() && !attacker.InRange( this, 1 ) )
			{
				/* Fan Throw
				 * Effect: - To: "0x57D4F5B" - ItemId: "0x27A3" - ItemIdName: "Tessen" - FromLocation: "(992 299, 24)" - ToLocation: "(992 308, 22)" - Speed: "10" - Duration: "0" - FixedDirection: "False" - Explode: "False" - Hue: "0x0" - Render: "0x0"
				 * Damage: 50-65
				 */
				Effects.SendPacket( attacker, attacker.Map, new HuedEffect( EffectType.Moving, Serial.Zero, Serial.Zero, 0x27A3, this.Location, attacker.Location, 10, 0, false, false, 0, 0 ) );
				AOS.Damage( attacker, this, Utility.RandomMinMax( 50, 65 ), 100, 0, 0, 0, 0 );
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.05 > Utility.RandomDouble() )
			{
				/* Fanning Fire
				 * Graphic: Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x3709" ItemIdName: "fire column" FromLocation: "(994 325, 16)" ToLocation: "(994 325, 16)" Speed: "10" Duration: "30" FixedDirection: "True" Explode: "False" Hue: "0x0" RenderMode: "0x0" Effect: "0x34" ExplodeEffect: "0x1" ExplodeSound: "0x0" Serial: "0x57D4F5B" Layer: "5" Unknown: "0x0"
				 * Sound: 0x208
				 * Start cliloc: 1070833
				 * Effect: Fire res -10% for 10 seconds
				 * Damage: 35-45, 100% fire
				 * End cliloc: 1070834
				 * Effect does not stack
				 */

				defender.SendLocalizedMessage( 1070833 ); // The creature fans you with fire, reducing your resistance to fire attacks.

				int effect = -(defender.FireResistance / 10);

				ResistanceMod mod = new ResistanceMod( ResistanceType.Fire, effect );

				defender.FixedParticles( 0x37B9, 10, 30, 0x34, EffectLayer.RightFoot );
				defender.PlaySound( 0x208 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( defender, this, Utility.RandomMinMax( 35, 45 ), 0, 100, 0, 0, 0 );

				defender.AddResistanceMod( mod );
		
				ExpireTimer timer = new ExpireTimer( defender, mod, TimeSpan.FromSeconds( 10.0 ) );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		public bool IsFanned( Mobile m )
		{
			return m_Table.Contains( m );
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				Priority = TimerPriority.TwoFiftyMS;
		}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( 1070834 ); // Your resistance to fire attacks has returned.
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}
		}

		public LinkedYin( Serial serial ) : base( serial )
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
		}
	}
}
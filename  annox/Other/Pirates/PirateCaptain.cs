using System;
using System.Collections;
using Server;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a corpse of a pirate" )]
	public class PirateCaptain : BaseCreature
	{
		private static bool m_Talked;
		string[] PirateSay = new string[] 
		{ 
			"Ye be dealing with a pirate, Matey!", 
			"Ye find it wise to cross blades with a pirate, fool?",
			"To the depths ye shall be fallin'!",
			"Yer time has come yeh mongrel."
		}; 

		//public override bool ClickTitle{ get{ return false; } }		

		[Constructable]
		public PirateCaptain() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "the pirate captain";
			Hue = Utility.RandomSkinHue();

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );

				Kryss kryss = new Kryss();
				kryss.Movable = false;
				//kryss.Resource = ResourceName.Gold;
				kryss.Skill = SkillName.Wrestling;

				Item necklace = new Necklace();
				necklace.Name = "a pirate captain's medallion";
				necklace.Movable = false;
				necklace.Hue = 38;

				AddItem( kryss );

				AddItem( new Shirt() );

				AddItem( new FancyDress() );

				AddItem( new Shoes() );

				AddItem( new HeaterShield() );

				AddItem( necklace );

				AddItem( new FloppyHat() );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );

				Cutlass cutlass = new Cutlass();
				cutlass.Movable = false;
				//cutlass.Resource = ResourceName.Gold;
				cutlass.Skill = SkillName.Wrestling;

				AddItem( cutlass );

				AddItem( new FormalShirt() );
	
				AddItem( new LongPants( Utility.RandomNeutralHue()) );

				AddItem( new Boots( Utility.RandomNeutralHue()) );

				AddItem( new HeaterShield() );

				AddItem( new WideBrimHat( Utility.RandomRedHue()) );
			}

			SetStr( 100, 115 );
			SetDex( 100, 102 );
			SetInt( 50, 65 );
			SetHits( 300, 450 );

			SetDamage( 25, 37 );

			SetSkill( SkillName.MagicResist, 40.0, 53.2 );
			SetSkill( SkillName.Tactics, 95.6, 100.0 );
			SetSkill( SkillName.Wrestling, 110.0, 120.0 );

			Fame = 2000;
			Karma = -5000;

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
		}
		
			public override int TreasureMapLevel{ get{ return 4; } }
		
			public override void GenerateLoot()
			{
				AddLoot( LootPack.Average );
			}

			public override bool AlwaysMurderer{ get{ return true; } }

        		public override void OnMovement( Mobile m, Point3D oldLocation ) 
                	{                                                    
       		  		if( m_Talked == false ) 
        	  		{ 
      		      			if ( m.InRange( this, 3 ) && m is PlayerMobile ) 
        				{                
            		   			m_Talked = true; 
            		   			SayRandom( PirateSay, this ); 
           		   			this.Move( GetDirectionTo( m.Location ) );
             		   			SpamTimer t = new SpamTimer(); 
           		   			t.Start(); 
            				} 
        	  		} 
			}

			public override bool OnBeforeDeath()
			{
				this.Say( "Me crew shall seek their revenge on ye!" );
				return base.OnBeforeDeath();
			}

    	  		private class SpamTimer : Timer 
			{ 
		   		public SpamTimer() : base( TimeSpan.FromSeconds( 12 ) ) 
	       	   		{ 
          				Priority = TimerPriority.OneSecond; 
       		   		} 

         	   		protected override void OnTick() 
        	   		{ 
           				m_Talked = false; 
        	   		} 
      			}
			
			private static void SayRandom( string[] say, Mobile m ) 
	        	{ 
	           		m.Say( say[Utility.Random( say.Length )] ); 
			}

			public PirateCaptain( Serial serial ) : base( serial )
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

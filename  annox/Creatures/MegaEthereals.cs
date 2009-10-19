

using System;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Engines.VeteranRewards;

namespace Server.Mobiles
{
	public class MegaEtherealMount : Item, IMount, IMountItem, Engines.VeteranRewards.IRewardItem
	{
		private int m_MountedID;
		private int m_RegularID;
		private Mobile m_Rider;
		private bool m_IsRewardItem;
		private bool m_IsDonationItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; }
		}

		public override double DefaultWeight
		{
			get { return 1.0; }
		}

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public bool IsDonationItem
		{
			get { return m_IsDonationItem; }
			set { m_IsDonationItem = value; InvalidateProperties(); }
		}

		[Constructable]
		public MegaEtherealMount( int itemID, int mountID ) : base( itemID )
		{
			m_MountedID = mountID;
			m_RegularID = itemID;
			m_Rider = null;

			Layer = Layer.Invalid;

			LootType = LootType.Blessed;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if( m_IsDonationItem )
			{
				list.Add( "Donation Ethereal" );
				list.Add( "7.5 sec slower cast time if not a 9mo. Veteran" );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int MountedID
		{
			get
			{
				return m_MountedID;
			}
			set
			{
				if ( m_MountedID != value )
				{
					m_MountedID = value;

					if ( m_Rider != null )
						ItemID = value;
				}
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int RegularID
		{
			get
			{
				return m_RegularID;
			}
			set
			{
				if ( m_RegularID != value )
				{
					m_RegularID = value;

					if ( m_Rider == null )
						ItemID = value;
				}
			}
		}

		public MegaEtherealMount( Serial serial ) : base( serial )
		{
		}

		public override bool DisplayLootType{ get{ return false; } }

		public virtual int FollowerSlots{ get{ return 1; } }

		public void RemoveFollowers()
		{
			if ( m_Rider != null )
				m_Rider.Followers -= FollowerSlots;

			if ( m_Rider != null && m_Rider.Followers < 0 )
				m_Rider.Followers = 0;
		}

		public void AddFollowers()
		{
			if ( m_Rider != null )
				m_Rider.Followers += FollowerSlots;
		}

		public virtual bool Validate( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
				return false;
			}
			else if ( m_IsRewardItem && !Engines.VeteranRewards.RewardSystem.CheckIsUsableBy( from, this, null ) )
			{
				// CheckIsUsableBy sends the message
				return false;
			}
			else if ( !BaseMount.CheckMountAllowed( from, true ) )
			{
				// CheckMountAllowed sends the message
				return false;
			}
			else if ( from.Mounted )
			{
				from.SendLocalizedMessage( 1005583 ); // Please dismount first.
				return false;
			}
			else if ( from.IsBodyMod && !from.Body.IsHuman )
			{
				from.SendLocalizedMessage( 1061628 ); // You can't do that while polymorphed.
				return false;
			}
			else if ( from.HasTrade )
			{
				from.SendLocalizedMessage( 1042317, "", 0x41 ); // You may not ride at this time
				return false;
			}
			else if ( (from.Followers + FollowerSlots) > from.FollowersMax )
			{
				from.SendLocalizedMessage( 1049679 ); // You have too many followers to summon your mount.
				return false;
			}
			else if ( !Multis.DesignContext.Check( from ) )
			{
				// Check sends the message
				return false;
			}

			return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Validate( from ) )
				new EtherealSpell( this, from ).Cast();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 ); // version

			writer.Write( m_IsDonationItem );
			writer.Write( (bool) m_IsRewardItem );

			writer.Write( (int)m_MountedID );
			writer.Write( (int)m_RegularID );
			writer.Write( m_Rider );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			LootType = LootType.Blessed;

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				{
					m_IsDonationItem = reader.ReadBool();
					goto case 2;
				}
				case 2:
				{
					m_IsRewardItem = reader.ReadBool();
					goto case 0;
				}
				case 1: reader.ReadInt(); goto case 0;
				case 0:
				{
					m_MountedID = reader.ReadInt();
					m_RegularID = reader.ReadInt();
					m_Rider = reader.ReadMobile();

					if ( m_MountedID == 0x3EA2 )
						m_MountedID = 0x3EAA;

					break;
				}
			}

			AddFollowers();

			if ( version < 3 && Weight == 0 )
				Weight = -1;
		}

		public override DeathMoveResult OnParentDeath( Mobile parent )
		{
			Rider = null;//get off, move to pack

			return DeathMoveResult.RemainEquiped;
		}

		public static void Dismount( Mobile m )
		{
			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Rider
		{
			get
			{
				return m_Rider;
			}
			set
			{
				if ( value != m_Rider )
				{
					if ( value == null )
					{
						Internalize();
						UnmountMe();

						RemoveFollowers();
						m_Rider = value;
					}
					else
					{
						if ( m_Rider != null )
							Dismount( m_Rider );

						Dismount( value );

						RemoveFollowers();
						m_Rider = value;
						AddFollowers();

						MountMe();
					}
				}
			}
		}

		public void UnmountMe()
		{
			Container bp = m_Rider.Backpack;

			ItemID = m_RegularID;
			Layer = Layer.Invalid;
			Movable = true;

			if ( Hue == 0x4001 )
				Hue = 0;

			if ( bp != null )
			{
				bp.DropItem( this );
			}
			else
			{
				Point3D loc = m_Rider.Location;
				Map map = m_Rider.Map;

				if ( map == null || map == Map.Internal )
				{
					loc = m_Rider.LogoutLocation;
					map = m_Rider.LogoutMap;
				}

				MoveToWorld( loc, map );
			}
		}

		public void MountMe()
		{
			ItemID = m_MountedID;
			Layer = Layer.Mount;
			Movable = false;

			if ( Hue == 0 )
				Hue = 0x4001;

			ProcessDelta();
			m_Rider.ProcessDelta();
			m_Rider.EquipItem( this );
			m_Rider.ProcessDelta();
			ProcessDelta();
		}

		public IMount Mount
		{
			get
			{
				return this;
			}
		}

		public static void StopMounting( Mobile mob )
		{
			if ( mob.Spell is EtherealSpell )
				((EtherealSpell)mob.Spell).Stop();
		}

		public void OnRiderDamaged( int amount, Mobile from, bool willKill )
		{
		}

        //pre SVN 187
        //private class EtherealSpell : Spell
        //{
        //    private static SpellInfo m_Info = new SpellInfo( "Ethereal Mount", "", SpellCircle.Second, 230 );

        //    private MegaEtherealMount m_Mount;
        //    private Mobile m_Rider;

        //    public EtherealSpell( MegaEtherealMount mount, Mobile rider ) : base( rider, null, m_Info )
        //    {
        //        m_Rider = rider;
        //        m_Mount = mount;
        //    }

        //    public override bool ClearHandsOnCast{ get{ return false; } }
        //    public override bool RevealOnCast{ get{ return false; } }

        //    public override TimeSpan GetCastRecovery()
        //    {
        //        return TimeSpan.Zero;
        //    }

        //    public override TimeSpan GetCastDelay()
        //    {
        //        return TimeSpan.FromSeconds( ( (m_Mount.IsDonationItem && RewardSystem.GetRewardLevel( m_Rider ) < 3 )? 0 : 0 ) );
        //    }

        //    public override int GetMana()
        //    {
        //        return 0;
        //    }

        //    public override bool ConsumeReagents()
        //    {
        //        return true;
        //    }

        //    public override bool CheckFizzle()
        //    {
        //        return true;
        //    }

        //    private bool m_Stop;

        //    public void Stop()
        //    {
        //        m_Stop = true;
        //        Disturb( DisturbType.Hurt, false, false );
        //    }

        //    public override bool CheckDisturb( DisturbType type, bool checkFirst, bool resistable )
        //    {
        //        if ( type == DisturbType.EquipRequest || type == DisturbType.UseRequest/* || type == DisturbType.Hurt*/ )
        //            return false;

        //        return true;
        //    }

        //    public override void DoHurtFizzle()
        //    {
        //        if ( !m_Stop )
        //            base.DoHurtFizzle();
        //    }

        //    public override void DoFizzle()
        //    {
        //        if ( !m_Stop )
        //            base.DoFizzle();
        //    }

        //    public override void OnDisturb( DisturbType type, bool message )
        //    {
        //        if ( message && !m_Stop )
        //            Caster.SendLocalizedMessage( 1049455 ); // You have been disrupted while attempting to summon your ethereal mount!

        //    }

        //    public override void OnCast()
        //    {
        //        if ( !m_Mount.Deleted && m_Mount.Rider == null && m_Mount.Validate( m_Rider ) )
        //            m_Mount.Rider = m_Rider;

        //        FinishSequence();
        //    }
        //}

        private class EtherealSpell : Spell
        {
            private static SpellInfo m_Info = new SpellInfo("Ethereal Mount", "", 230);

            private MegaEtherealMount m_Mount;
            private Mobile m_Rider;

            public EtherealSpell(MegaEtherealMount mount, Mobile rider)
                : base(rider, null, m_Info)
            {
                m_Rider = rider;
                m_Mount = mount;
            }

            public override bool ClearHandsOnCast { get { return false; } }
            public override bool RevealOnCast { get { return false; } }

            public override TimeSpan GetCastRecovery()
            {
                return TimeSpan.Zero;
            }

            public override double CastDelayFastScalar { get { return 0; } }

            public override TimeSpan CastDelayBase
            {
                get
                {
                    return TimeSpan.FromSeconds(((m_Mount.IsDonationItem && RewardSystem.GetRewardLevel(m_Rider) < 3) ? 12.5 : 5.0));
                }
            }

            public override int GetMana()
            {
                return 0;
            }

            public override bool ConsumeReagents()
            {
                return true;
            }

            public override bool CheckFizzle()
            {
                return true;
            }

            private bool m_Stop;

            public void Stop()
            {
                m_Stop = true;
                Disturb(DisturbType.Hurt, false, false);
            }

            public override bool CheckDisturb(DisturbType type, bool checkFirst, bool resistable)
            {
                if (type == DisturbType.EquipRequest || type == DisturbType.UseRequest/* || type == DisturbType.Hurt*/ )
                    return false;

                return true;
            }

            public override void DoHurtFizzle()
            {
                if (!m_Stop)
                    base.DoHurtFizzle();
            }

            public override void DoFizzle()
            {
                if (!m_Stop)
                    base.DoFizzle();
            }

            public override void OnDisturb(DisturbType type, bool message)
            {
                if (message && !m_Stop)
                    Caster.SendLocalizedMessage(1049455); // You have been disrupted while attempting to summon your ethereal mount!

                //m_Mount.UnmountMe();
            }

            public override void OnCast()
            {
                if (!m_Mount.Deleted && m_Mount.Rider == null && m_Mount.Validate(m_Rider))
                    m_Mount.Rider = m_Rider;

                FinishSequence();
            }
        }
	}

//Old Ethereals Begin//////////////////////////////////////////////////////////////////////////////////////////////////

	public class MegaEtherealHorse : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealHorse() : base( 0x20DD, 0x3EAA )
		{
			Name = "Ethereal Horse Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealHorse( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal horse" )
				Name = null;

			if ( ItemID == 0x2124 )
				ItemID = 0x20DD;
		}
	}

	public class MegaEtherealLlama : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealLlama() : base( 0x20F6, 0x3EAB )
		{
			Name = "Ethereal Llama Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealLlama( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal llama" )
				Name = null;
		}
	}

	public class MegaEtherealOstard : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealOstard() : base( 0x2135, 0x3EAC )
		{
			Name = "Ethereal Ostard Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealOstard( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal ostard" )
				Name = null;
		}
	}

	public class MegaEtherealRidgeback : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealRidgeback() : base( 0x2615, 0x3E9A )
		{
			Name = "Ethereal Ridgeback Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealRidgeback( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal ridgeback" )
				Name = null;
		}
	}

	public class MegaEtherealUnicorn : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealUnicorn() : base( 0x25CE, 0x3E9B )
		{
			Name = "Ethereal Unicorn Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealUnicorn( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal unicorn" )
				Name = null;
		}
	}

	public class MegaEtherealBeetle : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealBeetle() : base( 0x260F, 0x3E97 )
		{
			Name = "Ethereal Beetle Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealBeetle( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal beetle" )
				Name = null;
		}
	}

	public class MegaEtherealKirin : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealKirin() : base( 0x25A0, 0x3E9C )
		{
			Name = "Ethereal Ki-Rin Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealKirin( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal kirin" )
				Name = null;
		}
	}

	public class MegaEtherealSwampDragon : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealSwampDragon() : base( 0x2619, 0x3E98 )
		{
			Name = "Ethereal Swamp Dragon Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealSwampDragon( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal swamp dragon" )
				Name = null;
		}
	}

//New Ethereals End////////////////////////////////////////////////////////////////////////////////////////////////////

//New Ethereals Begin//////////////////////////////////////////////////////////////////////////////////////////////////

	public class MegaEtherealChargeroftheFallen : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealChargeroftheFallen() : base( 11676, 0x3E92 )
		{
			Name = "Ethereal Charger of the Fallen Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealChargeroftheFallen( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal charger of the fallen statuette" )
				Name = null;			
		}
	}

	public class MegaEtherealChimera : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealChimera() : base( 11669, 0x3E90 )
		{
			Name = "Ethereal Chimera Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealChimera( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal chimera statuette" )
				Name = null;
		}
	}

	public class MegaEtherealCuSidhe : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealCuSidhe() : base( 11670, 0x3E91 )
		{
			Name = "Ethereal Cu Sidhe Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealCuSidhe( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal cu sidhe statuette" )
				Name = null;
		}
	}

	public class MegaEtherealHiryu : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealHiryu() : base( 0x276A, 0x3E94 )
		{
			Name = "Ethereal Hiryu Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealHiryu( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal hiryu statuette" )
				Name = null;
		}
	}

	public class MegaEtherealHellsteed : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealHellsteed() : base( 0x2617, 0x3EBB )
		{
			Name = "Ethereal Hell Steed Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealHellsteed( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal hell steed statuette" )
				Name = null;
		}
	}

	public class MegaEtherealArmoredSwampDragon : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealArmoredSwampDragon() : base( 0x2619, 0x3EBE )
		{
			Name = "Ethereal Armored Swamp Dragon Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealArmoredSwampDragon( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal armored swamp dragon statuette" )
				Name = null;			
		}
	}

	public class MegaEtherealForestOstard : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealForestOstard() : base( 0x2137, 0x3EA5 )
		{
			Name = "Ethereal Forest Ostard Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealForestOstard( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal forest ostard statuette" )
				Name = null;
		}
	}

	public class MegaEtherealFrenziedOstard : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealFrenziedOstard() : base( 0x2136, 0x3EA4 )
		{
			Name = "Ethereal Frenzied Ostard Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealFrenziedOstard( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal frenzied ostard statuette" )
				Name = null;
		}
	}

	public class MegaEtherealSavageRidgeback : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealSavageRidgeback() : base( 0x2615, 0x3EB8 )
		{
			Name = "Ethereal Savage Ridgeback Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealSavageRidgeback( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal savage ridgeback statuette" )
				Name = null;
		}
	}

	public class MegaEtherealPolarBear : MegaEtherealMount 
	{
		[Constructable] 
		public MegaEtherealPolarBear() : base( 8417, 16069 )
		{ 
			Name = "Ethereal Polar Bear Statuette";
			LootType = LootType.Blessed; 
		} 

		public MegaEtherealPolarBear( Serial serial ) : base( serial ) 
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

			if ( Name != "an ethereal polar bear statuette" )
				Name = null;
		} 
	}

	public class MegaEtherealSeaHorse : MegaEtherealMount
	{
		[Constructable]
		public MegaEtherealSeaHorse() : base( 0x25BA, 0x3EB3 )
		{
			Name = "Ethereal Sea Horse Statuette";
			LootType = LootType.Blessed;
		}

		public MegaEtherealSeaHorse( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal sea horse statuette" )
				Name = null;
		}

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.CanSwim = true;
				from.Criminal = false;
			}
		}
	}

//New Ethereals End////////////////////////////////////////////////////////////////////////////////////////////////////

}
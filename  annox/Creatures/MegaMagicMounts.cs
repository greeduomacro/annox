using System;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Engines.VeteranRewards;

namespace Server.Mobiles
{
	public class MegaMagicMount : Item, IMount, IMountItem, Engines.VeteranRewards.IRewardItem
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
		public MegaMagicMount( int itemID, int mountID ) : base( itemID )
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
				list.Add( "Donation Magic Mount" );
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

		public MegaMagicMount( Serial serial ) : base( serial )
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

//UNMOUNTED HUE BEGIN ///////////////////////////////////////////////////////////////////////////////////

			if ( Name != null )
			{
//Standard Mounts______________________________________________________________________________________//
			if ( Name == "Magic Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Llama Statuette" )
				Hue = 0;
//NonStandard Mounts___________________________________________________________________________________//
			else
			if ( Name == "Magic Ostard Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Forest Ostard Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Frenzied Ostard Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Ridgeback Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Savage Ridgeback Statuette" )
				Hue = 961;
			else
			if ( Name == "Magic Unicorn Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Beetle Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Fire Beetle Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Kirin Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Swamp Dragon Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Armored Swamp Dragon Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Chimera Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Cu Sidhe Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Lesser Hiryu Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Hiryu Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Polar Bear Statuette" )
				Hue = 0;
//Special Mounts_______________________________________________________________________________________//
			else
			if ( Name == "Charger of the Fallen" )
				Hue = 0;
			else
			if ( Name == "Magic Sea Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Skeletal Steed Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Silver Steed Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Dark Steed Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Council of Mages War Horse Statuette" )
				Hue = 506;
			else
			if ( Name == "Magic Minax War Horse Statuette" )
				Hue = 1157;
			else
			if ( Name == "Magic True Britannians War Horse Statuette" )
				Hue = 1254;
			else
			if ( Name == "Magic Shadowlords War Horse Statuette" )
				Hue = 1429;
			else
			if ( Name == "Magic Fire Steed Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Nightmare Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Rend Statuette" )
				Hue = 1175;
			else
			if ( Name == "Magic Red Death Statuette" )
				Hue = 32;
			}
			else
			if ( Name == "Magic Ice Beetle Statuette" )
				Hue = 1152;
			else
			{
				Hue = 0;
			}

//UNMOUNTED HUE END /////////////////////////////////////////////////////////////////////////////////////

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

//MOUNTED HUE BEGIN /////////////////////////////////////////////////////////////////////////////////////

			if ( Name != null )
			{
//Standard Mounts______________________________________________________________________________________//
			if ( Name == "Magic Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Llama Statuette" )
				Hue = 0;
//NonStandard Mounts___________________________________________________________________________________//
			else
			if ( Name == "Magic Ostard Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Forest ostard Statuette" )
				Hue = 0; //Random?
			else
			if ( Name == "Magic Frenzied Ostard Statuette" )
				Hue = 0; //Random?
			else
			if ( Name == "Magic Ridgeback Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Savage Ridgeback Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Unicorn Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Beetle Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Fire Beetle Statuette" )
				Hue = 1161;
			else
			if ( Name == "Magic Kirin Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Swamp Dragon Statuette" )
				Hue = 2129;
			else
			if ( Name == "Magic Armored Swamp Dragon Statuette" )
				Hue = 0; //Random?
			else
			if ( Name == "Magic Chimera Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Cu Sidhe Statuette" )
				Hue = 0; //Random?
			else
			if ( Name == "Magic Lesser Hiryu Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Hiryu Statuette" )
				Hue = 0; //Random?
			else
			if ( Name == "Magic Polar Bear Statuette" )
				Hue = 0;
//Special Mounts_______________________________________________________________________________________//
			else
			if ( Name == "Charger of the Fallen" )
				Hue = 0;
			else
			if ( Name == "Magic Sea Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Skeletal Steed Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Silver Steed Statuette" )
				Hue = 1154;
			else
			if ( Name == "Magic Dark Steed Statuette" )
				Hue = 1175;
			else
			if ( Name == "Magic Council of Mages War Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Minax War Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic True Britannians War Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Shadowlords War Horse Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Fire Steed Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Nightmare Statuette" )
				Hue = 0;
			else
			if ( Name == "Magic Rend Statuette" )
				Hue = 1175;
			else
			if ( Name == "Magic Red Death Statuette" )
				Hue = 32;
			}
			else
			if ( Name == "Magic Ice Beetle Statuette" )
				Hue = 1152;
			else
			{
				Hue = 0;
			}

//MOUNTED HUE END ///////////////////////////////////////////////////////////////////////////////////////

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

        //pre-SVN 187
        //private class EtherealSpell : Spell
        //{
        //    private static SpellInfo m_Info = new SpellInfo( "Ethereal Mount", "", SpellCircle.Second, 230 );

        //    private MegaMagicMount m_Mount;
        //    private Mobile m_Rider;

        //    public EtherealSpell( MegaMagicMount mount, Mobile rider ) : base( rider, null, m_Info )
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
        //            Caster.SendLocalizedMessage( 1049455 ); // You have been disrupted while attempting to summon your magic mount!

        //        //m_Mount.UnmountMe();
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

            private MegaMagicMount m_Mount;
            private Mobile m_Rider;

            public EtherealSpell(MegaMagicMount mount, Mobile rider)
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

//Standard Mounts Begin//////////////////////////////////////////////////////////////

	public class MegaMagicHorse : MegaMagicMount
	{

		[Constructable]
		public MegaMagicHorse() : base( 0x20DD, 0x3EA1 )
		{
			Name = "Magic Horse Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicHorse( Serial serial ) : base( serial )
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

			if ( Name == "a magic horse" )
				Name = null;

		}
	}

	public class MegaMagicLlama : MegaMagicMount
	{

		[Constructable]
		public MegaMagicLlama() : base( 0x20F6, 0x3EA6 )
		{
			Name = "Magic Llama Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicLlama( Serial serial ) : base( serial )
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

			if ( Name == "a magic llama" )
				Name = null;
		}
	}

//Standard Mounts End//////////////////////////////////////////////////////////////

//NonStandard Mounts Begin/////////////////////////////////////////////////////////

	public class MegaMagicOstard : MegaMagicMount
	{

		[Constructable]
		public MegaMagicOstard() : base( 0x25B2, 0x3EA3 )
		{
			Name = "Magic Ostard Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicOstard( Serial serial ) : base( serial )
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

			if ( Name == "a magic ostard" )
				Name = null;
		}
	}

	public class MegaMagicForestOstard : MegaMagicMount
	{

		[Constructable]
		public MegaMagicForestOstard() : base( 0x25B3, 0x3EA5 )
		{
			Name = "Magic Forest Ostard Statuette";
//TODO Random Osty Hues?//
//			Hue  = 0;
//TDO END//
			LootType = LootType.Blessed;
		}

		public MegaMagicForestOstard( Serial serial ) : base( serial )
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

			if ( Name == "a magic forest ostard" )
				Name = null;
		}
	}

	public class MegaMagicFrenziedOstard : MegaMagicMount
	{

		[Constructable]
		public MegaMagicFrenziedOstard() : base( 0x25B4, 0x3EA4 )
		{
			Name = "Magic Frenzied Ostard Statuette";
//TODO Random Osty Hues?//
//			Hue  = 0;
//TODO END//
			LootType = LootType.Blessed;
		}

		public MegaMagicFrenziedOstard( Serial serial ) : base( serial )
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

			if ( Name == "a magic frenzied ostard" )
				Name = null;
		}
	}

	public class MegaMagicRidgeback : MegaMagicMount
	{

		[Constructable]
		public MegaMagicRidgeback() : base( 0x2615, 0x3E9A )
		{
			Name = "Magic Ridgeback Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicRidgeback( Serial serial ) : base( serial )
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

			if ( Name == "a magic ridgeback" )
				Name = null;
		}
	}

	public class MegaMagicSavageRidgeback : MegaMagicMount
	{

		[Constructable]
		public MegaMagicSavageRidgeback() : base( 0x2615, 0x3EB8 )
		{
			Name = "Magic Savage Ridgeback Statuette";
			Hue  = 961;
			LootType = LootType.Blessed;
		}

		public MegaMagicSavageRidgeback( Serial serial ) : base( serial )
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

			if ( Name == "a magic savage ridgeback" )
				Name = null;
		}
	}

	public class MegaMagicUnicorn : MegaMagicMount
	{

		[Constructable]
		public MegaMagicUnicorn() : base( 0x25CE, 0x3E9B )
		{
			Name = "Magic Unicorn Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicUnicorn( Serial serial ) : base( serial )
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

			if ( Name == "a magic unicorn" )
				Name = null;
		}
	}

	public class MegaMagicBeetle : MegaMagicMount
	{

		[Constructable]
		public MegaMagicBeetle() : base( 0x260F, 0x3E97 )
		{
			Name = "Magic Beetle Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicBeetle( Serial serial ) : base( serial )
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

			if ( Name == "a magic beetle" )
				Name = null;
		}
	}

	public class MegaMagicFireBeetle : MegaMagicMount
	{

		[Constructable]
		public MegaMagicFireBeetle() : base( 0x281C, 0x3E95 )
		{
			Name = "Magic Fire Beetle Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicFireBeetle( Serial serial ) : base( serial )
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

			if ( Name == "a magic fire beetle" )
				Name = null;
		}
	}

	public class MegaMagicKirin : MegaMagicMount
	{

		[Constructable]
		public MegaMagicKirin() : base( 0x25A0, 0x3E9C )
		{
			Name = "Magic Kirin Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicKirin( Serial serial ) : base( serial )
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

			if ( Name == "a magic kirin" )
				Name = null;
		}
	}

	public class MegaMagicSwampDragon : MegaMagicMount
	{

		[Constructable]
		public MegaMagicSwampDragon() : base( 0x2619, 0x3E98 )
		{
			Name = "Magic Swamp Dragon Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicSwampDragon( Serial serial ) : base( serial )
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

			if ( Name == "a magic swamp dragon" )
				Name = null;
		}
	}

	public class MegaMagicArmoredSwampDragon : MegaMagicMount
	{

		[Constructable]
		public MegaMagicArmoredSwampDragon() : base( 0x2619, 0x3EBE )
		{
			Name = "Magic Armored Swamp Dragon Statuette";
//TODO Armor Ore Hues//
//			Hue  = 0;
//TDO END//
			LootType = LootType.Blessed;
		}

		public MegaMagicArmoredSwampDragon( Serial serial ) : base( serial )
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

			if ( Name == "a magic swamp dragon" )
				Name = null;
		}
	}

	public class MegaMagicChimera : MegaMagicMount
	{

		[Constructable]
		public MegaMagicChimera() : base( 0x2D95, 0x3E90 )
		{
			Name = "Magic Chimera Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicChimera( Serial serial ) : base( serial )
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

			if ( Name == "a magic chimera" )
				Name = null;
		}
	}

	public class MegaMagicCuSidhe : MegaMagicMount
	{

		[Constructable]
		public MegaMagicCuSidhe() : base( 0x2D96, 0x3E91 )
		{
			Name = "Magic Cu Sidhe Statuette";
//TODO Cu Sidhe Hues//
//			Hue  = 0;
//TOD END//
			LootType = LootType.Blessed;
		}

		public MegaMagicCuSidhe( Serial serial ) : base( serial )
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

			if ( Name == "a magic cu sidhe" )
				Name = null;
		}
	}

	public class MegaMagicLesserHiryu : MegaMagicMount
	{

		[Constructable]
		public MegaMagicLesserHiryu() : base( 0x276A, 0x3E94 )
		{
			Name = "Magic Lesser Hiryu Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicLesserHiryu( Serial serial ) : base( serial )
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

			if ( Name == "a magic lesser hiryu" )
				Name = null;
		}
	}

	public class MegaMagicHiryu : MegaMagicMount
	{

		[Constructable]
		public MegaMagicHiryu() : base( 0x276A, 0x3E94 )
		{
			Name = "Magic Hiryu Statuette";
//TODO Random Hiryu Hues//
//			Hue  = 0;
//TODO END//
			LootType = LootType.Blessed;
		}

		public MegaMagicHiryu( Serial serial ) : base( serial )
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

			if ( Name == "a magic hiryu" )
				Name = null;
		}
	}

	public class MegaMagicPolarBear : MegaMagicMount 
	{

		[Constructable] 
		public MegaMagicPolarBear() : base( 8417, 16069 )
		{ 
			Name = "Magic Polar Bear Statuette";
			Hue  = 0;
			LootType = LootType.Blessed; 
		} 

		public MegaMagicPolarBear( Serial serial ) : base( serial ) 
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

			if ( Name != "a magic polar bear" )
				Name = null;
		} 
	}

//NonStandard Mounts End///////////////////////////////////////////////////////////////////

//Special Mounts Begin/////////////////////////////////////////////////////////////////////

	public class MegaChargeroftheFallen : MegaMagicMount
	{

		[Constructable]
		public MegaChargeroftheFallen() : base( 0x2D9C, 0x3E92 )
		{
			Name = "Charger of the Fallen";
			LootType = LootType.Blessed;
		}

		public MegaChargeroftheFallen( Serial serial ) : base( serial )
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

			if ( Name == "charger of the fallen" )
				Name = null;			
		}
	}

	public class MegaMagicSeaHorse : MegaMagicMount
	{

		[Constructable]
		public MegaMagicSeaHorse() : base( 0x25BA, 0x3EB3 )
		{
			Name = "Magic Sea Horse Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicSeaHorse( Serial serial ) : base( serial )
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

			if ( Name == "an magic sea horse" )
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

	public class MegaMagicSkeletalsteed : MegaMagicMount
	{

		[Constructable]
		public MegaMagicSkeletalsteed() : base( 0x2617, 0x3EBB )
		{
			Name = "Magic Skeletal Steed";
			LootType = LootType.Blessed;
		}

		public MegaMagicSkeletalsteed( Serial serial ) : base( serial )
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

			if ( Name == "a magic skeletal steed" )
				Name = null;
		}
	}

	public class MegaMagicSilverSteed : MegaMagicMount
	{

		[Constructable]
		public MegaMagicSilverSteed() : base( 0x259D, 0x3E9F )
		{
			Name = "Magic Silver Steed Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicSilverSteed( Serial serial ) : base( serial )
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

			if ( Name == "a magic silver steed" )
				Name = null;

		}
	}

	public class MegaMagicDarkSteed : MegaMagicMount
	{

		[Constructable]
		public MegaMagicDarkSteed() : base( 0x259B, 0x3EA1 )
		{
			Name = "Magic Dark Steed Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicDarkSteed( Serial serial ) : base( serial )
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

			if ( Name == "a magic dark steed" )
				Name = null;

		}
	}

	public class MegaMagicCoMWarHorse : MegaMagicMount
	{

		[Constructable]
		public MegaMagicCoMWarHorse() : base( 0x2120, 0x3EB1 )
		{
			Name = "Magic Council of Mages War Horse Statuette";
			Hue  = 506;
			LootType = LootType.Blessed;
		}

		public MegaMagicCoMWarHorse( Serial serial ) : base( serial )
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

			if ( Name == "a magic council of mages war horse" )
				Name = null;

		}
	}
	public class MegaMagicMinaxWarHorse : MegaMagicMount
	{

		[Constructable]
		public MegaMagicMinaxWarHorse() : base( 0x2121, 0x3EAF )
		{
			Name = "Magic Minax War Horse Statuette";
			Hue  = 1157;
			LootType = LootType.Blessed;
		}

		public MegaMagicMinaxWarHorse( Serial serial ) : base( serial )
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

			if ( Name == "a magic minax horse" )
				Name = null;

		}
	}

	public class MegaMagicTBWarHorse : MegaMagicMount
	{

		[Constructable]
		public MegaMagicTBWarHorse() : base( 0x2124, 0x3EB2 )
		{
			Name = "Magic True Britannians War Horse Statuette";
			Hue  = 1254;
			LootType = LootType.Blessed;
		}

		public MegaMagicTBWarHorse( Serial serial ) : base( serial )
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

			if ( Name == "a magic true britannians war horse" )
				Name = null;

		}
	}

	public class MegaMagicSLWarHorse : MegaMagicMount
	{

		[Constructable]
		public MegaMagicSLWarHorse() : base( 0x211F, 0x3EB0 )
		{
			Name = "Magic Shadowlords War Horse Statuette";
			Hue  = 1429;
			LootType = LootType.Blessed;
		}

		public MegaMagicSLWarHorse( Serial serial ) : base( serial )
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

			if ( Name == "a magic shadowlords war horse" )
				Name = null;

		}
	}

	public class MegaMagicFireSteed : MegaMagicMount
	{

		[Constructable]
		public MegaMagicFireSteed() : base( 0x21F1, 0x3E9E )
		{
			Name = "Magic Fire Steed Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicFireSteed( Serial serial ) : base( serial )
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

			if ( Name == "a magic fire steed" )
				Name = null;

		}
	}

	public class MegaMagicNightmare : MegaMagicMount
	{

		[Constructable]
		public MegaMagicNightmare() : base( 0x259C, 0x3EB7 )
		{
			Name = "Magic Nightmare Statuette";
			LootType = LootType.Blessed;
		}

		public MegaMagicNightmare( Serial serial ) : base( serial )
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

			if ( Name == "a magic nightmare" )
				Name = null;

		}
	}

	public class MegaMagicRend : MegaMagicMount
	{

		[Constructable]
		public MegaMagicRend() : base( 0x2D95, 0x3E90 )
		{
			Name = "Magic Rend Statuette";
			Hue  = 1175;
			LootType = LootType.Blessed;
		}

		public MegaMagicRend( Serial serial ) : base( serial )
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

			if ( Name == "a magic rend" )
				Name = null;
		}
	}

	public class MegaMagicRedDeath : MegaMagicMount
	{

		[Constructable]
		public MegaMagicRedDeath() : base( 0x2617, 0x3EBB )
		{
			Name = "Magic Red Death Statuette";
			Hue  = 32;
			LootType = LootType.Blessed;
		}

		public MegaMagicRedDeath( Serial serial ) : base( serial )
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

			if ( Name == "a magic red death" )
				Name = null;
		}
	}

	public class MegaMagicIceBeetle : MegaMagicMount
	{

		[Constructable]
		public MegaMagicIceBeetle() : base( 0x281C, 0x3E97 )
		{
			Name = "Magic Ice Beetle Statuette";
			Hue  = 1152;
			LootType = LootType.Blessed;
		}

		public MegaMagicIceBeetle( Serial serial ) : base( serial )
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

			if ( Name == "a magic ice beetle" )
				Name = null;
		}
	}

//Special Mounts End////////////////////////////////////////////////////////////////////////

//Custom Animation Mounts Begin//
//			       //
//   Reserved for later use    //
//			       //
///Custom Animation Mounts End///

}
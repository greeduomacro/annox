using System;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class ParchmentMessage : Item
	{
		public static int GetRandomLevel()
		{
			return Utility.RandomMinMax( 1, 3 );
		}

		private Map m_TargetMap;
		private int m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public Map TargetMap
		{
			get{ return m_TargetMap; }
			set{ m_TargetMap = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level
		{
			get{ return m_Level; }
			set{ m_Level = Math.Max( 1, Math.Min( value, 4 ) ); }
		}

		[Constructable]
		public ParchmentMessage() : this( Map.Trammel )
		{
		}

		public ParchmentMessage( Map map ) : this( map, GetRandomLevel() )
		{
		}

		[Constructable]
		public ParchmentMessage( Map map, int level ) : base( 0x227B )
		{
			Name = "a parchment message";
			Weight = 1.0;
			Hue = 0x2EF;
			m_TargetMap = map;
			m_Level = level;
		}

		public ParchmentMessage( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version

			writer.Write( (int) m_Level );

			writer.Write( m_TargetMap );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 2:
				{
					m_Level = reader.ReadInt();
					goto case 1;
				}
				case 1:
				{
					m_TargetMap = reader.ReadMap();
					break;
				}
				case 0:
				{
					m_TargetMap = Map.Trammel;
					break;
				}
			}

			if ( version < 2 )
				m_Level = GetRandomLevel();
		}

		private double GetMinSkillLevel()
		{
			switch ( m_Level )
			{
				case 1: return -3.0;
				case 2: return 41.0;
				case 3: return 51.0;
				case 4: return 61.0;
				case 5: return 70.0;
				case 6: return 70.0;

				default: return 0.0;
			}
		}

		private bool HasRequiredSkill( Mobile from )
		{
			return ( from.Skills[SkillName.Cartography].Value >= GetMinSkillLevel() );
		}

		public override void OnDoubleClick( Mobile from )
		{
			double minSkill = GetMinSkillLevel();

			if ( IsChildOf( from.Backpack ) )
			{
				if ( from.Skills[SkillName.Cartography].Value < minSkill )
					from.SendMessage( "You cannot make anything out of the parchment." );

				double maxSkill = minSkill + 60.0;

				if ( !from.CheckSkill( SkillName.Cartography, minSkill, maxSkill ) )
				{
					from.SendMessage( "You try to read the parchment, but fail." );
					return;
				}
				else
				{
					from.SendMessage( "You are able to figure out what the parchment says." );
					from.AddToBackpack( new TreasureMessage( m_Level, m_TargetMap ) );
					Delete();
				}

			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}
	}
}
using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class GuardedTeleporter : Teleporter, ILinkedCreatureObject
	{
		//ILinkedCreatureObject properties
		
		//set this away from the default (BaseLinkedCreature) if you want only a particular creature type to
		//"guard" the door
		Type _LinkedCreatureGuardType;
		
		Rectangle2D _GuardedRegion;
		Map _GuardedMap;
		
		Point3D _TossPoint;
		Map _TossMap;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Type LinkedCreatureGuardType
		{
			get
			{ 
				if( _LinkedCreatureGuardType == null || !_LinkedCreatureGuardType.IsSubclassOf( typeof( Mobile ) ) )
				{
					_LinkedCreatureGuardType = typeof( BaseLinkedCreature );
				}
				return _LinkedCreatureGuardType; 
			}
			set{ _LinkedCreatureGuardType = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Rectangle2D GuardedRegion
		{
			get{ return _GuardedRegion; }
			set{ _GuardedRegion = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Map GuardedMap
		{
			get{ return _GuardedMap; }
			set{ _GuardedMap = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D TossPoint
		{
			get{ return _TossPoint; }
			set{ _TossPoint = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public Map TossMap
		{
			get{ return _TossMap; }
			set{ _TossMap = value; }
		}
		
		
		public void Lockdown()
		{
			//teleporters do not need to be forcibly shut, as they simply won't function if they're not on.
			
			//TODO: if the teleporter is visible, have it report something?
			
			
			//don't bother tossing them if there's no toss point defined
			if( _TossPoint == Point3D.Zero || _TossMap == Map.Internal )
			{
				return;
			}
			
			
			IPooledEnumerable ie = GuardedMap.GetMobilesInBounds( GuardedRegion );
			
			List<Mobile> totoss = new List<Mobile>();
			
			foreach( Mobile m in ie )
			{
				//toss players and pets
				if( m is PlayerMobile || m is BaseCreature && ((BaseCreature)m).Controlled )
				{
					totoss.Add( m );
				}
			}
			
			ie.Free();
			
			foreach( Mobile m in totoss )
			{
				m.MoveToWorld( _TossPoint, _TossMap );
			}
					
		}
				
		
		[Constructable]
		public GuardedTeleporter() : this( new Point3D( 0, 0, 0 ), null, false )
		{
		}

		[Constructable]
		public GuardedTeleporter( Point3D pointDest, Map mapDest ) : this( pointDest, mapDest, false )
		{
		}

		[Constructable]
		public GuardedTeleporter( Point3D pointDest, Map mapDest, bool creatures ) : base( pointDest, mapDest, creatures  )
		{
		}
		
		public GuardedTeleporter( Serial serial ) : base( serial )
		{
		}
		
		public override bool OnMoveOver( Mobile from )
		{
			if( !BaseLinkedCreature.IsAccessible( this ) )
			{
				from.SendMessage( "You must defeat the creatures guarding this before proceeding." );
				return false;
			}
			
			return base.OnMoveOver( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( 0 );
			
			writer.Write( LinkedCreatureGuardType.Name );
			
			writer.Write( _GuardedRegion );
			writer.Write( _GuardedMap );
		
			writer.Write( _TossPoint );
			writer.Write( _TossMap );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			_LinkedCreatureGuardType = ScriptCompiler.FindTypeByName( reader.ReadString() );
			
			_GuardedRegion = reader.ReadRect2D();
			_GuardedMap = reader.ReadMap();
			
			_TossPoint = reader.ReadPoint3D();
			_TossMap = reader.ReadMap();
		}
			
	}

}
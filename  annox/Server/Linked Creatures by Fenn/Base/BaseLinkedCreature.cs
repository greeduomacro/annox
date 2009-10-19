using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Regions;
using Server.Engines.CannedEvil;
using Server.Misc;
using Server.Network;


namespace Server.Mobiles
{
	//base class for Linked creatures.  All special functionality, linking, and damage modifiers is handled here
	public class BaseLinkedCreature : BaseCreature
	{
		//you do NOT want these tamable!
		public override sealed bool AllowMaleTamer{ get{ return false; } }
		public override sealed bool AllowFemaleTamer{ get{ return false; } }
		
		//set this true in an inherited class to allow them to link to any linkable anywhere in the world
		public virtual bool GlobalScopeLink{ get{ return false; } }
		
		//set this true in an inherited class to allow them to link to other cross-creature linkable types of linkable creatures
		public virtual bool CrossCreatureLink{ get{ return false; } }
		
		//set this false in an inherited class to disallow them to link with the same class of creature
		public virtual bool LinkToSameClass{ get{ return true; } }
		
		//set this true in an inherited class to allow the creature to link with linkable creatures in an opposite scope ( global vs. local )
		public virtual bool CrossScopeLink{ get{ return false; } }

		//set this true in an inherited creature to disallow pets from damaging the creature
		public virtual bool BlockPetDamage{ get{ return false; } }
		
		//set this true in an inherited creature to slaughter pets on contact
		public virtual bool KillPets{ get{ return false; } }
		
		//set this higher in an inherited creature to force this number to link before the creatures are attackable
		public virtual int MinLinkNum{ get{ return 0; } }
		
		//set this in an inherited creature to cap the number to link.  0 means unlimited # of links
		public virtual int MaxLinkNum{ get{ return 0; } }
		
		//set this true in an inherited creature to force all creatures to be killed at once
		public virtual bool SynchKill{ get{ return false; } }
		
		//set this true in an inherited creature to buff all surviving creatures when one is killed
		public virtual bool BuffOthersOnKill{ get{ return false; } }
		
				
		//change this to change how far a local scope linked creature will perceive other creatures to link to
		public virtual int LocalLinkPerceptionRange{ get{ return 10; } }
		
		//sound effect, particle effect reference numbers for damage fail
		public virtual int NoDamageEffect{ get{ return 0x374A; } }
		public virtual int NoDamageSound{ get{ return 0x53A; } }
		
		//sound effect, particle effect reference numbers for when a fellow linked creature falls
		public virtual int KillLinkedEffect{ get{ return 0x3728; } }
		public virtual int KillLinkedSound{ get{ return 0x215; } }
		
		
		//used for development and DebugLinkedCreaturesging.  May not ever need to be used unless you wanna see them chatter a bit
		public virtual bool DebugLinkedCreatures{ get{ return false; } }
		
		//this stores the list of all linked creatures that are linked with this one.
		protected List<BaseLinkedCreature> _LinkedCreatures;
		
		
		//the constructor sits inline with the standard BaseCreature constructor, allowing for easy
		//development of custom linked creatures
		public BaseLinkedCreature(AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed ) : base( ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed )
		{
			_LinkedCreatures = new List<BaseLinkedCreature>();
			
			//keep it immortal, hidden, and frozen until it has linked to the desired number
			Blessed = true;
			Frozen = true;
			Hidden = true;
			
			//wait for the mobile to be fully placed in the world before trying to link
			Timer.DelayCall( TimeSpan.FromSeconds( 1 ), new TimerStateCallback( Link_Callback ), null );
			
		}

		public BaseLinkedCreature( Serial serial ) : base( serial )
		{
		}
		
		
		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			//this kills pets if the KillPets is set true
			if ( to is BaseCreature )
			{
				BaseCreature creature = (BaseCreature)to;
				if( creature.Controlled && KillPets )
				{
					if( DebugLinkedCreatures )
					{
						PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Killing Pet*" );
					}
					creature.Kill();
				}
					
			}
			
			base.AlterMeleeDamageTo( to, ref damage );
		}

		//these handles damage if the linked creature cannot be killed
		public override void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
			CheckDamageFrom( from, ref damage );
			
			base.AlterSpellDamageFrom( from, ref damage );
		}
		
		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			CheckDamageFrom( from, ref damage );
			
			base.AlterMeleeDamageFrom( from, ref damage );
		}
		
		//this does the meat and potatoes work to prevent damage
		public void CheckDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
			{
				BaseCreature creature = (BaseCreature)from;
				
				if( creature.Controlled && BlockPetDamage )
				{
					if( DebugLinkedCreatures )
					{
						PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Blocking Pet Damage*" );
					}
					damage = 0;
				}
				
				if( creature.Controlled && KillPets )
				{
					if( DebugLinkedCreatures )
					{
						PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Killing Pet*" );
					}
					creature.Kill();
				}
			}
			
			if( !LinkedCreatureAttackable() )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Cannot take damage*" );
				}
				damage = 0;

				PlaySound( NoDamageSound );
				FixedEffect( NoDamageEffect, 10, 5 );
			}
		}
		
		
		//this handles blocking of the killing of linked creatures, and unlinking creatures
		public override bool OnBeforeDeath()
		{
			if( !LinkedCreatureKillable() )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Cannot be killed*" );
				}
				return false;
			}
			
			UnlinkToAllCreatures();
			
			return base.OnBeforeDeath();
		}
		
		//this performs the check to see if the linked creature take damage.  What is required is that
		//all linked creatures are under attack by unique targets
		public bool LinkedCreatureAttackable()
		{
			if( !UnderAttack() )
			{
				return false;
			}
			
			//check all the linked creatures to see if they are currently engaged in combat
			foreach( BaseLinkedCreature creature in _LinkedCreatures )
			{
				if( !creature.UnderAttack() )
				{
					return false;
				}
			}
			return true;
			
		}
		
		public bool LinkedCreatureKillable()
		{
			if( !LinkedCreatureAttackable() )
			{
				return false;
			}
			
			if( SynchKill )
			{
				//check all the linked creatures to see if they are near death
				foreach( BaseLinkedCreature creature in _LinkedCreatures )
				{
					//if their hits are greater than 1%, block death
					if( creature.Hits > creature.HitsMax / 100 )
					{
						return false;
					}
				}
				
			}
			return true;
			
		}
		
		//this reports if this linked creature is currently under attack and at least one of the attackers is still attacking it
		public bool UnderAttack()
		{
			foreach( AggressorInfo aggressor in Aggressors )
			{
				if( aggressor.Attacker.Combatant == this )
				{
					//ignore any pets if pet damage is blocked
					if( aggressor.Attacker is BaseCreature && BlockPetDamage )
					{
						continue;
					}
					
					return true;
				}
			}
			
			foreach( AggressorInfo aggressor in Aggressed )
			{
				if( aggressor.Defender.Combatant == this )
				{
					//ignore any pets if pet damage is blocked
					if( aggressor.Attacker is BaseCreature && BlockPetDamage )
					{
						continue;
					}
					
					return true;
				}
			}			
			return false;
		}
		
		
		//this begins the link scanning process, subject to the restrictions applied to it
		protected void Link_Callback( object state )
		{
			if( this.Deleted )
			{
				return;
			}
			
			//reset the world's guarded objects
			//NOTE: will this be overkill?  Lag?
			
			List<Item> illist = new List<Item>();
			foreach( Item item in World.Items.Values )
			{
				if( item is ILinkedCreatureObject )
				{
					illist.Add( item );
				}
			}
			
			foreach( Item item in illist )
			{
				IsAccessible( item );
			}
			
			
			if( DebugLinkedCreatures )
			{
				PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Beginning link...*" );
			}
			
			
			if( GlobalScopeLink )
			{
				//if you're linking to all creatures
				foreach( Mobile m in World.Mobiles.Values )
				{
					if( m is BaseLinkedCreature )
					{
						LinkToCreature( (BaseLinkedCreature)m );
					}
				}
			}
			else
			{
				//scan the world around it for creatures to link to
				IPooledEnumerable en = this.Map.GetMobilesInRange( this.Location, LocalLinkPerceptionRange );	
				
				foreach( Mobile m in en )
				{
					if( m is BaseLinkedCreature )
					{
						LinkToCreature( (BaseLinkedCreature)m );
					}
				}
				
				en.Free();
			}
			
			//this checks if the creature is ready to fight (ie: enough links have been formed and it is ready for players
			//note: it counts itself in the linking!
			if( _LinkedCreatures.Count >= MinLinkNum )
			{
				Blessed = false;
				Frozen = false;
				Hidden = false;
			}
			
			
		}
		
		//this begins the attempt to link this creature to another creature
		protected bool LinkToCreature( BaseLinkedCreature creature )
		{
			
			Type linktype = null;
			//determine what type to link to
			if( CrossCreatureLink )
			{
				//attempt to link to any base linked creature
				linktype = typeof( BaseLinkedCreature );
			}
			else
			{
				//link to only creatures of this same type
				linktype = this.GetType();
			}
			
			//check for matching types
			if( ( creature.GetType() != linktype && !CrossCreatureLink ) || creature == this )
			{
				return false;
			}
			
			//will not link if it has achieved maximum link count 
			if( MaxLinkNum > 0 && _LinkedCreatures.Count >= MaxLinkNum )
			{
				return false;
			}
			
			
			//check if these two creatures can link.  During this check, the other creature will link up
			//if they're compatable
			if( !creature.LinkTo( this ) )
			{
				return false;
			}
			
			//use this method in reverse to perform the local link operation
			return LinkTo( creature );
		}
		
		//this continues the attempt to link.  it is called when another base linked creature tries to link up
		public bool LinkTo( BaseLinkedCreature creature )
		{
			//will not link if it has achieved maximum link count
			//note: it counts itself in the linking!
			if( MaxLinkNum > 0 && _LinkedCreatures.Count >= MaxLinkNum )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Too many links*" );
				}
				return false;
			}
			
			//if they don't want to cross-creature link
			if( creature.GetType() != this.GetType() && !CrossCreatureLink  )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Incompatable*" );
				}
				return false;
			}
			
			
			//if they don't want to link to the same creature type
			if( creature.GetType() == this.GetType() && !LinkToSameClass  )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Won't link to same class*" );
				}
				return false;
			}
			
			//if they have incompatable scopes
			if( ( !CrossScopeLink || !creature.CrossScopeLink ) && GlobalScopeLink != creature.GlobalScopeLink )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Cannot cross scope link*" );
				}
				return false;
			}
			
			//if this creature is not in global scope mode, and the other one is out of range
			if( !GlobalScopeLink && !this.InRange( creature, LocalLinkPerceptionRange ) )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Out of range*" );
				}
				return false;
			}
			
			//if they're already linked
			if( _LinkedCreatures.IndexOf( creature ) > -1 )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Already linked*" );
				}
				return false;
			}
			
			//otherwise, add em and link up
			_LinkedCreatures.Add( creature );

			if( DebugLinkedCreatures )
			{
				PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Forming link*" );
			}
			
			//this checks if the creature is ready to fight (ie: enough links have been formed and it is ready for players
			//note: it counts itself in the linking!
			if( _LinkedCreatures.Count >= MinLinkNum )
			{
				Blessed = false;
				Frozen = false;
				Hidden = false;
			}
			
						
			//this tells the creature requesting the link to also link up
			return true;
		}
		
		//when a linked creature dies, it calls this to tell all linked creatures to ignore it
		protected void UnlinkToAllCreatures()
		{
			foreach( BaseLinkedCreature creature in _LinkedCreatures )
			{
				if( BuffOthersOnKill )
				{
					BuffCreature( creature );
				}
				
				creature.Unlink( this );
			}
		}
		
		public void Unlink( BaseLinkedCreature creature )
		{
			if( _LinkedCreatures.IndexOf( creature ) != -1 )
			{
				if( DebugLinkedCreatures )
				{
					PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*Unlinking a fallen linked creature*" );
				}
				
				PlaySound( KillLinkedSound );
				FixedEffect( KillLinkedEffect, 10, 5 );

				
					
				_LinkedCreatures.Remove( creature );
			}
		}
		
		//this performs tying up of loose ends if one is deleted for some reason other than being killed
		public override void OnDelete()
		{
			UnlinkToAllCreatures();
			
			base.OnDelete();
		}
		
		public void BuffCreature( BaseLinkedCreature creature )
		{
			//the buff process is as follows:
			
			//*give 10% of the killed creature's max hits
			//*increase their resists by 5% of the killed creature, to a maximum of 95
			
			creature.Hits += creature.HitsMax / 10;
			
			for( int i = 0; i < 5; i++ )
			{
				int newresist = Math.Min( 95, creature.Resistances[i] + (int)( this.Resistances[i]* .05 ) );
				
				creature.SetResistance( (ResistanceType)i, newresist, newresist );
			}
		}
		
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			
			writer.Write( _LinkedCreatures.Count );
			
			foreach( BaseLinkedCreature creature in _LinkedCreatures )
			{
				writer.Write( (Mobile)creature );
			}
			
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			int count = reader.ReadInt();
			
			_LinkedCreatures = new List<BaseLinkedCreature>();
			
			for( int i = 0; i < count; i++ )
			{
				_LinkedCreatures.Add( (BaseLinkedCreature)reader.ReadMobile() );
			}
			
			//lock them down again if they're not fully linked
			if( _LinkedCreatures.Count < MinLinkNum )
			{
				Blessed = true;
				Frozen = true;
				Hidden = true;
			}
			
		}
		
		//this determines if the item is "guarded" by linked creatures.  Depending on this object's
		public static bool IsAccessible( Item item )
		{
			
			Type guardtype = null;
			
			//if the item supports the ILinkedCreatureObject interface, then it can be custom defined 
			if( item is ILinkedCreatureObject )
			{
				guardtype = ((ILinkedCreatureObject)item).LinkedCreatureGuardType;
				
			}
			
			//default checks is on BaseLinkedCreature
			if( guardtype == null )
			{
				guardtype = typeof( BaseLinkedCreature );
			}
				
			
			//instance the guard type to determine its guarding scope
			
			BaseLinkedCreature testcreature = null;
			
			
			try
			{
				testcreature = (BaseLinkedCreature)Activator.CreateInstance( guardtype );
			}
			catch
			{
				//cheap, but effective
				testcreature = new BaseLinkedCreature( AIType.AI_Melee, FightMode.Closest, 0, 0, 0, 0 );
			}
			
			bool globalguard = testcreature.GlobalScopeLink; 
			int guardcheckrange = testcreature.LocalLinkPerceptionRange;
			
			//clean up after self
			testcreature.Delete();
			
			if( globalguard )
			{
				foreach( Mobile m in World.Mobiles.Values )
				{
					//if a guard is still found
					if( m.GetType() == guardtype || m.GetType().IsSubclassOf( guardtype ) )
					{
						//this recloses doors and such if they're sitting open
						if( item is ILinkedCreatureObject )
						{
							((ILinkedCreatureObject)item).Lockdown();
						}
			
						
						return false;
					}
				}
			}
			else
			{
				IPooledEnumerable en = item.Map.GetMobilesInRange( item.Location, guardcheckrange );	
				
				foreach( Mobile m in en )
				{
					//if a guard is still found
					if( m.GetType() == guardtype || m.GetType().IsSubclassOf( guardtype ) )
					{
						en.Free();
						
						//this recloses doors and such if they're sitting open
						if( item is ILinkedCreatureObject )
						{
							((ILinkedCreatureObject)item).Lockdown();
						}
						return false;
					}
				}
				
				en.Free();
			}
			return true;
		}
	}
}
using System;
using Server;


namespace Server.Items
{
	public interface ILinkedCreatureObject
	{
		//used to store info about what kind of creature guards this (need not be a base linked creature!)
		Type LinkedCreatureGuardType{ get; set; }
		
		//used to forcibly close doors, etc, and purges the guarded region when creatures respawn
		void Lockdown();
		
		//this defines a location where this system is currently restricting player access.  When the object
		//executes Lockdown(), player or pet found in this region is purged to the defined toss point
		Rectangle2D GuardedRegion{ get; set; }
		Map GuardedMap{ get; set; }
		
		//this is where all players and pets are tossed when the guarded region is under lockdown
		Point3D TossPoint{ get; set; }
		Map TossMap{ get; set; }
	}

}
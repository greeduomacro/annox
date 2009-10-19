using System;
using Server.Items;
using Server.Mobiles;

using Solaris.Tools;

namespace Server.Commands
{
	//this produces spawners around the world for the demon triumvirate.  They connect up in sets of 3, and
	//must be engaged and killed simultaneously
	public class GenDemonTriumvirate
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GenDemonTriumvirate", AccessLevel.Administrator, new CommandEventHandler( GenDemonTriumvirate_OnCommand ) );
		}

		[Usage( "GenDemonTriumvirate" )]
		[Description( "Produces spawners for the linked creatures Demon Triumvirate in various locations" )]
		private static void GenDemonTriumvirate_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Generating spawners for demon triumvirate..." );
			
			SpawnHelper.AddNewSpawner( typeof( DemonTriumvirate), 1, TimeSpan.FromHours( 24 ), new Point3D( 2495, 3935, 5 ), Map.Felucca );
			SpawnHelper.AddNewSpawner( typeof( DemonTriumvirate), 1, TimeSpan.FromHours( 24 ), new Point3D( 2140, 3945, 5 ), Map.Felucca );
			SpawnHelper.AddNewSpawner( typeof( DemonTriumvirate), 1, TimeSpan.FromHours( 24 ), new Point3D( 2486, 3550, 5 ), Map.Felucca );
			
			e.Mobile.SendMessage( "Generation complete!" );
			
		}
	}
}

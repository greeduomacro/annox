using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Solaris.Tools
{
	public class SpawnHelper
	{
	
		public static void AddNewSpawner( Type spawntype, int count, TimeSpan mindelay, Point3D location, Map map )
		{
			AddNewSpawner( spawntype, count, mindelay, mindelay, location, map );
		}
		
		public static void AddNewSpawner( Type spawntype, int count, TimeSpan mindelay, TimeSpan maxdelay, Point3D location, Map map )
		{
			
			if( spawntype == null )
			{
				return;
			}
			
			Spawner spawner = MakeUniqueSpawner( location, map );
			
			if( spawner.CreaturesName.IndexOf( spawntype.Name ) == -1 )
			{
				spawner.CreaturesName.Add( spawntype.Name );
			}
			
			spawner.Count = count;
			spawner.MinDelay = mindelay;
			spawner.MaxDelay = maxdelay;
		}
		
		//looks at the location provided for a spawner, and returns it if it exists, otherwise makes a new one
		public static Spawner MakeUniqueSpawner( Point3D location, Map map )
		{
			IPooledEnumerable ie = map.GetItemsInRange( location, 0 );
				
			Spawner spawner = null;
			
			foreach( Item item in ie )
			{
				if( item is Spawner )
				{
					spawner = (Spawner)item;
					break;
				}
			}
			
			if( spawner == null )
			{
				spawner = new Spawner();
				spawner.MoveToWorld( location, map );
			}
			
			return spawner;
		}
	}
}
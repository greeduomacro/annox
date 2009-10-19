/***************************
**    Monster Contract Dealer   **
**    Creator: Raisor: Created the Monster Contract sytem for RunUO ver 1.0	**
**    Darkness_PR Made the NPC for the Monster Contract System for RunUO ver 1.0 **
**    Current Updater for RunUO ver 2.0: Soultaker    **
**    Version: 2.0a				**
***************************/
// Currently Being Updated by Soultaker
// All Credit goes to Raisor & Darkness_PR otherwise we wouldnt have this fantastic system.

using System; 
using Server;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable( 0x14EF, 0x14F0 )]
	public class MonsterContract : Item
	{
		private string m_type;
		private int reward;
		private int m_amount;
		private int m_killed;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public string Monster
		{
			get{ return m_type; }
			set{ m_type = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Reward
		{
			get{ return reward; }
			set{ reward = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int AmountToKill
		{
			get{ return m_amount; }
			set{ m_amount = value; }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int AmountKilled
		{
			get{ return m_killed; }
			set{ m_killed = value; }
		}
		
		[Constructable]
		public MonsterContract() : base( 0x14EF )
		{
			Movable = true;
			LootType = LootType.Blessed;
			Monster = GetRandomMonster( Utility.Random( 5 ) );
			AmountToKill = Utility.Random( 10 ) + 5;
			Reward = Utility.Random( 1000 ) * AmountToKill + 500;
			Name = "a Contract: " + AmountToKill + " " + Monster + "s";
			AmountKilled = 0;
		}
		
		[Constructable]
		public MonsterContract( string type, int atk, int gpreward ) : base( 0x14F0 )
		{
			Movable = true;
			LootType = LootType.Blessed;
			Monster = type;
			AmountToKill = atk;
			Reward = gpreward;
			Name = "a Contract: " + AmountToKill + " " + Monster + "s";
			AmountKilled = 0;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if( IsChildOf( from.Backpack ) )
			{
				from.SendGump( new MonsterContractGump( from, this ) );
			} 
			else 
		    {
		    	from.SendLocalizedMessage( 1047012 ); // This contract must be in your backpack to use it
		    }
		}
		
		public MonsterContract( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		
			writer.Write( m_type );
			writer.Write( reward );
			writer.Write( m_amount );
			writer.Write( m_killed );
		}

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
			
			m_type = reader.ReadString();
			reward = reader.ReadInt();
			m_amount = reader.ReadInt();
			m_killed = reader.ReadInt();
			LootType = LootType.Blessed;
		}
		
		public string GetRandomMonster( int genre )
		{
			switch ( genre )
			{
				case 0:
					switch (Utility.Random( 5 ) )
					{
						case 0:	return "Lich Lord";
								//break;
						case 1:	return "Lich";
								//break;
						case 2:	return "Spectre";
								//break;
						case 3:	return "Shade";
								//break;
						case 4:	return "Wraith";
								//break;
						default: return "Wraith";
								//break;
					}
					//break;
				case 1:
					switch (Utility.Random( 5 ) )
					{
						case 0:	return "Air Elemental";
								//break;
						case 1:	return "Fire Elemental";
								//break;
						case 2:	return "Water Elemental";
								//break;
						case 3:	return "Earth Elemental";
								//break;
						case 4:	return "Blood Elemental";
								//break;
						default: return "Air Elemental";
								//break;
					}
					//break;
				case 2:
					switch (Utility.Random( 5 ) )
					{
						case 0:	return "Headless One";
								//break;
						case 1:	return "Horde Minion";
								//break;
						case 2:	return "Mongbat";
								//break;
						case 3:	return "Ogre";
								//break;
						case 4:	return "Ettin";
								//break;
						default: return "Mongbat";
								//break;
					}
					//break;
				case 3:
					switch (Utility.Random( 5 ) )
					{
						case 0:	return "Terathan Warrior";
								//break;
						case 1:	return "Terathan Drone";
								//break;
						case 2:	return "Terathan Avenger";
								//break;
						case 3:	return "Terathan Matriarch";
								//break;
						case 4:	return "Dread Spider";
								//break;
						default: return "Dread Spider";
								//break;
					}
					//break;
				case 4:
					switch (Utility.Random( 5 ) )
					{
						case 0:	return "Ophidian Matriarch";
								//break;
						case 1:	return "Ophidian Mage";
								//break;
						case 2:	return "Ophidian ArchMage";
								//break;
						case 3:	return "Giant Snake";
								//break;
						case 4:	return "Dragon";
								//break;
						default: return "Giant Snake";
								//break;
					}
					//break;
				default:
					switch (Utility.Random( 5 ) )
					{
						case 0:	return "Headless One";
								//break;
						case 1:	return "Horde Minion";
								//break;
						case 2:	return "Mongbat";
								//break;
						case 3:	return "Ogre";
								//break;
						case 4:	return "Ettin";
								//break;
						default: return "Mongbat";
								//break;
					}
					//break;
			}
		}
	}
}

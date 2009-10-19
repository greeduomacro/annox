		////////////////////////////////////////////////////////////////////////////////////////
	   /////                                                                            ////////
	  //////    Version: 1.0        Author: Vorspire        Shard: Alternate-PK         ////////
	 ///////    Edited by A_Li_N                                                        ////////
	////////                                                                            ////////
	////////    QuakeNet: #Alternate-PK		MSN: alere_flammas666@hotmail.com           ////////
	////////                                                                            ////////
	////////    Description: This stone allows players to increase skills based on      ////////
	////////                 the settings you chose. This stone is fully custom-        ////////
	////////                 -isable and includes an experience feature, if your        ////////
	////////                 shard uses a similar experience system. Everything in      ////////
	////////                 this script is straight forward and easy to under-         ////////
	////////                 -stand. On behalf of Alternate-PK, I hope you enjoy        ////////
	////////                 this script to its full potential.                         ////////
	////////                                                                            ////////
	////////    Distribution: This script can be freely distributed, as long as the     ////////
	////////                  credit notes are left intact.	This script can also be     ////////
	////////                  modified, as long as the credit notes are left intact.    ///////
	////////                                                                            //////
	/////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Factions;

namespace Server.Items
{
	public class SkillStoneGump : Gump
	{
		private Mobile m_From;
		private SkillBuyStone m_Stone;
		private int m_Page;

		public SkillStoneGump( SkillBuyStone stone, Mobile from, int page ) : base( 180, 30 )
		{
			m_From = from;
			m_Stone = stone;
			m_Page = page;
			int iStart = m_Page * 20;
			if( iStart < 0 || iStart > 40 )
				iStart = 0;

			Closable = true;
			Disposable = false;
			Dragable = false;
			Resizable = false;

			AddPage(0);
			AddBackground( 72, 17, 640, 550, 9270 );

			if( m_Stone.CoolLooking )
				AddAlphaRegion( 86, 33, 608, 516 );

			//Column 1
			AddBackground( 170, 40, 201, 63, 9270 );	//Top
			AddBackground( 116, 116, 255, 54, 9270 );	//Middle
			AddImage( 65, 62, 10400 );
			AddBackground( 93, 186, 278, 358, 9270 );	//Bottom
			AddBackground( 193, 196, 20, 338, 9270 );	//Div 1
			AddBackground( 252, 196, 20, 338, 9270 );	//Div 2
			AddBackground( 300, 196, 20, 338, 9270 );	//Div 3
			AddLabel( 111, 201, 53, "Skill Name" );
			AddLabel( 227, 201, 53, "%" );
			AddLabel( 274, 201, 53, "Silver" );

			//Column 2
			AddBackground( 410, 40, 201, 63, 9270 );	//Top
			AddImage( 635, 62, 10410 );
			AddBackground( 410, 116, 255, 54, 9270 );	//Middle
			AddBackground( 410, 186, 278, 358, 9270 );	//Bottom
			AddBackground( 510, 196, 20, 338, 9270 );	//Div 1
			AddBackground( 569, 196, 20, 338, 9270 );	//Div 2
			AddBackground( 617, 196, 20, 338, 9270 );	//Div 3
			AddLabel( 434, 201, 53, "Skill Name" );
			AddLabel( 544, 201, 53, "%" );
			AddLabel( 591, 201, 53, "Silver" );

			AddLabel( 194, 61, 53, "Buy Skills" );
			AddLabel( 136, 132, 43, "Silver Cost per " + m_Stone.SkillIncrease + "%" );
			AddLabel( 267, 132, 62, m_Stone.PriceInSilver.ToString() );

			AddBackground( 673, 0, 57, 57, 9270 );		//Exit
			AddButton( 681, 11, 2642, 2643, 0, GumpButtonType.Reply, 0 );		//Close Gump

			AddButton( 482, 58, 5526, 5527, 1, GumpButtonType.Reply, 0 );		//Help
			if( iStart > 0 )
				AddButton( 426, 46, 4506, 4506, 2, GumpButtonType.Reply, 0 );	//Previous
			if( iStart < 40 )
				AddButton( 548, 46, 4502, 4502, 3, GumpButtonType.Reply, 0 );	//Next


			for( int i = 0; i < m_From.Skills.Length && i < 20; i++ )
			{
				Skill skill = m_From.Skills[i+iStart];
				if( skill == null || skill.Base > m_Stone.MaxCanBuyTo-m_Stone.SkillIncrease )
					continue;

				AddLabelCropped( (i >= 10 ? 422 : 105), (i >= 10 ? 225+((i-10)*30) : 225+i*30), 90, 30, 62, skill.Name );
				AddLabel( (i >= 10 ? 531 : 213), (i >= 10 ? 225+((i-10)*30) : 225+i*30), 43, skill.Base.ToString() );
				AddButton( (i >= 10 ? 589 : 271), (i >= 10 ? 225+((i-10)*30) : 225+i*30), 4014, 4016, 100+i+iStart, GumpButtonType.Reply, 0 );
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int BID = info.ButtonID;
			m_From.CloseGump( typeof( SkillStoneGump ) );

			if( BID == 1 )
				m_From.SendGump( new SkillStoneGumpHelp( m_Stone, m_From ) );

			else if( BID == 2 )
				m_From.SendGump( new SkillStoneGump( m_Stone, m_From, m_Page-1 ) );

			else if( BID == 3 )
				m_From.SendGump( new SkillStoneGump( m_Stone, m_From, m_Page+1 ) );

			else if( BID >= 100 && BID <= m_From.Skills.Length+100 )
			{
				int skill = BID - 100;
				if( skill < 0 || skill >= m_From.Skills.Length )
					return;

				if( m_From.Skills[(SkillName)skill].Base + m_Stone.SkillIncrease > m_Stone.MaxCanBuyTo )
					m_From.SendMessage( "You can not buy skills past {0}%", m_Stone.MaxCanBuyTo );

				else if( m_From.SkillsTotal + (m_Stone.SkillIncrease*10) > m_From.SkillsCap )
					m_From.SendMessage( "You cannot buy skills above your Skill Cap" );

				else
				{
					Container pack = m_From.Backpack;
					Container bank = m_From.BankBox;
					if( (pack != null && pack.ConsumeTotal( typeof( Silver ), m_Stone.PriceInSilver )) ||
						(Banker.Withdraw( m_From, m_Stone.PriceInSilver )) )
					{
						m_From.Skills[(SkillName)skill].Base += m_Stone.SkillIncrease;
						m_From.SendMessage( "You payed {0} Silver to gain {1} skill in {2}", m_Stone.PriceInSilver, m_Stone.SkillIncrease, m_From.Skills[(SkillName)skill].Name );
					}
					else
						m_From.SendMessage( "You need {0} silver to use this!", m_Stone.PriceInSilver );
				}

				m_From.SendGump( new SkillStoneGump( m_Stone, m_From, m_Page ) );
			}
		}
	}
}
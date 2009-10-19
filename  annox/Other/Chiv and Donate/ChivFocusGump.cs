using System;
using Server;
using Server.Gumps;
using System.Collections;
using Server.Misc; 
using Server.Network; 
using Server.Mobiles;

namespace Server.Gumps
{
	public class ChivFocusGump : Gump
	{
		private Skill skill;  //so we know which skill they clicked
		private Mobile m_From; //to change the mobile

		public ChivFocusGump(Mobile from)//putting the gump where we want it to show up
			: base( 125, 125 )
		{
			this.Closable=true;//settings
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(126, 136, 245, 124, 9200);
			this.AddLabel(131, 168, 0, @"Chivalry");//add the two labels to the side
			this.AddLabel(133, 213, 0, @"Focus");
			m_From = from;//find the mobile so we can use it in the class easily

			switch(from.Skills[SkillName.Chivalry].Lock)//check their lock status to make the appropriate button gump show up
			{
				default:
				case SkillLock.Up: this.AddButton(294, 171, 0x983, 0x983, (int)Buttons.B_Chivalry, GumpButtonType.Reply, 0); break;
				case SkillLock.Down: this.AddButton(294, 171, 0x985, 0x985, (int)Buttons.B_Chivalry, GumpButtonType.Reply, 0); break;
				case SkillLock.Locked: this.AddButton(294, 171, 0x82C, 0x82C, (int)Buttons.B_Chivalry, GumpButtonType.Reply, 0); break;
			}

			switch(from.Skills[SkillName.Focus].Lock)//do the same for the focus skill
			{
				default:
				case SkillLock.Up: this.AddButton(294, 214, 0x983, 0x983, (int)Buttons.B_Focus, GumpButtonType.Reply, 0); break;
				case SkillLock.Down: this.AddButton(294, 214, 0x985, 0x985, (int)Buttons.B_Focus, GumpButtonType.Reply, 0); break;
				case SkillLock.Locked: this.AddButton(294, 214, 0x82C, 0x82C, (int)Buttons.B_Focus, GumpButtonType.Reply, 0); break;
			}

		}

		public override void OnResponse( NetState sender, RelayInfo info )//this is teh onresponse method that you always override
		{
			PlayerMobile from;//make another player mobile
			from = m_From as PlayerMobile;//change our mobile to player mobile
			Skill sk;
			//from.SendMessage("Button {0}", info.ButtonID);//you can uncommnet this to see what the button id is your pressing if unsure

			if(info.ButtonID == 2)//if they click the focus button
			{
				sk = m_From.Skills[SkillName.Focus];//set the skill to focus
				switch ( sk.Lock )//check the lock
				{
					case SkillLock.Up: sk.SetLockNoRelay( SkillLock.Down ); sk.Update(); break;//change the lock and update it
					case SkillLock.Down: sk.SetLockNoRelay( SkillLock.Locked ); sk.Update(); break;
					case SkillLock.Locked: sk.SetLockNoRelay( SkillLock.Up ); sk.Update(); break;
				}
				m_From.SendGump( new ChivFocusGump(m_From) );//send the gump again if they want to change it again
			}
			else if(info.ButtonID == 1)//if they click the first button for chivalry
			{
				sk = m_From.Skills[SkillName.Chivalry];//set the skill to chivalry
				switch ( sk.Lock )//check the lock
				{
					case SkillLock.Up: sk.SetLockNoRelay( SkillLock.Down ); sk.Update(); break;//change it accordingly and update it
					case SkillLock.Down: sk.SetLockNoRelay( SkillLock.Locked ); sk.Update(); break;
					case SkillLock.Locked: sk.SetLockNoRelay( SkillLock.Up ); sk.Update(); break;
				}
				m_From.SendGump( new ChivFocusGump(m_From) );//send the gump again for them to continue changing.
			}
		}   
		
		public enum Buttons//Here are all our buttons to more easily tell what the button does.
		{
			B_Close,//note the first one must always be close because it is button 0 
			B_Chivalry,//and if you do not put this you will not be able to close the gump
			B_Focus,
		}

	}
}
//10OCT2007 PvP Skulls by XenoNeo
//http://www.runuo.com/forums/custom-script-releases/80880-runuo-2-0-rc1-pvp-skulls.html
//In playermobile.cs, find the OnDeath Method not the OnBeforeDeath:
/*  	if( c is Corpse )
			{
				PlayerMobile corpsekiller = ((Corpse)c).Owner.LastKiller as PlayerMobile;

				if( corpsekiller != null )
				{
		        		Item skull = new CorpseSkull();
					skull.Name = "Skull of " + ((Corpse)c).Owner.RawName.ToString() + " killed by " + corpsekiller.RawName.ToString();

					if ( this.Kills >= 3 )
						skull.Hue = 35;

					else if ( ((Corpse)c).Criminal == true )
						skull.Hue = 903;

					else
						skull.Hue = 295;

            				skull.MoveToWorld( c.Location, c.Map );
				}
			}
 */

using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Regions;

namespace Server.Items
{

    public class CorpseSkull : Item
    {
        private Timer m_Timer;

        public CorpseSkull()
            : base(0x1AE1)
        {
            Movable = false;
            m_Timer = new DecayTimer(this);
            m_Timer.Start();
        }

        public CorpseSkull(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Timer = new DecayTimer(this);
                        m_Timer.Start();
                        break;
                    }
            }
        }
    }

    public class DecayTimer : Timer
    {
        private Item i_item;

        public DecayTimer(Item item)
            : base(TimeSpan.FromDays(10.0))
        {
            Priority = TimerPriority.OneSecond;
            i_item = item;
        }

        protected override void OnTick()
        {
            if ((i_item != null) && (!i_item.Deleted))
                i_item.Delete();
        }
    }
}
http://www.runuo.com/forums/showthread.php?t=71105
DEATH on player demise by zardoz

http://www.runuo.com/forums/custom-script-releases/87291-start-location-gump.html
Start Location Gump by CEO

Combined by RavonTUS
Play at An Nox, the cure for the UO addiction.
http:/annox.no-ip.com


It DOES require a small edit to Scripts\Mobiles\PlayerMobile.cs but the change is not large.

       public override void OnDeath( Container c )
       {
           base.OnDeath( c );

       //**********Added for DEATH to appear on Death

       {
           Mobile m = new VisitingDEATH();
           m.Location = c.Location;
           m.Map = c.Map;
       }

       //**********End Added for DEATH

           HueMod = -1;
           NameMod = null;
           SavagePaintExpiration = TimeSpan.Zero;

           SetHairMods( -1, -1 );



The gate is running on its own default timer. 

You will need to use another method to make it remain for longer. It's ages since I wrote this code and I haven't experimented with alternatives much.

The other timers used are the obvious 5 senonds ones. You can play with these as much as you like. 

	if (!m_Owner.Deleted)
	  {
	    Effects.SendLocationParticles (EffectItem.Create (m_Owner.Location, m_Owner.Map, EffectItem.DefaultDuration), 0x1fcb, 10, 14, 2023);
	    m_Owner.PlaySound (0x293);
	    m_Owner.Delete ();
	  }
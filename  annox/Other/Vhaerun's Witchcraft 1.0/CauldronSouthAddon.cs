
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class CauldronSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CauldronSouthAddonDeed();
			}
		}

		[ Constructable ]
		public CauldronSouthAddon()

		{
			AddonComponent ac;
            ac = new AddonComponent(2416);
            ac.Name = "brew";
            ac.Hue = 63;
            AddComponent(ac, 0, 0, 8);

            ac = new AddonComponent(2420);
            AddComponent(ac, 0, 0, 0);

            //ac = new AddonComponent(2421);
            //AddComponent(ac, 0, 0, 0);


            ac = new AddonComponent(4012);
            ac.Light = LightType.Circle150;
            AddComponent(ac, 0, 0, 0);
        }

        public override void OnComponentUsed(AddonComponent ac, Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 2))  
                from.SendMessage("You are too far away.");
            else
            {
                from.Emote("*stirs the brew*");
                from.Say("hihihihiiii!");
                from.PlaySound(32);
                if (!from.Mounted)
                from.Animate(33, 5, 1, true, false, 0);

            }
        }


        public CauldronSouthAddon(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class CauldronSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CauldronSouthAddon();
			}
		}

		[Constructable]
		public CauldronSouthAddonDeed()
		{
			Name = "a cauldron deed";
		}

        public CauldronSouthAddonDeed(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
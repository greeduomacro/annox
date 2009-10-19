using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using Server.Gumps;

namespace Server.Items
{
	public class VenomWeaponDeed : BaseSword
	{
		[Constructable]
		public VenomWeaponDeed() : base( 0x227A )
		{
			Name = "Venom Weapon Deed";
			Weight = 1.0;
			Hue = 2373;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) ) from.SendLocalizedMessage( 1042001 );
			else from.SendGump( new InternalGump( from, this ) );
		}

		private class InternalGump : Gump
		{
			private Mobile m_From;
			private VenomWeaponDeed m_Deed;

			public InternalGump( Mobile from, VenomWeaponDeed deed ) : base( 50, 50 )
			{
				m_From = from;
				m_Deed = deed;

				from.CloseGump( typeof( InternalGump ) );

				AddPage ( 0 );
				AddBackground( 10, 10, 465, 405, 0xA28 );

				AddImage(442,35, 10441);

				AddPage ( 1 );

				AddLabel( 120, 25, 0x34, "Select the Type of Weapon you Prefer.");

				AddLabel( 75,  55, 59, "Venom Axes");
				AddLabel( 75,  85, 59, "Venom Bows");
				AddLabel( 75, 115, 59, "Venom Knives");
				AddLabel( 75, 145, 59, "Venom Maces");
				AddLabel( 75, 175, 59, "Venom Pole Arms");
				AddLabel( 75, 205, 59, "Venom Spears and Forks");
				AddLabel( 75, 235, 59, "Venom Staves");
				AddLabel( 75, 265, 59, "Venom Swords");

				AddButton( 40,  58, 0x2623, 0x2622, 1, GumpButtonType.Page, 2 );
				AddButton( 40,  88, 0x2623, 0x2622, 2, GumpButtonType.Page, 3 );
				AddButton( 40, 118, 0x2623, 0x2622, 3, GumpButtonType.Page, 4 );
				AddButton( 40, 148, 0x2623, 0x2622, 4, GumpButtonType.Page, 5 );
				AddButton( 40, 178, 0x2623, 0x2622, 5, GumpButtonType.Page, 6 );
				AddButton( 40, 208, 0x2623, 0x2622, 6, GumpButtonType.Page, 7 );
				AddButton( 40, 238, 0x2623, 0x2622, 7, GumpButtonType.Page, 8 );
				AddButton( 40, 268, 0x2623, 0x2622, 8, GumpButtonType.Page, 9 );

				AddPage ( 2 );

				AddLabel( 160, 25, 0x34, "Select the Axe you Desire.");

				AddLabel( 75,  55, 59, "Venom Axe");
				AddLabel( 75,  85, 59, "Venom Battle Axe");
				AddLabel( 75, 115, 59, "Venom Double Axe");
				AddLabel( 75, 145, 59, "Venom Executioner's Axe");
				AddLabel( 75, 175, 59, "Venom Hatchet");
				AddLabel( 75, 205, 59, "Venom Large Battle Axe");
				AddLabel( 75, 235, 59, "Venom Pickaxe");
				AddLabel( 75, 265, 59, "Venom Two Handed Axe");
				AddLabel( 75, 295, 59, "Venom War Axe");

				AddButton( 40,  58, 0x2623, 0x2622, 1, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 2, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 3, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 4, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 5, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 6, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 7, GumpButtonType.Reply, 0 );
				AddButton( 40, 268, 0x2623, 0x2622, 8, GumpButtonType.Reply, 0 );
				AddButton( 40, 298, 0x2623, 0x2622, 9, GumpButtonType.Reply, 0 );

				AddPage ( 3 );

				AddLabel( 160, 25, 0x34, "Select the Bow you Desire.");

				AddLabel( 75,  55, 59, "Venom Bow");
				AddLabel( 75,  85, 59, "Venom Composite Bow");
				AddLabel( 75, 115, 59, "Venom Crossbow");
				AddLabel( 75, 145, 59, "Venom Heavy Crossbow");
				AddLabel( 75, 175, 59, "Venom Repeating Crossbow");

				AddButton( 40,  58, 0x2623, 0x2622, 10, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 11, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 12, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 13, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 14, GumpButtonType.Reply, 0 );

				AddPage ( 4 );

				AddLabel( 160, 25, 0x34, "Select the Knife you Desire.");

				AddLabel( 75,  55, 59, "Venom Butcher Knife");
				AddLabel( 75,  85, 59, "Venom Cleaver");
				AddLabel( 75, 115, 59, "Venom Dagger");
				AddLabel( 75, 145, 59, "Venom Skinning Knife");

				AddButton( 40,  58, 0x2623, 0x2622, 15, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 16, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 17, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 18, GumpButtonType.Reply, 0 );

				AddPage ( 5 );

				AddLabel( 160, 25, 0x34, "Select the Mace you Desire.");

				AddLabel( 75,  55, 59, "Venom Club");
				AddLabel( 75,  85, 59, "Venom Hammer Pick");
				AddLabel( 75, 115, 59, "Venom Mace");
				AddLabel( 75, 145, 59, "Venom Maul");
				AddLabel( 75, 175, 59, "Venom Scepter");
				AddLabel( 75, 205, 59, "Venom War Hammer");
				AddLabel( 75, 235, 59, "Venom War Mace");

				AddButton( 40,  58, 0x2623, 0x2622, 19, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 20, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 21, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 22, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 23, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 24, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 25, GumpButtonType.Reply, 0 );

				AddPage ( 6 );

				AddLabel( 140, 25, 0x34, "Select the Pole Arm you Desire.");

				AddLabel( 75,  55, 59, "Venom Bardiche");
				AddLabel( 75,  85, 59, "Venom Halberd");
				AddLabel( 75, 115, 59, "Venom Scythe");

				AddButton( 40,  58, 0x2623, 0x2622, 26, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 27, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 28, GumpButtonType.Reply, 0 );

				AddPage ( 7 );

				AddLabel( 130, 25, 0x34, "Select the Spear or Fork you Desire.");

				AddLabel( 75,  55, 59, "Venom Bladed Staff");
				AddLabel( 75,  85, 59, "Venom Double Bladed Staff");
				AddLabel( 75, 115, 59, "Venom Pike");
				AddLabel( 75, 145, 59, "Venom Pitchfork");
				AddLabel( 75, 175, 59, "Venom Short Spear");
				AddLabel( 75, 205, 59, "Venom Spear");
				AddLabel( 75, 235, 59, "Venom War Fork");

				AddButton( 40,  58, 0x2623, 0x2622, 29, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 30, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 31, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 32, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 33, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 34, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 35, GumpButtonType.Reply, 0 );

				AddPage ( 8 );

				AddLabel( 160, 25, 0x34, "Select the Staff you Desire.");

				AddLabel( 75,  55, 59, "Venom Black Staff");
				AddLabel( 75,  85, 59, "Venom Gnarled Staff");
				AddLabel( 75, 115, 59, "Venom Quarter Staff");
				AddLabel( 75, 145, 59, "Venom Shepherd's Crook");

				AddButton( 40,  58, 0x2623, 0x2622, 36, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 37, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 38, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 39, GumpButtonType.Reply, 0 );

				AddPage ( 9 );

				AddLabel( 160, 25, 0x34, "Select the Sword you Desire.");

				AddLabel( 75,  55, 59, "Venom Bone Harvester");
				AddLabel( 75,  85, 59, "Venom Broad Sword");
				AddLabel( 75, 115, 59, "Venom Crescent Blade");
				AddLabel( 75, 145, 59, "Venom Cutlass");
				AddLabel( 75, 175, 59, "Venom Katana");
				AddLabel( 75, 205, 59, "Venom Kryss");
				AddLabel( 75, 235, 59, "Venom Lance");
				AddLabel( 75, 265, 59, "Venom Long Sword");
				AddLabel( 75, 295, 59, "Venom Scimitar");
				AddLabel( 75, 325, 59, "Venom Viking Sword");

				AddButton( 40,  58, 0x2623, 0x2622, 40, GumpButtonType.Reply, 0 );
				AddButton( 40,  88, 0x2623, 0x2622, 41, GumpButtonType.Reply, 0 );
				AddButton( 40, 118, 0x2623, 0x2622, 42, GumpButtonType.Reply, 0 );
				AddButton( 40, 148, 0x2623, 0x2622, 43, GumpButtonType.Reply, 0 );
				AddButton( 40, 178, 0x2623, 0x2622, 44, GumpButtonType.Reply, 0 );
				AddButton( 40, 208, 0x2623, 0x2622, 45, GumpButtonType.Reply, 0 );
				AddButton( 40, 238, 0x2623, 0x2622, 46, GumpButtonType.Reply, 0 );
				AddButton( 40, 268, 0x2623, 0x2622, 47, GumpButtonType.Reply, 0 );
				AddButton( 40, 298, 0x2623, 0x2622, 48, GumpButtonType.Reply, 0 );
				AddButton( 40, 328, 0x2623, 0x2622, 49, GumpButtonType.Reply, 0 );
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( m_Deed.Deleted ) return;

				BaseWeapon weapon = null;

				switch ( info.ButtonID )
				{
					case 0: return;
					case 1: weapon = new VenomAxe() ; break;
					case 2: weapon = new VenomBattleAxe() ; break;
					case 3: weapon = new VenomDoubleAxe() ; break;
					case 4: weapon = new VenomExecutionersAxe() ; break;
					case 5: weapon = new VenomHatchet() ; break;
					case 6: weapon = new VenomLargeBattleAxe() ; break;
					case 7: weapon = new VenomPickaxe() ; break;
					case 8: weapon = new VenomTwoHandedAxe() ; break;
					case 9: weapon = new VenomWarAxe() ; break;
					case 10: weapon = new VenomBow() ; break;
					case 11: weapon = new VenomCompositeBow() ; break;
					case 12: weapon = new VenomCrossbow() ; break;
					case 13: weapon = new VenomHeavyCrossbow() ; break;
					case 14: weapon = new VenomRepeatingCrossbow() ; break;
					case 15: weapon = new VenomButcherKnife() ; break;
					case 16: weapon = new VenomCleaver() ; break;
					case 17: weapon = new VenomDagger() ; break;
					case 18: weapon = new VenomSkinningKnife() ; break;
					case 19: weapon = new VenomClub() ; break;
					case 20: weapon = new VenomHammerPick() ; break;
					case 21: weapon = new VenomMace() ; break;
					case 22: weapon = new VenomMaul() ; break;
					case 23: weapon = new VenomScepter() ; break;
					case 24: weapon = new VenomWarHammer() ; break;
					case 25: weapon = new VenomWarMace() ; break;
					case 26: weapon = new VenomBardiche() ; break;
					case 27: weapon = new VenomHalberd() ; break;
					case 28: weapon = new VenomScythe() ; break;
					case 29: weapon = new VenomBladedStaff() ; break;
					case 30: weapon = new VenomDoubleBladedStaff() ; break;
					case 31: weapon = new VenomPike() ; break;
					case 32: weapon = new VenomPitchfork() ; break;
					case 33: weapon = new VenomShortSpear() ; break;
					case 34: weapon = new VenomSpear() ; break;
					case 35: weapon = new VenomWarFork() ; break;
					case 36: weapon = new VenomBlackStaff() ; break;
					case 37: weapon = new VenomGnarledStaff() ; break;
					case 38: weapon = new VenomQuarterStaff() ; break;
					case 39: weapon = new VenomShepherdsCrook() ; break;
					case 40: weapon = new VenomBoneHarvester() ; break;
					case 41: weapon = new VenomBroadSword() ; break;
					case 42: weapon = new VenomCrescentBlade() ; break;
					case 43: weapon = new VenomCutlass() ; break;
					case 44: weapon = new VenomKatana() ; break;
					case 45: weapon = new VenomKryss() ; break;
					case 46: weapon = new VenomLance() ; break;
					case 47: weapon = new VenomLongSword() ; break;
					case 48: weapon = new VenomScimitar() ; break;
					case 49: weapon = new VenomVikingSword() ; break;
				}

				if ( weapon != null )
				{
					weapon.Quality = m_Deed.Quality;
					weapon.Resource = m_Deed.Resource;
					if ( m_Deed.Crafter != null ) weapon.Crafter = m_Deed.Crafter;
					m_From.Backpack.DropItem( weapon );
					m_From.SendMessage( "You summon the Venom Weapon!" );
					m_Deed.Delete();
				}
			}
		}

		public VenomWeaponDeed( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
}
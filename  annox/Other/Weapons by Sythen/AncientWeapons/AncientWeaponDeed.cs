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
    public class AncientWeaponDeed : Item
    {
        [Constructable]
        public AncientWeaponDeed()
            : this(1)
        {
        }

        [Constructable]
        public AncientWeaponDeed(int amount)
            : base(0x227B)
        {
            Name = "Ancient Weapon Deed";
            Stackable = false;
            Weight = 1.0;
            Hue = 2101;
            //LootType = LootType.Blessed;

            Amount = amount;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            else
                from.SendGump(new InternalGump(from, this));
        }

        private class InternalGump : Gump
        {
            private Mobile m_From;
            private AncientWeaponDeed m_Deed;

            public InternalGump(Mobile from, AncientWeaponDeed deed)
                : base(50, 50)
            {
                m_From = from;
                m_Deed = deed;

                from.CloseGump(typeof(InternalGump));

                AddPage(0);
                AddBackground(10, 10, 465, 405, 0xA28);

                AddImage(442, 35, 10441);

                AddPage(1);

                AddLabel(120, 25, 0x34, "Select the Type of Weapon you Prefer.");

                AddLabel(75, 55, 59, "Ancient Axes");
                AddLabel(75, 85, 59, "Ancient Bows");
                AddLabel(75, 115, 59, "Ancient Knives");
                AddLabel(75, 145, 59, "Ancient Maces");
                AddLabel(75, 175, 59, "Ancient Pole Arms");
                AddLabel(75, 205, 59, "Ancient Spears and Forks");
                AddLabel(75, 235, 59, "Ancient Staves");
                AddLabel(75, 265, 59, "Ancient Swords");

                AddButton(40, 58, 0x2623, 0x2622, 1, GumpButtonType.Page, 2);
                AddButton(40, 88, 0x2623, 0x2622, 2, GumpButtonType.Page, 3);
                AddButton(40, 118, 0x2623, 0x2622, 3, GumpButtonType.Page, 4);
                AddButton(40, 148, 0x2623, 0x2622, 4, GumpButtonType.Page, 5);
                AddButton(40, 178, 0x2623, 0x2622, 5, GumpButtonType.Page, 6);
                AddButton(40, 208, 0x2623, 0x2622, 6, GumpButtonType.Page, 7);
                AddButton(40, 238, 0x2623, 0x2622, 7, GumpButtonType.Page, 8);
                AddButton(40, 268, 0x2623, 0x2622, 8, GumpButtonType.Page, 9);

                AddPage(2);

                AddLabel(160, 25, 0x34, "Select the Axe you Desire.");

                AddLabel(75, 55, 59, "Ancient Axe");
                AddLabel(75, 85, 59, "Ancient Battle Axe");
                AddLabel(75, 115, 59, "Ancient Double Axe");
                AddLabel(75, 145, 59, "Ancient Executioner's Axe");
                AddLabel(75, 175, 59, "Ancient Hatchet");
                AddLabel(75, 205, 59, "Ancient Large Battle Axe");
                AddLabel(75, 235, 59, "Ancient Pickaxe");
                AddLabel(75, 265, 59, "Ancient Two Handed Axe");
                AddLabel(75, 295, 59, "Ancient War Axe");

                AddButton(40, 58, 0x2623, 0x2622, 1, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 2, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 3, GumpButtonType.Reply, 0);
                AddButton(40, 148, 0x2623, 0x2622, 4, GumpButtonType.Reply, 0);
                AddButton(40, 178, 0x2623, 0x2622, 5, GumpButtonType.Reply, 0);
                AddButton(40, 208, 0x2623, 0x2622, 6, GumpButtonType.Reply, 0);
                AddButton(40, 238, 0x2623, 0x2622, 7, GumpButtonType.Reply, 0);
                AddButton(40, 268, 0x2623, 0x2622, 8, GumpButtonType.Reply, 0);
                AddButton(40, 298, 0x2623, 0x2622, 9, GumpButtonType.Reply, 0);

                AddPage(3);

                AddLabel(160, 25, 0x34, "Select the Bow you Desire.");

                AddLabel(75, 55, 59, "Ancient Bow");
                AddLabel(75, 85, 59, "Ancient Composite Bow");
                AddLabel(75, 115, 59, "Ancient Crossbow");
                AddLabel(75, 145, 59, "Ancient Heavy Crossbow");
                AddLabel(75, 175, 59, "Ancient Repeating Crossbow");

                AddButton(40, 58, 0x2623, 0x2622, 10, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 11, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 12, GumpButtonType.Reply, 0);
                AddButton(40, 148, 0x2623, 0x2622, 13, GumpButtonType.Reply, 0);
                AddButton(40, 178, 0x2623, 0x2622, 14, GumpButtonType.Reply, 0);

                AddPage(4);

                AddLabel(160, 25, 0x34, "Select the Knife you Desire.");

                AddLabel(75, 55, 59, "Ancient Butcher Knife");
                AddLabel(75, 85, 59, "Ancient Cleaver");
                AddLabel(75, 115, 59, "Ancient Dagger");
                AddLabel(75, 145, 59, "Ancient Skinning Knife");

                AddButton(40, 58, 0x2623, 0x2622, 15, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 16, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 17, GumpButtonType.Reply, 0);
                AddButton(40, 148, 0x2623, 0x2622, 18, GumpButtonType.Reply, 0);

                AddPage(5);

                AddLabel(160, 25, 0x34, "Select the Mace you Desire.");

                AddLabel(75, 55, 59, "Ancient Club");
                AddLabel(75, 85, 59, "Ancient Hammer Pick");
                AddLabel(75, 115, 59, "Ancient Mace");
                AddLabel(75, 145, 59, "Ancient Maul");
                AddLabel(75, 175, 59, "Ancient Scepter");
                AddLabel(75, 205, 59, "Ancient War Hammer");
                AddLabel(75, 235, 59, "Ancient War Mace");

                AddButton(40, 58, 0x2623, 0x2622, 19, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 20, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 21, GumpButtonType.Reply, 0);
                AddButton(40, 148, 0x2623, 0x2622, 22, GumpButtonType.Reply, 0);
                AddButton(40, 178, 0x2623, 0x2622, 23, GumpButtonType.Reply, 0);
                AddButton(40, 208, 0x2623, 0x2622, 24, GumpButtonType.Reply, 0);
                AddButton(40, 238, 0x2623, 0x2622, 25, GumpButtonType.Reply, 0);

                AddPage(6);

                AddLabel(140, 25, 0x34, "Select the Pole Arm you Desire.");

                AddLabel(75, 55, 59, "Ancient Bardiche");
                AddLabel(75, 85, 59, "Ancient Halberd");
                AddLabel(75, 115, 59, "Ancient Scythe");

                AddButton(40, 58, 0x2623, 0x2622, 26, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 27, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 28, GumpButtonType.Reply, 0);

                AddPage(7);

                AddLabel(130, 25, 0x34, "Select the Spear or Fork you Desire.");

                AddLabel(75, 55, 59, "Ancient Bladed Staff");
                AddLabel(75, 85, 59, "Ancient Double Bladed Staff");
                AddLabel(75, 115, 59, "Ancient Pike");
                AddLabel(75, 145, 59, "Ancient Pitchfork");
                AddLabel(75, 175, 59, "Ancient Short Spear");
                AddLabel(75, 205, 59, "Ancient Spear");
                AddLabel(75, 235, 59, "Ancient War Fork");

                AddButton(40, 58, 0x2623, 0x2622, 29, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 30, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 31, GumpButtonType.Reply, 0);
                AddButton(40, 148, 0x2623, 0x2622, 32, GumpButtonType.Reply, 0);
                AddButton(40, 178, 0x2623, 0x2622, 33, GumpButtonType.Reply, 0);
                AddButton(40, 208, 0x2623, 0x2622, 34, GumpButtonType.Reply, 0);
                AddButton(40, 238, 0x2623, 0x2622, 35, GumpButtonType.Reply, 0);

                AddPage(8);

                AddLabel(160, 25, 0x34, "Select the Staff you Desire.");

                AddLabel(75, 55, 59, "Ancient Black Staff");
                AddLabel(75, 85, 59, "Ancient Gnarled Staff");
                AddLabel(75, 115, 59, "Ancient Quarter Staff");
                AddLabel(75, 145, 59, "Ancient Shepherd's Crook");

                AddButton(40, 58, 0x2623, 0x2622, 36, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 37, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 38, GumpButtonType.Reply, 0);
                AddButton(40, 148, 0x2623, 0x2622, 39, GumpButtonType.Reply, 0);

                AddPage(9);

                AddLabel(160, 25, 0x34, "Select the Sword you Desire.");

                AddLabel(75, 55, 59, "Ancient Bone Harvester");
                AddLabel(75, 85, 59, "Ancient Broad Sword");
                AddLabel(75, 115, 59, "Ancient Crescent Blade");
                AddLabel(75, 145, 59, "Ancient Cutlass");
                AddLabel(75, 175, 59, "Ancient Katana");
                AddLabel(75, 205, 59, "Ancient Kryss");
                AddLabel(75, 235, 59, "Ancient Lance");
                AddLabel(75, 265, 59, "Ancient Long Sword");
                AddLabel(75, 295, 59, "Ancient Scimitar");
                AddLabel(75, 325, 59, "Ancient Viking Sword");

                AddButton(40, 58, 0x2623, 0x2622, 40, GumpButtonType.Reply, 0);
                AddButton(40, 88, 0x2623, 0x2622, 41, GumpButtonType.Reply, 0);
                AddButton(40, 118, 0x2623, 0x2622, 42, GumpButtonType.Reply, 0);
                AddButton(40, 148, 0x2623, 0x2622, 43, GumpButtonType.Reply, 0);
                AddButton(40, 178, 0x2623, 0x2622, 44, GumpButtonType.Reply, 0);
                AddButton(40, 208, 0x2623, 0x2622, 45, GumpButtonType.Reply, 0);
                AddButton(40, 238, 0x2623, 0x2622, 46, GumpButtonType.Reply, 0);
                AddButton(40, 268, 0x2623, 0x2622, 47, GumpButtonType.Reply, 0);
                AddButton(40, 298, 0x2623, 0x2622, 48, GumpButtonType.Reply, 0);
                AddButton(40, 328, 0x2623, 0x2622, 48, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (m_Deed.Deleted)
                    return;

                Item weapon = null;

                switch (info.ButtonID)
                {
                    case 0: return;
                    case 1: weapon = new AncientAxe(); break;
                    case 2: weapon = new AncientBattleAxe(); break;
                    case 3: weapon = new AncientDoubleAxe(); break;
                    case 4: weapon = new AncientExecutionersAxe(); break;
                    case 5: weapon = new AncientHatchet(); break;
                    case 6: weapon = new AncientLargeBattleAxe(); break;
                    case 7: weapon = new AncientPickaxe(); break;
                    case 8: weapon = new AncientTwoHandedAxe(); break;
                    case 9: weapon = new AncientWarAxe(); break;
                    case 10: weapon = new AncientBow(); break;
                    case 11: weapon = new AncientCompositeBow(); break;
                    case 12: weapon = new AncientCrossbow(); break;
                    case 13: weapon = new AncientHeavyCrossbow(); break;
                    case 14: weapon = new AncientRepeatingCrossbow(); break;
                    case 15: weapon = new AncientButcherKnife(); break;
                    case 16: weapon = new AncientCleaver(); break;
                    case 17: weapon = new AncientDagger(); break;
                    case 18: weapon = new AncientSkinningKnife(); break;
                    case 19: weapon = new AncientClub(); break;
                    case 20: weapon = new AncientHammerPick(); break;
                    case 21: weapon = new AncientMace(); break;
                    case 22: weapon = new AncientMaul(); break;
                    case 23: weapon = new AncientScepter(); break;
                    case 24: weapon = new AncientWarHammer(); break;
                    case 25: weapon = new AncientWarMace(); break;
                    case 26: weapon = new AncientBardiche(); break;
                    case 27: weapon = new AncientHalberd(); break;
                    case 28: weapon = new AncientScythe(); break;
                    case 29: weapon = new AncientBladedStaff(); break;
                    case 30: weapon = new AncientDoubleBladedStaff(); break;
                    case 31: weapon = new AncientPike(); break;
                    case 32: weapon = new AncientPitchfork(); break;
                    case 33: weapon = new AncientShortSpear(); break;
                    case 34: weapon = new AncientSpear(); break;
                    case 35: weapon = new AncientWarFork(); break;
                    case 36: weapon = new AncientBlackStaff(); break;
                    case 37: weapon = new AncientGnarledStaff(); break;
                    case 38: weapon = new AncientQuarterStaff(); break;
                    case 39: weapon = new AncientShepherdsCrook(); break;
                    case 40: weapon = new AncientBoneHarvester(); break;
                    case 41: weapon = new AncientBroadSword(); break;
                    case 42: weapon = new AncientCrescentBlade(); break;
                    case 43: weapon = new AncientCutlass(); break;
                    case 44: weapon = new AncientKatana(); break;
                    case 45: weapon = new AncientKryss(); break;
                    case 46: weapon = new AncientLance(); break;
                    case 47: weapon = new AncientLongSword(); break;
                    case 48: weapon = new AncientScimitar(); break;
                    case 49: weapon = new AncientVikingSword(); break;
                }



                if (weapon != null)
                {

                    m_From.Backpack.DropItem(weapon);
                    m_From.SendMessage("You summon the Ancient Weapon!");
                    //m_From.AddItem( weapon );
                }

                m_Deed.Delete();
            }
        }

        public AncientWeaponDeed(Serial serial)
            : base(serial)
        {
        }

        //------------------------------------------------------------------Removed For RunUO 2.0 SVN Compatability---------//


        // public override Item Dupe( int amount )
        //{
        //	return base.Dupe( new AncientWeaponDeed( amount ), amount );
        //}

        //------------------------------------------------------------------------------------------------------------------//

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
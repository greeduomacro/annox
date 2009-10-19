using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.ContextMenus;
using Server.Items;
using Server.Gumps;

namespace Server.Mobiles
{

    [CorpseName("a weapon collector's corpse")]
    public class WeaponsCollector : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public WeaponsCollector()
            : base()


//----------------------------------------------------------------------------------------------------//
        {
            Body = 400;
            Hue = Utility.RandomSkinHue();
            if (Female = Utility.RandomBool())
            {
                Body = 401;
                Name = NameList.RandomName("female");
            }
            else
            {
                Name = NameList.RandomName("male");
            }


            //----------------------------------------------------------------------------------------------------//

            //Title = "[A Weapons Collector]";
            //CantWalk = true;
            Direction = Direction.South;
            Hue = Utility.RandomSkinHue();
            Utility.AssignRandomHair(this);
            Blessed = true;


            BodySash bs = new BodySash();
            bs.Hue = 33;
            AddItem(bs);

            PlateArms pa = new PlateArms();
            pa.Hue = 0;
            AddItem(pa);

            PlateChest pc = new PlateChest();
            pc.Hue = 0;
            AddItem(pc);

            PlateGloves pg = new PlateGloves();
            pg.Hue = 0;
            AddItem(pg);

            PlateLegs pl = new PlateLegs();
            pl.Hue = 0;
            AddItem(pl);

            PlateGorget pt = new PlateGorget();
            pt.Hue = 0;
            AddItem(pt);

            //----------------------------------------------------------------------------------------------------//

        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new WeaponsCollectorEntry(from, this));
        }

        public class WeaponsCollectorEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public WeaponsCollectorEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {


                if (!(m_Mobile is PlayerMobile))
                    return;

                PlayerMobile mobile = (PlayerMobile)m_Mobile;

                {
                    if (!mobile.HasGump(typeof(WeaponsCollectorGump)))
                    {
                        mobile.SendGump(new WeaponsCollectorGump(mobile));
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------//

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            Mobile m = from;
            PlayerMobile mobile = m as PlayerMobile;

            if (mobile != null)
            {
                if

//----------------------------------------------------------------------------------------------------//



//----------------------------------------------------------------------------------------------------//

//---------Follow The Format Below To Add Your Own Weapons For The Weapons Collector To Buy-----------//

//----------------------------------------------------------------------------------------------------//



//--------------------------------------------------------------------------Ancient Weapon Set--------//

((dropped is AncientAxe)
| (dropped is AncientBattleAxe)
| (dropped is AncientDoubleAxe)
| (dropped is AncientExecutionersAxe)
| (dropped is AncientHatchet)
| (dropped is AncientLargeBattleAxe)
| (dropped is AncientPickaxe)
| (dropped is AncientTwoHandedAxe)
| (dropped is AncientWarAxe)
| (dropped is AncientBow)
| (dropped is AncientCompositeBow)
| (dropped is AncientCrossbow)
| (dropped is AncientHeavyCrossbow)
| (dropped is AncientRepeatingCrossbow)
| (dropped is AncientButcherKnife)
| (dropped is AncientCleaver)
| (dropped is AncientDagger)
| (dropped is AncientSkinningKnife)
| (dropped is AncientClub)
| (dropped is AncientHammerPick)
| (dropped is AncientMace)
| (dropped is AncientMaul)
| (dropped is AncientScepter)
| (dropped is AncientWarHammer)
| (dropped is AncientWarMace)
| (dropped is AncientBardiche)
| (dropped is AncientHalberd)
| (dropped is AncientScythe)
| (dropped is AncientBladedStaff)
| (dropped is AncientDoubleBladedStaff)
| (dropped is AncientPike)
| (dropped is AncientPitchfork)
| (dropped is AncientShortSpear)
| (dropped is AncientSpear)
| (dropped is AncientWarFork)
| (dropped is AncientBlackStaff)
| (dropped is AncientGnarledStaff)
| (dropped is AncientQuarterStaff)
| (dropped is AncientShepherdsCrook)
| (dropped is AncientBoneHarvester)
| (dropped is AncientBroadSword)
| (dropped is AncientCrescentBlade)
| (dropped is AncientCutlass)
| (dropped is AncientKatana)
| (dropped is AncientKryss)
| (dropped is AncientLance)
| (dropped is AncientLongSword)
| (dropped is AncientScimitar)
| (dropped is AncientVikingSword)

//----------------------------------------------------------------------------Venom Weapon Set---------//


| (dropped is VenomAxe)
| (dropped is VenomBattleAxe)
| (dropped is VenomDoubleAxe)
| (dropped is VenomExecutionersAxe)
| (dropped is VenomHatchet)
| (dropped is VenomLargeBattleAxe)
| (dropped is VenomPickaxe)
| (dropped is VenomTwoHandedAxe)
| (dropped is VenomWarAxe)
| (dropped is VenomButcherKnife)
| (dropped is VenomCleaver)
| (dropped is VenomDagger)
| (dropped is VenomSkinningKnife)
| (dropped is VenomClub)
| (dropped is VenomHammerPick)
| (dropped is VenomMace)
| (dropped is VenomMaul)
| (dropped is VenomScepter)
| (dropped is VenomWarHammer)
| (dropped is VenomWarMace)
| (dropped is VenomBardiche)
| (dropped is VenomHalberd)
| (dropped is VenomScythe)
| (dropped is VenomBow)
| (dropped is VenomCompositeBow)
| (dropped is VenomCrossbow)
| (dropped is VenomHeavyCrossbow)
| (dropped is VenomRepeatingCrossbow)
| (dropped is VenomBladedStaff)
| (dropped is VenomDoubleBladedStaff)
| (dropped is VenomPike)
| (dropped is VenomPitchfork)
| (dropped is VenomShortSpear)
| (dropped is VenomSpear)
| (dropped is VenomWarFork)
| (dropped is VenomBlackStaff)
| (dropped is VenomGnarledStaff)
| (dropped is VenomQuarterStaff)
| (dropped is VenomShepherdsCrook)
| (dropped is VenomBoneHarvester)
| (dropped is VenomBroadSword)
| (dropped is VenomCrescentBlade)
| (dropped is VenomCutlass)
| (dropped is VenomKatana)
| (dropped is VenomKryss)
| (dropped is VenomLance)
| (dropped is VenomLongSword)
| (dropped is VenomScimitar)
| (dropped is VenomVikingSword)


//-----------------------------------------------------------------------------Soul Weapon Set---------//

| (dropped is EntrappedSoulAxe)
| (dropped is EntrappedSoulBattleAxe)
| (dropped is EntrappedSoulDoubleAxe)
| (dropped is EntrappedSoulExecutionersAxe)
| (dropped is EntrappedSoulHatchet)
| (dropped is EntrappedSoulLargeBattleAxe)
| (dropped is EntrappedSoulPickaxe)
| (dropped is EntrappedSoulTwoHandedAxe)
| (dropped is EntrappedSoulWarAxe)
| (dropped is EntrappedSoulButcherKnife)
| (dropped is EntrappedSoulCleaver)
| (dropped is EntrappedSoulDagger)
| (dropped is EntrappedSoulSkinningKnife)
| (dropped is EntrappedSoulClub)
| (dropped is EntrappedSoulHammerPick)
| (dropped is EntrappedSoulMace)
| (dropped is EntrappedSoulMaul)
| (dropped is EntrappedSoulScepter)
| (dropped is EntrappedSoulWarHammer)
| (dropped is EntrappedSoulWarMace)
| (dropped is EntrappedSoulBardiche)
| (dropped is EntrappedSoulHalberd)
| (dropped is EntrappedSoulScythe)
| (dropped is EntrappedSoulBow)
| (dropped is EntrappedSoulCompositeBow)
| (dropped is EntrappedSoulCrossbow)
| (dropped is EntrappedSoulHeavyCrossbow)
| (dropped is EntrappedSoulRepeatingCrossbow)
| (dropped is EntrappedSoulBladedStaff)
| (dropped is EntrappedSoulDoubleBladedStaff)
| (dropped is EntrappedSoulPike)
| (dropped is EntrappedSoulPitchfork)
| (dropped is EntrappedSoulShortSpear)
| (dropped is EntrappedSoulSpear)
| (dropped is EntrappedSoulWarFork)
| (dropped is EntrappedSoulBlackStaff)
| (dropped is EntrappedSoulGnarledStaff)
| (dropped is EntrappedSoulQuarterStaff)
| (dropped is EntrappedSoulShepherdsCrook)
| (dropped is EntrappedSoulBoneHarvester)
| (dropped is EntrappedSoulBroadSword)
| (dropped is EntrappedSoulCrescentBlade)
| (dropped is EntrappedSoulCutlass)
| (dropped is EntrappedSoulKatana)
| (dropped is EntrappedSoulKryss)
| (dropped is EntrappedSoulLance)
| (dropped is EntrappedSoulLongSword)
| (dropped is EntrappedSoulScimitar)
| (dropped is EntrappedSoulVikingSword)

//-----------------------------------------------------------------------------Area Weapon Set---------//

| (dropped is AreaAxe)
| (dropped is AreaBattleAxe)
| (dropped is AreaDoubleAxe)
| (dropped is AreaExecutionersAxe)
| (dropped is AreaHatchet)
| (dropped is AreaLargeBattleAxe)
| (dropped is AreaPickaxe)
| (dropped is AreaTwoHandedAxe)
| (dropped is AreaWarAxe)
| (dropped is AreaButcherKnife)
| (dropped is AreaCleaver)
| (dropped is AreaDagger)
| (dropped is AreaSkinningKnife)
| (dropped is AreaClub)
| (dropped is AreaHammerPick)
| (dropped is AreaMace)
| (dropped is AreaMaul)
| (dropped is AreaScepter)
| (dropped is AreaWarHammer)
| (dropped is AreaWarMace)
| (dropped is AreaBardiche)
| (dropped is AreaHalberd)
| (dropped is AreaScythe)
| (dropped is AreaBow)
| (dropped is AreaCompositeBow)
| (dropped is AreaCrossbow)
| (dropped is AreaHeavyCrossbow)
| (dropped is AreaRepeatingCrossbow)
| (dropped is AreaBladedStaff)
| (dropped is AreaDoubleBladedStaff)
| (dropped is AreaPike)
| (dropped is AreaPitchfork)
| (dropped is AreaShortSpear)
| (dropped is AreaSpear)
| (dropped is AreaWarFork)
| (dropped is AreaBlackStaff)
| (dropped is AreaGnarledStaff)
| (dropped is AreaQuarterStaff)
| (dropped is AreaShepherdsCrook)
| (dropped is AreaBoneHarvester)
| (dropped is AreaBroadSword)
| (dropped is AreaCrescentBlade)
| (dropped is AreaCutlass)
| (dropped is AreaKatana)
| (dropped is AreaKryss)
| (dropped is AreaLance)
| (dropped is AreaLongSword)
| (dropped is AreaScimitar)
| (dropped is AreaVikingSword)

//--------------------------------------------------------------------------Standard Weapon Set-------//

| (dropped is Axe)
| (dropped is BattleAxe)
| (dropped is DoubleAxe)
| (dropped is ExecutionersAxe)
| (dropped is Hatchet)
| (dropped is LargeBattleAxe)
| (dropped is Pickaxe)
| (dropped is TwoHandedAxe)
| (dropped is WarAxe)
| (dropped is ButcherKnife)
| (dropped is Cleaver)
| (dropped is Dagger)
| (dropped is SkinningKnife)
| (dropped is Club)
| (dropped is HammerPick)
| (dropped is Mace)
| (dropped is Maul)
| (dropped is Scepter)
| (dropped is WarHammer)
| (dropped is WarMace)
| (dropped is Bardiche)
| (dropped is Halberd)
| (dropped is Scythe)
| (dropped is Bow)
| (dropped is CompositeBow)
| (dropped is Crossbow)
| (dropped is HeavyCrossbow)
| (dropped is RepeatingCrossbow)
| (dropped is BladedStaff)
| (dropped is DoubleBladedStaff)
| (dropped is Pike)
| (dropped is Pitchfork)
| (dropped is ShortSpear)
| (dropped is Spear)
| (dropped is WarFork)
| (dropped is BlackStaff)
| (dropped is GnarledStaff)
| (dropped is QuarterStaff)
| (dropped is ShepherdsCrook)
| (dropped is BoneHarvester)
| (dropped is Broadsword)
| (dropped is CrescentBlade)
| (dropped is Cutlass)
| (dropped is Katana)
| (dropped is Kryss)
| (dropped is Lance)
| (dropped is Longsword)
| (dropped is Scimitar)
| (dropped is VikingSword))

                //--------------------------------------------------------------------<New Set Name> Weapon Set-------//

                // Left Blank For Further Additions...

                //----------------------------------------------------------------------------------------------------//

                //---------Follow The Format Above To Add Your Own Weapons For The Weapons Collector To Buy-----------//

                //----------------------------------------------------------------------------------------------------//
                {
                    mobile.AddToBackpack(new Gold(1500, 2500));
                    mobile.SendMessage("You have sold your Weapon to the Weapons Collector!");
                    this.PrivateOverheadMessage(MessageType.Regular, 0, false, "I thank thee kindly!", mobile.NetState);
                    dropped.Delete();

                }

                else
                {
                    this.PrivateOverheadMessage(MessageType.Regular, 0, false, "I have no need for this item.", mobile.NetState);

                }
            }

            return base.OnDragDrop(from, dropped);
        }

        public WeaponsCollector(Serial serial)
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
        }
    }
}
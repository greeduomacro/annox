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

    [CorpseName("a book collector's corpse")]
    public class BookCollector : Mobile
    {

        public virtual bool IsInvulnerable { get { return true; } }

        [Constructable]
        public BookCollector()
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

            //Title = "[A Book Collector]";
            //CantWalk = true;
            Direction = Direction.South;
            Hue = Utility.RandomSkinHue();
            Utility.AssignRandomHair(this);
            Blessed = true;


            BodySash bs = new BodySash();
            bs.Hue = 33;
            AddItem(bs);

            //PlateArms pa = new PlateArms();
            //pa.Hue = 0;
            //AddItem(pa);

            FormalShirt pc = new FormalShirt();
            pc.Hue = 0;
            AddItem(pc);

            //PlateGloves pg = new PlateGloves();
            //pg.Hue = 0;
            //AddItem(pg);

            LongPants pl = new LongPants();
            pl.Hue = 0;
            AddItem(pl);

            Sandals pt = new Sandals();
            pt.Hue = 0;
            AddItem(pt);

            //----------------------------------------------------------------------------------------------------//

        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new BookCollectorEntry(from, this));
        }

        public class BookCollectorEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public BookCollectorEntry(Mobile from, Mobile giver)
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
                    if (!mobile.HasGump(typeof(BookCollectorGump)))
                    {
                        mobile.SendGump(new BookCollectorGump(mobile));
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

//---------Follow The Format Below To Add Your Own Books For The Book Collector To Buy-----------//

//----------------------------------------------------------------------------------------------------//



//--------------------------------------------------------------------------XGuardians OSI Books--------//

 ((dropped is BeltranGuideBook)
| (dropped is BirdsBritanniaBook)
| (dropped is BritannianFloraBook)
| (dropped is ClassicChildrenTalesVolumeOneBook)
| (dropped is ClassicChildrenTalesVolumeTwoBook)
| (dropped is ClassicTalesOfVesperBook)
| (dropped is DeceitDungeonHorrosBook)
| (dropped is DimensionalTravelBook)
| (dropped is DiversityLandBook)
| (dropped is EthicalHedonismBook)
| (dropped is GrammerOrcischBook)
| (dropped is JournalDiscoveryDay11and13Tomb)
| (dropped is JournalDiscoveryDay14and15Tomb)
| (dropped is JournalDiscoveryDay15and16Tomb)
| (dropped is JournalDiscoveryDay17and19Tomb)
| (dropped is JournalDiscoveryDay19and21Tomb)
| (dropped is JournalDiscoveryDay1Tomb)
| (dropped is JournalDiscoveryDay2Tomb)
| (dropped is JournalDiscoveryDay3and5Tomb)
| (dropped is JournalDiscoveryDay6Tomb)
| (dropped is JournalDiscoveryDay7Tomb)
| (dropped is JournalDiscoveryDay8Tomb)
| (dropped is JournalDiscoveryDay9and10Tomb)
| (dropped is JournalGrimmochDrummel11Day13)
| (dropped is JournalGrimmochDrummel14Day16)
| (dropped is JournalGrimmochDrummel7Day10)
| (dropped is JournalGrimmochDrummel17Day22)
| (dropped is JournalGrimmochDrummel3Day5)
| (dropped is JournalGrimmochDrummelDay1)
| (dropped is JournalGrimmochDrummelDay2)
| (dropped is JournalGrimmochDrummelDay23)
| (dropped is JournalGrimmochDrummelDay6)
| (dropped is LysanderDay11and13Book)
| (dropped is LysanderDay1Book)
| (dropped is LysanderDay2Book)
| (dropped is LysanderDay3and6Book)
| (dropped is LysanderDay7Book)
| (dropped is LysanderDay8and10Book)
| (dropped is MyStoryBook)
| (dropped is PhonemesOrcishTongueBook)
| (dropped is PoliticalCallBook)
| (dropped is PrimerArmsBook)
| (dropped is RankingTradesBook)
| (dropped is RegardingLlamasBook)
| (dropped is SongOfSamletheBook)
| (dropped is TaleTribesBook)
| (dropped is TalkingWispsBook)
| (dropped is TamingDragonsBook)
| (dropped is TheBoldStangerBook)
| (dropped is TheBurningOfTrinsicBook)
| (dropped is TheFightBook)
| (dropped is TheLifeTravelingBook)
| (dropped is TheMajorTradeBook)
| (dropped is TheWildGirlBook)
| (dropped is TreatiseAlchemyBook))


                //--------------------------------------------------------------------<New Set Name> Book Set-------//

                // Left Blank For Further Additions...

                //----------------------------------------------------------------------------------------------------//

                //---------Follow The Format Above To Add Your Own Books For The Book Collector To Buy-----------//

                //----------------------------------------------------------------------------------------------------//
                {
                    mobile.AddToBackpack(new Gold(1500, 2500));
                    mobile.SendMessage("You have sold your book to the Book Collector!");
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

        public BookCollector(Serial serial)
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
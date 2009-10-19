/*
Runic Casting 29JAN2008 (rename by RavonTUS since there are two may "Rune" things already)
 
Rune Magic System originally scripted by Alari

Rune Magic 2.0 scripted from Alari's Rune Magic System by Vhaerun

Notes:

I've moved the runes themselves to a seperate script for ease of modification for
individual shards and rescripted the BaseRune type to include a SpellCrafting-like
ability that requires the magery skill to use.

As I have not had to mess with serial/deserials, this should be a plug-and-play
script, and be able to be implemented overtop of the original Rune Magic System
scripted by Alari. My thanks go to her... both this and the CRL Homestead would
not be possible without her first laying the groundwork.

I've tried to clean up the scripting a little, keeping in the notes that are
the most important to those not familiar with the system in general.

*/

using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;

namespace Server.Items
{
    public class RunicCastingBag : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x3D; } }
        public override int DefaultDropSound { get { return 0x48; } }

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(29, 34, 108, 94); }
        }

        [Constructable]
        public RunicCastingBag()
            : base(0xE76)
        {
            Name = "Runic Casting Bag";
            Weight = 1.0;
            LootType = LootType.Blessed;
            Hue = Utility.RandomBirdHue();
        }

        public override bool DisplayLootType { get { return false; } }

        public void RunicCastingBagCast(Mobile m, RunicCastingBag bag)
        {
            // descs from U6. For reference.
            // I've left in my notes for rareness, this is custom to my shard.

            bool foundAn = false; // Negate/Dispel	- common
            bool foundBal = false;
            bool foundBet = false; // Small		- semi-common
            bool foundChar = false;
            bool foundCorp = false; // Death		- rare
            bool foundDes = false; // Lower/Down		- semi-common
            bool foundEx = false; // Freedom		- semi-common
            bool foundFlam = false; // Flame		- semi-common
            bool foundGrav = false; // Energy/Field	- rare
            bool foundHur = false; // Wind		- semi-common
            bool foundIn = false; // Make/Create/Cause	- common
            bool foundJux = false; // Danger/Trap/Harm	- semi-common
            bool foundKal = false; // Summon/Invoke	- common
            bool foundLor = false; // Light		- common
            bool foundMani = false; // Life/Healing	- common
            bool foundNox = false; // Poison		- semi-common
            bool foundAgle = false;
            bool foundOrt = false; // Magic		- semi-common
            bool foundPas = false;
            bool foundPor = false; // Move/Movement	- semi-common
            bool foundQuas = false; // Illusion		- semi-common
            bool foundRel = false; // Change		- common
            bool foundSanct = false; // Protect/Protection	- semi-common
            bool foundSar = false;
            bool foundTym = false; // Time		- rare
            bool foundUm = false;
            bool foundUus = false; // Raise/Up		- semi-common
            bool foundVas = false; // Great		- rare
            bool foundWis = false; // Know/Knowledge	- semi-common
            bool foundXen = false; // Creature		- semi-common
            bool foundYlem = false; // Matter		- semi-common
            bool foundZu = false; // Sleep		- semi-common

            foreach (Item I in bag.Items)
            {
                if (I is An)
                    foundAn = true;
                if (I is Bal)
                    foundBal = true;
                if (I is Bet)
                    foundBet = true;
                if (I is CharRune)
                    foundChar = true;
                if (I is Corp)
                    foundCorp = true;
                if (I is Des)
                    foundDes = true;
                if (I is Ex)
                    foundEx = true;
                if (I is Flam)
                    foundFlam = true;
                if (I is Grav)
                    foundGrav = true;
                if (I is Hur)
                    foundHur = true;
                if (I is In)
                    foundIn = true;
                if (I is Jux)
                    foundJux = true;
                if (I is Kal)
                    foundKal = true;
                if (I is Lor)
                    foundLor = true;
                if (I is Mani)
                    foundMani = true;
                if (I is Nox)
                    foundNox = true;
                if (I is Agle)
                    foundAgle = true;
                if (I is Ort)
                    foundOrt = true;
                if (I is Pas)
                    foundPas = true;
                if (I is Por)
                    foundPor = true;
                if (I is Quas)
                    foundQuas = true;
                if (I is Rel)
                    foundRel = true;
                if (I is Sanct)
                    foundSanct = true;
                if (I is Sar)
                    foundSar = true;
                if (I is Tym)
                    foundTym = true;
                if (I is Um)
                    foundUm = true;
                if (I is Uus)
                    foundUus = true;
                if (I is Vas)
                    foundVas = true;
                if (I is Wis)
                    foundWis = true;
                if (I is Xen)
                    foundXen = true;
                if (I is Ylem)
                    foundYlem = true;
                if (I is Zu)
                    foundZu = true;
            }


            int m_SpellID = -1;  // no match


            /// spells go here.  ////////////////////////////////////////////
            //if ( ( found ) ) && bag.Items.Count ==  )
            //    m_SpellID = ;

            ///  first circle   /////////////////////////////////////////////

            // clumsy: Uus Jux
            if ((foundUus && foundJux) && bag.Items.Count == 2)
                m_SpellID = 0;

            // Create food: In Mani Ylem
            if ((foundIn && foundMani && foundYlem) && bag.Items.Count == 3)
                m_SpellID = 1;

            // Feeblemind: Rel Wis
            if ((foundRel && foundWis) && bag.Items.Count == 2)
                m_SpellID = 2;

            // Heal: In Mani
            if ((foundIn && foundMani) && bag.Items.Count == 2)
                m_SpellID = 3;

            // Magic arrow: In Por Ylem
            if ((foundIn && foundPor && foundYlem) && bag.Items.Count == 3)
                m_SpellID = 4;

            // Night sight: In Lor
            if ((foundIn && foundLor) && bag.Items.Count == 2)
                m_SpellID = 5;

            // Reactive armor: Flam Sanct
            if ((foundFlam && foundSanct) && bag.Items.Count == 2)
                m_SpellID = 6;

            // Weaken: Des Mani
            if ((foundDes && foundMani) && bag.Items.Count == 2)
                m_SpellID = 7;


            ///  second circle   ///////////////////////////////////////////////

            // Agility: Ex Uus
            if ((foundUus && foundEx) && bag.Items.Count == 2)
                m_SpellID = 8;

            // Cunning: Uus Wis
            if ((foundUus && foundWis) && bag.Items.Count == 2)
                m_SpellID = 9;

            // Cure: An Nox
            if ((foundAn && foundNox) && bag.Items.Count == 2)
                m_SpellID = 10;

            // Harm: An Mani
            if ((foundAn && foundMani) && bag.Items.Count == 2)
                m_SpellID = 11;

            // Magic Trap: In Jux
            if ((foundIn && foundJux) && bag.Items.Count == 2)
                m_SpellID = 12;

            // Magic Untrap: An Jux
            if ((foundAn && foundJux) && bag.Items.Count == 2)
                m_SpellID = 13;

            // Protection: Uus Sanct
            if ((foundUus && foundSanct) && bag.Items.Count == 2)
                m_SpellID = 14;

            // Strength: Uus Mani
            if ((foundUus && foundMani) && bag.Items.Count == 2)
                m_SpellID = 15;


            ///  Third circle   ////////////////////////////////////////////

            // Bless: Rel Sanct
            if ((foundRel && foundSanct) && bag.Items.Count == 2)
                m_SpellID = 16;

            // Fireball: Vas Flam
            if ((foundVas && foundFlam) && bag.Items.Count == 2)
                m_SpellID = 17;

            // Magic Lock: An Por
            if ((foundAn && foundPor) && bag.Items.Count == 2)
                m_SpellID = 18;

            // Poison: In Nox
            if ((foundIn && foundNox) && bag.Items.Count == 2)
                m_SpellID = 19;

            // Telekinesis: Ort Por Ylem
            if ((foundOrt && foundPor && foundYlem) && bag.Items.Count == 3)
                m_SpellID = 20;

            // Teleport: Rel Por
            if ((foundRel && foundPor) && bag.Items.Count == 2)
                m_SpellID = 21;

            // Unlock: Ex Por
            if ((foundEx && foundPor) && bag.Items.Count == 2)
                m_SpellID = 22;

            // Wall of Stone: In Sanct Ylem
            if ((foundIn && foundSanct && foundYlem) && bag.Items.Count == 3)
                m_SpellID = 23;


            ///  Fourth circle   ////////////////////////////////////////////

            // Arch Cure: Vas An Nox
            if ((foundVas && foundAn && foundNox) && bag.Items.Count == 3)
                m_SpellID = 24;

            // Arch Protection: Vas Uus Sanct
            if ((foundVas && foundUus && foundSanct) && bag.Items.Count == 3)
                m_SpellID = 25;

            // Curse: Des Sanct
            if ((foundDes && foundSanct) && bag.Items.Count == 2)
                m_SpellID = 26;

            // Fire Field: In Flam Grav
            if ((foundIn && foundFlam && foundGrav) && bag.Items.Count == 3)
                m_SpellID = 27;

            // Greater Heal: In Vas Mani
            if ((foundIn && foundVas && foundMani) && bag.Items.Count == 3)
                m_SpellID = 28;

            // Lightning: Por Ort Grav
            if ((foundPor && foundOrt && foundGrav) && bag.Items.Count == 3)
                m_SpellID = 29;

            // Mana Drain: Ort Rel
            if ((foundOrt && foundRel) && bag.Items.Count == 2)
                m_SpellID = 30;

            // Recall: Kal Ort Por
            if ((foundKal && foundOrt && foundPor) && bag.Items.Count == 3)
                m_SpellID = 31;


            /// Fifth  circle   ////////////////////////////////////////////

            // Blade Spirits: In Jux Hur Ylem
            if ((foundIn && foundJux && foundHur && foundYlem) && bag.Items.Count == 4)
                m_SpellID = 32;

            // Dispel Field: An Grav
            if ((foundAn && foundGrav) && bag.Items.Count == 2)
                m_SpellID = 33;

            // Incognito: Kal In Ex
            if ((foundKal && foundIn && foundEx) && bag.Items.Count == 3)
                m_SpellID = 34;

            // Magic Reflection: In Jux Sanct
            if ((foundIn && foundJux && foundSanct) && bag.Items.Count == 3)
                m_SpellID = 35;

            // Mind Blast: Por Corp Wis
            if ((foundPor && foundCorp && foundWis) && bag.Items.Count == 3)
                m_SpellID = 36;

            // Paralyze: An Ex Por
            if ((foundAn && foundEx && foundPor) && bag.Items.Count == 3)
                m_SpellID = 37;

            // PoisonField: In Nox Grav
            if ((foundIn && foundNox && foundGrav) && bag.Items.Count == 3)
                m_SpellID = 38;

            // Summon Creature: Kal Xen
            if ((foundKal && foundXen) && bag.Items.Count == 2)
                m_SpellID = 39;


            /// Sixth  circle   ////////////////////////////////////////////

            // Dispel: An Ort
            if ((foundAn && foundOrt) && bag.Items.Count == 2)
                m_SpellID = 40;

            // Eenrgy Bolt: Corp Por
            if ((foundCorp && foundPor) && bag.Items.Count == 2)
                m_SpellID = 41;

            // Explosion: Vas Ort Flam
            if ((foundVas && foundOrt && foundFlam) && bag.Items.Count == 3)
                m_SpellID = 42;

            // Invisibility: An Lor Xen
            if ((foundAn && foundLor && foundXen) && bag.Items.Count == 3)
                m_SpellID = 43;

            // Mark: Kal Por Ylem
            if ((foundKal && foundPor && foundYlem) && bag.Items.Count == 3)
                m_SpellID = 44;

            // Mass Curse: Vas Des Sanct
            if ((foundVas && foundDes && foundSanct) && bag.Items.Count == 3)
                m_SpellID = 45;

            // Paralyze Field: In Ex Grav
            if ((foundIn && foundEx && foundGrav) && bag.Items.Count == 3)
                m_SpellID = 46;

            // Reveal: Wis Quas
            if ((foundWis && foundQuas) && bag.Items.Count == 2)
                m_SpellID = 47;


            /// Seventh  circle   ////////////////////////////////////////////

            // Chain Lightning: Vas Ort Grav
            if ((foundVas && foundOrt && foundGrav) && bag.Items.Count == 3)
                m_SpellID = 48;

            // Energy Field: In Sanct Grav
            if ((foundIn && foundSanct && foundGrav) && bag.Items.Count == 3)
                m_SpellID = 49;

            // Flame Strike: Kal Vas Flam
            if ((foundKal && foundVas && foundFlam) && bag.Items.Count == 3)
                m_SpellID = 50;

            // Gate Travel: Vas Rel Por
            if ((foundVas && foundRel && foundPor) && bag.Items.Count == 3)
                m_SpellID = 51;

            // Mana Vampire: Ort Sanct
            if ((foundOrt && foundSanct) && bag.Items.Count == 2)
                m_SpellID = 52;

            // Mass Dispel: Vas An Ort
            if ((foundVas && foundAn && foundOrt) && bag.Items.Count == 3)
                m_SpellID = 53;

            // Meteor Swarm: Flam Kal Des Ylem
            if ((foundFlam && foundKal && foundDes && foundYlem) && bag.Items.Count == 4)
                m_SpellID = 54;

            // Polymorph: Vas Ylem Rel
            if ((foundVas && foundYlem && foundRel) && bag.Items.Count == 3)
                m_SpellID = 55;


            // Captain the First was the First one to code the 8th circle spells and publish them!
            /// Eighth  circle   //////////////////////////////////////////// 

            // "Earthquake", "In Vas Por" 
            if ((foundIn && foundVas && foundPor) && bag.Items.Count == 3)
                m_SpellID = 56;

            // "Energy Vortex", "Vas Corp Por" 
            if ((foundVas && foundCorp && foundPor) && bag.Items.Count == 3)
                m_SpellID = 57;

            // "Resurrection", "An Corp" 
            if ((foundAn && foundCorp) && bag.Items.Count == 2)
                m_SpellID = 58;

            // "Air Elemental", "Kal Vas Xen Hur" 
            if ((foundKal && foundVas && foundXen && foundHur) && bag.Items.Count == 4)
                m_SpellID = 59;

            // "Summon Daemon", "Kal Vas Xen Corp" 
            if ((foundKal && foundVas && foundXen && foundCorp) && bag.Items.Count == 4)
                m_SpellID = 60;

            // "Earth Elemental", "Kal Vas Xen Ylem" 
            if ((foundKal && foundVas && foundXen && foundYlem) && bag.Items.Count == 4)
                m_SpellID = 61;

            // "Fire Elemental", "Kal Vas Xen Flam" 
            if ((foundKal && foundVas && foundXen && foundFlam) && bag.Items.Count == 4)
                m_SpellID = 62;

            // "Water Elemental", "Kal Vas Xen An Flam" 
            if ((foundKal && foundVas && foundXen && foundAn && foundFlam) && bag.Items.Count == 5)
                m_SpellID = 63;

            // Necromancy Spells ///////////////////////////////

            // Animate Dead, "Uus Corp"
            if ((foundUus && foundCorp) && bag.Items.Count == 2)
                m_SpellID = 100;

            // Blood Oath, "In Jux Mani Xen"
            if ((foundIn && foundJux && foundMani && foundXen) && bag.Items.Count == 4)
                m_SpellID = 101;

            // Corpse Skin, "In Agle Corp Ylem"
            if ((foundIn && foundAgle && foundCorp && foundYlem) && bag.Items.Count == 4)
                m_SpellID = 102;

            // Curse Weapon, "An Sanct Grav Char"
            if ((foundAn && foundSanct && foundGrav && foundChar) && bag.Items.Count == 4)
                m_SpellID = 103;

            // Evil Omen, "Pas Tym An Sanct"
            if ((foundPas && foundTym && foundAn && foundSanct) && bag.Items.Count == 4)
                m_SpellID = 104;

            // Exorcism, "Ort Corp Grav"
            if ((foundOrt && foundCorp && foundGrav) && bag.Items.Count == 3)
                m_SpellID = 116;

            // Horrific Beast, "Rel Xen Vas Bal"
            if ((foundRel && foundXen && foundVas && foundBal) && bag.Items.Count == 4)
                m_SpellID = 105;

            // Lich Form, "Rel Xen Corp Ort"
            if ((foundRel && foundXen && foundCorp && foundOrt) && bag.Items.Count == 4)
                m_SpellID = 106;

            // Mind Rot, "Wis An Bet"
            if ((foundWis && foundAn && foundBet) && bag.Items.Count == 3)
                m_SpellID = 107;

            // Pain Spike, "In Sar"
            if ((foundIn && foundSar) && bag.Items.Count == 2)
                m_SpellID = 108;

            // Poison Spike, "In Vas Nox"
            if ((foundIn && foundVas && foundNox) && bag.Items.Count == 3)
                m_SpellID = 109;

            // Strangle, "In Bal Nox"
            if ((foundIn && foundBal && foundNox) && bag.Items.Count == 3)
                m_SpellID = 110;

            // Summon Familiar, "Kal Xen Bal"
            if ((foundKal && foundXen && foundBal) && bag.Items.Count == 3)
                m_SpellID = 111;

            // Vampiric Embrace, "Rel Xen An Sanct"
            if ((foundRel && foundXen && foundAn && foundSanct) && bag.Items.Count == 4)
                m_SpellID = 112;

            // Vengeful Spirit, "Kal Xen Bal Bet"
            if ((foundKal && foundXen && foundBal && foundBet) && bag.Items.Count == 4)
                m_SpellID = 113;

            // Wither, "Kal Vas An Flam"
            if ((foundKal && foundVas && foundAn && foundFlam) && bag.Items.Count == 4)
                m_SpellID = 114;

            // Wraith Form, "Rel Xen Um"
            if ((foundRel && foundXen && foundUm) && bag.Items.Count == 3)
                m_SpellID = 115;

            /// end spells /////////////////////////////////////

            if (foundZu)  // currently unused.
                m.SendLocalizedMessage(1008128); //	*shudders from extreme cold!*
            //m.SendMessage("One of the runestones feels cold.");

            /// end spells /////////////////////////////////////


            /// begin spellcasting /////////////////////////////


            if (!Multis.DesignContext.Check(m))
                return; // They are customizing

            if (!IsChildOf(m.Backpack))
            {
                m.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            if (m_SpellID == -1)
            {
                //1042648	Error: Invalid Special Effect Number
                //500202	Spell failed
                //500208	It appears to be blank.
                //501631	You have failed to create the rune book.
                //501999	hrmph, I failed.
                //1010548	I failed at isGoodObject.
                //1042148	Creation failed.  Please try again.
                //1044043	You failed to create the item, and some of your materials are lost.
                //3000027	Bind Failed
                //1044043	You failed to create the item, and some of your materials are lost.
                //1044157	You fail to create the item, but no materials were lost.
                m.SendLocalizedMessage(1044043); //	You failed to create the item, and some of your materials are lost.
                //m.SendMessage("Not a valid spell");
                return;
            }

            Spell spell = SpellRegistry.NewSpell(m_SpellID, m, this);

            if (spell != null)
            {
                spell.Cast();
                
                //If you would want to drop 50% of the time, you would write:
                //if ( 0.5 > Utility.RandomDouble() )
                if (0.25 > Utility.RandomDouble())
                {
                    //this should delete the runes after casting, if you want to do that.
                    //code snippet 'borrowed' from baseboard =D
                    //1010474	The etching on the rune has been changed.
                    //1046115	I have the rune right here. No?  Maybe in this pocket? No. Well - this is most embarrassing.
                    //1072896	runed switch
                    //1049060	That item is too broken to increase its durability.
                    //1038290	It looks to have suffered some wear and tear.
                    m.SendLocalizedMessage(1008114); //You have lost some resources

                    for (int i = bag.Items.Count - 1; i >= 0; --i)
                    {
                        if (i < bag.Items.Count)
                            ((Item)Items[i]).Delete();
                    }
                }
            }
            else
                m.SendLocalizedMessage(502345); // This spell has been temporarily disabled.
        }

        public class RunicCastingBagMenu : ContextMenuEntry
        {
            private RunicCastingBag i_RunicCastingBag;
            private Mobile m_Caster;

            public RunicCastingBagMenu(Mobile from, RunicCastingBag bag)
                : base(2090, 1)
            {
                m_Caster = from;
                i_RunicCastingBag = bag;
            }

            public override void OnClick()
            {
                if (i_RunicCastingBag.IsChildOf(m_Caster.Backpack))
                {
                    i_RunicCastingBag.RunicCastingBagCast(m_Caster, i_RunicCastingBag);
                }
                else
                {
                    m_Caster.SendLocalizedMessage(1060640);   // That item must be in your backpack to be used.
                }
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (from.Alive)
                list.Add(new RunicCastingBagMenu(from, this));
        }

        public RunicCastingBag(Serial serial)
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

    ///  Full Rune Bag ///////////////////////////////////////////

    public class FullRunicCastingBag : Bag
    {
        [Constructable]
        public FullRunicCastingBag()
            : base()
        {
            Name = "Full Runic Letter Bag";
            Hue = Utility.RandomMetalHue();
            LootType = LootType.Blessed;

            PlaceItemIn(this, 30, 20, new Bal());
            PlaceItemIn(this, 40, 20, new CharRune());
            PlaceItemIn(this, 50, 20, new Agle());
            PlaceItemIn(this, 60, 20, new Pas());
            PlaceItemIn(this, 70, 20, new Sar());
            PlaceItemIn(this, 80, 20, new Um());

            PlaceItemIn(this, 30, 35, new An());
            PlaceItemIn(this, 40, 35, new Bet());
            PlaceItemIn(this, 50, 35, new Corp());
            PlaceItemIn(this, 60, 35, new Des());
            PlaceItemIn(this, 70, 35, new Ex());
            PlaceItemIn(this, 80, 35, new Flam());
            PlaceItemIn(this, 90, 35, new Grav());

            PlaceItemIn(this, 30, 50, new Hur());
            PlaceItemIn(this, 40, 50, new In());
            PlaceItemIn(this, 50, 50, new Jux());
            PlaceItemIn(this, 60, 50, new Kal());
            PlaceItemIn(this, 70, 50, new Lor());
            PlaceItemIn(this, 80, 50, new Mani());
            PlaceItemIn(this, 90, 50, new Nox());

            PlaceItemIn(this, 30, 65, new Ort());
            PlaceItemIn(this, 40, 65, new Por());
            PlaceItemIn(this, 50, 65, new Quas());
            PlaceItemIn(this, 60, 65, new Rel());
            PlaceItemIn(this, 70, 65, new Sanct());
            PlaceItemIn(this, 80, 65, new Tym());
            PlaceItemIn(this, 90, 65, new Uus());

            PlaceItemIn(this, 30, 80, new Vas());
            PlaceItemIn(this, 40, 80, new Wis());
            PlaceItemIn(this, 50, 80, new Xen());
            PlaceItemIn(this, 60, 80, new Ylem());
            PlaceItemIn(this, 70, 80, new Zu());

            PlaceItemIn(this, 70, 100, new RuneMagicBook());
            PlaceItemIn(this, 90, 100, new RunicCastingBag());
        }

        private static void PlaceItemIn(Container parent, int x, int y, Item item)
        {
            parent.AddItem(item);
            item.Location = new Point3D(x, y, 0);
        }

        public override bool DisplayLootType { get { return false; } }

        public FullRunicCastingBag(Serial serial)
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

    public class RuneMagicBook : BlueBook
    {
        [Constructable]
        public RuneMagicBook()
            : base("Runic Casting", "Alari", 50, true) // writable so players can make notes
        {
            Hue = Utility.RandomBirdHue();

            int cnt = 0;
            string[] lines;
            lines = new string[] 
			{ 
				"     Runic Casting", 
				"      by Alari", 
				"", 
				"The following is a short", 
				"description of rune magic,", 
				"the known spells, and the",
				"meanings of runes.",
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"    Runic Casting Bags", 
				"", 
				"Rune bags and runes are", 
				"imbued with the power to", 
				"assist the caster in the", 
				"casting of a spell without", 
				"the need of reagents.", 
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"", 
				"", 
				"Place one of each", 
				"required rune stone", 
				"inside the rune bag,", 
				"and concentrate on the", 
				"incantation of the spell.", 
				"[click on the bag]", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"Following is a complete", 
				"list of all known spells", 
				"and the runes needed to", 
				"cast them.", 
				"Note that even with the", 
				"runes, a mage must still", 
				"have the will and power", 
				"to cast the spell.", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"First Circle", 
				" Clumsy", 
				"    In Jux", 
				"",
				"",
				" Create Food", 
				"    In Mani Ylem", 
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"", 
				" Feeblemind", 
				"    Rel Wis", 
				"",
				"",
				" Heal", 
				"    In Mani", 
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"", 
				" Magic Arrow", 
				"    In Por Ylem", 
				"",
				"",
				" Night Sight", 
				"    In Lor", 
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"", 
				" Reactive Armor", 
				"    Flam Sanct", 
				"",
				"", 
				" Weaken", 
				"    Des Mani", 
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"", 
				"[some pages have been", 
				"torn out of this volume]", 
				"", 
				"", 
				"[the work continues with", 
				"the meanings of the runes]", 
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"  Meanings of Runes", 
				"", 
				"An   - Negate/Dispel", 
				"Bet  - Small", 
				"Corp - Death", 
				"Des  - Lower/Down", 
				"Ex   - Freedom", 
				"Flam - Flame", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"Grav - Energy/Field", 
				"Hur  - Wind", 
				"In   - Make/Create/Cause", 
				"Jux  - Danger/Trap/Harm", 
				"Kal  - Summon/Invoke", 
				"Lor  - Light", 
				"Mani - Life/Healing", 
				"Nox  - Poison", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"Ort  - Magic", 
				"Por  - Move/Movement", 
				"Quas - Illusion", 
				"Rel  - Change", 
				"Sanct- Protection", 
				"Tym  - Time", 
				"Uus  - Raise/Up", 
				"Vas  - Great", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"Wis  - Knowledge", 
				"Xen  - Creature", 
				"Ylem - Matter", 
				"Zu   - Sleep", 
				"", 
				"Runes must be used in", 
				"combinations to form", 
				"spells of power!", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"", 
				"The meanings are the key!", 
				"", 
				"", 
				"The following pages have", 
				"been left blank for thee", 
				"to take thy notes here.", 
				"", 
			};
            Pages[cnt++].Lines = lines;

            lines = new string[] 
			{ 
				"", 
				"Have fun discovering", 
				"the other spells.", 
				"", 
				"Best of luck in", 
				"thy experiments!", 
				"", 
				" - Alari", 

			};
            Pages[cnt++].Lines = lines;

            lines = new string[]
			{
				"",
				"I have found the power",
				"to harness even more",
				"than Alari imagined...",
				"For inside each rune",
				"there is a hidden power",
				"waiting to be released.",
				"",
			};
            Pages[cnt++].Lines = lines;

            lines = new string[]
			{
				"Those gifted in magic",
				"need only use the rune",
				"upon a weapon, armor,",
				"shield or clothing to",
				"unlock the secrets",
				"within...",
				"",
				"  - Vhaerun",
			};
            Pages[cnt++].Lines = lines;
        }

        public RuneMagicBook(Serial serial)
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

    public class RunicCastingBagBook : RuneMagicBook
    {
        [Constructable]
        public RunicCastingBagBook()
            : base()
        {
        }

        public RunicCastingBagBook(Serial serial)
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
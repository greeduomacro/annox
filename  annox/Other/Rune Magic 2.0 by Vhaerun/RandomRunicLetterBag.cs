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
    ///  Random Rune Letter Bag by RavonTUS ///////////////////////////////////////////

    public class RandomRunicLetterBag : Bag
    {
        [Constructable]
        public RandomRunicLetterBag()
            : base()
        {
            Name = "Random Runic Letter Bag";
            Hue = Utility.RandomMetalHue();
            LootType = LootType.Blessed;

            switch (Utility.Random(6))  //picks one of the following
            {
                case 0: PlaceItemIn(this, 30, 20, new Bal()); break;
                case 1: PlaceItemIn(this, 40, 20, new CharRune()); break;
                case 2: PlaceItemIn(this, 50, 20, new Agle()); break;
                case 3: PlaceItemIn(this, 60, 20, new Pas()); break;
                case 4: PlaceItemIn(this, 70, 20, new Sar()); break;
                case 5: PlaceItemIn(this, 80, 20, new Um()); break;
            }

            switch (Utility.Random(7))  //picks one of the following
            {
                case 0: PlaceItemIn(this, 30, 35, new An()); break;
                case 1: PlaceItemIn(this, 40, 35, new Bet()); break;
                case 2: PlaceItemIn(this, 50, 35, new Corp()); break;
                case 3: PlaceItemIn(this, 60, 35, new Des()); break;
                case 4: PlaceItemIn(this, 70, 35, new Ex()); break;
                case 5: PlaceItemIn(this, 80, 35, new Flam()); break;
                case 6: PlaceItemIn(this, 90, 35, new Grav()); break;
            }

            switch (Utility.Random(7))  //picks one of the following
            {
                case 0: PlaceItemIn(this, 30, 50, new Hur()); break;
                case 1: PlaceItemIn(this, 40, 50, new In()); break;
                case 2: PlaceItemIn(this, 50, 50, new Jux()); break;
                case 3: PlaceItemIn(this, 60, 50, new Kal()); break;
                case 4: PlaceItemIn(this, 70, 50, new Lor()); break;
                case 5: PlaceItemIn(this, 80, 50, new Mani()); break;
                case 6: PlaceItemIn(this, 90, 50, new Nox()); break;
            }

            switch (Utility.Random(7))  //picks one of the following
            {
                case 0: PlaceItemIn(this, 30, 65, new Ort()); break;
                case 1: PlaceItemIn(this, 40, 65, new Por()); break;
                case 2: PlaceItemIn(this, 50, 65, new Quas()); break;
                case 3: PlaceItemIn(this, 60, 65, new Rel()); break;
                case 4: PlaceItemIn(this, 70, 65, new Sanct()); break;
                case 5: PlaceItemIn(this, 80, 65, new Tym()); break;
                case 6: PlaceItemIn(this, 90, 65, new Uus()); break;
            }

            switch (Utility.Random(5))  //picks one of the following
            {
                case 0: PlaceItemIn(this, 30, 80, new Vas()); break;
                case 1: PlaceItemIn(this, 40, 80, new Wis()); break;
                case 2: PlaceItemIn(this, 50, 80, new Xen()); break;
                case 3: PlaceItemIn(this, 60, 80, new Ylem()); break;
                case 4: PlaceItemIn(this, 70, 80, new Zu()); break;
            }
            //PlaceItemIn(this, 70, 100, new RuneMagicBook());
            //PlaceItemIn(this, 90, 100, new RunicCastingBag());
        }

        private static void PlaceItemIn(Container parent, int x, int y, Item item)
        {
            parent.AddItem(item);
            item.Location = new Point3D(x, y, 0);
        }

        public override bool DisplayLootType { get { return false; } }

        public RandomRunicLetterBag(Serial serial)
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
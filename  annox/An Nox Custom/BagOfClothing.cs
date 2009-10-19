//04OCT2006 Bags of Assorted Clothing
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    #region BagOfClothing
    public class BagOfClothing : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfClothing()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Clothing";  //change the name
            Hue = hue;      

            DropItem(new BagOfDresses());
            DropItem(new BagOfJewlery());
            DropItem(new BagOfShirts());
            DropItem(new BagOfPants());
            DropItem(new BagOfShoes());
            DropItem(new BagOfCloaks());
            DropItem(new BagOfHats());
        }

        public BagOfClothing(Serial serial)
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
    #endregion

    #region BagOfDresses
    public class BagOfDresses : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfDresses()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Dresses";  //change the name
            Hue = hue;      

            for (int i = 1; i <= 10; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0: hue = Utility.RandomPinkHue(); break;
                    case 1: hue = Utility.RandomYellowHue(); break;
                    case 2: hue = Utility.RandomBlueHue(); break;
                }
                switch (Utility.Random(7))
                {
                    case 0: DropItem(new Skirt(hue)); break;
                    case 1: DropItem(new Kilt(hue)); break;
                    case 2: DropItem(new GildedDress(hue)); break;
                    case 3: DropItem(new FancyDress(hue)); break;
                    case 4: DropItem(new PlainDress(hue)); break;
                    case 5: DropItem(new FemaleKimono(hue)); break;
                    case 6: DropItem(new FemaleElvenRobe(hue)); break;
                }
            }
        }

        public BagOfDresses(Serial serial)
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
    #endregion

    #region BagOfJewlery
    public class BagOfJewlery : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfJewlery()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Jewlery";  //change the name
            Hue = hue;      

            for (int i = 1; i <= 10; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0: hue = Utility.RandomPinkHue(); break;
                    case 1: hue = Utility.RandomYellowHue(); break;
                    case 2: hue = Utility.RandomBlueHue(); break;
                }

                switch (Utility.Random(8))
                {
                    case 0: DropItem(new GoldNecklace()); break;
                    case 1: DropItem(new GoldBeadNecklace()); break;
                    case 2: DropItem(new SilverNecklace()); break;
                    case 3: DropItem(new SilverBeadNecklace()); break;
                    case 4: DropItem(new GoldEarrings()); break;
                    case 5: DropItem(new SilverEarrings()); break;
                    case 6: DropItem(new GoldRing()); break;
                    case 7: DropItem(new SilverRing()); break;
                }
            }
        }


        public BagOfJewlery(Serial serial)
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
    #endregion

    #region BagOfShirts
    public class BagOfShirts : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfShirts()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Shirts";  //change the name
            Hue = hue;      

            for (int i = 1; i <= 10; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0: hue = Utility.RandomPinkHue(); break;
                    case 1: hue = Utility.RandomYellowHue(); break;
                    case 2: hue = Utility.RandomBlueHue(); break;
                }

                switch (Utility.Random(14))
                {
                    case 0: DropItem(new Shirt(hue)); break;
                    case 1: DropItem(new FancyShirt(hue)); break;
                    case 2: DropItem(new Doublet(hue)); break;
                    case 3: DropItem(new Surcoat(hue)); break;
                    case 4: DropItem(new Kilt(hue)); break;
                    case 5: DropItem(new Tunic(hue)); break;
                    case 6: DropItem(new FormalShirt(hue)); break;
                    case 7: DropItem(new JesterSuit(hue)); break;
                    case 8: DropItem(new JinBaori(hue)); break;
                    case 9: DropItem(new Hakama(hue)); break;
                    case 10: DropItem(new Kamishimo(hue)); break;
                    case 11: DropItem(new HakamaShita(hue)); break;
                    case 12: DropItem(new MaleKimono(hue)); break;
                    case 13: DropItem(new MaleElvenRobe(hue)); break;
                }
            }
        }


        public BagOfShirts(Serial serial)
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
    #endregion

    #region BagOfPants
    public class BagOfPants : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfPants()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Pants";  //change the name
            Hue = hue;      

            for (int i = 1; i <= 10; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0: hue = Utility.RandomPinkHue(); break;
                    case 1: hue = Utility.RandomYellowHue(); break;
                    case 2: hue = Utility.RandomBlueHue(); break;
                }

                switch (Utility.Random(4))
                {
                    case 0: DropItem(new ShortPants(hue)); break;
                    case 1: DropItem(new LongPants(hue)); break;
                    case 2: DropItem(new TattsukeHakama(hue)); break;
                    case 3: DropItem(new ElvenPants(hue)); break;
                }
            }
        }


        public BagOfPants(Serial serial)
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
    #endregion

    #region BagOfShoes
    public class BagOfShoes : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfShoes()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Shoes";  //change the name
            Hue = hue;      

            for (int i = 1; i <= 10; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0: hue = Utility.RandomPinkHue(); break;
                    case 1: hue = Utility.RandomYellowHue(); break;
                    case 2: hue = Utility.RandomBlueHue(); break;
                }
                switch (Utility.Random(9))
                {
                    case 0: DropItem(new FurBoots(hue)); break;
                    case 1: DropItem(new Boots(hue)); break;
                    case 2: DropItem(new ThighBoots(hue)); break;
                    case 3: DropItem(new Shoes(hue)); break;
                    case 4: DropItem(new Sandals(hue)); break;
                    case 5: DropItem(new NinjaTabi(hue)); break;
                    case 6: DropItem(new SamuraiTabi(hue)); break;
                    case 7: DropItem(new Waraji(hue)); break;
                    case 8: DropItem(new ElvenBoots(hue)); break;
                }

            }
        }

        public BagOfShoes(Serial serial)
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
    #endregion

    #region BagOfCloaks
    public class BagOfCloaks : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfCloaks()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Cloaks";  //change the name
            Hue = hue;      

            for (int i = 1; i <= 10; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0: hue = Utility.RandomPinkHue(); break;
                    case 1: hue = Utility.RandomYellowHue(); break;
                    case 2: hue = Utility.RandomBlueHue(); break;
                }

                switch (Utility.Random(4))
                {
                    case 0: DropItem(new HalfApron(hue)); break;
                    case 1: DropItem(new Obi(hue)); break;
                    case 2: DropItem(new Cloak(hue)); break;
                    case 3: DropItem(new FurCape(hue)); break;
                }
            }
        }


        public BagOfCloaks(Serial serial)
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
    #endregion

    #region BagOfHats
    public class BagOfHats : Bag
    {
        int hue = 0;

        [Constructable]
        public BagOfHats()
        {
            switch (Utility.Random(3))
            {
                case 0: hue = Utility.RandomPinkHue(); break;
                case 1: hue = Utility.RandomYellowHue(); break;
                case 2: hue = Utility.RandomBlueHue(); break;
            }
            Name = "Bag of Hats";  //change the name
            Hue = hue;      

            for (int i = 1; i <= 10; i++)
            {
                switch (Utility.Random(3))
                {
                    case 0: hue = Utility.RandomPinkHue(); break;
                    case 1: hue = Utility.RandomYellowHue(); break;
                    case 2: hue = Utility.RandomBlueHue(); break;
                }

                switch (Utility.Random(23))
                {
                    case 0: DropItem(new Kasa(hue)); break;
                    case 1: DropItem(new ClothNinjaHood(hue)); break;
                    case 2: DropItem(new FlowerGarland(hue)); break;
                    case 3: DropItem(new FloppyHat(hue)); break;
                    case 4: DropItem(new WideBrimHat(hue)); break;
                    case 5: DropItem(new Cap(hue)); break;
                    case 6: DropItem(new SkullCap(hue)); break;
                    case 7: DropItem(new Bandana(hue)); break;
                    case 8: DropItem(new BearMask(hue)); break;
                    case 9: DropItem(new DeerMask(hue)); break;
                    case 10: DropItem(new HornedTribalMask(hue)); break;
                    case 11: DropItem(new TribalMask(hue)); break;
                    case 12: DropItem(new TallStrawHat(hue)); break;
                    case 13: DropItem(new StrawHat(hue)); break;
                    case 14: DropItem(new TallStrawHat(hue)); break;
                    case 15: DropItem(new OrcishKinMask(hue)); break;
                    case 16: DropItem(new SavageMask(hue)); break;
                    case 17: DropItem(new WizardsHat(hue)); break;
                    case 18: DropItem(new MagicWizardsHat(hue)); break;
                    case 19: DropItem(new Bonnet(hue)); break;
                    case 20: DropItem(new FeatheredHat(hue)); break;
                    case 21: DropItem(new TricorneHat(hue)); break;
                    case 22: DropItem(new JesterHat(hue)); break;
                }
            }
        }

        public BagOfHats(Serial serial)
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
    #endregion
}
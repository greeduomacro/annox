// ZombieX by SpookyRobert.... earthquake crash should  be fixed, but I wasn't able 
//to reproduce the crash myself so I can't really test it 
//21JAN2008 Added Hair & Facial & Lower Torso Items
//01AUG2008 I think this is needed for the EntrappedSoulWeapon

using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Network;
using Server.Targets;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("a rotting corpse")]
    public class Zombiex : BaseCreature
    {

        public override bool CanRegenHits { get { return false; } }

        public override bool IsScaredOfScaryThings { get { return false; } }
        public override bool IsScaryToPets { get { return true; } }
        private RotTimer m_Timer;

        [Constructable]
        public Zombiex()
            : base(AIType.AI_Melee, FightMode.Closest, 20, 1, 0.2, 0.4)
        {
            Name = "A Contagious Zombie";
            Body = 155;
            BaseSoundID = 471;

            //17MAR2008 - too strong, make it match SerpentineDragon *** START ***
            //SetStr(100);
            //SetDex(25);
            //SetInt(10);

            //SetHits(1000);
            //SetStam(150);
            //SetMana(0);

            //SetDamage(10, 15);

            //SetDamageType(ResistanceType.Physical, 25);
            //SetDamageType(ResistanceType.Cold, 25);
            //SetDamageType(ResistanceType.Poison, 50);

            //SetResistance(ResistanceType.Physical, 60, 80);
            //SetResistance(ResistanceType.Fire, 40, 60);
            //SetResistance(ResistanceType.Cold, 99, 100);
            //SetResistance(ResistanceType.Poison, 99, 100);
            //SetResistance(ResistanceType.Energy, 40, 60);

            //SetSkill(SkillName.Poisoning, 120.0);
            //SetSkill(SkillName.MagicResist, 250.0);
            //SetSkill(SkillName.Tactics, 100.0);
            //SetSkill(SkillName.Wrestling, 90.1, 100.0);

            //PassiveSpeed = .4;
            //ActiveSpeed = .8;

            //Fame = 6000;
            //Karma = -6000;

            //VirtualArmor = 40;

            SetStr(111, 140);
            SetDex(201, 220);
            SetInt(1001, 1040);

            SetHits(480);

            SetDamage(5, 12);

            SetDamageType(ResistanceType.Physical, 75);
            SetDamageType(ResistanceType.Poison, 25);

            SetResistance(ResistanceType.Physical, 35, 40);
            SetResistance(ResistanceType.Fire, 25, 35);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 25, 35);
            SetResistance(ResistanceType.Energy, 25, 35);

            SetSkill(SkillName.EvalInt, 100.1, 110.0);
            SetSkill(SkillName.Magery, 110.1, 120.0);
            SetSkill(SkillName.Meditation, 100.0);
            SetSkill(SkillName.MagicResist, 100.0);
            SetSkill(SkillName.Tactics, 50.1, 60.0);
            SetSkill(SkillName.Wrestling, 30.1, 100.0);

            Fame = 15000;
            Karma = 15000;

            VirtualArmor = 36;
            //17MAR2008 - too strong, make it match SerpentineDragon *** END   ***


            //If you would want to drop 50% of the time, you would write:
            //if ( 0.5 > Utility.RandomDouble() )
            if (0.25 > Utility.RandomDouble())
            {
                PackItem(new EntrappedSoulWeaponDeed());
            }

            //Remove timer here to stop decay don't forget the Deserialize timer 

            //01AUG2008 I think this is needed for the EntrappedSoulWeapon *** START ***
            PackItem(new Head());
            //01AUG2008 I think this is needed for the EntrappedSoulWeapon *** END   ***

            m_Timer = new RotTimer(this);
            m_Timer.Start();
        }

        public override bool OnBeforeDeath()
        {
            m_Timer.Stop();
            return base.OnBeforeDeath();
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            //This finds the mobiles in the area looking for enemys 
            if (!m.Hidden && InRange(m, 20) && !InRange(oldLocation, 1) && InLOS(m) && IsEnemy(m) && m.AccessLevel < AccessLevel.Counselor)
            {
                this.Combatant = (m);

            }
            //This deals with the Zombie's calls to other zombiex's in the area 
            if (m is Zombiex && this.Combatant != null && InLOS(m))
            {
                if (m.Combatant == null)
                {
                    m.Combatant = this.Combatant;
                    m.Say("*Moan*");  // what does the zombie getting called say
                    this.Say("*MMooaann*"); // what does the zombie doing the calling say
                }

            }
            return;

        }
        public override bool IsEnemy(Mobile m)
        {
            //What should the zombie not Attack? figured the not attack list would be smaller than an attack list
            if (m is Zombiex || m is AncientLich || m is Bogle || m is LichLord || m is Shade || m is Spectre || m is Wraith || m is BoneKnight || m is Ghoul || m is Mummy || m is SkeletalKnight || m is Skeleton || m is Zombie || m is ShadowKnight || m is DarknightCreeper || m is RevenantLion || m is LadyOfTheSnow || m is RottingCorpse || m is SkeletalDragon || m is Lich)
                return false;

            return true;
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            if (this.HitsMaxSeed < 10)
            {
                this.HitsMaxSeed = 10;
            }
            if (this.Hits < this.HitsMax / 4)
            {
                this.CantWalk = true;
            }
            if (attacker is PlayerMobile)
            {
                switch (Utility.Random(2))
                {
                    case 0: this.Str -= 1;
                        //this.Say(" losing 1 Str from getting hit"); 
                        break;
                    //case 1: this.HitsMaxSeed -= Utility.RandomMinMax(1,10); break; 
                }
            }

        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (defender is PlayerMobile)
            {
                if (defender.Hits < 10)
                {
                    Zombiex zomb = new Zombiex();

                    zomb.Map = defender.Map;
                    zomb.Female = defender.Female;
                    zomb.Body = defender.Body;
                    zomb.Location = defender.Location;
                    zomb.Hue = Utility.RandomMinMax(1267, 1272);
                    zomb.Name = defender.Name;
                    zomb.Title = "*Infected*";

                    //21JAN2008 Added Hair & Facial & Lower Torso Items *** START ***
                    zomb.HairItemID = defender.HairItemID;
                    zomb.HairHue = defender.HairHue;
                    zomb.FacialHairItemID = defender.FacialHairItemID;
                    zomb.FacialHairHue = defender.FacialHairHue;
                    zomb.BodyMod = defender.BodyMod;

                    zomb.EquipItemFromLayer(defender, zomb, Layer.InnerLegs);
                    zomb.EquipItemFromLayer(defender, zomb, Layer.OuterLegs);
                    zomb.EquipItemFromLayer(defender, zomb, Layer.InnerTorso);
                    zomb.EquipItemFromLayer(defender, zomb, Layer.MiddleTorso);
                    zomb.EquipItemFromLayer(defender, zomb, Layer.OuterTorso);
                    zomb.EquipItemFromLayer(defender, zomb, Layer.Waist);

                    //if (zomb.Female != null)
                    if (!zomb.Female)
                        zomb.EquipItemFromLayer(defender, zomb, Layer.Shirt);
                    //21JAN2008 Some updated *** END   ***
                    new Zombiex();

                    defender.Kill();
                    
                }

                switch (Utility.Random(2))
                {
                    case 0: this.Str -= 1;
                        //this.Say(" losing 1 Str from hitting"); 
                        break;
                }
            }

            if (defender is BaseCreature)
            {
                switch (Utility.Random(4))
                {
                    case 0: this.Str -= 1;
                        //this.Say(" losing 1 Str from hitting"); 
                        break;
                }
            }
        }

        //21JAN2008 Added Hair & Facial & Lower Torso Items *** START ***
        private Item CopyItemFromLayer(Mobile from, Layer layer)
        {
            Item item = from.FindItemOnLayer(layer);
            if (item == null)
            {
                return null;
            }
            Item copy = new Item();
            copy.ItemID = item.ItemID;
            copy.Hue = item.Hue;
            copy.Layer = item.Layer;
            copy.Name = item.Name;
            return copy;
        }

        private void EquipItemFromLayer(Mobile equiper, Mobile from, Layer layer)
        {
            Item item = CopyItemFromLayer(from, layer);
            if (item != null)
            {
                equiper.AddItem(item);
            }
        }
        //21JAN2008 Added Hair & Facial & Lower Torso Items *** END  ***

        private class RotTimer : Timer
        {
            private Mobile m_Mobile;

            //Change timespan to change the rate of decay 

            public RotTimer(Mobile m)
                : base(TimeSpan.FromMinutes(1.0))
            {
                m_Mobile = m;
            }

            protected override void OnTick()
            {
                RotTimer rotTimer = new RotTimer(m_Mobile);
                if (m_Mobile.Str < 2)
                {
                    m_Mobile.Kill();
                    Stop();
                }
                else
                {
                    if (m_Mobile.Hits > m_Mobile.HitsMax / 2)
                    {
                        m_Mobile.Hits -= m_Mobile.HitsMax / 100;
                        //m_Mobile.Say(" losing 1% Hits");
                    }

                    if (m_Mobile.Hits <= m_Mobile.HitsMax / 2)
                    {
                        m_Mobile.Hits -= 1;
                        //m_Mobile.Say(" losing 1 Hitpoint");
                    }
                    if (m_Mobile.Hits < m_Mobile.HitsMax / 4)
                    {
                        m_Mobile.CantWalk = true;
                        //m_Mobile.Say(" Cant Walk Anymore");

                    }

                    if (m_Mobile.Str > 100)
                    {
                        m_Mobile.Str -= m_Mobile.Str / 30;
                        //m_Mobile.Say(" losing 3.33% Str");
                    }
                    if (m_Mobile.Str <= 100)
                    {
                        m_Mobile.Str -= 1;
                        //m_Mobile.Say(" losing 1 Str point");
                    }

                    rotTimer.Start();
                }
            }
        }
        public override bool AlwaysMurderer { get { return true; } }

        public override bool BleedImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override Poison HitPoison { get { return Poison.Lethal; } }
        //public virtual bool CanRummageCorpses { get { return true; } } //causes warrning error
        public override bool CanRummageCorpses { get { return true; } }

        public Zombiex(Serial serial)
            : base(serial)
        {
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            //Remove timer here to stop decay but don't forget the one Constructable section!

            m_Timer = new RotTimer(this);
            m_Timer.Start();
        }
    }
}
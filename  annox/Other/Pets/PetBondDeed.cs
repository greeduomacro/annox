//http://www.runuo.com/forums/custom-script-releases/85613-runuo-2-0-rc1-pet-bond-deed.html

using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using System.Collections;
using Server.Gumps;
using Server.Targeting;
using Server.Misc;
using Server.Accounting;
using System.Xml;
using Server.Mobiles;

namespace Server.Items
{
    public class PetBondDeed : Item
    {
        [Constructable]
        public PetBondDeed()
            : base(0x14F0)
        {
            base.Weight = 0;
            base.LootType = LootType.Blessed;
            base.Name = "a pet bond deed";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                from.Target = new InternalTarget(from, this);
            }
            else
            {
                //from.SendMessage("É necessário estar em sua mochila.");
                //from.SendLocalizedMessage(1061609);  //That creature is already bonded in a Blood Oath.
		from.SendLocalizedMessage(1060640);  //The item must be in your backpack to use it.
            }
        }

        public PetBondDeed(Serial serial)
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

    public class InternalTarget : Target
    {
        private Mobile m_From;
        private PetBondDeed m_Deed;

        public InternalTarget(Mobile from, PetBondDeed deed)
            : base(3, false, TargetFlags.None)
        {
            m_Deed = deed;
            m_From = from;
            //from.SendMessage("Selecione o animal para bondar");
            from.SendMessage("Select a pet to bond.");
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (m_Deed.IsChildOf(m_From.Backpack))
            {
                if (targeted is Mobile)
                {
                    if (targeted is BaseCreature)
                    {
                        BaseCreature creature = (BaseCreature)targeted;
                        if (!creature.Tamable)
                        {
                            //from.SendMessage("Este animal não esta domado");
                            from.SendLocalizedMessage(1042946); //This animal appears to have never been tamed.
                        }
                        else if (!creature.Controlled || creature.ControlMaster != from)
                        {
                            //from.SendMessage("Este animal não é seu");
                            from.SendMessage("This is not a pet.");
                        }
                        else if (creature.IsDeadPet)
                        {
                            from.SendMessage("Este animal esta morto");
                            from.SendLocalizedMessage(1049667);  //Your pet is dead and will not respond to that command.
                        }
                        else if (creature.Summoned)
                        {
                            //from.SendMessage("Impossível de bondar um summon");
                            from.SendMessage("You may not bond a summoned creature.");
                        }
                        else if (creature.Body.IsHuman)
                        {
                            //from.SendMessage("Impossível de bondar uma pessoa");
                            from.SendMessage("You may not bond another person.");
                        }
                        else
                        {

                            if (creature.IsBonded == true)
                            {
                                //from.SendMessage("Este animal ja esta bonded");
                                from.SendLocalizedMessage(1049666);  //Your pet has bonded with you!
                            }
                            else
                            {

                                if (from.Skills[SkillName.AnimalTaming].Base < creature.MinTameSkill)
                                {
                                    //from.SendMessage("Você não possuiu tamer suficiente para bonda-lo");
                                    from.SendLocalizedMessage(10752680); //Your pet cannot form a bond with you until your animal taming ability has risen.
                                }
                                else if (from.Skills[SkillName.AnimalLore].Base < creature.MinTameSkill)
                                {
                                    //from.SendMessage("Você não possuiu animal lore suficiente para bonda-lo");
                                    from.SendMessage("Your pet cannot form a bond with you until your animal taming ability has risen.");
                                }
                                else
                                {
                                    try
                                    {
                                        creature.IsBonded = true;
                                        from.SendMessage("{0} foi bondado com sucesso", creature.Name);
                                        from.SendLocalizedMessage(1049666); //Your pet has bonded with you!
                                        m_Deed.Delete();
                                    }
                                    catch
                                    {
                                        //from.SendMessage("Ocorreu um problema ao bondar seu animal. Contacte a Staff");
                                        from.SendLocalizedMessage(503380); //Please contact a gamemaster and let them know there is a bug here.
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        //from.SendMessage("Você pode bondar somente animais");
                        from.SendMessage("You can only bond animals.");
                    }
                }
                else
                {
                    //from.SendMessage("Você pode bondar somente animais");
                    from.SendMessage("You can only bond animals.");
                }
            }
            else
            {
                //from.SendMessage("É necessário estar em sua mochila.");
                from.SendLocalizedMessage(1060640); // The item must be in your backpack to use it.
            }
        }
    }
}

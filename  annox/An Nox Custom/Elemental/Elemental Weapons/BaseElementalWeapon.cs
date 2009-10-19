using System;
using Server.Items;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class BaseElementalWeapon : BaseMeleeWeapon
    {
        public abstract int EffectID { get; }
        public abstract Type AmmoType { get; }
        public abstract Item Ammo { get; }

        public override int DefHitSound { get { return 0x234; } }
        public override int DefMissSound { get { return 0x238; } }

        public override SkillName DefSkill { get { return SkillName.Magery; } }
        public override WeaponType DefType { get { return WeaponType.Ranged; } }
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.ShootXBow; } }

        public override SkillName AccuracySkill { get { return SkillName.Magery; } }

        public BaseElementalWeapon(int itemID)
            : base(itemID)
        {
        }

        public BaseElementalWeapon(Serial serial)
            : base(serial)
        {
        }

        public override TimeSpan OnSwing(Mobile attacker, Mobile defender)
        {
            // Make sure we've been standing still for .10 second
            if (DateTime.Now > (attacker.LastMoveTime + TimeSpan.FromSeconds(Core.AOS ? 0.5 : .10)) || (Core.AOS && WeaponAbility.GetCurrentAbility(attacker) is MovingShot))
            {
                bool canSwing = true;

                if (Core.AOS)
                {
                    canSwing = (!attacker.Paralyzed && !attacker.Frozen);

                    if (canSwing)
                    {
                        Spell sp = attacker.Spell as Spell;

                        canSwing = (sp == null || !sp.IsCasting || !sp.BlocksMovement);
                    }
                }

                if (canSwing && attacker.HarmfulCheck(defender))
                {
                    attacker.DisruptiveAction();
                    attacker.Send(new Swing(0, attacker, defender));

                    if (OnFired(attacker, defender))
                    {
                        if (CheckHit(attacker, defender))
                            OnHit(attacker, defender);
                        else
                            OnMiss(attacker, defender);
                    }
                }

                return GetDelay(attacker);
            }
            else
            {
                return TimeSpan.FromSeconds(0.25);
            }

        }

        public virtual bool OnFired(Mobile attacker, Mobile defender)
        {
            Container pack = attacker.Backpack;

            if (attacker.Player && (pack == null || !pack.ConsumeTotal(AmmoType, 0)))
                return false;

            attacker.MovingEffect(defender, EffectID, 18, 1, false, false);

            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)2); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 2:
                case 1:
                {
                    break;
                }
                case 0:
                {
                    /*m_EffectID =*/
                    reader.ReadInt();
                    break;
                }
            }

            if (version < 2)
            {
                WeaponAttributes.MageWeapon = 0;
                WeaponAttributes.UseBestSkill = 0;
            }
        }
    }
}
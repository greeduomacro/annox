///////////////////////
//     Made By       //
//   †PrplBeast†     //
///////////////////////
using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
    public class LayerTarget : Target // Create our targeting class (which we derive from the base target class)
    {
        private OneHandedChangeDeed m_Deed;

        public LayerTarget(OneHandedChangeDeed deed)
            : base(1, false, TargetFlags.None)
        {
            m_Deed = deed;
        }

        protected override void OnTarget(Mobile from, object target) // Override the protected OnTarget() for our feature
        {
            if (m_Deed.Deleted || m_Deed.RootParent != from)
                return;

            if (target is BaseWeapon)
            {
                BaseWeapon baseweapon = (BaseWeapon)target;

                if (baseweapon.Layer != Layer.TwoHanded)
                {
                    from.SendMessage("You cannot change that to a one handed weapon!!!");

                }
                else
                {
                    baseweapon.Layer = Layer.OneHanded;
                    from.SendMessage("You changed it to a one handed weapon!!!");

                    m_Deed.Delete(); // Delete the bless deed
                }
            }
            else
            {
                from.SendMessage("You cannot change that to a one handed weapon?");
            }
        }
    }

    public class OneHandedChangeDeed : Item // Create the item class which is derived from the base item class
    {
        public override string DefaultName
        {
            get { return "One Handed Change Deed"; }
        }

        [Constructable]
        public OneHandedChangeDeed()
            : base(0x14F0)
        {
            Weight = 1.0;
            LootType = LootType.Blessed;
        }

        public OneHandedChangeDeed(Serial serial)
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

        public override bool DisplayLootType { get { return false; } }

        public override void OnDoubleClick(Mobile from) // Override double click of the deed to call our target
        {
            if (!IsChildOf(from.Backpack)) // Make sure its in their pack
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else
            {
                from.SendMessage("What would you like to change to a one handed weapon?");
                from.Target = new LayerTarget(this); // Call our target
            }
        }
    }
}
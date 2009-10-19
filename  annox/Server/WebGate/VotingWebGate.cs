////Coded by kaball //////
////feel free to edit ////
using Server.Gumps;

namespace Server.Items
{
    public class VotingWebGate : Item
    {
        [Constructable]
        public VotingWebGate()
            : base(6907)
        {
            Movable = false;
            Hue = 1166;
            Name = "Vote for our World";
            Light = LightType.Circle300;
        }

        public VotingWebGate(Serial serial)
            : base(serial)
        {
        }

        public override bool OnMoveOver(Mobile m)
        {
            if (m.Alive)
            {
                m.PlaySound(0x214);
                m.FixedEffect(0x376A, 10, 16);

                int i = 0;

                while (i < 52)
                {
                    ///
                    i++;
                }
                m.LaunchBrowser("www.connectuo.com/index.php?page=shards&do=vote&id=16");
            }
            else
            {
                //m.SendLocalizedMessage(2, "Your dead and can't use this" ); 
            }

            return true;
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
        }
    }
}

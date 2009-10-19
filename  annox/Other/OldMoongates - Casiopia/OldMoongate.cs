using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{
    public class GateDest
    {
        public Point3D Location;
        public int Description;

        public GateDest(Point3D loc, int desc)
        {
            Location = loc;
            Description = desc;
        }
    }

    public class OldMoongate : Item
    {

        private static readonly GateDest[] m_FeluccaList = new GateDest[]
			{
				new GateDest( new Point3D( 1336, 1997, 5 ), 1005390 ), // Britain 
				new GateDest( new Point3D( 4467, 1283, 5 ), 1005389 ), // Moonglow
				new GateDest( new Point3D( 3563, 2139, 34 ), 1005396 ), // Magincia
				new GateDest( new Point3D(  643, 2067, 5 ), 1005395 ), // Skara Brae
				new GateDest( new Point3D( 1828, 2948, -20 ), 1005394 ), // Trinsic
				new GateDest( new Point3D( 2701,  692, 5 ), 1005393 ), // Minoc/Vesper
				new GateDest( new Point3D(  771,  752, 5 ), 1005392 ), // Yew
				new GateDest( new Point3D( 1499, 3771, 5 ), 1005391 ) // Jhelom
			};

        [Constructable]
        public OldMoongate()
            : base(0xF6C)
        {
            Movable = false;
            Light = LightType.Circle300;
        }

        public OldMoongate(Serial serial)
            : base(serial)
        {
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, 1005389 + m_FeluccaList[GetGateNumber(from.Location, from.Map)].Description);
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.Player)
                return;

            if (from.InRange(GetWorldLocation(), 1))
                UseGate(from);
            else
                from.SendLocalizedMessage(500446); // That is too far away.
        }

        public int GetGateNumber(Point3D location, Map map)
        {
            int gateloc = 0;
            int hours, minutes, totalMinutes;

            int length = m_FeluccaList.Length;

            while (gateloc < length && Location != m_FeluccaList[gateloc++].Location) ; //Probably a better way to do this
            gateloc %= length;

            Clock.GetTime(map, location.X, location.Y, out hours, out minutes, out totalMinutes);
            int period = totalMinutes % 120;
            return (gateloc + period / 30 * 2 + Math.Min(1, period % 30 / 10)) % length;
        }

        public override bool OnMoveOver(Mobile m)
        {
            return !m.Player || UseGate(m);
        }

        public bool UseGate(Mobile m)
        {
            //if ( m.Criminal )
            //m.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily.
            //else
            if (Server.Spells.SpellHelper.CheckCombat(m))
                m.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
            else if (m.Spell != null)
                m.SendLocalizedMessage(1049616); // You are too busy to do that at the moment.
            else
            {
                m.Combatant = null;
                m.Warmode = m.Hidden = false;

                Point3D location = m_FeluccaList[GetGateNumber(m.Location, m.Map)].Location;

                m.MoveToWorld(location, m.Map);
                Effects.PlaySound(location, m.Map, 0x1FE);
            }
            return false;
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

        public static void Initialize()
        {
            CommandSystem.Register("MoonGen", AccessLevel.Administrator, new CommandEventHandler(MoonGen_OnCommand));
        }

        [Usage("MoonGen")]
        [Description("Generates public moongates. Removes all old moongates.")]
        public static void MoonGen_OnCommand(CommandEventArgs e)
        {
            DeleteAll();

            int count = 0;

            count += MoonGen(m_FeluccaList, Map.Felucca);
            count += MoonGen(m_FeluccaList, Map.Trammel);

            World.Broadcast(0x35, true, "{0} moongates generated.", count);
        }

        private static void DeleteAll()
        {
            ArrayList list = new ArrayList();

            foreach (Item item in World.Items.Values)
                if (item is OldMoongate)
                    list.Add(item);

            foreach (Item item in list)
                item.Delete();

            if (list.Count > 0)
                World.Broadcast(0x35, true, "{0} moongates removed.", list.Count);
        }

        private static int MoonGen(GateDest[] list, Map map)
        {
            int length = list.Length;
            for (int i = 0; i < length; i++)
                (new OldMoongate()).MoveToWorld(list[i].Location, map);

            return length;
        }
    }
}
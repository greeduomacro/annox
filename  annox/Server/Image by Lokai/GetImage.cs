/****************************** GetImage.cs ********************************
 *
 *					(C) 2008, Lokai
 *			
 * Description: Command that displays a gump that lets you
 *	  browse all 16382 images in the game. Images are 
 *	  displayed 10 to a page. You can set the start image
 *	  at the command or in the Gump using the Text Box
 *	  provided.
 *	  
 * Updated November 5, 2009: Now lets you create Static items
 *	  from the list available by targeting a location.
 *   
/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************
 *
 *   Modified by Lord Greywolf
 *   for searching with ouit being case sensative
 *   and for the tiling option
 *   Main credit goes to Loki for the origional script
 *
 ***************************************************************************/
using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Targeting;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Network;

namespace Server.Custom
{
    public class GetImageCommand
    {
        public static void Initialize()
        {
            //This is the command the GM can use to show the new Gump.
            CommandSystem.Register("GetImage", AccessLevel.GameMaster, new CommandEventHandler(GetImage_OnCommand));
        }

        [Usage("GetImage [imageID]")]
        [Description("Shows the GetImageGump, displaying imageID first or image 1, if not specified.")]
        public static void GetImage_OnCommand(CommandEventArgs e)
        {
            //Initialize image to 1
            int image = 1;

            //If the GM gives the command with no image number, then send the regular Gump.
            if (e.Arguments.Length == 0) e.Mobile.SendGump(new GetImageGump());
            else
            {
                //Try to convert the first argument to a number and set the image to that number.
                try { image = Convert.ToInt32(e.Arguments[0]); }
                catch { e.Mobile.SendMessage("Usage: GetImage [imageID]"); }
                finally { e.Mobile.SendGump(new GetImageGump(image)); }
            }
        }
    }

    public class GetImageGump : Gump
    {
        private static int ImageID;

        //If the base constructor is called, set the image to '1'.
        public GetImageGump() : this(1) { }

        public GetImageGump(int imageID)
            : base(40, 40)
        {
            //Set the external private variable so we can use it later during the OnResponse method.
            ImageID = imageID;

            //If the image is out of range, set the image to image '1'.
            if (ImageID < 1 || ImageID > 16382) ImageID = 1;

            //Initialize internal variables used in the Gump
            int x = 20; //This is the X-coordinate of where the first image will be located.
            int num = 10; //This is the number of images we will display
            int show = ImageID; //Set the first image we will show to the private variable.
            string name = "no name"; //Initialize the name of the image in case we have trouble finding it.

            //If the image is higher than 16372, then we cannot display 10 images, so scale the number down.
            if (ImageID > 16372) num = 16382 - ImageID;

            AddPage(0);
            AddBackground(0, 0, 760, 145, 0x13BE);
            AddBackground(0, 146, 760, 424, 0x13BE);
            AddAlphaRegion(6, 152, 748, 352);
            AddBackground(0, 511, 180, 39, 0x13BE);
            AddBackground(181, 511, 289, 39, 0x13BE);
            AddBackground(470, 511, 290, 39, 0x13BE);

            //Loop through the 10 images displayed.
            for (int q = 0; q < num; q++)
            {
                try
                {
                    //Show the item.
                    AddItem(x, 155, show);
                    AddImageTiledButton(x + 5, 90, 4030, 4031, show + 20000, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 500927);
                    AddImageTiledButton(x + 5, 115, 4009, 4010, show + 40000, GumpButtonType.Reply, 0, 1352, 0, 140, 20, 1027024);

                    //Derive the name from the ItemTable in TileData, and reformat, if necessary.
                    name = TileData.ItemTable[show].Name;
                    if (name == "MissingName") name = "Missing Name";
                    name = name.Replace("%s%", "s");
                    name = name.Replace("%es%", "es");

                    //Display the name of the item.
                    AddHtml(x + 7, 32, 70, 60, name, false, false);
                }
                catch
                {
                    //If displaying the name or item fails, display a canned message.
                    AddHtml(x, 92, 60, 120, string.Format("Unable to show Image ID {0}.", show.ToString()), false, false);
                }
                //Show the number of the item above the name.
                AddLabel(x + 7, 12, 80, show.ToString());

                show++; //Increment the image ID before looping again.
                x += 70; //Increment the X-coordinate by 70 to make room for the next image.
            }

            //Text boxes and buttons for starting a new search.
            AddLabel(200, 520, 380, "Search by name:");
            AddTextEntry(330, 520, 50, 20, 32, 1, "");
            AddButton(415, 520, 4015, 4016, 2, GumpButtonType.Reply, 0);

            AddLabel(490, 520, 380, "Search by number:");
            AddTextEntry(620, 520, 50, 20, 32, 2, "1");
            AddButton(705, 520, 4015, 4016, 5, GumpButtonType.Reply, 0);

            //Add icons to move forward and backward through pages.
            if (ImageID > 1) AddButton(7, 13, 0x1519, 0x1519, 3, GumpButtonType.Reply, 0); // Previous Page
            if (ImageID < 16373) AddButton(707, 13, 0x151A, 0x151A, 4, GumpButtonType.Reply, 0); // Next Page
        }

        private bool FindItem(Mobile m, int itemID)
        {
            IPooledEnumerable eable = m.Map.GetItemsInRange(new Point3D(m.X, m.Y, m.Z), 0);
            foreach (Item item in eable)
            {
                if (item.Z == m.Z && item.ItemID == itemID) return true;
            }
            return false;
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile m = state.Mobile;
            int x = info.ButtonID;
            TextRelay tr1 = info.GetTextEntry(1);
            TextRelay tr2 = info.GetTextEntry(2);

            if (x > 19999 && x < 40000)
            {
                int itemID = x - 20000;
                m.Target = new CreateItemTarget(itemID);
            }
            else if (x >= 40000 && x < 60000)
            {
                int itemID = x - 40000;
                string[] subArgs = new string[2];
                subArgs[0] = "static";
                subArgs[1] = Convert.ToString(itemID);
                BoundingBoxPicker.Begin(m, new BoundingBoxCallback(TileBox_Callback), new TileState(subArgs));
            }
            else if (x < 2 || x > 5) m.CloseGump(typeof(GetImageGump));
            else
            {
                if (x == 2 && tr1 != null)
                {
                    //Try to read the text typed in the search box.
                    string temp = "";
                    try { temp = tr1.Text; }
                    catch { }

                    //If no text found, send an error, and re-display the gump.
                    if (temp.Length < 1)
                    {
                        m.SendMessage("Invalid search string.");
                        m.SendGump(new GetImageGump(ImageID));
                    }
                    else m.SendGump(new SearchImageGump(temp));
                }
                else if (x == 5 && tr2 != null)
                {
                    //Try to interpret the number typed in the browse box.
                    int temp = 0;
                    try { temp = Convert.ToInt32(tr2.Text, 10); }
                    catch { }

                    //If out of range, send an error, and re-display the gump.
                    if (temp > 16382 || temp < 1)
                    {
                        m.SendMessage("Please enter a decimal number between 1 and 16382.");
                        m.SendGump(new GetImageGump(ImageID));
                    }
                    else m.SendGump(new GetImageGump(temp));
                }
                else if (x == 3) m.SendGump(new GetImageGump(ImageID - 10)); //Previous Page
                else if (x == 4) m.SendGump(new GetImageGump(ImageID + 10)); //Next Page
                else m.CloseGump(typeof(GetImageGump));
            }
        }

        private static void TileBox_Callback(Mobile from, Map map, Point3D start, Point3D end, object state)
        {
            TileState ts = (TileState)state;
            if (ts.m_UseFixedZ) start.Z = end.Z = ts.m_FixedZ;
            Server.Commands.Add.Invoke(from, start, end, ts.m_Args);
            from.SendGump(new GetImageGump(ImageID));
        }

        private class TileState
        {
            public bool m_UseFixedZ;
            public int m_FixedZ;
            public string[] m_Args;

            public TileState(string[] args) : this(false, 0, args) { }

            public TileState(int fixedZ, string[] args) : this(true, fixedZ, args) { }

            public TileState(bool useFixedZ, int fixedZ, string[] args)
            {
                m_UseFixedZ = useFixedZ;
                m_FixedZ = fixedZ;
                m_Args = args;
            }
        }

        private class CreateItemTarget : Target
        {
            private int m_ItemID;

            public CreateItemTarget(int itemID)
                : base(18, true, TargetFlags.None)
            {
                m_ItemID = itemID;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                IPoint3D target = targeted as IPoint3D;
                if (target == null) return;

                Map map = from.Map;
                if (map == null) return;

                Point3D location = new Point3D(target);
                if (target is StaticTarget) location.Z -= TileData.ItemTable[((StaticTarget)target).ItemID & 0x3FFF].CalcHeight;

                Item newItem = new Static(m_ItemID);
                newItem.MoveToWorld(location, from.Map);
                from.Target = new CreateItemTarget(m_ItemID);
            }

            protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
            {
                from.SendGump(new GetImageGump(m_ItemID));
                base.OnTargetCancel(from, cancelType);
            }
        }
    }
}

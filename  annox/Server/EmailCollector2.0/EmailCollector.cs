using System; 
using Server; 
using System.IO; 
using Server.Gumps; 
using Server.Network; 
using Server.Items; 
using Server.Mobiles; 
using Server.Accounting;

using Server.Commands;

namespace Server.Gumps 
{ 
      public class UpdateEmail : Gump 
      { 
            public static void Initialize() 
            {
                CommandSystem.Register("UpdateEmail", AccessLevel.Player, new CommandEventHandler(UpdateEmail_OnCommand)); 
            } 

            private static void UpdateEmail_OnCommand( CommandEventArgs e ) 
            { 
               e.Mobile.SendGump( new UpdateEmail( e.Mobile ) ); 
            } 

            private Mobile m_From; 

            public UpdateEmail( Mobile owner ) : base( 25,25 ) 
            { 

               this.m_From = owner; 

         Closable=true; 
         Disposable=true; 
         Dragable=true; 
         Resizable=false; 
         AddPage(0); 
         AddBackground(25, 22, 407, 228, 5120); 
         AddPage(1); 
         AddImageTiled(43, 171, 200, 20, 1124); 
         AddHtml( 36, 32, 386, 100, @"<CENTER><U>Email Collection</U><BR>Please give us your email so we can tell you about up coming events and other shard matters.<BR>Thanks -Ravon", (bool)true, (bool)true); 
         AddLabel(43, 146, 1160, @"Email Address:"); 
         AddTextEntry(43, 171, 200, 20, 0x384, 0, @"" ); 
         AddButton(43, 203, 4026, 4027, 1, GumpButtonType.Reply, 0); 
         AddLabel(85, 205, 1149, @"Submit"); 
         AddButton(275, 217, 11400, 11410, 2, GumpButtonType.Page, 2); 
         AddLabel(297, 214, 1149, @"Privacy Policy"); 
         AddImage(358, 142, 5516); 
         AddPage(2); 
         AddHtml( 38, 32, 381, 173, @"<CENTER><U>Privacy Policy</U><BR>Your privacy is very important to us.  If you any any question or comments please email one of our staff.", (bool)true, (bool)true); 
         AddButton(44, 213, 4005, 4006, 3, GumpButtonType.Page, 1); 
         AddLabel(81, 215, 1149, @"Back"); 

      } 
       
            public override void OnResponse( NetState state, RelayInfo info ) 
            { 

              if ( info.ButtonID == 1 ) // Add Email 
               { 
                           Mobile from = state.Mobile; 
                           Account acct = (Account)from.Account; 
                     string newEmail = (string)info.GetTextEntry( 0 ).Text; 

                           acct.SetTag( "Email", newEmail ); 

            m_From.SendMessage( "Thank you." ); 
            m_From.SendMessage( 38, "You can update your email address at anytime by saying [updateemail in game." ); 
         } 

        
           } 
   } 
} 

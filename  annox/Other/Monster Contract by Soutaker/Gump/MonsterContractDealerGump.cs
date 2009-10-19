/***************************
**    Monster Contract Dealer   **
**    Creator: Raisor: Created the Monster Contract sytem for RunUO ver 1.0	**
**    Darkness_PR Made the NPC for the Monster Contract System for RunUO ver 1.0 **
**    Current Updater for RunUO ver 2.0: Soultaker    **
**    Version: 2.0a				**
***************************/
// Currently Being Updated by Soultaker
// All Credit goes to Raisor & Darkness_PR otherwise we wouldnt have this fantastic system.

using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Commands; //Added to work on Runuo 2.0

namespace Server.Gumps
{ 
   public class MonsterContractDealerGump : Gump 
   { 
      public static void Initialize() 
      { 
//         Commands.Register( "MonsterContractDealerGump", AccessLevel.GameMaster, new CommandEventHandler( MonsterContractDealerGump_OnCommand ) );  //Removed for Runuo 2.0
          Commands.CommandSystem.Register("MonsterContractDealerGump", AccessLevel.GameMaster, new CommandEventHandler(MonsterContractDealerGump_OnCommand)); // Added for Runuo 2.0
      } 

//      private static void MonsterContractDealerGump_OnCommand( CommandEventArgs e ) // removed works on runuo 1.0
      private static void MonsterContractDealerGump_OnCommand( CommandEventArgs e ) // Fixed for Runuo 2.0
      { 
         e.Mobile.SendGump( new MonsterContractDealerGump( e.Mobile ) ); 
      } 

      public MonsterContractDealerGump( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Monster Contracts" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Well hello there! May I speak with you for a second? I got a favor to ask you and, I was wondering if you could help me.<BR><BR>I have in my possession some Monster Contracts. But im too old to be hunting, I allready worked for the gold and food I need for now. But you! You look so young and in need of a job.<BR>" +
"<BASEFONT COLOR=YELLOW>So could you please accept one of my monster contracts?<BR><BR>Oh wow, thank you my friend. The way this contract works is that it will display the monster you will need to hunt. By knowledge you should know where they are at. But if not just ask some people, I think they will be glad to help you." +
"<BASEFONT COLOR=YELLOW>After you have located the species you need hunt, just go ahead and kill it, and then double click the contract and select CLAIM CORPSE, after you have reached the amount desired in the contract go ahead and claim your prize!<BR><BR>If you wish you may come to me again and ask for another contract I have plenty to give out!" +
						     "</BODY>", false, true);

			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 
      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               from.SendMessage( "A monster contract has been placed in your backpack!Thank you my friend for your kindness!" );
               break; 
            } 

         }
      }
   }
}

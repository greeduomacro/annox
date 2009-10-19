/***************************************************************************
 *                                  RemoveAccountTag.cs
 *                            		-------------------
 *  begin                	: September, 2007
 *  version					: 2.0 **VERSION FOR RUNUO 2.0**
 *  copyright            	: Matteo Visintin
 *  email                	: tocasia@alice.it
 *  msn						: Matteo_Visintin@hotmail.com
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

/***************************************************************************
 *  Info:
 * 			Remove specified tag (or tags if more than one present)
 * 			from target account.
 * 
 * 			paramater 1: 	account to remove tag from
 * 			parameter 2: 	tag\s to remove
 * 
 ***************************************************************************/

using System;

using Server;
using Server.Accounting;
using Server.Gumps;

namespace Server.Commands
{
	public class RemoveAccountTag
	{
		#region registrazione
		public static void Initialize()
		{
			CommandSystem.Register( "RemoveAccountTag" , AccessLevel.Developer, new CommandEventHandler( RemoveAccountTag_OnCommand ) );
		}
		#endregion
	
		#region callback
		[Usage( "RemoveAccountTag <account> <tag>" )]
		[Description( "Remove a tag from target account" )]
		public static void RemoveAccountTag_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;
			if( from == null || from.Deleted )
				return;

			if( e.Length == 2 )
			{
				string accString = e.GetString( 0 );
				string tagString = e.GetString( 1 );

				if( !string.IsNullOrEmpty( accString ) )
				{
					Account acct = Accounts.GetAccount( accString ) as Account;

					if( acct != null )
					{
						if( !string.IsNullOrEmpty( tagString ) )
						{
							if( !string.IsNullOrEmpty(acct.GetTag( tagString )) )
							{
								string msg = string.Format( "You are going to remove tag <em><basefont color=red>{0}</basefont></em> " +
								                            "from accunt <em><basefont color=red>{1}</basefont></em>.<br>" +
							                            	"Are you sure you want to proceed?", tagString, accString );
								from.SendGump( new WarningGump( 1060635, 30720, msg, 0xFFC000, 420, 280, new WarningGumpCallback( ConfirmRemoveCallBack ), new object[]{ acct, tagString }, true ) );
							}
							else
							{
								from.SendMessage( "Target account exist but does not have that tag." );
							}
						}
						else
						{
							from.SendMessage( "Invalid tag (null or empty)." );
						}
					}
					else
					{
						from.SendMessage( "Target account does not exist." );
					}
				}
				else
				{
					from.SendMessage( "Invalid userName (null or empty)." );
				}
			}
			else
			{
				from.SendMessage( "CommandUse: [RemoveAccountTag <account> <tag>" );
			}
		}

      	private static void ConfirmRemoveCallBack( Mobile from, bool okay, object state )
      	{
      		object[] states = (object[])state;

      		Account acct = (Account)states[0];
      		string tag = (string)states[1];

      		if( okay )
      		{
      			from.SendMessage( "You have decided to proceede." );

      			try
      			{
      				acct.RemoveTag( tag );
      				from.SendMessage( "You have successfully removed tag >>{0}<< from account >>{1}<<.", tag, acct.Username );
      			}
      			catch( System.Exception e )
      			{
      				Console.WriteLine( e.ToString() );
      			}
      		}
      	}
		#endregion
	}
}

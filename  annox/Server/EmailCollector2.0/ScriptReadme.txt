Well first of all i'd like to Thank Paige from fallenSouls.org 
for scripting this he did 95% of the work i just treaked it a little to be more user friendly !


Installation:

installing this is very simple just put the too scripts in your custome scripts folder 
then if ya want you can edit the  privacy policy and stuff in EmailCollection.cs 
it's not too hard to figure out how to change text in this

Next step in runuo/scripts/misc/CharaterCreation.cs you only have to do this if 
You want the gump to popip when a new player joins or Creates a new char!!


change :


		//CityInfo city = args.City;
        	CityInfo city = new CityInfo( "Britain", "Sweet Dreams Inn", 1496, 1628, 10 );

		newChar.MoveToWorld( city.Location, Map.Felucca );

		Console.WriteLine( "Login: {0}: New character being created (account={1})", args.State, ((Account)args.Account).Username );
		Console.WriteLine( " - Character: {0} (serial={1})", newChar.Name, newChar.Serial );
		Console.WriteLine( " - Started: {0} {1}", city.City, city.Location );

		new WelcomeTimer( newChar ).Start();

to:

                //CityInfo city = args.City;
        	CityInfo city = new CityInfo( "Britain", "Sweet Dreams Inn", 1496, 1628, 10 );

		newChar.MoveToWorld( city.Location, Map.Felucca );

		Console.WriteLine( "Login: {0}: New character being created (account={1})", args.State, ((Account)args.Account).Username );
		Console.WriteLine( " - Character: {0} (serial={1})", newChar.Name, newChar.Serial );
		Console.WriteLine( " - Started: {0} {1}", city.City, city.Location );

		new WelcomeTimer( newChar ).Start();
                new StartTimer( newChar ).Start(); 


And then when ppl make a new char the gump will popup you can choose weather it's closeable or not in EmailCollector.cs

Credit's go to:
Paige Main Scripting/Gump
Link_of_Hyrule Tweaking/Testing/Writing This Read Me



Contact Information:

Link's Info:

Email: Link_of_Hyrule@kokiriforestuo.cjb.net
Msn: Matt_of_the_Elite@msn.com
AIM: linkofhyruless
YIM: Link_of_Hyrule_ssb
WebSite: http://www.KokiriForestUO.cjb.net

Paige's Info:

Email: I Don't Know for some gay reason!
MSN: RoninGT@msn.com
Aim: RoninGTO
YIM: Eville_Dude_69_420
WebSite: http://www.fallensouls.org














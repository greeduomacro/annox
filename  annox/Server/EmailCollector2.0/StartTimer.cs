using System; 
using Server.Gumps; 
using Server.Network; 

namespace Server.Misc 
{ 
   /// <summary> 
   /// This timer spouts some welcome messages to a user at a set interval. It is used on character creation and login. 
   /// </summary> 
   public class StartTimer : Timer 
   { 
      private Mobile m_Mobile; 

      /*public StartTimer( Mobile m ) : this( m, m_Messages.Length ) 
      { 
      }*/ 

      public StartTimer( Mobile m ) : base( TimeSpan.FromSeconds( 30.0 ) ) 
      { 
         m_Mobile = m; 
      } 

      protected override void OnTick() 
      { 
         m_Mobile.SendGump( new UpdateEmail( m_Mobile ) ); 
         Stop(); 
      } 
   } 
} 
 

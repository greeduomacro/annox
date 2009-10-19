using System;
using System.IO;
using System.Text;

namespace System
{
	public class ConsoleHook : TextWriter
	{
		public override Encoding Encoding
		{
			get { return Encoding.ASCII; }
		}

		private string Timestamp
		{
			get { return String.Format( "{0:D2}/{1:D2}-{2:D2}:{3:D2} ",DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Hour,DateTime.Now.Minute ); }
		}

		private static Stream m_OldOutput;
		private static bool m_Newline;

		public static void Initialize()
		{
			m_OldOutput = Console.OpenStandardOutput();
			Console.SetOut( new ConsoleHook() );
			m_Newline = true;
		}

		public override void WriteLine( string value )
		{
			if ( m_Newline )
			{
				value = Timestamp + value;
			}

			byte[] data = Encoding.GetBytes( value );
			m_OldOutput.Write( data,0,data.Length );
			m_OldOutput.WriteByte( 10 );
			m_Newline = true;
		}

		public override void Write( string value )
		{
			if ( m_Newline )
			{
				value = Timestamp + value;
			}

			byte[] data = Encoding.GetBytes( value );
			m_OldOutput.Write( data,0,data.Length );
			m_Newline = false;
		}
	}
}
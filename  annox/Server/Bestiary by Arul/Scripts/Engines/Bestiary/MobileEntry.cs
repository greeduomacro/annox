//#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Server.Mobiles;
using Server.Items;

using Ultima;
namespace Server.Bestiary
{
	/// <summary>
	/// Custom enum to differentiate between metadata tokens within a module
	/// </summary>
	public enum MetadataToken
	{
		String		= 0x07000000,

		MemberRef	= 0x0A000000,
		MethodRef	= 0x06000000,
		
		Method		= MemberRef | MethodRef
	};

	/// <summary>
	/// Generic method handler.
	/// 
	/// Doesn't handle method polymorphism, the only way it
	/// differentiates between methods with the same name is by the paramCount.
	/// TODO? Who knows.
	/// </summary>
	/// <param name="m">Parent MobileEntry</param>
	/// <param name="paramCount">Parameter count</param>
	public delegate void MethodHandler( MobileEntry m, int paramCount );	
	
	
	/*
	//Method handler that supports polymorphism.
	//public delegate void MethodHandler( MobileEntry m ); 
	public struct HandlerInfo
	{
		private const string 		format = "{0}//";
		public readonly string 	MethodName;
		public readonly Type[] 	Types;
		private readonly int 		CachedHash;
		
		public HandlerInfo( string name, Type[] types )
		{
			MethodName = name;
			Types = types;
		}
		
		public override int GetHashCode()
		{
				if(CachedHash != 0)
				return CachedHash;
			
			StringBuilder hashBuilder = new StringBuilder();
			hashBuilder.AppendFormat(format, MethodName);
			
			foreach(Type t in Types)
			{
				hashBuilder.AppendFormat(format, t.Name);	
			}
			
			string strHash = hashBuilder.ToString();
			
			return (CachedHash = strHash.GetHashCode());
		}		
	};*/

	public sealed class MobileEntry
	{
		#region [Static]
		/// <summary>
		/// The top layer or border image, respectively.
		/// </summary>
		private static Bitmap m_BorderImage			= new Bitmap( "Data/Bestiary/layer_top.png" );

		/// <summary>
		/// The bottom layer or background, respectively.
		/// </summary>
		private static Bitmap m_Background			= new Bitmap( "Data/Bestiary/layer_bottom.jpg" );

		/// <summary>
		/// Watermark image, should be f.e. your shard's logo.
		/// </summary>
		private static Bitmap m_WaterMark			= new Bitmap( "Data/Bestiary/watermark.png" );

		/// <summary>
		/// Parameters for the encoder
		/// </summary>
		private static EncoderParameters m_EncoderParameter 	= new EncoderParameters();

		/// <summary>
		/// Used to look-up slayer titles
		/// </summary>
		private static StringList m_Cliloc			= new StringList( "enu" );

		/// <summary>
		/// JPEG encoder by default
		/// </summary>
		private static ImageCodecInfo m_Encoder;

		/// <summary>
		/// HTML templates of the page
		/// </summary>
		private static Dictionary<string, string> m_Templates = new Dictionary<string, string>();

		/// <summary>
		/// Needed to set the alpha blend matrix
		/// </summary>
		internal static ImageAttributes imgAttrs = new ImageAttributes();

		/// <summary>
		/// Used to render the watermark
		/// </summary>
		internal static float[][] alphaBlendMatrix = new float[][] {
				new float[] { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f },	// Red		100%
				new float[] { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f },	// Green	100%
				new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f },	// Blue		100%
				new float[] { 0.0f, 0.0f, 0.0f, .075f, 0.0f },	// Alpha	7.5%
				new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f }	// Gamma	100%
			};

		/// <summary>
		/// Maps method names to their particular methodhandlers
		/// </summary>
		private static Dictionary<string, MethodHandler> m_Handlers = new Dictionary<string, MethodHandler>();		
		// method polymorphism
		//private static Dictionary<HandlerInfo, MethodHandler> m_Handlers = new Dictionary<HandlerInfo, MethodHandler>();

		/// <summary>
		/// Types to ignore while dispatching method names
		/// </summary> 
		private static Dictionary<string, int> m_IgnoredTypes = new Dictionary<string, int>();

		/// <summary>
		/// Blank handler used for debug purpose
		/// </summary>
		private static MethodHandler m_BlankHandler = delegate( MobileEntry m, int paramCount )	{/*supress the unregistered handler message in debug mode, TODO!*/};

		/// <summary>
		/// Gets a hue from the data file.
		/// </summary>
		/// <param name="index">Id of the hue</param>
		/// <returns>The UO hue, null on error.</returns>
		public static Hue GetHue( int index )
		{
			string huesFile = Core.FindDataFile( "hues.mul" );

			if( ( huesFile == null ) || !File.Exists( huesFile ) )
			{
				return null;
			}

			Hue hue = null;

			using( FileStream stream = new FileStream( huesFile, FileMode.Open, FileAccess.Read, FileShare.Read ) )
			{
				BinaryReader reader = new BinaryReader( stream );

				int offset = index / 8;
				int remainder = index % 8;
				int startAddress = ( offset * 0x2c4 ) + ( remainder * 0x58 );

				if( (startAddress + 0x58) < stream.Length )
				{
					stream.Seek( (long)startAddress, SeekOrigin.Begin );
					hue = new Hue( index, reader );
				}
			}
			return hue;
		}
		
		/// <summary>
		/// Static ctor; initializes method handlers, templates, codecs and whatnot.
		/// </summary>
		static MobileEntry()
		{
			#region [Method handlers]
			/*******************************************************
			 * Method name: set_Body
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (int)
			 *
			 * Description:
			 *	Syntactic un-sugar for the Body{set;get;} property.
			 *
			 * Notes:
			 * 	Used to set mobiles body to specified value.
			 *
			 ********************************************************/
			m_Handlers[ "set_Body" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{ typeof(int) };
						
						m.m_BodyId = m.Pop<int>();
					};
			/*******************************************************
			 * Method name: SetStr
			 * 
			 * Parameters: 1 / 2
			 *
			 * Parameter types: (int) / (int, int)
			 *
			 * Description:			 
			 * 	Used to set mobiles strength to specified value.
			 *
			 * Notes:
			 * 	Mutation with two arguments describes min->max range.
			 *
			 ********************************************************/
			m_Handlers[ "SetStr" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						
						if( paramCount == 2 )
						{
							m.m_Str[ 0 ] = m.Pop<int>();
							m.m_Str[ 1 ] = m.Pop<int>();
						}
						else
						{
							m.m_Str[ 0 ] = m.m_Str[ 1 ] = m.Pop<int>();
						}
					};
			/*******************************************************
			 * Method name: SetDex
			 * 
			 * Parameters: 1 / 2
			 *
			 * Parameter types: (int) / (int, int)
			 *
			 * Description:			 
			 * 	Used to set mobiles dexterity to specified value.
			 *
			 * Notes:
			 * 	Mutation with two arguments describes min->max range.
			 *
			 ********************************************************/
			m_Handlers[ "SetDex" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						
						if( paramCount == 2 )
						{
							m.m_Dex[ 0 ] = m.Pop<int>();
							m.m_Dex[ 1 ] = m.Pop<int>();
						}
						else
						{
							m.m_Dex[ 0 ] = m.m_Dex[ 1 ] = m.Pop<int>();
						}
					};
			/*******************************************************
			 * Method name: SetInt
			 * 
			 * Parameters: 1 / 2
			 *
			 * Parameter types: (int) / (int, int)
			 *
			 * Description:			 
			 * 	Used to set mobiles intelligence to specified value.
			 *
			 * Notes:
			 * 	Mutation with two arguments describes min->max range.
			 *
			 ********************************************************/
			m_Handlers[ "SetInt" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						if( paramCount == 2 )
						{
							m.m_Int[ 0 ] = m.Pop<int>();
							m.m_Int[ 1 ] = m.Pop<int>();
						}
						else
						{
							m.m_Int[ 0 ] = m.m_Int[ 1 ] = m.Pop<int>();
						}
					};
			/*******************************************************
			 * Method name: SetDamageType
			 * 
			 * Parameters: 2
			 *
			 * Parameter types: (int, int)
			 *
			 * Description:			 
			 * 	Used to set mobiles damage types.
			 *
			 * Notes:
			 * 	The first value on the stack is the amount of damage, the second
			 * 	is the type of the damage (in code specified as DamageType enum).
			 *
			 ********************************************************/
			m_Handlers[ "SetDamageType" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						
						int value = m.Pop<int>();
						int type = m.Pop<int>();

						switch( type )
						{
							case 0:
								m.m_DamagePhysical = value;
								break;
							case 1:
								m.m_DamageFire = value;
								break;
							case 2:
								m.m_DamageCold = value;
								break;
							case 3:
								m.m_DamagePoison = value;
								break;
							case 4:
								m.m_DamageEnergy = value;
								break;
							default:
								break;
						}
					};
			/*******************************************************
			 * Method name: SetResistance
			 * 
			 * Parameters: 2 / 3
			 *
			 * Parameter types: (int, int) / (int, int, int)
			 *
			 * Description:			 
			 * 	Used to set mobiles resistance types.
			 *
			 * Notes:
			 * 	The first value on the stack is the maximum resistance, the second
			 * 	is the minimum resistance or resistance type, respectively.
			 *
			 ********************************************************/
			m_Handlers[ "SetResistance" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int),typeof(int)};
						
						int max = m.Pop<int>();
						int min = max;

						if( paramCount == 3 )
						{
							min = m.Pop<int>();
						}

						int type = m.Pop<int>();

						switch( type )
						{
							case 0:
								m.m_Physical = new int[] { min, max };
								break;
							case 1:
								m.m_Fire = new int[] { min, max };
								break;
							case 2:
								m.m_Cold = new int[] { min, max };
								break;
							case 3:
								m.m_Poison = new int[] { min, max };
								break;
							case 4:
								m.m_Energy = new int[] { min, max };
								break;
							default:
								break;
						}
					};
			/*******************************************************
			 * Method name: SetSkill
			 * 
			 * Parameters: 2 / 3
			 *
			 * Parameter types: (double, int) / (double, double, int)
			 *
			 * Description:			 
			 * 	Used to set mobiles skills.
			 *
			 * Notes:
			 * 	The first value on the stack is the maximum skill value, the second
			 * 	is the minimum skill value or skill type, respectively.
			 *
			 ********************************************************/
			m_Handlers[ "SetSkill" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(double),typeof(int)};
						//Type[] typeSignature = new Type[]{typeof(double),typeof(double),typeof(int)};
						double max = m.Pop<double>();
						double min = max;

						if( paramCount == 3 )
						{
							min = m.Pop<double>();
						}

						int type = m.Pop<int>();

						m.m_Skills[ type ] = new double[] { min, max };
					};
					
			/********************************************************
				Polymorphic method handler (PMH):
				
				Note: 
					- in current release PMH-ing is not needed, as the PMH code gets
					  a little ugly in comparison to param-count way, I'll just leave here
					  a small example.
				
			m_Handlers[new HandlerInfo( "SetSkill",new Type[]{typeof(double),typeof(int)})] =
					delegate( MobileEntry m )
					{
						double max 	= m.Pop<double>();
						double min 		= max;
						int type 			= m.Pop<int>();

						m.m_Skills[ type ] = new double[] { min, max };
					};
					
			m_Handlers[new HandlerInfo( "SetSkill", new Type[]{typeof(double),typeof(double),typeof(int)})] =
					delegate( MobileEntry m )
					{
						double max 	= m.Pop<double>();
						double min 		= m.Pop<double>();
						int type 			= m.Pop<int>();

						m.m_Skills[ type ] = new double[] { min, max };
					};
			********************************************************/
			
			/*******************************************************
			 * Method name: set_Fame
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (int)
			 *
			 * Description:			 
			 * 	Syntactic un-sugar for the Fame{set;get;} property.
			 *
			 * Notes:
			 * 	USed to set mobiles fame to the value specified.
			 *
			 ********************************************************/
			m_Handlers[ "set_Fame" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						m.m_Fame = m.Pop<int>(  );
					};
			/*******************************************************
			 * Method name: set_VirtualArmor
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (int)
			 *
			 * Description:			 
			 * 	Syntactic un-sugar for the VirtualArmor{set;get;} property.
			 *
			 * Notes:
			 * 	USed to set mobiles VirtualArmor to the value specified.
			 *
			 ********************************************************/
			m_Handlers[ "set_VirtualArmor" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						m.m_VirtualArmor = m.Pop<int>(  );
					};
			/*******************************************************
			 * Method name: set_Title
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (string)
			 *
			 * Description:			 
			 * 	Syntactic un-sugar for the Title{set;get;} property.
			 *
			 * Notes:
			 * 	USed to set mobiles Title to the value specified.
			 *
			 ********************************************************/
			m_Handlers[ "set_Title" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(string)};
						m.m_Title = m.Pop<string>(  );
					};
			/*******************************************************
			 * Method name: set_Karma
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (int)
			 *
			 * Description:			 
			 * 	Syntactic un-sugar for the Karma{set;get;} property.
			 *
			 * Notes:
			 * 	USed to set mobiles Karma to the value specified.
			 *
			 ********************************************************/
			m_Handlers[ "set_Karma" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						m.m_Karma = m.Pop<int>(  );
					};
			/*******************************************************
			 * Method name: SetDamage
			 * 
			 * Parameters: 2
			 *
			 * Parameter types: (int, int)
			 *
			 * Description:			 
			 * 	Used to set mobiles damage potential.
			 *
			 * Notes:
			 * 	The first value on the stack is the maximum damage,
			 * 	the second value is the minimum damage.
			 *
			 ********************************************************/
			m_Handlers[ "SetDamage" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						m.m_Damage[1] = m.Pop<int>();
						m.m_Damage[0] = m.Pop<int>();
					};
			/*******************************************************
			 * Method name: set_Hue
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (int)
			 *
			 * Description:			 
			 * 	Syntactic un-sugar for the Hue{set;get;} property.
			 *
			 * Notes:
			 * 	USed to set mobiles Hue to the value specified.
			 *
			 ********************************************************/
			m_Handlers[ "set_Hue" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						m.m_Hue = m.Pop<int>(  );						
					};
			/*******************************************************
			 * Method name: Utility::RandomDouble
			 * 
			 * Parameters: 0
			 *
			 * Parameter types: (void)
			 *
			 * Description:			 
			 * 	Pushes a random value on the stack.
			 *
			 * Notes:
			 * 	Should push "Random (0.0, 1.0)" instead?
			 *
			 ********************************************************/
			m_Handlers[ "Utility::RandomDouble" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[0];
						m.m_Stack.Push( Utility.RandomDouble() );						
					};
			/*******************************************************
			 * Method name: Utility::RandomMinMax
			 * 
			 * Parameters: 2
			 *
			 * Parameter types: (int, int)
			 *
			 * Description:			 
			 * 	Pushes a random value within the range min/max on the stack.
			 *
			 * Notes:
			 * 	Should push "Random (n1, n2)" instead?
			 *
			 ********************************************************/
			m_Handlers[ "Utility::RandomMinMax" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						if( paramCount == 2 )
						{
							m.m_Stack.Push( Utility.RandomMinMax( m.Pop<int>(), m.Pop<int>() ) );
						}						
					};
			/*******************************************************
			 * Method name: Utility::Random
			 * 
			 * Parameters: 1 / 2
			 *
			 * Parameter types: (int) / (int, int)
			 *
			 * Description:			 
			 * 	Pushes a random value on the stack.
			 *
			 * Notes:
			 * 	Should push "Random (n1) / Random(n1, n2)" instead?
			 *
			 ********************************************************/
			m_Handlers[ "Utility::Random" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						//Type[] typeSignature = new Type[]{typeof(int),typeof(int)};
						if( paramCount == 1 )
						{
							m.m_Stack.Push( Utility.Random( m.Pop<int>() ) );
						}
						else if ( paramCount == 2 )
						{
							m.m_Stack.Push( Utility.Random( m.Pop<int>(), m.Pop<int>() ) );
						}
					};
			/*******************************************************
			 * Method name: Utility::RandomBool
			 * 
			 * Parameters: 0
			 *
			 * Parameter types: (void)
			 *
			 * Description:			 
			 * 	Pushes a random true/false value on the stack.
			 *
			 * Notes:
			 * 	Should push "Random (true/false)" instead?
			 *
			 ********************************************************/
			m_Handlers[ "Utility::RandomBool" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[0];
						m.m_Stack.Push( Utility.RandomBool() );
					};
			/*******************************************************
			 * Method name: set_MinTameSkill
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (double)
			 *
			 * Description:			 
			 * 	Syntactic un-sugar for the MinTameSkill{set;get;} property.
			 *
			 * Notes:
			 * 	USed to set mobiles MinTameSkill to the value specified.
			 *
			 ********************************************************/
			m_Handlers[ "set_MinTameSkill" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(double)};
						m.m_MinToTame = m.Pop<double>();
					};
			/*******************************************************
			 * Method name: set_ControlSlots
			 * 
			 * Parameters: 1
			 *
			 * Parameter types: (int)
			 *
			 * Description:			 
			 * 	Syntactic un-sugar for the ControlSlots{set;get;} property.
			 *
			 * Notes:
			 * 	USed to set mobiles ControlSlots to the value specified.
			 *
			 ********************************************************/
			m_Handlers[ "set_ControlSlots" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(int)};
						m.m_ControlSlots = m.Pop<int>();
					};
			/*******************************************************
			 * Method name: BaseCreature::.ctor
			 * 
			 * Parameters: 6
			 *
			 * Parameter types: (double, double, int, int, int, int)
			 *
			 * Description:			 
			 * 	Constructor of the BaseCreature class.
			 *
			 * Notes:
			 * 	Sets following properties in the respective order:
			 *	- (skipped) Passive speed
			 *	- (skipped) Active speed
			 *	- (skipped) Fight range
			 *	- (skipped) Range perception
			 *	- (skipped) Fight mode
			 *	- AI Mode
			 *
			 ********************************************************/
			m_Handlers[ "BaseCreature::.ctor" ] =
					delegate( MobileEntry m, int paramCount )
					{
						//Type[] typeSignature = new Type[]{typeof(double),typeof(double),typeof(int),typeof(int),typeof(int),typeof(int)};
						
						m.Pop<double>();
						m.Pop<double>();
						m.Pop<int>();
						m.Pop<int>();
						m.Pop<int>();
						m.m_Mode = ( (AIType)m.Pop<int>() ).ToString().Remove( 0, 3 );
					};
			/*******************************************************
			 * Method name: BaseMount::.ctor
			 * 
			 * Parameters: 6
			 *
			 * Parameter types: (double, double, int, int, int, int, int, int, string)
			 *
			 * Description:			 
			 * 	Constructor of the BaseCreature class.
			 *
			 * Notes:
			 * 	Sets following properties in the respective order:
			 *	- (skipped) Passive speed
			 *	- (skipped) Active speed
			 *	- (skipped) Fight range
			 *	- (skipped) Range perception
			 *	- (skipped) Fight mode
			 *	- AI Mode
			 *	- (skipped) ItemID
			 *  - Body ID
			 *  - (skipped) Name
			 *
			 ********************************************************/
			m_Handlers[ "BaseMount::.ctor" ] =
					delegate( MobileEntry m, int paramCount )
					{
						/*Type[] typeSignature = new Type[]{	typeof(double),
																					typeof(double),
																					typeof(int),
																					typeof(int),
																					typeof(int),
																					typeof(int),
																					typeof(int),
																					typeof(int),
																					typeof(string)};*/
						
						m.Pop<double>();
						m.Pop<double>();
						m.Pop<int>();
						m.Pop<int>();
						m.Pop<int>();
						m.m_Mode = ( (AIType)m.Pop<int>() ).ToString().Remove( 0, 3 );
						m.Pop<int>();
						m.m_BodyId = m.Pop<int>();
						m.Pop<string>();
					};
			// Some blank handlers
			m_Handlers[ "Container::DropItem" ] = m_BlankHandler;
			m_Handlers[ "Utility::RandomList" ] = m_BlankHandler;
			m_Handlers[ "set_Tamable" ] = m_BlankHandler;
			m_Handlers[ "SetHits" ] = m_BlankHandler;
			m_Handlers[ "AddItem" ] = m_BlankHandler;
			m_Handlers[ "set_SpeechHue" ] = m_BlankHandler;
			m_Handlers[ "set_Female" ] = m_BlankHandler;
			m_Handlers[ "Utility::AssignRandomHair" ] = m_BlankHandler;
			m_Handlers[ "Utility::RandomNeutralHue" ] = m_BlankHandler;
			m_Handlers[ "Utility::RandomSkinHue" ] = m_BlankHandler;
			m_Handlers[ "set_BaseSoundID" ] = m_BlankHandler;
			m_Handlers[ "SetMana" ] = m_BlankHandler;
			m_Handlers[ "set_Name" ] = m_BlankHandler;
			m_Handlers[ "PackItem" ] = m_BlankHandler;
			m_Handlers[ "PackArmor" ] = m_BlankHandler;
			m_Handlers[ "PackWeapon" ] = m_BlankHandler;
			m_Handlers[ "Body::op_Implicit" ] = m_BlankHandler;
			m_Handlers[ "Seed::RandomBonsaiSeed" ] = m_BlankHandler;
			#endregion

			ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

			// find the JPEG encoder.
			foreach( ImageCodecInfo encoder in encoders )
			{
				if( encoder.FormatDescription == "JPEG" )
				{
					m_Encoder = encoder;
					break;
				}
			}

			// Ignore several types when doing the method dispatch
			m_IgnoredTypes.Add("TimeSpan", 0);
			m_IgnoredTypes.Add("DateTime", 0);
			m_IgnoredTypes.Add("Map", 0);
			m_IgnoredTypes.Add("NameList", 0);
			m_IgnoredTypes.Add("Loot", 0);

			// Set up the encoder
			m_EncoderParameter.Param[ 0 ] = new EncoderParameter( System.Drawing.Imaging.Encoder.Quality, new long[ 1 ] { 0x46 } );
			imgAttrs.SetColorMatrix( new ColorMatrix( alphaBlendMatrix ), ColorMatrixFlag.Default, ColorAdjustType.Bitmap );

			m_Templates.Add( "tableTop", 			"		<center>\n" +
													"			<img src=\"../images/{0}.jpg\" border=\"0\" alt=\"{0}\" />\n" +
													"			<br />\n" +
													"			<br />\n" +
													"			<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"mobileEntry\">\n" );
			m_Templates.Add( "nameHeader", "				<tr>\n" +
													"					<td bgcolor=\"#cccccc\" colspan=\"2\" align=\"center\" style=\"padding: 2px; color: #000\">\n" +
													"						<b>{0}</b>\n" +
													"					</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "strenghtOneArg", "				<tr>\n" +
													"					<th>Strength: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "strenghtTwoArgs", "				<tr>\n" +
													"					<th>Strength: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "dexterityOneArg", "				<tr>\n" +
													"					<th>Dexterity: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "dexterityTwoArgs", "				<tr>\n" +
													"					<th>Dexterity: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "intelligenceOneArg", "				<tr>\n" +
													"					<th>Intelligence: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "intelligenceTwoArgs", "				<tr>\n" +
													"					<th>Intelligence: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "damageTypesHeader", "				<tr>\n" +
													"					<th valign=\"top\">Damage types: </th>\n" +
													"					<td>\n" );
			m_Templates.Add( "resistancesHeader", "				<tr>\n" +
													"					<th valign=\"top\">Resistances: </th>\n" +
													"					<td>\n" );
			m_Templates.Add( "damagePhysical", "						<div style=\"border: 1px solid #555; background-image: url('../physical.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damageFire", "						<div style=\"border: 1px solid #555; background-image: url('../fire.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damageCold", "						<div style=\"border: 1px solid #555; background-image: url('../cold.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damagePoison", "						<div style=\"border: 1px solid #555; background-image: url('../poison.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "damageEnergy", "						<div style=\"border: 1px solid #555; background-image: url('../energy.gif'); width: {0}px; color: #000; font-weight: bold\">\n" +
													"							{0}%\n" +
													"						</div>\n" );
			m_Templates.Add( "endRow", "						<br />\n" +
													"					</td>\n" +
													"				</tr>" );
			m_Templates.Add( "minMaxDmgOneArg", "				<tr>\n" +
													"					<th>Damage: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "minMaxDmgTwoArgs", "				<tr>\n" +
													"					<th>Damage: </th>\n" +
													"					<td>{0} - {1}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "mode", "				<tr>\n" +
													"					<th>Mode: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "fame", "				<tr>\n" +
													"					<th>Fame: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "karma", "				<tr>\n" +
													"					<th>Karma: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "slayer", "				<tr>\n" +
													"					<th>Slayer: </th>\n" +
													"					<td>\n" +
													"						<span style=\"color: #990000\">\n" +
													"							{0}\n" +
													"						</span>\n" +
													"					</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "armour", "				<tr>\n" +
													"					<th>Armour: </th>\n" +
													"					<td>{0}</td>\n" +
													"				</tr>\n" );
			m_Templates.Add( "minToTame", "				<tr>\n" +
										"					<th>Minimal taming: </th>\n" +
										"					<td>{0:F1}</td>\n" +
										"				</tr>\n" );
			m_Templates.Add( "slots", "				<tr>\n" +
										"					<th>Control slots: </th>\n" +
										"					<td>{0}</td>\n" +
										"				</tr>\n" );
			m_Templates.Add( "immunity", "				<tr>\n" +
							"					<th>Poison immunity: </th>\n" +
							"					<td>{0}</td>\n" +
							"				</tr>\n" );
			m_Templates.Add( "barding", "				<tr>\n" +
							"					<th>Barding: </th>\n" +
							"					<td>{0}</td>\n" +
							"				</tr>\n" );
			m_Templates.Add( "skillsHeader", "				<tr>\n" +
													"					<th>Skills: </th>\n" +
													"					<td>\n" );
			m_Templates.Add( "skillRow", "						<b>{0}</b>: {1}<br />\n" );
			m_Templates.Add( "tableFooter", "</table>\n");
		}
		#endregion

		#region [Fields]
		/// <summary>
		/// Reflection.Module which this mobile is a part of.
		/// </summary>
		private Module m_Module;
		/// <summary>
		/// Reflection.Type associated with this mobile
		/// </summary>
		private Type m_MasterType;
		/// <summary>
		/// Min-Max Str
		/// </summary>
		private int[] m_Str = new int[2];		
		/// <summary>
		/// Min-Max Dex
		/// </summary>
		private int[] m_Dex = new int[2];		
		/// <summary>
		/// Min-Max Int
		/// </summary>
		private int[] m_Int = new int[2];		
		/// <summary>
		/// Min-Max Damage
		/// </summary>
		private int[] m_Damage = new int[2];		
		/// <summary>
		/// Min-Max Physical resist
		/// </summary>
		private int[] m_Physical = new int[2];		
		/// <summary>
		/// Min-Max Fire resist
		/// </summary>
		private int[] m_Fire = new int[2];		
		/// <summary>
		/// Min-Max Cold resist
		/// </summary>
		private int[] m_Cold = new int[2];		
		/// <summary>
		/// Min-Max Poison resist
		/// </summary>
		private int[] m_Poison = new int[2];		
		/// <summary>
		/// Min-Max Energy resist
		/// </summary>
		private int[] m_Energy = new int[ 2 ];

		private int m_DamagePhysical;
		private int m_DamageFire;
		private int m_DamageCold;
		private int m_DamagePoison;
		private int m_DamageEnergy;
		private int m_BodyId;
		private int m_Hue;
		private int m_Fame;
		private int m_Karma;
		private int m_VirtualArmor;
		private int m_ControlSlots;
		/// <summary>
		/// Flags;
		/// </summary>
		private int m_Barding;
		private double m_Difficulty;
		private double m_MinToTame;
		private string m_Title;
		private string m_Mode;
		private string m_Name;
		/// <summary>
		/// Used to make the HTML navigation
		/// </summary>
		private string m_PrevLink, m_NextLink;
		/// <summary>
		/// Poison level immunuty
		/// </summary>
		private Poison m_Immunity;
		/// <summary>
		/// What kind of slayer is this beast vulnerable to?
		/// </summary>
		private SlayerEntry m_Slayer;
		/// <summary>
		/// Stack containing parameters for the methods
		/// </summary>
		private Stack m_Stack = new Stack();
		/// <summary>
		/// Skillid - [MinSkill, MaxSkill] Map
		/// </summary>
		private Dictionary<int, double[]> m_Skills = new Dictionary<int, double[]>();
		#endregion

		#region [Properties]
		public string Name { get { return m_Name; } set { m_Name = value; } }
		
		public string PrevLink { get { return m_PrevLink; } set { m_PrevLink = value; } }
		public string NextLink { get { return m_NextLink; } set { m_NextLink = value; } }
		
		public Type MasterType { get { return m_MasterType; } set { m_MasterType = value; } }
		
		/// <summary>
		/// Returns the final generated HTML code.
		/// </summary>
		public string Html
		{
			get
			{
				StringBuilder sb = new StringBuilder( 0x2000 );

				#region [Header]
				sb.AppendFormat( m_Templates[ "tableTop" ], m_MasterType.Name );
				sb.AppendFormat( m_Templates[ "nameHeader" ], m_Name );
				#endregion

				#region [Stats output]
				if( m_Str[ 0 ] != m_Str[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "strenghtTwoArgs" ], m_Str[ 1 ], m_Str[ 0 ] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "strenghtOneArg" ], m_Str[ 0 ] );
				}

				if( m_Dex[ 0 ] != m_Dex[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "dexterityTwoArgs" ], m_Dex[ 1 ], m_Dex[ 0 ] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "dexterityOneArg" ], m_Dex[ 0 ] );
				}

				if( m_Int[ 0 ] != m_Int[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "intelligenceTwoArgs" ], m_Int[ 1 ], m_Int[ 0 ] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "intelligenceOneArg" ], m_Int[ 0 ] );
				}
				#endregion

				#region [Damage Types]
				sb.Append( m_Templates[ "damageTypesHeader" ] );
				if( m_DamagePhysical != 0 )
					sb.AppendFormat( m_Templates[ "damagePhysical" ], m_DamagePhysical );
				if( m_DamageFire != 0 )
					sb.AppendFormat( m_Templates[ "damageFire" ], m_DamageFire );
				if( m_DamageCold != 0 )
					sb.AppendFormat( m_Templates[ "damageCold" ], m_DamageCold );
				if( m_DamagePoison != 0 )
					sb.AppendFormat( m_Templates[ "damagePoison" ], m_DamagePoison );
				if( m_DamageEnergy != 0 )
					sb.AppendFormat( m_Templates[ "damageEnergy" ], m_DamageEnergy );
				sb.Append( m_Templates[ "endRow" ] );
				#endregion

				#region [Resistances]
				sb.Append( m_Templates[ "resistancesHeader" ] );
				if( m_Physical[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damagePhysical" ], m_Physical[ 0 ] );
				if( m_Fire[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damageFire" ], m_Fire[ 0 ] );
				if( m_Cold[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damageCold" ], m_Cold[ 0 ] );
				if( m_Poison[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damagePoison" ], m_Poison[ 0 ] );
				if( m_Energy[ 0 ] != 0 )
					sb.AppendFormat( m_Templates[ "damageEnergy" ], m_Energy[ 0 ] );
				sb.Append( m_Templates[ "endRow" ] );
				#endregion

				#region [Some stuff]
				if( m_Damage[ 0 ] != m_Damage[ 1 ] )
				{
					sb.AppendFormat( m_Templates[ "minMaxDmgTwoArgs" ], m_Damage[ 0 ], m_Damage[1] );
				}
				else
				{
					sb.AppendFormat( m_Templates[ "minMaxDmgOneArg" ], m_Damage[1] );
				}

				sb.AppendFormat( m_Templates[ "mode" ], m_Mode );
				sb.AppendFormat( m_Templates[ "fame" ], m_Fame );
				sb.AppendFormat( m_Templates[ "karma" ], m_Karma );
				sb.AppendFormat( m_Templates[ "armour" ], m_VirtualArmor );

				if( m_Slayer != null )
				{
					sb.AppendFormat( m_Templates[ "slayer" ], m_Cliloc.Table[ m_Slayer.Title ] );
				}

				if( m_ControlSlots > 0 )
				{
					sb.AppendFormat( m_Templates[ "minToTame" ], m_MinToTame );
					sb.AppendFormat( m_Templates[ "slots" ], m_ControlSlots );
				}

				if( m_Immunity != null )
				{
					sb.AppendFormat( m_Templates[ "immunity" ], m_Immunity.ToString() );
				}

				StringBuilder bard = new StringBuilder( 0x400 );

				if( ( m_Barding & 4 ) != 0 )
				{
					bard.Append( "<b>Bard Immune</b><br />\n" );
				}
				else
				{
					bard.AppendFormat( "<b>Difficulty:</b> {0:F1}<br />\n", m_Difficulty );

					if( ( m_Barding & 1 ) != 0 )
					{
						bard.Append( "<b>Unprovokable</b><br />\n" );
					}

					if( ( m_Barding & 2 ) != 0 )
					{
						bard.Append( "<b>Uncalmable</b><br />\n" );
					}
				}

				sb.AppendFormat( m_Templates[ "barding" ], bard.ToString() );

				#endregion

				#region [Skills]
				sb.Append( m_Templates[ "skillsHeader" ] );
				List<int> keys = new List<int>( m_Skills.Keys );

				for( int i = 0; i < 5 && i < m_Skills.Count; i++ )
				{
					double[] skillVal = m_Skills[ keys[ i ] ];
					string skStrVal = "";

					if( skillVal[ 0 ] == skillVal[ 1 ] )
					{
						skStrVal = string.Format( "{0:F1}", skillVal[ 0 ] );
					}
					else
					{
						skStrVal = string.Format( "{0:F1} - {1:F1}", skillVal[ 0 ], skillVal[ 1 ] );
					}

					sb.AppendFormat( m_Templates[ "skillRow" ], SkillInfo.Table[ keys[ i ] ].Name, skStrVal );
				}
				sb.Append( m_Templates[ "endRow" ] );
				#endregion

				#region [Footer]
				sb.Append( m_Templates[ "tableFooter" ] );
				#endregion
			
				if( m_PrevLink != null )
				{
					sb.AppendFormat( "<span style=\"padding: 3px;border: 1px solid #555; background-color: #333; margin: 2px;\">{0}</span>", m_PrevLink );
				}
				
				if ( m_NextLink != null )
				{
                    sb.AppendFormat("&nbsp;&nbsp;&nbsp;<span style=\"padding: 3px;border: 1px solid #555; background-color: #333; margin: 2px;\">{0}</span>", m_NextLink);
				}
				
				sb.Append("</center><br /><br ?>");

				return sb.ToString();
			}
		}
		
		/// <summary>
		/// The entry is considered being empty if some fields are zero.
		/// </summary>
		public bool GuessEmpty
		{
			get
			{
				return ( 
					m_BodyId == 0 &&
					m_Str[1] == 0 && 
					m_Int[1] == 0 && 
					m_Dex[1] == 0 
				);
			}
		}
		#endregion

		public MobileEntry( Type type )
		{
			m_MasterType = type;
			m_Module = type.Module;
			m_Name = Bestiary.TypeRegistry[ m_MasterType ].Name;
			m_Slayer = this.SlayerGroup();

			// Get constructor info
			ConstructorInfo ctor = this.HandleSpecialType( type );

			// Drumroll please...
			AnalyseILCode( ctor.GetMethodBody().GetILAsByteArray() );

			#region [Additional data]
			{
				BaseCreature layla = (BaseCreature)Activator.CreateInstance( type ); // ye got me on my knees, yeah :/
				if( layla.Unprovokable )
				{
					m_Barding |= 0x1;
				}
				if( layla.Uncalmable )
				{
					m_Barding |= 0x2;
				}
				if( layla.BardImmune )
				{
					m_Barding |= 0x4;
				}
				m_Immunity = layla.PoisonImmune;
				m_Difficulty = Items.BaseInstrument.GetBaseDifficulty( layla );
				layla.Delete();
			}
			#endregion

			if( m_BodyId != 0 )
			{
				GenerateImage();
			}
		}		

		/// <summary>
		/// Predicts that the last 0/1 pushed onto the stack is the value to be returned. 
		/// </summary>
		/// <param name="methodName">name of the method</param>
		/// <returns>The result of analyze, false on error.</returns>
		public bool GetBooleanValue( string methodName )
		{
			MethodInfo method = m_MasterType.GetMethod( methodName );
			
			if( method != null )
			{
				byte[] methodData = method.GetMethodBody().GetILAsByteArray();
				
				BinaryReader codeReader = new BinaryReader(
				   new MemoryStream( methodData )
			   	);
			   	
			   	bool lastCode = false;

				while( codeReader.PeekChar() >= 0 )
				{
					OpCode op = OPCodeCache.Hit( codeReader.ReadByte() );
					
					if ( op == OpCodes.Ldc_I4_1 )
					{
						lastCode = true;
					}
					else if ( op == OpCodes.Ldc_I4_0 )
					{
						lastCode = false;
					}
				}
				
				return lastCode;		
			}
			
			return false;
		}
		
		/// <summary>
		/// Some constructors need an extra care.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private ConstructorInfo HandleSpecialType( Type type )
		{
			ConstructorInfo ctor = null;

			if( typeof( BaseMount ).IsAssignableFrom( type ) )
			{
				ctor = type.GetConstructor( new Type[] { typeof( string ) } );
			}

			return ( ctor ?? type.GetConstructor( Type.EmptyTypes ) );
		}

		/// <summary>
		/// Analyze the byte stream, then shook me all night long!
		/// </summary>
		/// <param name="code"></param>
		private void AnalyseILCode( byte[] code )
		{
			BinaryReader codeReader = new BinaryReader(
				   new MemoryStream( code )
			   );

			while( codeReader.PeekChar() >= 0 )
			{
				OpCode op = OPCodeCache.Hit( codeReader.ReadByte() ); // get our OpCode from the cache

				// its int32
				if( op == OpCodes.Ldc_I4 )
				{
					m_Stack.Push( codeReader.ReadInt32() );
				}
				// its int64
				else if( op == OpCodes.Ldc_I8 )
				{
					m_Stack.Push( codeReader.ReadInt64() );
				}
				// its double
				else if( op == OpCodes.Ldc_R8 )
				{
					m_Stack.Push( codeReader.ReadDouble() );
				}
				// its float
				else if( op == OpCodes.Ldc_R4 )
				{
					m_Stack.Push( codeReader.ReadSingle() );
				}
				// Here it gets a little tricky, OpCodes from 0x16 to 0x1E are:
				//
				// Ldc_I4_0 
				// Ldc_I4_1 
				// Ldc_I4_2 
				// Ldc_I4_3 
				// Ldc_I4_4 
				// Ldc_I4_5 
				// Ldc_I4_6 
				// Ldc_I4_7 
				// Ldc_I4_8 
				//
				// Read them as Load Int32 value of 0,1,2,3,4 ... onto the stack.
				// That being said, following the assumption that loading 0 onto the stack means executing
				// an op code with the value of 0x16 we simply can substract 0x16 from the op code value to get
				// the actual number being pushed onto the stack.
				else if( op.Value > 0x15 && op.Value < 0x1F )
				{
					m_Stack.Push( op.Value - 0x16 );
				}
				// Loads a constant value of '-1' onto the stack
				else if( op == OpCodes.Ldc_I4_M1 )
				{
					m_Stack.Push( -1 );
				}
				// Loads a signed byte value as an int32, they say its more effecient, trust 'em.
				else if( op == OpCodes.Ldc_I4_S )
				{
					m_Stack.Push( (int)codeReader.ReadSByte() );
				}
				// Loads a string stored in m_Module
				else if( op == OpCodes.Ldstr )
				{
					int stringDescriptor = codeReader.ReadInt32(); // DWORD string descriptor

					if( MatchMetadata( stringDescriptor, MetadataToken.String ) ) // sanity check, am I really a string?
					{
						m_Stack.Push( m_Module.ResolveString( stringDescriptor ) );
					}
					else
					{
						m_Stack.Push( "(error - string value couldn't be resolved.)" );
					}
				}
				// Though I really don't believe that OpCodes.Call gets ever generated as its f*cking unsafe
				// I'll still handle it here, just see:
				// SomeObj obj = null;
				// obj.SomeMethod("hahahrhhahr");
				//
				// Assuming that SomeMethod is declared as:
				//
				// public void SomeMethod(string text) { Console.WriteLine(text); }
				//
				// Guess what? No System.NullReferenceException gets raised, this behavior might lead
				// to a couple of hard-to-trace bugs.
				else if( op == OpCodes.Call || op == OpCodes.Callvirt )
				{
					int methodDescriptor = codeReader.ReadInt32();

					if( MatchMetadata( methodDescriptor, MetadataToken.Method ) ) // sanity check, am I really a method?
					{
						MethodBase mb = m_Module.ResolveMethod( methodDescriptor );
						//Type[] parameterTypeSignature = Array.ConvertAll<ParameterInfo, Type>(mb.GetParameters(), delegate(ParameterInfo info){ return info.ParameterType; });

						if( (mb.DeclaringType.IsSubclassOf( typeof( Mobile ) ) || mb.DeclaringType == typeof( Mobile )) && !mb.IsConstructor )
						{
							Dispatch( mb.Name, /*parameterTypeSignature*/ mb.GetParameters().Length );
						}
						else
						{
							// if the declaring type of the method is not Mobile or one of its derivation,
							// we need to also dispatch the declaring type's name along, so that we can
							// differentiate between methods with same names but different declaring type.
							Dispatch( mb.Name, mb.DeclaringType.Name,  /*parameterTypeSignature*/ mb.GetParameters().Length );
						}
					}
				}
				else
				{
					// all opcodes that push something onto the stack have been taken care of.
					// now we have to check whether the given opcode has an operand or not.
					// if so, we'll skip appropriate amount of bytes.

					OperandType operandType = op.OperandType;

					switch( operandType )
					{
						// There's no operand
						case OperandType.InlineNone:
							{
							}
							break;
						// 64-bit IEEE floating point number
						case OperandType.InlineR:
						// 64-bit integer
						case OperandType.InlineI8:
							{
								codeReader.ReadInt64();
							}
							break;
						
						// The switch instruction implements a jump table.
						// The format of the instruction is an unsigned int32 representing the number of targets N,
						// followed by N int32 values specifying jump targets: these targets are represented
						// as offsets (positive or negative) from the beginning of the instruction following
						// this switch instruction.						
						case OperandType.InlineSwitch:
							{
								uint switchBranches = codeReader.ReadUInt32();

								while( switchBranches-- > 0 )
								{
									codeReader.ReadInt32();
								}
							}
							break;
						case OperandType.ShortInlineR:
						case OperandType.InlineType:
						case OperandType.InlineTok:
						case OperandType.InlineString:
						case OperandType.InlineSig:
						case OperandType.InlineMethod:
						case OperandType.InlineI:
						case OperandType.InlineField:
						case OperandType.InlineBrTarget:
							{
								codeReader.ReadInt32();
							}
							break;
						case OperandType.InlineVar:
							{
								codeReader.ReadInt16();
							}
							break;
						case OperandType.ShortInlineVar:
						case OperandType.ShortInlineI:
						case OperandType.ShortInlineBrTarget:
							{
								codeReader.ReadByte();
							}
							break;
					}
				}
			}
		}

		/// <summary>
		/// Pops the value of predicted type <typeparamref name="T"/> outta the stack.
		/// </summary>
		/// <typeparam name="T">Type to be returned.</typeparam>
		/// <returns></returns>
		private T Pop<T>()
		{
			if( m_Stack.Count > 0 )
			{
				object pop = m_Stack.Pop();

				if( pop is T )
				{
					return (T)pop;
				}				
			}

			return default( T );
		}

		/// <summary>
		/// Am I really what am I expected to be, huh ?
		/// </summary>
		/// <param name="descriptor"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		private bool MatchMetadata( int descriptor, MetadataToken token )
		{
			return ( descriptor & (int)token ) != 0;
		}

		/// <summary>
		/// Get the slayer entry for this mobile.
		/// </summary>
		/// <returns></returns>
		private SlayerEntry SlayerGroup()
		{
			foreach( SlayerGroup group in Server.Items.SlayerGroup.Groups )
			{
				if( Array.IndexOf<Type>( group.Super.Types, m_MasterType ) != -1 )
				{
					return group.Super;
				}

				foreach( SlayerEntry entry in group.Entries )
				{
					if( Array.IndexOf<Type>( entry.Types, m_MasterType ) != -1 )
					{
						return entry;
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Method dispatcher
		/// </summary>
		/// <param name="methodName">Name of the method to dispatch.</param>
		/// <param name="typeName">Declaring type of the method.</param>
		/// <param name="paramCount">Parameter count.</param>
        private void Dispatch( string methodName, string typeName, int paramCount )
        {
            if (string.IsNullOrEmpty(typeName))
            {
                Dispatch(methodName, paramCount);
            }
            else
            {				
				if( !m_IgnoredTypes.ContainsKey(typeName) )
				{
					Dispatch( string.Concat( typeName, "::", methodName ), paramCount );
				}
            }
        }
		
		private void Dispatch( string methodName, int paramCount )
		{
			MethodHandler handler;

			if( m_Handlers.TryGetValue( methodName, out handler ) )
			{
				handler( this, paramCount );
			}
			else
			{
#if DEBUG
				Console.WriteLine("Unregistered handler for method: {0} !", methodName);
#endif
			}		
		}

		/// <summary>
		/// Generate image for this mobile.
		/// </summary>
		private void GenerateImage()
		{
			Frame[] animFrames = Animations.GetAnimation( m_BodyId, 0, 1, ( m_Hue - 1 ), false );
			
			Bitmap bmp = null;
			
			if( Bestiary.UseFixes )
			{
				//string fixPath = Path.Combine("Bestiary/fixes", m_MasterType.Name + ".jpg");
                string fixPath = Path.Combine("C:/Inetpub/wwwroot/status/Bestiary/fixes", m_MasterType.Name + ".jpg");
				
				if( File.Exists(fixPath) )
				{
					bmp = new Bitmap( fixPath );
				}
			}

            if (animFrames != null || bmp != null)
            {
                using (Bitmap mobImage = new Bitmap(bmp ?? animFrames[0].Bitmap))
                {
                    using (Bitmap result = new Bitmap(m_BorderImage.Width, m_BorderImage.Height))
                    {
                        using (Bitmap title = ASCIIText.DrawText(3, m_Name, 0x3B2))
                        {
                            using (Graphics gr = Graphics.FromImage(result))
                            {
                                using (Bitmap tz = ASCIIText.DrawText(3, string.Format(" - {0} - Bestiary -", Bestiary.ShardName), 1260))
                                {
                                    using (SolidBrush blackBrush = new SolidBrush(Color.FromArgb(60, 1, 1, 1)))
                                    {
                                        if (m_Hue > 0)
                                        {
                                            Hue hue = GetHue(m_Hue - 1);

                                            if (hue != null)
                                            {
												// explicitely apply the hue, GetAnimation method doesn't work for a few bodyIds.
                                                hue.ApplyTo(mobImage, false);
                                            }
                                        }

                                        GraphicsUnit unit = GraphicsUnit.Pixel;
                                        RectangleF rect = mobImage.GetBounds(ref unit);
                                        int topLeftX = (214 - (mobImage.Width >> 1));
                                        int topLeftY = (170 - (mobImage.Height >> 1));
                                        int bottomRightX = (int)(topLeftX + rect.Width);
                                        int bottomRightY = (int)(topLeftY + rect.Height);

										string customBg = Bestiary.TypeRegistry[m_MasterType].Background;
										
										if( !string.IsNullOrEmpty(customBg) )
										{
											using( Bitmap cBg = new Bitmap(customBg) )
											{
												gr.DrawImage(cBg, 0.0f, 0.0f);	
											}
										}
										else
										{									
                                        	gr.DrawImage(m_Background, 0.0f, 0.0f);
                                        }
                                        
                                        gr.FillRectangle(blackBrush, new Rectangle(22, 22, 385, 30));
                                        gr.DrawImage(
                                            m_WaterMark,
                                            new Rectangle(0, 0, m_BorderImage.Width, m_BorderImage.Height),
                                            0,
                                            0,
                                            m_BorderImage.Width,
                                            m_BorderImage.Height,
                                            GraphicsUnit.Pixel,
                                            imgAttrs
                                        ); // these custom attributes mean 7.5% alpha
                                        gr.DrawImage(title, ((bottomRightX + topLeftX) >> 1) - (title.Width >> 1), topLeftY - 5 - title.Height);
                                        gr.DrawImage(mobImage, topLeftX, topLeftY);
                                        gr.DrawImage(m_BorderImage, 0, 0, m_BorderImage.Width, m_BorderImage.Height);
                                        gr.DrawImage(tz, (result.Width >> 1) - (tz.Width >> 1), 25);

                                        //result.Save(Path.Combine("./Bestiary/images/", m_MasterType.Name + ".jpg"), m_Encoder, m_EncoderParameter);
                                        result.Save(Path.Combine("C:/Inetpub/wwwroot/status/Bestiary/images/", m_MasterType.Name + ".jpg"), m_Encoder, m_EncoderParameter);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Couldn't acquire animation frames for bodyID: {0}, {1}", m_BodyId, m_Name);
            }
		}
	};	
}

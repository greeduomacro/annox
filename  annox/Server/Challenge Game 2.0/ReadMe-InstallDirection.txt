In PlayerMobile.cs

add these flags:

		isinchal		= 0x00100001,
		canbechal		= 0x00100002,
		TempMount		= 0x00100003


Under private int m_Profession;

add:
		private int m_Profession;
		private bool isinchal = false;
		private bool canbechal = true;
		private BaseMount m_TempMount;
		private int m_Wins; 
		private int m_Loses; 
		
		[CommandProperty( AccessLevel.GameMaster ) ]
		public BaseMount TempMount
		{
			get { return m_TempMount; }
			set { m_TempMount = value; }
		}
		
		[CommandProperty(AccessLevel.Counselor)]
		public bool IsInChallenge
		{
			get{return isinchal;}
			set{isinchal = value;}
		}
		
		[CommandProperty(AccessLevel.Counselor)]
		public bool CanBeChallenged
		{
			get{return canbechal;}
			set{canbechal = value;}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Wins
		{
			get{return m_Wins;}
			set{m_Wins = value;}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Loses
		{
			get{return m_Loses;}
			set{m_Loses = value;}
		}

In Deserialize:
                case 26:
                    m_Wins= Reader.ReadInt();
                    m_Loses = Reader.ReadInt();
                    goto case 25;
		case 25:
In Serialize:
            writer.Write((int)26);
            writer.Write(m_Wins);
            writer.Write(m_Loses);
using System;


namespace dimples
{
	public class Security
	{
		static encryption defaultEncryption;
		private static Security _instance;
		public static Security Instance()
		{
			if (_instance != null)
				return _instance;
			else
				_instance = new Security ();
			defaultEncryption = new encryption ();
			_instance.str = "string not set";
			return _instance;
		}
		private Security()
		{
		}
		void encrypt(string msg, encryption key=null)
		{
			if (key == null)
				key = defaultEncryption;
		}
		public string str;
	}
	public class encryption
	{
		public encryption()
		{
		}
	}
}
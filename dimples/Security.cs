using System;
using System.Threading.Tasks;
using Buddy;

namespace dimples
{
	public class Security
	{
		static encryption defaultEncryption;
		private static Security _instance;
		private BuddyClient CommunicationClient;
		private string token = string.Empty;
		private AuthenticatedUser user;
		async public Task login(string username, string pwd)
		{
			if (token==string.Empty)
			{
				token = "0";
				CommunicationClient.LoginAsync(username, pwd).ContinueWith(r2 => {
					//string tag;
					CommunicationClient.StartSessionAsync(user,username+DateTime.Now.ToString()).ContinueWith(r3=>{
						if (r3.Exception!=null) token = string.Empty;
						else token = user.Token;
					} );
				} );
			}
		}
		public void create_user(string uname, string pwd)
		{
			_instance.CommunicationClient.CreateUserAsync (uname, pwd).ContinueWith (r => {
				//if (r.Exception!=null) //Toast.MakeText(this,r.Exception.ToString(),ToastLength.Long).Show();

            }); 
		}
		public static Security Instance()
		{
			if (_instance != null)
				return _instance;
			else
				_instance = new Security ();
			defaultEncryption = new encryption ();

			//_instance.str = "string not set";
			_instance.CommunicationClient = new Buddy.BuddyClient(ExternalCommunication.appName,ExternalCommunication.appCode);
			return _instance;
		}
		private Security()
		{
		}
		void sendMsg(string msg)
		{
			string send =defaultEncryption.encrypt (ref msg);
			//_instance.CommunicationClient.LoginAsync(
		}

		public string str;
	}
	public class encryption
	{
		
		char[] key = new char[128];
		char[] unkey = new char[128];
		public encryption()
		{
			for (int i=0; i<32; i++) {
				key[i] = (char)i;
				unkey[i]=(char)i;
			}
			int[] perm = {59,35,110,111,88,106,82,55,126,48,63,101,57,96,84,32,102,72,76,71,51,37,41,112,69,122,85,120
				,49,107,83,86,99,65,43,70,118,39,36,93,79,108,123,95,98,64,81,100,87,67,56,47,116,34,92,91,80,40,53,117
				,75,33,105,74,42,78,124,115,113,44,121,45,114,119,46,60,125,97,38,66,61,109,52,77,62,73,94,89,68,50,103
				,90,104,58,54};
			for (int i=0; i<perm.Length; i++) {
				key[i] = (char)perm [i];
				key[perm [i]] = (char)i;
			}
			key[127] = (char)127;
			unkey[127] = (char)127;
		}
		//simple substitution cipher on all "readable" characters for proof of concept
		public string encrypt(ref string msg)
		{
			string res = string.Empty;
			foreach (char c in msg) {
				if (c<128)
					res += key [(int)c];
			}
			return res;
		}
		private string decrypt(string cip)
		{
			string res = string.Empty;
			foreach (char c in cip) {
				res += unkey [(int)c];
			}
			return res;
		}
	}
	public class ExternalCommunication
	{
		//uses Buddy Platform SDK
		public const string appName = "dimples";
		public const string appCode = "6C417E66-EC49-4B4B-BD98-4FFCA8B5E390";
	}
}
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace dimples
{
	[Activity (Label = "DiMPLES", MainLauncher = false)]
	public class Profile : Activity, AppInterface
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Profile);
		}
		public Profile ()
		{
		}
		public string encrypt()
		{
			return "";
		}
		public string getInfo(string request)
		{
			return "";
		}
		public void send(string message = "", string encryption = "")
		{
		}
		public void read()
		{
		}
	}
}


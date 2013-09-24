using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace dimples
//DIMPLeS: the Doctor-In-My-Pocket Locationless eHealthcare Solution
{
	[Activity (Label = "dimples", MainLauncher = true)]
	public class Activity1 : Activity
	{
		//int count = 1;
		public static Security sec;
		public static List<AppInterface> apps;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			sec = Security.Instance ();
			//apps.Add(new Users());
			//apps.Add (new Broadcast ());
			sec.str = "string set";
			// Set our view from the "main" layout resource

			SetContentView (Resource.Layout.Main);
			StartActivity (typeof(Navigation));
			// Get our button from the layout resource,
			// and attach an event to it
			/*Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};*/
		}
	}
}



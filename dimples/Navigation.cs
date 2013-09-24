using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace dimples
{
	[Activity (Label = "Navigation")]			
	public class Navigation : Activity
	{
		static Security sec;
		protected override void OnCreate (Bundle bundle)
		{
			sec = Security.Instance ();
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Navigation);
			FindViewById<TextView> (Resource.Id.textView1).Text = sec.str;
			// Create your application here
		}
	}
}


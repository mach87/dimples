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
	[Activity (Label = "DiMPLES", MainLauncher = true)]
	public class Activity1 : Activity
	{
		//int count = 1;
		public SystemCore sys;
		public static List<AppInterface> apps;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			//sec = Security.Instance ();
			//apps.Add(new Users());
			//apps.Add (new Broadcast ());
			//sec.str = "string set";
			// Set our view from the "main" layout resource


			StartActivity (typeof(Login));
			// Get our button from the layout resource,
			// and attach an event to it
			/*Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};*/
		
		}
	}
	public class SystemCore
	{
		private Security sec;
		public static SystemCore _sys;
		private Activity cur;
		public static SystemCore Instance(Activity act)
		{
			if (_sys==null) _sys = new SystemCore();
			_sys.setCurrentActivity (act);
			return _sys;
		}
		private SystemCore()
		{
			sec = Security.Instance ();
		}
		public void setCurrentActivity(Activity act=null)
		{
			cur = act;
			if (cur != null)
			{
				try
				{
					cur.GetType ();
				}
				catch(AccessViolationException ex) {
					cur = null;
				}
				catch(Exception ex){
					cur = null;
				}
			}
		}
		public void MakeToast(string toast)
		{
			if (cur == null)
				return;
			Toast.MakeText (cur, toast, ToastLength.Long).Show ();
		}
	}
}



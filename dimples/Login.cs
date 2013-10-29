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
	[Activity (Label = "Login")]			
	public class Login : Activity
	{
		
		const bool PASS=true;
		const bool FAIL=false;
		public static Security sec;
		private SystemCore sys;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Login);
			sec = Security.Instance();
			sys = SystemCore.Instance (this);
			//sys.MakeToast ("toast");
			// Create your application here
			Button button = FindViewById<Button> (Resource.Id.sign_in);
			button.Click += delegate {
				EditText uname = FindViewById<EditText>(Resource.Id.uname);
				EditText pwd= FindViewById<EditText>(Resource.Id.pwd);

				if (FirstCheckUser(uname.Text,pwd.Text)==PASS)
				{
					sec.login(uname.Text,pwd.Text).ContinueWith(r=>{
						StartActivity(typeof(Profile));
					} );
				}
			};
			TextView createLink = FindViewById<TextView> (Resource.Id.create_user);
			createLink.Click += delegate {
				EditText uname = FindViewById<EditText>(Resource.Id.uname);
				EditText pwd= FindViewById<EditText>(Resource.Id.pwd);

				if (FirstCheckUser(uname.Text,pwd.Text)==PASS)
				{
					sec.create_user(uname.Text,pwd.Text);
				}
			};
		}
		private bool FirstCheckUser(string uname, string pwd)
		{
			string msg=string.Empty;
			if (uname==string.Empty) msg+="enter a username\n";
			if (pwd==string.Empty) msg+="enter a password\n";
			if (msg!=string.Empty)
			{
				Toast.MakeText(this,msg,ToastLength.Long).Show();
				return FAIL;
			}
			return PASS;
		}
	}
}


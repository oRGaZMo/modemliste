using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace modemlist
{
	[Activity (Label = "modemlist", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		TableLogic RI;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestedOrientation=Android.Content.PM.ScreenOrientation.Landscape;
			RequestedOrientation=Android.Content.PM.ScreenOrientation.Locked;

			RI = new TableLogic ();
		
			SetContentView (Resource.Layout.Main);

			ActionBar.SetCustomView (Resource.Layout.CustomActionBar);
			ActionBar.SetDisplayShowCustomEnabled (true);

			// buttons initialisieren
			#region BUTTONVALIUM
			RI.button1 = FindViewById<Button> (Resource.Id.button1);
			RI.button2 = FindViewById<Button> (Resource.Id.button2);
			RI.button3 = FindViewById<Button> (Resource.Id.button3);
			RI.button4 = FindViewById<Button> (Resource.Id.button4);
			RI.button10= FindViewById<Button> (Resource.Id.button10);
			RI.button11= FindViewById<Button> (Resource.Id.button11);
			RI.button12= FindViewById<Button> (Resource.Id.button12);
			RI.button20= FindViewById<Button> (Resource.Id.button20);
			RI.button21= FindViewById<Button> (Resource.Id.button21);
			RI.button22= FindViewById<Button> (Resource.Id.button22);
			RI.button30= FindViewById<Button> (Resource.Id.button30);
			RI.button31= FindViewById<Button> (Resource.Id.button31);
			RI.button32= FindViewById<Button> (Resource.Id.button32);
			RI.button40= FindViewById<Button> (Resource.Id.button40);
			RI.button41= FindViewById<Button> (Resource.Id.button41);
			RI.button42= FindViewById<Button> (Resource.Id.button42);
			RI.button50= FindViewById<Button> (Resource.Id.button50);
			RI.button51= FindViewById<Button> (Resource.Id.button51);
			#endregion

			RI.blistErstellen ();
			RI.ModemsInstanzieren ();
		}
	}
}



using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace modemlist
{
	[Activity (Label = "modemlist",ConfigurationChanges=Android.Content.PM.ConfigChanges.Orientation|Android.Content.PM.ConfigChanges.ScreenSize, MainLauncher = true, Icon = "@drawable/icon")]
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

			ActionBar.Hide();
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

			RI.LL = FindViewById<LinearLayout> (Resource.Id.linearLayout2);
			RI.TL = FindViewById<TableLayout> (Resource.Id.tableLayout1);

			RI.CreateButtonList ();
			RI.ModemsInstanzieren ();

			RI.button2.Click += ScreenshotTest;
		}

		void ScreenshotTest(object sender,EventArgs EventArgs)
		{
			Android.Graphics.Bitmap b = Android.Graphics.Bitmap.CreateBitmap(RI.TL.Width,RI.TL.Height,Android.Graphics.Bitmap.Config.Argb8888);
			Android.Graphics.Canvas c = new Android.Graphics.Canvas (b);
			c.DrawColor (Android.Graphics.Color.White);
			RI.TL.Draw(c);

			using (System.IO.FileStream fs = new System.IO.FileStream (
				"/sdcard/screen.png", System.IO.FileMode.Create)) {
				b.Compress (Android.Graphics.Bitmap.CompressFormat.Png, 90, fs);}
			
			var uri = Android.Net.Uri.FromFile (new Java.IO.File("/sdcard/screen.png"));
			var email = new Intent (Android.Content.Intent.ActionSend);
			email.SetType ("message/rfc822");
			email.PutExtra (Android.Content.Intent.ExtraEmail, new string[]{"person1@xamarin.com"} );
			email.PutExtra (Android.Content.Intent.ExtraCc,	new string[]{"person3@xamarin.com"} );
			email.PutExtra (Android.Content.Intent.ExtraSubject, "[ModemListe]");
			email.PutExtra (Android.Content.Intent.ExtraText, "Hello from Xamarin.Android");	
			email.PutExtra (Intent.ExtraStream,uri);
			StartActivity (Intent.CreateChooser(email,"send"));

		}
		public override void OnContentChanged ()
		{
			base.OnContentChanged ();
			RequestedOrientation=Android.Content.PM.ScreenOrientation.Landscape;
			RequestedOrientation=Android.Content.PM.ScreenOrientation.Locked;
		}


		protected override void OnResume ()
		{
			base.OnResume ();
			RequestedOrientation=Android.Content.PM.ScreenOrientation.Landscape;
			RequestedOrientation=Android.Content.PM.ScreenOrientation.Locked;
			try {
				RI.ButtonValuesRefresh();} 
			catch (Exception ex) {
				Console.Write (ex.StackTrace);}
		}


	}
}



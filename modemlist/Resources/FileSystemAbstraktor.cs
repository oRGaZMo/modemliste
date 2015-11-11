using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;


namespace modemlist
{

	/// <summary>
	/// FileSystemAbstraktor
	/// </summary>
	public static class FSA
	{
		static string ExtérnalStoragePath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

		static string datafile		= Path.Combine (ExtérnalStoragePath, "datafile.txt");
		static string logfile		= Path.Combine (ExtérnalStoragePath, "logfile.txt");
		static string settingsfile	= Path.Combine (ExtérnalStoragePath, "settingsfile.txt");
		static string notefile		= Path.Combine (ExtérnalStoragePath, "notefile.txt");
		public static string screenfile	= Path.Combine (ExtérnalStoragePath, "screenfile.png");

		public static void Data2File(string[] dataarray)
		{
			try{
				File.WriteAllLines(datafile,dataarray);}
			catch(Exception e){
				Console.WriteLine (e.StackTrace);
			}
		}
		public static void Log2File(string logfile)
		{

		}
		public static void Settings2File(string settings)
		{

		}
		public static void Note2File(string note)
		{

		}
		public static void Screen2File(Android.Graphics.Bitmap b)
		{
			try{
				using(FileStream fs=new FileStream(screenfile,FileMode.Create)){
					b.Compress(Android.Graphics.Bitmap.CompressFormat.Png,90,fs);
					Console.WriteLine(screenfile);
				}
			}catch(Exception e){Console.Write (e.StackTrace);}

		}


		//=========================================// READ OUT //========================================//

		//Buttonvalues als int array aus dem permanenten speicher ausgeben;
		public static int[] File2Data ()
		{
			//leere Arrays erstellen
			int[] 		ia = new int[14]; 
			string[] 	sa = new string[]{""};
			//auslesen des STRING Array aus File
			try{
				sa = File.ReadAllLines(datafile);}
			catch(Exception e){
				Console.WriteLine (e.StackTrace);			}
			//längenvergleich der arrays und bei gleichheit conversion der strings in int
			if (ia.Length == sa.Length) {
				for (int i = 0; i < sa.Length; i++)
					ia [i] = Convert.ToInt32 (sa [i]);			}

			return ia;
		}


		public static string File2Log ()
		{
			return "";
		}
		public static string Settings2File ()
		{
			return "";
		}
		public static string File2Note ()
		{
			return "";
		}
		public static string File2Screen ()
		{
			return "";
		}
	}

}


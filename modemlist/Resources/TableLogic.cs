using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace modemlist
	{
		/*BUTTONS
	 *
	 *1 TABLE
	 *2 LOG
	 *3 SEND
	 *4 SETUP
	 *
	 *10 11 12 		D2  FZ  SK  BI
	 *20 21 22		D3  FZ  SK  BI
	 *30 31 32	 	HB2 FZ  SK  BI
	 *40 41 42 		HB3 FZ  SK  BI
	 *50 51			13-69   20-69
	 *
	 *
	 */		//they are everywhere

		public class TableLogic
		{

			D2 d2;
			D3 d3;
			HB2 hb2;
			HB3 hb3;
			Amp13 amp13;
			Amp20 amp20;


			// ModemKlassen Instanzieren und mit werten aus permanentem speicher füllen
			public void ModemsInstanzieren()
			{
				/*
			* BUTTONS D2
			* 10C Fahrzeug.ADD 		<--ok
			* 10LC Fahrzeug_SUB, 		<--ok
			* BUTTON 
			* 11C VerbrauchSK_ADD		<--ok
			* 11LC VerbrauchSK_SUB, 	<--ok
			* BUTTON 
			* 12C VerbrauchBI_ADD
			* 12LC VerbrauchBI_SUB,
			*/
				d2 = new D2 ();
				/*
			* BUTTONS D3
			* 20C Fahrzeug.ADD			<--ok
			* 20LC Fahrzeug_SUB			<--ok
			* 21C VerbrauchSK_ADD		<--ok
			* 21LC VerbrauchSK_SUB, 	<--ok
			* 22C VerbrauchBI_ADD		<--ok
			* 22LC VerbrauchBI_SUB,		<--ok
			*/
				d3 = new D3 ();
				/*
			* BUTTONS HB2
			* 30LC Fahrzeug_SUB			<--ok
			* 31LC VerbrauchSK_SUB, 	<--ok
			* 32LC VerbrauchBI_SUB,		<--ok
			* 30C Fahrzeug.ADD			<--ok
			* 31C VerbrauchSK_ADD		<--ok
			* 32C VerbrauchBI_ADD		<--ok	
			*/
				hb2 = new HB2 ();
				/*
			* BUTTONS HB2
			* 40LC Fahrzeug_SUB			<--ok
			* 41LC VerbrauchSK_SUB, 	<--ok
			* 42LC VerbrauchBI_SUB,		<--ok
			* 40C Fahrzeug.ADD			<--ok
			* 41C VerbrauchSK_ADD		<--ok
			* 42C VerbrauchBI_ADD		<--ok	
			*/
				hb3 = new HB3 ();
				amp13 = new Amp13 ();
				amp20 = new Amp20 ();

				int[] ia = FSA.File2Data ();

				d2.Fahrzeug = ia [0];
				d2.VerbrauchSK= ia [1];
				d2.VerbrauchBI= ia [2];
				d3.Fahrzeug= ia [3];
				d3.VerbrauchSK= ia [4];
				d3.VerbrauchBI= ia [5];
				hb2.Fahrzeug= ia [6];
				hb2.VerbrauchSK= ia [7];
				hb2.VerbrauchBI= ia [8];
				hb3.Fahrzeug= ia [9];
				hb3.VerbrauchSK= ia [10];
				hb3.VerbrauchBI= ia [11];
				amp13.Fahrzeug= ia [12];
				amp20.Fahrzeug= ia [13];
			}


			//BUTTON INITIALISIERUNGSZEUG
			#region BUTTON VALIUM
			public List<Button> blist;
			// MENU
			/*BUTTONS
	 	 *
	 	 *1 TABLE
	  	 *2 LOG
	     *3 SEND
	     *4 SETUP
	     */
			public Button button1;
			public Button button2;
			public Button button3;
			public Button button4;
			//MODEMS
			// 10 11 12 		D2  FZ  SK  BI
			public Button button10;
			public Button button11;
			public Button button12;
			// 20 21 22		D3  FZ  SK  BI
			public Button button20;
			public Button button21;
			public Button button22;
			// 30 31 32	 	HB2 FZ  SK  BI
			public Button button30;
			public Button button31;
			public Button button32;
			// 40 41 42 		HB3 FZ  SK  BI
			public Button button40;
			public Button button41;
			public Button button42;
			//AMPS
			//50 51			13-69   20-69
			public Button button50;
			public Button button51;
			/// <summary>
			/// Blists the erstellen.
			/// </summary>
			#endregion

			// Liste aller buttons generieren und zu EVENTS ANMELDEN
			public void blistErstellen()   
			{
				blist = new List<Button> ();
				blist.Add (button1);
				blist.Add (button2);
				blist.Add (button3);
				blist.Add (button4);
				blist.Add (button10);
				blist.Add (button11);
				blist.Add (button12);
				blist.Add (button20);
				blist.Add (button21);
				blist.Add (button22);
				blist.Add (button30);
				blist.Add (button31);
				blist.Add (button32);
				blist.Add (button40);
				blist.Add (button41);
				blist.Add (button42);
				blist.Add (button50);
				blist.Add (button51);


				foreach (Button b in blist) 
				{
					if (b != null) {
						b.Click += buttonOnClick;
						b.LongClick += buttonOnLongClick;
					}
				}
			}

			public void buttonOnClick(object sender, EventArgs EventArgs)
			{
				Button b = sender as Button;
				#region MENUBUTTONS
				if (b.Id == button1.Id)
					Console.WriteLine ("BUTTON 1");
				else if (b.Id == button2.Id)
					Console.WriteLine ("BUTTON 2");
				else if (b.Id == button3.Id)
					Console.WriteLine ("BUTTON 3");
				else if (b.Id == button4.Id)
					Console.WriteLine ("BUTTON 4");
				#endregion
				#region D2 BUTTONS
				else if (b.Id == button10.Id)
					d2.Fahrzeug_ADD ();
				//Console.WriteLine ("BUTTON 10");
				else if (b.Id == button11.Id)
					d2.VerbrauchSK_ADD ();
				//Console.WriteLine ("BUTTON 11");
				else if (b.Id == button12.Id)
					d2.VerbrauchBI_ADD ();
				//Console.WriteLine ("BUTTON 12");
				#endregion
				#region D3 BUTTOND
				else if (b.Id == button20.Id)
					d3.Fahrzeug_ADD ();
				//Console.WriteLine ("BUTTON 20");
				else if (b.Id == button21.Id)
					d3.VerbrauchSK_ADD ();
				//Console.WriteLine ("BUTTON 21");
				else if (b.Id == button22.Id)
					d3.VerbrauchBI_ADD ();
				//Console.WriteLine ("BUTTON 22");
				#endregion
				#region HB2 BUTTONS
				else if (b.Id == button30.Id)
					hb2.Fahrzeug_ADD ();
				//Console.WriteLine ("BUTTON 30");
				else if (b.Id == button31.Id)
					hb2.VerbrauchSK_ADD ();
				//Console.WriteLine ("BUTTON 31");
				else if (b.Id == button32.Id)
					hb2.VerbrauchBI_ADD ();
				//Console.WriteLine ("BUTTON 32");
				#endregion
				#region HB3 BUTTONS
				else if (b.Id == button40.Id)
					hb3.Fahrzeug_ADD ();
				//Console.WriteLine ("BUTTON 40");
				else if (b.Id == button41.Id)
					hb3.VerbrauchSK_ADD ();
				//Console.WriteLine ("BUTTON 41");
				else if (b.Id == button42.Id)
					hb3.VerbrauchBI_ADD ();
				//Console.WriteLine ("BUTTON 42");
				#endregion
				#region HB3 BUTTONS
				else if (b.Id == button50.Id)
					amp13.Fahrzeug_ADD ();
				//Console.WriteLine ("BUTTON 50");
				else if (b.Id==button51.Id)
					amp20.Fahrzeug_ADD ();
				//Console.WriteLine ("BUTTON 51");
				#endregion
				ButtonValuesRefresh ();
			}

			public void buttonOnLongClick(object sender, EventArgs EventArgs)
			{
				Button b = sender as Button;
				#region MENUBUTTONS
				if (b.Id == button1.Id)
					Console.WriteLine ("LONGBUTTON 1");
				else if (b.Id == button2.Id)
					Console.WriteLine ("LONGBUTTON 2");
				else if (b.Id == button3.Id)
					Console.WriteLine ("LONGBUTTON 3");
				else if (b.Id == button4.Id)
					Console.WriteLine ("LONGBUTTON 4");
				#endregion
				#region D2 BUTTONS
				else if (b.Id == button10.Id)
					d2.Fahrzeug_SUB ();
				//Console.WriteLine ("LONGBUTTON 10");
				else if (b.Id == button11.Id)
					d2.VerbrauchSK_SUB ();
				//Console.WriteLine ("LONGBUTTON 11");
				else if (b.Id == button12.Id)
					d2.VerbrauchBI_SUB ();
				//Console.WriteLine ("LONGBUTTON 12");
				#endregion
				#region D3 Buttons
				else if (b.Id == button20.Id)
					d3.Fahrzeug_SUB ();
				//Console.WriteLine ("LONGBUTTON 20");
				else if (b.Id == button21.Id)
					d3.VerbrauchSK_SUB ();
				//Console.WriteLine ("LONGBUTTON 21");
				else if (b.Id == button22.Id)
					d3.VerbrauchBI_SUB ();
				//Console.WriteLine ("LONGBUTTON 22");
				#endregion
				#region HB2 BUTTONS
				else if (b.Id==button30.Id)
					hb2.Fahrzeug_SUB();	
				//Console.WriteLine ("LONGBUTTON 30");
				else if (b.Id==button31.Id)
					hb2.VerbrauchSK_SUB();
				//Console.WriteLine ("LONGBUTTON 31");
				else if (b.Id==button32.Id)
					hb2.VerbrauchBI_SUB();
				//Console.WriteLine ("LONGBUTTON 32");
				#endregion
				#region HB3 BUTTONS
				else if (b.Id==button40.Id)
					hb3.Fahrzeug_SUB();	
				//Console.WriteLine ("LONGBUTTON 40");
				else if (b.Id==button41.Id)
					hb3.VerbrauchSK_SUB();
				//Console.WriteLine ("LONGBUTTON 41");
				else if (b.Id==button42.Id)
					hb3.VerbrauchBI_SUB();
				//Console.WriteLine ("LONGBUTTON 42");
				#endregion
				#region HB3 BUTTONS
				else if (b.Id==button50.Id)
					amp13.Fahrzeug_SUB ();
				//Console.WriteLine ("LONGBUTTON 50");
				else if (b.Id==button51.Id)
					amp20.Fahrzeug_SUB ();
				//Console.WriteLine ("LONGBUTTON 51");
				#endregion
				ButtonValuesRefresh ();
			}

			// Changes in den Modemklassen auf UI anzeigen (Buttonvalues aktualisieren)

			public void ButtonValuesRefresh()
			{			
				button10.Text = d2.Fahrzeug.ToString();
				button11.Text = d2.VerbrauchSK.ToString();
				button12.Text = d2.VerbrauchBI.ToString();
				button20.Text = d3.Fahrzeug.ToString();
				button21.Text = d3.VerbrauchSK.ToString();
				button22.Text = d3.VerbrauchBI.ToString();
				button30.Text = hb2.Fahrzeug.ToString();
				button31.Text = hb2.VerbrauchSK.ToString();
				button32.Text = hb2.VerbrauchBI.ToString();
				button40.Text = hb3.Fahrzeug.ToString();
				button41.Text = hb3.VerbrauchSK.ToString();
				button42.Text = hb3.VerbrauchBI.ToString();
				button50.Text = amp13.Fahrzeug.ToString();
			button51.Text = amp20.Fahrzeug.ToString ();

				// Writes Data to PesistentStorage
			FSA.Data2File (new string[] {
				button10.Text,
				button11.Text,
				button12.Text,
				button20.Text,
				button21.Text,
				button22.Text,
				button30.Text,
				button31.Text,
				button32.Text,
				button40.Text,
				button41.Text,
				button42.Text,
				button50.Text,
				button51.Text
			});

			}
		}
}


	/*
button1
button2
button3
button4
button1
button1
button1
button2
button2
button2
button3
button3
button3
button4
button4
button4
button5
button5

button1
button2
button3
button4
button10
button11
button12
button20
button21
button22
button30
button31
button32
button40
button41
button42
button50
button51
*/
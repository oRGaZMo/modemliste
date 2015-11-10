using System;

namespace modemlist
{
	public abstract class Modem
	{
		public int Fahrzeug{ get; set; }
		public int VerbrauchSK{ get; set; }
		public int VerbrauchBI{ get; set; }


		public void VerbrauchSK_ADD()
		{
			VerbrauchSK++;

			Console.WriteLine("Verbrauch SK: " + VerbrauchSK);		//DEBUG ONLY

			if(Fahrzeug>=1)
				Fahrzeug--;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);		//DEBUG ONLY
		}
		public void VerbrauchSK_SUB()
		{
			VerbrauchSK--;
			Console.WriteLine("Verbrauch SK: " + VerbrauchSK);		//DEBUG ONLY

			Fahrzeug++;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);			//DEBUG ONLY
		}
		public void VerbrauchBI_ADD()
		{
			VerbrauchBI++;
			Console.WriteLine("Verbrauch BI: " + VerbrauchBI);		//DEBUG ONLY

			if(Fahrzeug>=1)
				Fahrzeug--;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);			//DEBUG ONLY
		}
		public void VerbrauchBI_SUB()
		{
			VerbrauchBI--;
			Console.WriteLine("Verbrauch BI: " + VerbrauchBI);			//DEBUG ONLY

			Fahrzeug++;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);			//DEBUG ONLY
		}
		public void Fahrzeug_ADD()
		{
			Fahrzeug++;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);			//DEBUG ONLY
		}
		public void Fahrzeug_SUB()
		{
			if(Fahrzeug>=1)
				Fahrzeug--;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);		//DEBUG ONLY
		}
	}
	public abstract class Amp
	{
		public int Fahrzeug{ get; set; }

		public void Fahrzeug_ADD()
		{
			Fahrzeug++;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);			//DEBUG ONLY
		}
		public void Fahrzeug_SUB()
		{
			if(Fahrzeug>=1)
				Fahrzeug--;

			Console.WriteLine("Fahrzeug: " + Fahrzeug);		//DEBUG ONLY
		}
	}

	public class D2:Modem
	{
		public D2 ()
		{
			Fahrzeug = 0;
			VerbrauchSK = 0;
			VerbrauchBI = 0;
		}
	}
	public class D3:Modem
	{
		public D3 ()
		{
			Fahrzeug = 0;
			VerbrauchSK = 0;
			VerbrauchBI = 0;
		}
	}
	public class HB2:Modem
	{
		public HB2 ()
		{
			Fahrzeug = 0;
			VerbrauchSK = 0;
			VerbrauchBI = 0;
		}
	}
	public class HB3:Modem
	{
		public HB3 ()
		{
			Fahrzeug = 0;
			VerbrauchSK = 0;
			VerbrauchBI = 0;
		}
	}
	public class Amp13:Amp
	{
		public Amp13 ()
		{
			Fahrzeug = 0;
		}
	}
	public class Amp20:Amp
	{
		public Amp20 ()
		{
			Fahrzeug = 0;
		}
	}
}


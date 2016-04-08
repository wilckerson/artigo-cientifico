using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace ArtigoCientifico
{
	public partial class Computation : ContentPage
	{
		public Computation ()
		{
			InitializeComponent ();
		}

		async void OnClickBtn (object sender, EventArgs e)
		{

			lblElapsedTime.Text = "Calculating...";
			lblResult.Text = "";
			var startTime = DateTime.Now;

			string result = null;
			await Task.Run (() => {
				result = CalculatePiSpigotAlgorithm (1000);
			});

			var finishTime = DateTime.Now;
			var elapsedTime = (finishTime - startTime).TotalMilliseconds;

			lblElapsedTime.Text = string.Format ("Elapsed time: {0}ms", elapsedTime);
			lblResult.Text = string.Format ("Pi result: {0}", result);
		}

		string CalculatePiSpigotAlgorithm(int digits){
			string result = "";
			digits++;

			uint[] x = new uint[digits*3+2];
			uint[] r = new uint[digits*3+2];

			for (int j = 0; j < x.Length; j++)
				x[j] = 20;

			for (int i = 0; i < digits; i++)
			{
				uint carry = 0;
				for (int j = 0; j < x.Length; j++)
				{
					uint num = (uint)(x.Length - j - 1);
					uint dem = num * 2 + 1;

					x[j] += carry;

					uint q = x[j] / dem;
					r[j] = x[j] % dem;

					carry = q * num;
				}
				if(i<digits-1)
					result += (x[x.Length-1] / 10).ToString();
				r[x.Length - 1] = x[x.Length - 1] % 10; ;
				for (int j = 0; j < x.Length; j++)
					x[j] = r[j] * 10;
			}

			return result;
		}
	}
}


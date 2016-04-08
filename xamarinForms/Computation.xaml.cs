using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Text;

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
			
			StringBuilder pi = new StringBuilder(digits);
			String[] zero = { "0", "00", "000" };
			int d = 0, e, b, g, r;
			int c = (digits / 4 + 1) * 14;
			int[] a = new int[c];
			int f = 10000;

			for (int i = 0; i < c; i++) {
				a [i] = 20000000;
			}

			while ((b = c -= 14) > 0)
			{
				d = e = d % f;

				while (--b > 0)
				{
					d = d * b + a[b];
					g = (b << 1) - 1;
					a[b] = (d % g) * f;
					d /= g;
				}

				r = e + d / f;

				if (r < 1000)
				{
					pi.Append(zero[r > 99 ? 0 : r > 9 ? 1 : 2]);
				}
				pi.Append(r);
			}
			return pi.ToString();
		}

	}
}


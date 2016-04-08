using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace ArtigoCientifico
{
	
	public partial class WebRequest : ContentPage
	{
		public static IWebRequestService webRequestService;

		public WebRequest ()
		{
			InitializeComponent ();
		}

		async void OnClickBtn (object sender, EventArgs e)
		{

			lblElapsedTime.Text = "Requesting...";

			var startTime = DateTime.Now;
			string url = "https://api.github.com/users/xamarin/repos";

			var responseStream = await webRequestService.Get (url);
					
			var finishTime = DateTime.Now;
			var elapsedTime = (finishTime - startTime).TotalMilliseconds;

			lblElapsedTime.Text = string.Format ("Elapsed time: {0:0.00000}ms", elapsedTime);

			StreamReader reader = new StreamReader (responseStream);
			string strResponse = reader.ReadToEnd ();
			Debug.WriteLine (strResponse);

		}
	}
}


using System;
using System.Net;

namespace ArtigoCientifico.iOS
{
	public class WebRequestService : IWebRequestService
	{
		public WebRequestService ()
		{
		}

		#region IWebRequestService implementation

		public async System.Threading.Tasks.Task<System.IO.Stream> Get (string url)
		{
			HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create (url);
			request.Method = "GET";  
			//request.Accept = "*/*";
			request.UserAgent = "Xamarin.Forms.iOS"; 
			var response = await request.GetResponseAsync();
			return response.GetResponseStream();
		}

		#endregion
	}
}


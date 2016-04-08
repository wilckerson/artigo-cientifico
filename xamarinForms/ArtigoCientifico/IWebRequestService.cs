
using System;
using System.Threading.Tasks;
using System.IO;

public interface IWebRequestService{

	Task<Stream> Get(string url);

}
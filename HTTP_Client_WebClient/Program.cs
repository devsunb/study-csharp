using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Client_WebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string resText = wc.DownloadString("http://www.naver.com");
            Console.WriteLine(resText);
        }
    }
}

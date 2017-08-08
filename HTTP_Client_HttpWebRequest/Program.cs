using System;
using System.IO;
using System.Net;

namespace HTTP_Client_HttpWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest req = WebRequest.Create("http://www.naver.com") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                string resText = sr.ReadToEnd();
                Console.WriteLine(resText);
            }
        }
    }
}

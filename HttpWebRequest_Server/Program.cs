using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebRequest_Server
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

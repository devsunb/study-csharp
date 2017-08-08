using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8000);

                socket.Bind(endPoint);
                socket.Listen(10);

                Console.WriteLine("HTTP Web Server Opened at " + socket.LocalEndPoint + "!");

                while (true)
                {
                    Socket clntSocket = socket.Accept();
                    Console.WriteLine("Client [" + clntSocket.RemoteEndPoint + "] Requested!");
                    ThreadPool.QueueUserWorkItem(httpProcessFunc, clntSocket);
                }
            }
        }

        private static void httpProcessFunc(object state)
        {
            Socket socket = state as Socket;

            byte[] recvBytes = new byte[4096];
            socket.Receive(recvBytes);

            string header = "HTTP/1.0 200 OK\nContent-Type: text/html; charset=UTF-8\r\n\r\n";
            string sendtxt = "<html><body><h1>Hello, World!</h1></body></html>";
            byte[] sendBytes = Encoding.UTF8.GetBytes(header + sendtxt);

            socket.Send(sendBytes);

            socket.Close();
        }
    }
}

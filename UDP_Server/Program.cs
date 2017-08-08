using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9000);

            srvSocket.Bind(endPoint);

            byte[] recvBytes = new byte[1024];
            EndPoint clientEP = new IPEndPoint(IPAddress.None, 0);

            while (true)
            {
                int nRecv = srvSocket.ReceiveFrom(recvBytes, ref clientEP);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);
                Console.WriteLine("Client [" + clientEP.ToString() + "] : " + txt);

                byte[] sendBytes = Encoding.UTF8.GetBytes("Hello : " + txt);
                srvSocket.SendTo(sendBytes, clientEP);
            }
        }
    }
}

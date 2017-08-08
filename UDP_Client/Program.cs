using System;
<<<<<<< HEAD
using System.Text;
using System.Net;
using System.Net.Sockets;
=======
>>>>>>> cdaa176958055a4255c3c7df3bc1e898519e31af

namespace UDP_Client
{
    class MainClass
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint serverEP = new IPEndPoint(IPAddress.Parse("192.168.1.100"), 9000);
            EndPoint senderEP = new IPEndPoint(IPAddress.None, 0);

            int nTimes = 5;

            while (nTimes-- > 0)
            {
                byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                socket.SendTo(buf, serverEP);
                
                byte[] recvBytes = new byte[1024];
                int nRecv = socket.ReceiveFrom(recvBytes, ref senderEP);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                Console.WriteLine(txt);
            }

            socket.Close();
            Console.WriteLine("UDP Client Socket: Closed!");
            Console.ReadLine();
=======
            Console.WriteLine("Hello World!");
>>>>>>> cdaa176958055a4255c3c7df3bc1e898519e31af
        }
    }
}

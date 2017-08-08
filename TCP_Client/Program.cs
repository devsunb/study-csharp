using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_Client
{
    public class AsyncStateData
    {
        public byte[] Data;
        public Socket Socket;
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_LENGTH = 1024;

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                EndPoint serverEP = new IPEndPoint(IPAddress.Parse("192.168.1.100"), 9000);
                socket.Connect(serverEP);

                while (true)
                {
                    byte[] buf = new byte[MAX_LENGTH];
                    Console.Write("전송할 문자열 : ");
                    string sendtxt = Console.ReadLine();
                    if (sendtxt == "exit" || sendtxt.Length >= MAX_LENGTH) break;
                    buf = Encoding.UTF8.GetBytes(sendtxt);

                    try
                    {
                        socket.Send(buf);
                    }
                    catch (SocketException e)
                    {
                        socket.Close();
                        Console.WriteLine(e.ToString());
                    }

                    try
                    {
                        byte[] recvBytes = new byte[MAX_LENGTH];
                        int nRecv = socket.Receive(recvBytes);
                        string recvtxt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);
                        Console.WriteLine("Server : " + recvtxt);
                    }
                    catch (SocketException e)
                    {
                        socket.Close();
                        Console.WriteLine(e.ToString());
                    }
                }
            }

            Console.WriteLine("TCP Client Socket : Closed!");
            Console.ReadLine();
        }
    }
}

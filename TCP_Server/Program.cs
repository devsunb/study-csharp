using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCP_Server
{
    public class AsyncStateData
    {
        public byte[] Buffer;
        public Socket Socket;
    }

    class Program
    {
        const int MAX_LENGTH = 1024;

        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9000);
                socket.Bind(endPoint);
                socket.Listen(10);

                while (true)
                {
                    try
                    {
                        Socket clntSocket = socket.Accept();
                        Console.WriteLine("Client [" + clntSocket.RemoteEndPoint + "] Connected");
                        try
                        {
                            AsyncStateData data = new AsyncStateData();
                            data.Buffer = new byte[MAX_LENGTH];
                            data.Socket = clntSocket;
                            clntSocket.BeginReceive(data.Buffer, 0, data.Buffer.Length, SocketFlags.None, asyncReceiveCallback, data);
                        }
                        catch (SocketException e)
                        {
                            alertClosed(clntSocket);
                            clntSocket.Close();
                        }
                    }
                    catch(SocketException)
                    {
                        Console.WriteLine("Accept Error");
                    }
                }
            }
        }

        private static void asyncReceiveCallback(IAsyncResult asyncResult)
        {
            AsyncStateData recvData = asyncResult.AsyncState as AsyncStateData;
            try
            {
                int nRecv = recvData.Socket.EndReceive(asyncResult);
                string txt = Encoding.UTF8.GetString(recvData.Buffer, 0, nRecv);

                if (txt != "")
                    Console.WriteLine("Client [" + recvData.Socket.RemoteEndPoint + "] : " + txt);

                byte[] sendBytes = Encoding.UTF8.GetBytes("Hello : " + txt);
                recvData.Socket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, asyncSendCallback, recvData.Socket);
            }
            catch (SocketException e)
            {
                alertClosed(recvData.Socket);
                recvData.Socket.Close();
            }
        }

        private static void asyncSendCallback(IAsyncResult asyncResult)
        {
            Socket socket = asyncResult.AsyncState as Socket;
            try
            {
                socket.EndSend(asyncResult);

                AsyncStateData data = new AsyncStateData();
                data.Buffer = new byte[MAX_LENGTH];
                data.Socket = socket;
                socket.BeginReceive(data.Buffer, 0, data.Buffer.Length, SocketFlags.None, asyncReceiveCallback, data);
            }
            catch (SocketException e)
            {
                alertClosed(socket);
                socket.Close();
            }
        }

        private static void alertClosed(Socket socket)
        {
            Console.WriteLine("Client [" + socket.RemoteEndPoint + "] Closed!");
        }
    }
}

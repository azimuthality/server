using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;


namespace HTTPServer
{
    public class Server
    {
 
            TcpListener Listener;
            public Server(int Port)
            {
                Listener = new TcpListener(IPAddress.Any, Port);
                Listener.Start();
                while (true)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), Listener.AcceptTcpClient());

                }
            }
            static void ClientThread(Object StateInfo)
            {
                new Client((TcpClient)StateInfo);
            }
            ~Server()
            {
                if (Listener != null)
                {
                    Listener.Stop();
                }               
            }
        }
    
}

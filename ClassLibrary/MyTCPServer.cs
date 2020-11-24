using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace ClassLibrary
{
    public class MyTCPServer
    {
        TcpListener MyListener;
        TcpClient MyClient;
        NetworkStream stream;
        IPAddress ip;
        int port;

        #region getters&setters
        public TcpListener Listener { get => MyListener; set => MyListener = value; }
        public TcpClient TcpClient { get => MyClient; set => MyClient = value; }
        protected NetworkStream Stream { get => stream; set => stream = value; }
        public IPAddress IP { get => ip; set => ip = value; }
        public int Port { get => port; set => port = value; }
        #endregion getters&setters


        public MyTCPServer(IPAddress ip, int port)
        {
            IP = ip;
            Port = port;
            Listener = new TcpListener(ip, port);
        }

        public bool CheckIfPalindrome(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                char c2 = str[str.Length - 1 - i];
                if (c != c2)
                    return false;
                if (i == str.Length - 1)
                    return true;                
            }
            return true;
        }

        public delegate void TransmissionDataDelegate(NetworkStream stream);

        protected void StartListening()
        {
            Listener = new TcpListener(ip, Port);
            Listener.Start();
        }

        protected void AcceptClient()
        {
            while (true)
            {
                TcpClient tcpClient = MyListener.AcceptTcpClient();

                Stream = tcpClient.GetStream();

                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);

                transmissionDelegate.BeginInvoke(Stream, TransmissionCallback, tcpClient);                
            }
        }
        protected void BeginDataTransmission(NetworkStream stream)
        {
            while (true)
            {                
                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, 1024);
                String word = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                if (CheckIfPalindrome(word))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
                if (word == "quit")
                    break;
            }            
        }
        private void TransmissionCallback(IAsyncResult ar)
        {
            TcpClient client = (TcpClient)ar.AsyncState;
            client.Close();
        }

        public void Start()

        {
            StartListening();
            AcceptClient();
        }




    }
}

﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ClassLibrary;

class Program
    {
        public static void Main(string[] args)
        {
            Server server = new Server(IPAddress.Parse("127.0.0.1"),2048);
            server.Start();
        }
    }


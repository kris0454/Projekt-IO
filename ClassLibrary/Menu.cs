using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ClassLibrary
{
    class Menu
    {
        public void BeginDataTransmission(NetworkStream stream)
        {
            Functions functions = new Functions();


            byte[] welcome = new byte[1024];
            String hello = "Jeśli chcesz sprawdzić czy słowo jest palindromem wpisz a, zeby sprawdzić czy słowo jest anagramem wpisz b" + Environment.NewLine;
            welcome = Encoding.ASCII.GetBytes(hello);
            stream.Write(welcome, 0, welcome.Length);

            while (true)
            {
                if (stream.DataAvailable)
                {
                    stream.Write(welcome, 0, welcome.Length);
                }

                byte[] buffer = new byte[1024];
                stream.Read(buffer, 0, 1024);
                String choice = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                byte[] message = new byte[1024];

                if (choice == "a")
                {
                    String m1 = "podaj słowo" + Environment.NewLine;
                    message = Encoding.ASCII.GetBytes(m1);
                    stream.Write(message, 0, message.Length);
                    while (true)
                    {
                        byte[] palindrom = new byte[1024];
                        stream.Read(palindrom, 0, 1024);

                        String word = Encoding.UTF8.GetString(palindrom).TrimEnd('\0');

                        if (functions.CheckIfPalindrome(word))
                        {
                            Console.WriteLine("checking");
                            palindrom = Encoding.ASCII.GetBytes(word + Environment.NewLine);
                            stream.Write(palindrom, 0, palindrom.Length);

                            break;
                        }
                    }

                }
                if (choice == "b")
                {
                    String pattern;
                    String word2;
                    String m2 = "podaj wzor" + Environment.NewLine;
                    message = Encoding.ASCII.GetBytes(m2);
                    stream.Write(message, 0, message.Length);
                    while (true)
                    {
                        byte[] p = new byte[1024];
                        stream.Read(p, 0, 1024);
                        pattern = Encoding.UTF8.GetString(p).TrimEnd('\0');
                        if (pattern.Length > 3)
                            break;
                    }

                    String m3 = "podaj slowo do sprawdzenia" + Environment.NewLine;
                    message = Encoding.ASCII.GetBytes(m3);
                    stream.Write(message, 0, message.Length);

                    while (true)
                    {
                        byte[] w = new byte[1024];
                        stream.Read(w, 0, 1024);
                        word2 = Encoding.UTF8.GetString(w).TrimEnd('\0');
                        if (word2.Length > 2)
                            break;
                    }

                    String r;
                    byte[] result = new byte[1024];

                    Console.WriteLine(pattern.Length);
                    Console.WriteLine(word2.Length);
                    if (functions.CheckIfAnagram(pattern, word2))
                    {
                        r = word2 + " jest anagramem słowa " + pattern;
                    }
                    else
                    {
                        r = word2 + " nie jest anagramem słowa " + pattern;
                    }
                    result = Encoding.ASCII.GetBytes(r + Environment.NewLine);
                    stream.Write(result, 0, result.Length);
                    break;

                }
            }
        }


    }
}

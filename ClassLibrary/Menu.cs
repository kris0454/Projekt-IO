﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections;

namespace ClassLibrary
{
    class Menu
    {
        public void BeginDataTransmission(NetworkStream stream)
        {
            bool logged = false;
            Functions functions = new Functions();
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            StreamReader reader = new StreamReader(stream);

            do
            {
                writer.WriteLine("Podaj nazwe uzytkownika");
                //writer.Flush();
                String user = reader.ReadLine();

                writer.WriteLine("Podaj haslo");
                String password = reader.ReadLine();

                if (functions.LogIn(user, password))
                {
                    logged = true;
                }
                else
                {
                    writer.WriteLine("Bledne haslo lub uzytkownik");
                }
            } while (!logged);


            while (logged)
            {
                writer.WriteLine("Podaj swoje litery");
                String choice = reader.ReadLine();
                if (choice == "logout")
                {
                    writer.WriteLine("Zegnam");
                    Thread.Sleep(2000);
                    logged = false;
                }
                else
                {
                    ArrayList list = functions.findPossibleWords(choice);
                    list.Sort(Functions.sortVal());
                    foreach (Functions.Word w in list)
                    {
                        writer.WriteLine(w._word + ": " + w._val);
                    }
                }

                /*
                if (choice == "a")
                {
                    writer.WriteLine("podaj słowo");
                    String word = reader.ReadLine();
                    Console.WriteLine("checking");
                    if (functions.CheckIfPalindrome(word))
                    {
                       
                        writer.WriteLine(word + " jest palindromem");
                    }
                    else
                    {
                        writer.WriteLine(word + " nie jest palindromem");
                    }
                }

                if (choice == "b")
                {
                    writer.WriteLine("podaj wzor");
                    String pattern = reader.ReadLine();


                    writer.WriteLine("podaj slowo do sprawdzenia");
                    String word = reader.ReadLine();

                    if (functions.CheckIfAnagram(pattern, word))
                    {
                        writer.WriteLine(word + " jest anagramem słowa " + pattern);
                    }
                    else
                    {
                        writer.WriteLine(word + " nie jest anagramem słowa " + pattern);
                    }                   
                }
                if(choice=="logout")
                {
                    writer.WriteLine("Zegnam");
                    Thread.Sleep(2000);
                    logged = false;
                }*/
            }
        }
    }
}

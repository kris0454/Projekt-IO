using System;
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
                //writer.Flush();
                string temp = reader.ReadLine();
                int position = temp.IndexOf(";");
                String user = temp.Substring(0,position);
                Console.WriteLine("user: " + user);
                String password = temp.Substring(position + 1);
                Console.WriteLine("pass: " + password);

                if (functions.LogIn(user, password))
                {
                    logged = true;
                    writer.WriteLine("1");
                }
                else
                {
                    writer.WriteLine("0");
                }
            } while (!logged);


            while (logged)
            {
                String choice = reader.ReadLine();
                if (choice == "logout")
                {
                    Console.WriteLine("Logout");
                    //writer.WriteLine("Zegnam");
                    Thread.Sleep(2000);
                    logged = false;
                }
                else
                {
                    string temp = choice.Replace(", ", "");
                    Console.WriteLine(temp);
                    ArrayList list = functions.findPossibleWords(temp);
                    Console.WriteLine("test");
                    list.Sort(Functions.sortVal());
                    Console.WriteLine("test");
                    int i = 0;
                    foreach (Functions.Word w in list)
                    {
                        Console.WriteLine(i++);
                        writer.WriteLine(w._word + ": " + w._val);
                    }
                    writer.WriteLine("-");
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

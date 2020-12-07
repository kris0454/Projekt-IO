using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;



namespace ClassLibrary
{
    class Functions
    {
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

        
        public bool CheckIfAnagram(String pattern, String word)
        {
            if(pattern.Length != word.Length)
            {
                return false;
            }
            else
            {
                String canonicalFormPattern = String.Concat(pattern.OrderBy(c => c));
                String canonicalFormWord = String.Concat(pattern.OrderBy(c => c));
                if(canonicalFormPattern == canonicalFormWord)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LogIn(String login, String haslo)
        {            
            List<string> users = new List<string>();
            List<string> pass = new List<string>();

            StreamReader streamReader = new StreamReader("C:\\Users\\Piotrek\\Desktop\\STUDIA\\semestr5\\Inżynieria oprogramowania\\repos\\TCP server\\TCP server\\vars.txt");
            string line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                users.Add(components[0]);
                pass.Add(components[1]);
            }
            streamReader.Close();
            
            if (users.Contains(login) && pass.Contains(haslo) &&
                    Array.IndexOf(users.ToArray(), login) == Array.IndexOf(pass.ToArray(), haslo))
            {
                Console.WriteLine("Zalogowano");
                return true;
            }
            else
            {
                Console.WriteLine("Zly Login lub haslo!");
                return false;
            }
        }


    }
}

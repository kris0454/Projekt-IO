using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections;

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
            if (pattern.Length != word.Length)
            {
                return false;
            }
            else
            {
                String canonicalFormPattern = String.Concat(pattern.OrderBy(c => c));
                String canonicalFormWord = String.Concat(pattern.OrderBy(c => c));
                if (canonicalFormPattern == canonicalFormWord)
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

        String sort(String str)
        {
            char[] alfabet = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż' };

            char[] sorted = new char[str.Length];

            int k = 0;

            for (int j = 0; j < alfabet.Length; j++)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (alfabet[j] == str[i])
                    {
                        sorted[k] = str[i];
                        k++;
                    }
                }
            }

            return new String(sorted);
        }

        IDictionary<char, int> dictionary = new Dictionary<char, int>
        {
            //1 punkt: A (x9), E (x7), I (x8), N (x5), O (x6), R (x4), S (x4), W (x4), Z (x5)
            {'a',1}, {'e',1}, {'i',1}, {'n',1}, {'o',1}, {'r',1}, {'s',1}, {'w',1}, {'z',1},
            //2 punkty: C (x3), D (x3), K(x3), L(x3), M(x3), P (x3), T (x3), Y (x4)
            {'c',2}, {'d',2}, {'k',2}, {'l',2}, {'m',2}, {'p',2}, {'t',2}, {'y',2},
            //3 punkty: B (x2), G(x2), H(x2), J (x2), Ł (x2), U (x2)
            {'b',2}, {'g',2}, {'h',2}, {'j',2}, {'ł',2}, {'u',2},
            //5 punktów: Ą (x1), Ę (x1), F (x1), Ó (x1), Ś (x1), Ż (x1)
            {'ą',2}, {'ę',2}, {'f',2}, {'ó',2}, {'ś',2}, {'ż',2},

            {'ć',6}, {'ń',7}, {'ź',9}
        };

        int countWordVal(String str)
        {
            int val = 0;
            foreach (char c in str)
            {
                if (dictionary.ContainsKey(c))
                    val += dictionary[c];
                else
                    return 0;
            }
            return val;
        }

        public class Word
        {
            String word;
            String used;
            String notUsed;
            String needed;
            int val;
            public String _word { get => word; set => word = value; }
            public String _used { get => used; set => used = value; }
            public String _notUsed { get => notUsed; set => notUsed = value; }
            public String _needed { get => needed; set => needed = value; }
            public int _val { get => val; set => val = value; }

            public void print()
            {
                Console.WriteLine("słowo: " + this.word + " na planszy musisz znaleźć: " + this.needed);
                Console.WriteLine("litery użyte: " + this.used + " litery niepotrzebne: " + this.notUsed);
                Console.WriteLine();
            }
        }
        private class sortValDesc : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Word w1 = (Word)a;
                Word w2 = (Word)b;
                if (w1._val < w2._val)
                    return 1;
                if (w1._val > w2._val)
                    return -1;
                else
                    return 0;
            }
        }

        public static IComparer sortVal()
        {
            return (IComparer)new sortValDesc();
        }

        public ArrayList findPossibleWords(String letters)
        {
            StreamReader streamReader = new StreamReader("C:\\Users\\Piotrek\\Desktop\\STUDIA\\semestr5\\Inżynieria oprogramowania\\scrabble\\slowa.txt");
            char[] alfabet = { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'r', 's', 'ś', 't', 'u', 'w', 'y', 'z', 'ź', 'ż', '.' };
            ArrayList list = new ArrayList();

            while (streamReader.ReadLine() != null)
            {
                Word word = new Word();


                String dicWord = streamReader.ReadLine();
                String sortedLetters = sort(letters);
                String sortedDicWord = sort(dicWord);
                sortedLetters += ".";
                sortedDicWord += ".";
                String used = "";
                String notUsed = "";
                String needed = "";


                int i = 0;
                int j = 0;
                while (i < dicWord.Length)
                {
                    if (sortedLetters[j] == sortedDicWord[i])
                    {
                        if (sortedLetters[j] != '.')
                            used += sortedLetters[j];
                        j++;
                        i++;

                    }
                    if (Array.IndexOf(alfabet, sortedLetters[j]) < Array.IndexOf(alfabet, sortedDicWord[i]))
                    {
                        if (sortedLetters[j] != '.')
                            notUsed += sortedLetters[j];
                        j++;

                    }
                    else if (Array.IndexOf(alfabet, sortedLetters[j]) > Array.IndexOf(alfabet, sortedDicWord[i]))
                    {
                        if (sortedDicWord[i] != '.')
                            needed += sortedDicWord[i];
                        i++;
                    }
                }
                word._word = dicWord;
                word._used = used;
                word._notUsed = notUsed;
                word._needed = needed;
                word._val = countWordVal(dicWord);
                if (word._val > 0 && word._needed.Length < 1)
                    list.Add(word);
            }
            return list;
        }


    }
}

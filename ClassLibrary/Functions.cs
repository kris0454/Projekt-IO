using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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


    }
}

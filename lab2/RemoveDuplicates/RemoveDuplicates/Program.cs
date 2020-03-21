using System;
using System.Collections.Generic;

namespace RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage RemoveDuplicates.exe <input string>");
            }
            else
            {
                HashSet<char> setOfChar = new HashSet<char>();
                string inputStr = args[0];
                char tempCh;
                for (int i = 0; i < inputStr.Length; i++)
                {
                    tempCh = inputStr[i];
                    if (setOfChar.Contains(tempCh)){
                        inputStr = inputStr.Remove(i, 1);
                        i--;
                    }
                    else
                    {
                        setOfChar.Add(tempCh);
                    }
                }

                Console.WriteLine(inputStr);
            }
        }
    } 
}

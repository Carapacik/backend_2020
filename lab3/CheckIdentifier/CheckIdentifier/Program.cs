using System;

namespace CheckIdentifier
{
    public class Program
    {
        public static bool ParseArgs(string[] args, ref string inputStr)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("no");
                Console.WriteLine("Incorrect arguments count");
                Console.WriteLine("Usage CheckIdentifier.exe <input string>");
                return false;
            }
            inputStr = args[0];
            return true;
        }

        public static bool IsLetter(char character)
        {
			return (character >= 'A') && (character <= 'Z') || (character >= 'a') && (character <= 'z');
        }

        public static bool IsSymbolLetterOrDigit(string inputStr)
        {
            for (int i = 0; i < inputStr.Length; i++)
            {
                if (!(IsLetter(inputStr[i]) || char.IsDigit(inputStr[i])))
                {
                    return false;
                }
            }
            return true;
        }

        public static int CheckIdentifier(string inputStr)
        {
            if (inputStr == "")
            {
                Console.WriteLine("no");
                Console.WriteLine("The identifier can't be an empty string");
                return 1;
            }
            if (!IsLetter(inputStr[0]))
            {
                Console.WriteLine("no");
                Console.WriteLine("Identifier can't start with a digit.");
                return 1;
            }
            if (!IsSymbolLetterOrDigit(inputStr.Substring(1)))
            {
                Console.WriteLine("no");
                Console.WriteLine("The identifier must contain only numbers or letters.");
                return 1;
            }
            Console.WriteLine("yes");
            return 0;
        }

        public static int Main(string[] args)
        {
            string inputStr = "";
            if (!ParseArgs(args, ref inputStr))
            {
                return 1;
            }

            CheckIdentifier(inputStr);

            return 0;
        }
    }
}
using System;

namespace CheckIdentifier
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect arguments count");

                return 1;
            }
            else
            {
                string inputStr = args[0];
                if (inputStr.Length > 0)
                {
                    if (!IsNumber(inputStr[0]))
                    {
                        for (int i = 0; i < inputStr.Length; i++)
                        {
                            if (!IsNumber(inputStr[i]) && !IsLetter(inputStr[i]))
                            {
                                Console.WriteLine("No");
                                Console.WriteLine("The identifier must contain only numbers or letters.");

                                return 1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No");
                        Console.WriteLine("Identifier can't start with a digit.");

                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine("No");
                    Console.WriteLine("An empty string was passed.");

                    return 1;
                }

            }
            Console.WriteLine("yes");

            return 0;
        }

        public static bool IsNumber(char symbol)
        {
            return symbol >= '0' && symbol <= '9';
        }

        public static bool IsLetter(char symbol)
        {
            return (symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z');
        }
    }
}

using System;
using System.Text;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Transform("abbcbbb"));
        }

        public static string Transform(string input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
                if (input[i - 1] != input[i]) sb.Append(input[i]);

            return sb.ToString();
        }
    }
}
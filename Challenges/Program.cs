using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            string result = Run(1954);

            Console.WriteLine(result);
        }


        static public string Run(int n)
        {
            //
            // Write your code below; return type and arguments should be according to the problem's requirements
            //
            string roman = "";

            var romanDictionary = new Dictionary<int, string>(){
                { 0, "" },
                { 1, "I" },
                { 2, "II" },
                { 3, "III" },
                { 4, "IV" },
                { 5, "V" },
                { 6, "VI" },
                { 7, "VII" },
                { 8, "VIII" },
                { 9, "IX" },
                { 10, "X" },
                { 20, "XX" },
                { 30, "XXX" },
                { 40, "XL" },
                { 50, "L" },
                { 60, "LX" },
                { 70, "LXX" },
                { 80, "LXXX" },
                { 90, "XC" },
                { 100, "C" },
                { 200, "CC" },
                { 300, "CCC" },
                { 400, "CD" },
                { 500, "D" },
                { 600, "DC" },
                { 700, "DCC" },
                { 800, "DCCC" },
                { 900, "CM" },
                { 1000, "M" },
                { 2000, "MM" },
                { 3000, "MMM" },
                { 4000, "MMMM" },
                { 5000, "MMMMM" },
                { 6000, "MMMMMM" },
                { 7000, "MMMMMMM" },
                { 8000, "MMMMMMMM" },
                { 9000, "MMMMMMMMM" }
            };


            int[] tempInt = n.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
            string[] tempString = new string[tempInt.Length];
            for (int i = 0; i < tempString.Length; i++)
            {
                tempString[i] = tempInt[i].ToString();
            }

            Array.Reverse(tempString);

            if (tempString.Length == 4) roman += romanDictionary[int.Parse(tempString[3])*1000];
            if (tempString.Length >= 3) roman += romanDictionary[int.Parse(tempString[2])*100];
            if (tempString.Length >= 2) roman += romanDictionary[int.Parse(tempString[1])*10];
            if (tempString.Length >= 1) roman += romanDictionary[int.Parse(tempString[0])];

            return roman;
        }
    }
}
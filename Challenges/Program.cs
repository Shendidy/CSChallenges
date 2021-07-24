using System;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // This repo has a separate branch for each challenge, and master will remain just a starting template for new challenges.
            // To start a new challenge, just checkout a new branch with the name you want to give that challenge, then work there.
            Console.WriteLine(Solution.Run(100000001));
        }
    }
}

public class Solution
{
    static public bool Run(int number)
    {
        //
        // Write your code below; return type and arguments should be according to the problem's requirements
        //
        if (number < 1 || number > 100000000) return false;

        var counter = 0;
        for(int i = 2; counter < 2 && i*i <= number; i++)
            while(number % i == 0)
            {
                number = number / i;
                counter++;
            }

        return number > 1 ? counter == 1 : counter == 2;
    }
}
using System;
using System.Linq;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // This repo has a separate branch for each challenge, and master will remain just a starting template for new challenges.
            // To start a new challenge, just checkout a new branch with the name you want to give that challenge, then work there.
            Console.WriteLine(Solution.Run(new int[] { 2, 4, 5, 4, 2, 5, 6, 8, 7, 7, 9, 8 }));
        }
    }

    public class Solution
    {
        static public int Run(int[] student_list)
        {
            //
            // Write your code below; return type and arguments should be according to the problem's requirements
            //
            Array.Sort(student_list);
            for (int i = 1; i < student_list.Length; i++)
                if (student_list[i - 1] != student_list[i]) return student_list[i - 1];
                else i++;

            return student_list.Last();
        }
    }
}
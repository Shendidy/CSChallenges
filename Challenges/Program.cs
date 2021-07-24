using System;
using System.Text;
using System.Linq;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // This repo has a separate branch for each challenge, and master will remain just a starting template for new challenges.
            // To start a new challenge, just checkout a new branch with the name you want to give that challenge, then work there.
            Console.WriteLine(Solution.run("The iterator is just clutter"));
        }
    }

    public class Solution
    {

        public static String run(String p)
        {
            /*
            * Write your code below; return type and arguments should be according to the problem's requirements
            */


            StringBuilder sb = new();

            sb.Append($"{CountVouls(p)[0]} {CountVouls(p)[1]}::");
            sb.Append($"{ InvertCase(ReverseWordsOrder(p))}::");
            sb.Append($"{ p.Replace(' ', '-') }::");
            sb.Append(IdentifyVowels(p));

            return sb.ToString();
        }

        private static int[] CountVouls(string p)
        {
            p = p.ToLower();
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            int counterV = 0;
            int counterC = 0;
            foreach (var character in p.ToCharArray())
                if (vowels.Contains(character)) counterV++;
                else if (character != ' ') counterC++;

            return new int[] { counterV, counterC };
        }

        private static string InvertCase(string p)
        {
            StringBuilder sb = new();

            foreach (var character in p.ToCharArray())
                if (char.IsUpper(character)) sb.Append(character.ToString().ToLower());
                else if (char.IsLower(character)) sb.Append(character.ToString().ToUpper());
                else sb.Append(character.ToString());

            return sb.ToString();
        }

        private static string ReverseWordsOrder(string p)
        {
            StringBuilder sb = new();

            var t1 = p.Split(' ');
            for (int i = t1.Length - 1; i >= 0; i--)
            {
                if (i == 0) sb.Append($"{t1[i]}");
                else sb.Append($"{t1[i]} ");
            }

            return sb.ToString();
        }

        private static string IdentifyVowels(string p)
        {
            char[] vowels = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            StringBuilder sb = new();

            foreach (var character in p.ToCharArray())
                if (vowels.Contains(character)) sb.Append($"pv{character}");
                else sb.Append(character);

            return sb.ToString();
        }
    }
}
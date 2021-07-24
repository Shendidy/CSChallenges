using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // This repo has a separate branch for each challenge, and master will remain just a starting template for new challenges.
            // To start a new challenge, just checkout a new branch with the name you want to give that challenge, then work there.
            Console.WriteLine(Solution.Run(false, "The wizard quickly jinxed the gnomes before they vaporized.")+"*");
            Console.WriteLine();
            Console.WriteLine(Solution.Run(true, "- .... .   .-- .. --.. .- .-. -..   --.- ..- .. -.-. -.- .-.. -.--   .--- .. -. -..- . -..   - .... .   --. -. --- -- . ...   -... . ..-. --- .-. .   - .... . -.--   ...- .- .--. --- .-. .. --.. . -.. .-.-.-") + "*");
        }
    }

    public static class Solution
    {
        public static string Run(bool morseToEnglish, string textToTranslate)
        {
            //
            // Write your code below; return type and arguments should be according to the problem's requirements
            //


            string translatedText = morseToEnglish ? MorseToEnglish(textToTranslate) : EnglishToMorse(textToTranslate);
            return translatedText;
        }

        public static string MorseToEnglish(string textToTranslate)
        {
            var morseDictionary = MorseCode.GetMorseDictionary();
            StringBuilder finalString = new StringBuilder();

            foreach (string word in textToTranslate.Split("   "))
            {
                foreach(string character in word.Split(' '))
                {
                    foreach(KeyValuePair<char, string> morseChar in morseDictionary)
                    {
                        if (character == morseChar.Value && character != " ") finalString.Append(morseChar.Key);
                    }
                }
                finalString.Append(' ');
            }

            return String.Join("", finalString.ToString().Take(finalString.Length - 1).ToArray());
        }

        public static string EnglishToMorse(string textToTranslate)
        {
            var morseDictionary = MorseCode.GetMorseDictionary();
            StringBuilder finalString = new StringBuilder();

            foreach(char character in textToTranslate.ToLower().ToCharArray())
            {
                finalString.Append(morseDictionary[character] + " ");
            }

            return finalString.ToString().Substring(0,finalString.Length - 1);
        }
    }

    public class MorseCode
    {
        public static Dictionary<char, string> GetMorseDictionary()
        {
            Dictionary<char, string> morseCode = new Dictionary<char, string>();

            morseCode.Add('a', ".-");
            morseCode.Add('b', "-...");
            morseCode.Add('c', "-.-.");
            morseCode.Add('d', "-..");
            morseCode.Add('e', ".");
            morseCode.Add('f', "..-.");
            morseCode.Add('g', "--.");
            morseCode.Add('h', "....");
            morseCode.Add('i', "..");
            morseCode.Add('j', ".---");
            morseCode.Add('k', "-.-");
            morseCode.Add('l', ".-..");
            morseCode.Add('m', "--");
            morseCode.Add('n', "-.");
            morseCode.Add('o', "---");
            morseCode.Add('p', ".--.");
            morseCode.Add('q', "--.-");
            morseCode.Add('r', ".-.");
            morseCode.Add('s', "...");
            morseCode.Add('t', "-");
            morseCode.Add('u', "..-");
            morseCode.Add('v', "...-");
            morseCode.Add('w', ".--");
            morseCode.Add('x', "-..-");
            morseCode.Add('y', "-.--");
            morseCode.Add('z', "--..");
            morseCode.Add('0', "-----");
            morseCode.Add('1', ".----");
            morseCode.Add('2', "..---");
            morseCode.Add('3', "...--");
            morseCode.Add('4', "....-");
            morseCode.Add('5', ".....");
            morseCode.Add('6', "-....");
            morseCode.Add('7', "--...");
            morseCode.Add('8', "---..");
            morseCode.Add('9', "----.");
            morseCode.Add(' ', "   ");
            morseCode.Add('.', ".-.-.-");

            return morseCode;
        }
    }
}
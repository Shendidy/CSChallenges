using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonFileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            // read file into gameText
            var gamePath = "./Shendidy_vs_David_2021.07.11.txt";
            var gameName = gamePath.Split('/').Last().Split('.').First();
            var gameText = File.ReadAllText(gamePath);

            // Things to follow as improvement in the future to allow users importing their own games
            // validate text to ensure it's valid
            // text starts with "1. "
            // when split on '.' all elements will have 3 parts and will
            // end with integer except for last element representing the last move
            // when split on '.' all elements will have 2 ' ' except for last element, will have one or none
            // when splitting all elements on ' ' after being split on '.', then skipping last element,
            // the remeining 2 elements will represent valid Chess Notation

            // create json object
            List<string> movesList = GetMovesList(gameText);
            JObject initialGameJson = GetGameMovesInJson(movesList);
            JObject finalGameJson = new JObject(new JProperty(gameName, initialGameJson));

            // create json file with game moves
            File.WriteAllText("./Shendidy_vs_David_2021.07.11.json", finalGameJson.ToString());

            Console.WriteLine("File created!");
        }

        private static List<string> GetMovesList(string gameText)
        {
            List<string> movesList = new List<string>();
            var movesArray = gameText.Split(". ").Skip(1).ToArray();

            foreach (var move in movesArray)
            {
                string actualMove;

                actualMove = move.Split(' ').Length == 3 ?
                    String.Join(' ', move.Split(' ').SkipLast(1)) :
                    String.Join(' ', move.Split(' '));
                movesList.Add(actualMove);
            }
            return movesList;
        }

        private static JObject GetGameMovesInJson(List<string> gameMoves)
        {
            dynamic gameJson = new JObject();

            var moveNumber = 1;
            foreach (var move in gameMoves)
            {
                if (move.Split(' ').Length == 2)
                    gameJson.Add(
                        new JProperty(moveNumber.ToString(),
                            new JObject(
                                new JProperty("White", move.Split()[0]),
                                new JProperty("Black", move.Split()[1])
                            )
                        )
                    );

                else
                    gameJson.Add(
                    new JProperty(moveNumber.ToString(),
                        new JObject(
                            new JProperty("White", move.Split()[0])
                        )
                    )
                );

                moveNumber++;
            }

            return gameJson;
        }
    }
}

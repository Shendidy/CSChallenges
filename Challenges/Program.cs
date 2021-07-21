using Newtonsoft.Json;
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
            var gamePath = "./Games/Shendidy_vs_David_2021.07.11.txt";
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
            Game finalGameJson = GetGameMovesInJson(gameName, movesList);

            // create json file with game moves
            File.WriteAllText("./Shendidy_vs_David_2021.07.11.json", JsonConvert.SerializeObject(finalGameJson, Formatting.Indented));

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

        private static Game GetGameMovesInJson(string gameName, List<string> gameMoves)
        {
            Game game = new Game();
            game.Name = gameName;
            game.Moves = new List<Move>();

            var moveNumber = 1;
            foreach(var move in gameMoves)
            {
                Move newMove = new Move();
                newMove.Number = moveNumber++;

                if(move.Split(' ').Length > 1)
                {
                    newMove.White = move.Split(' ').First();
                    newMove.Black = move.Split(' ').Last();
                }
                else
                {
                    newMove.White = move.Split(' ').First();
                }

                game.Moves.Add(newMove);
            }



            return game;
        }

        public class Game
        {
            public string Name { get; set; }
            public List<Move> Moves { get; set; }
        }

        public class Move
        {
            public int Number { get; set; }
            public string White { get; set; }
            public string Black { get; set; }
        }
    }
}

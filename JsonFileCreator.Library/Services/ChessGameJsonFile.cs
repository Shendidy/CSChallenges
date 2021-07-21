using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonFileCreator.Library.Services
{
    public class ChessGameJsonFile
    {
        public static void CreateChessGameJsonFile(string gamePath)
        {
            var gameName = gamePath.Split('/').Last().Split('.').First();
            var gameText = File.ReadAllText(gamePath);

            List<string> movesList = GetMovesList(gameText);
            Game finalGameJson = GetGameMovesInJson(gameName, movesList);

            File.WriteAllText("./Shendidy_vs_David_2021.07.11.json", JsonConvert.SerializeObject(finalGameJson, Formatting.Indented));

            // Things to follow as improvement in the future to allow users importing their own games
            // validate text to ensure it's valid
            // text starts with "1. "
            // when split on '.' all elements will have 3 parts and will
            // end with integer except for last element representing the last move
            // when split on '.' all elements will have 2 ' ' except for last element, will have one or none
            // when splitting all elements on ' ' after being split on '.', then skipping last element,
            // the remeining 2 elements will represent valid Chess Notation
        }

        private static List<string> GetMovesList(string gameText)
        {
            List<string> movesList = new List<string>();
            var movesArray = gameText.Split(". ").Skip(1).ToArray();

            foreach (var move in movesArray)
                movesList.Add(String.Join(' ', move.Split(' ').Take(2)));

            return movesList;
        }

        private static Game GetGameMovesInJson(string gameName, List<string> gameMoves)
        {
            Game game = new Game();
            game.name = gameName;
            game.moves = new List<Move>();

            var moveNumber = 1;
            foreach (var move in gameMoves)
            {
                Move newMove = new Move();
                newMove.number = moveNumber++;

                newMove.white = move.Split(' ')[0];
                if (move.Split(' ').Length > 1) newMove.black = move.Split(' ')[1];

                game.moves.Add(newMove);
            }



            return game;
        }
    }
}

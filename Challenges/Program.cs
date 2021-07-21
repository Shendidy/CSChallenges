using JsonFileCreator.Library.Services;

namespace JsonFileCreator
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // call the creator method with the text file path to gnerate the json file in the same directory
            ChessGameJsonFile.CreateChessGameJsonFile("./Games/Shendidy_vs_David_2021.07.11.txt");
        }
    }
}

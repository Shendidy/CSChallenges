using System;
using Library.Services;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonUrl = "https://s3.eu-west-1.amazonaws.com/hackajob-assets1.p.hackajob/challenges/football_session/football.json";

            Console.WriteLine(LeagueServices.GetTotalGoals(jsonUrl, "liverpool"));
            Console.WriteLine();
            LeagueServices.LogAllTeamsScores(jsonUrl, "Value", false);
            Console.WriteLine();
            LeagueServices.LogAllTeamsScores(jsonUrl, "Key", true);
        }
    }
}

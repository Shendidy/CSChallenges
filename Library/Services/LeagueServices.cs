using System;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Library.Services
{
    public class LeagueServices
    {
        public static int GetTotalGoals(string jsonUrl, string teamKey)
        {
            int totalGoals = 0;

            Result result = GetDeserializedGamesResults(jsonUrl);

            foreach (Round round in result.rounds)
                foreach (Match match in round.matches)
                {
                    if (match.team1.key == teamKey) totalGoals += match.score1;
                    else if (match.team2.key == teamKey) totalGoals += match.score2;
                }

            return totalGoals;
        }

        private static Dictionary<string, int> GetAllTeamsTotalGoals(string jsonUrl)
        {
            Result result = GetDeserializedGamesResults(jsonUrl);

            Dictionary<string, string> teams = new Dictionary<string, string>();

            foreach (Round round in result.rounds)
                foreach (Match match in round.matches)
                    if (!teams.ContainsKey(match.team1.key)) teams.Add(match.team1.key, match.team1.name);



            Dictionary<string, int> allTeamsTotalGoals = new Dictionary<string, int>();

            foreach(KeyValuePair<string, string> team in teams)
                allTeamsTotalGoals.Add(team.Value, GetTotalGoals(jsonUrl, team.Key));

            return allTeamsTotalGoals;
        }

        private static Result GetDeserializedGamesResults(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader reader = new StreamReader(stream);

            return JsonConvert.DeserializeObject<Result>(reader.ReadToEnd());
        }

        public static void LogAllTeamsScores(string jsonUrl, string orderBy, bool ascending)
        {
            Dictionary<string, int> allTeamsTotalGoals = GetAllTeamsTotalGoals(jsonUrl);

            orderBy = orderBy.ToLower();

            if(!ascending)
            {
                if(orderBy == "key")
                    foreach (KeyValuePair<string, int> kvp in allTeamsTotalGoals.OrderByDescending(key => key.Key))
                        Console.WriteLine($"{kvp.Key} has scored {kvp.Value} goals!");

                else
                    foreach (KeyValuePair<string, int> kvp in allTeamsTotalGoals.OrderByDescending(value => value.Value))
                        Console.WriteLine($"{kvp.Key} has scored {kvp.Value} goals!");
            }

            else
            {
                if (orderBy == "key")
                    foreach (KeyValuePair<string, int> kvp in allTeamsTotalGoals.OrderBy(key => key.Key))
                        Console.WriteLine($"{kvp.Key} has scored {kvp.Value} goals!");

                else
                    foreach (KeyValuePair<string, int> kvp in allTeamsTotalGoals.OrderBy(value => value.Value))
                        Console.WriteLine($"{kvp.Key} has scored {kvp.Value} goals!");
            }
        }
    }
}

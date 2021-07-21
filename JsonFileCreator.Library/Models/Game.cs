using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonFileCreator.Library
{
    public class Game : IGame
    {
        [JsonProperty("Game Name")]
        public string name { get; set; }
        public List<Move> moves { get; set; }
    }
}

using Newtonsoft.Json;

namespace JsonFileCreator.Library
{
    public class Move : IMove
    {
        [JsonProperty("Move Number")]
        public int number { get; set; }
        [JsonProperty("White's move")]
        public string white { get; set; }
        [JsonProperty("Black's move")]
        public string black { get; set; }
    }
}

using System.Collections.Generic;

namespace JsonFileCreator.Library
{
    public interface IGame
    {
        List<Move> moves { get; set; }
        string name { get; set; }
    }
}
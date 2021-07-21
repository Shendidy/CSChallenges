namespace Library
{
    public interface IMatch
    {
        int score1 { get; set; }
        int score2 { get; set; }
        Team team1 { get; set; }
        Team team2 { get; set; }
    }
}
namespace Library
{
    public interface IRound
    {
        Match[] matches { get; set; }
        string name { get; set; }
    }
}
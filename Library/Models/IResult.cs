namespace Library
{
    public interface IResult
    {
        string name { get; set; }
        Round[] rounds { get; set; }
    }
}
namespace MathGame;

public class Result
{
    public string Operation { get; } 
    public int Points { get; }
    public Result(string operation, int points)
    {
        Operation = operation;
        Points = points;
    }
}
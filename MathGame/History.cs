namespace MathGame;

public class History
{
    public string Operation { get; set; }
    public int Points { get; set; }

    public History(string operation, int points)
    {
        Operation = operation;
        Points = points;
    }

    
}
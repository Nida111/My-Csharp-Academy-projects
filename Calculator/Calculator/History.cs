namespace Calculator;

public class History
{
    public string Operation { get; } 
    public double Result { get; }
    public History(string operation, double result)
    {
        Operation = operation;
        Result = result;
    }
}
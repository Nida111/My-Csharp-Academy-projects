namespace Calculator;

public static class UtilityFunctions
{
   public static void CalculatorUsage(int num)
   {
      Console.WriteLine($"The calculator was used {num} times");
   }
   
   public static void ShowResults(List<History> history)
   {
      foreach (var entry in history)
         Console.WriteLine($"\nIn game {entry.Operation} the result was {entry.Result} " );
   }
    
}
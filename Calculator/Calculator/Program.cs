using Calculator;
using System.Text.RegularExpressions;

namespace CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        int calculatorCount = 0;
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
        Calculator calculator = new Calculator();
        while (!endApp)
        {
            List<History> history = new List<History>(); 
            // Declare variables and set to empty.
            // Use Nullable types (with ?) to match type of System.Console.ReadLine
            string? numInput1;
            string? numInput2;
            double result = 0;

            // Ask the user to choose an operator.
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tr - Square Root "); // One input
            Console.WriteLine("\t10x - for power 10"); // one input is
            Console.WriteLine("\tp - taking power");
            Console.WriteLine("\tTF - trigonometric functions"); // one input 
            Console.Write("Your option? ");
            string? op = Console.ReadLine();
            op = op.Trim();
            op = op.ToLower();

            if (Regex.IsMatch(op, "[r|10x]"))
            {
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput1 = Console.ReadLine();
                }
                try
                {
                    result = calculator.SquareOperation(cleanNum1, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                
                History h1 = new History(op, result);
                history.Add(h1);
                calculatorCount++;
                
            }
            else if (Regex.IsMatch(op, "[tf]"))
            {
                Console.WriteLine("Choose a Trigonometric function from the following list:");
                Console.WriteLine("\ts - sin");
                Console.WriteLine("\tc - cos");
                Console.WriteLine("\tt - tan");
                string? triFunction = Console.ReadLine();
                triFunction = triFunction.Trim();
                triFunction = triFunction.ToLower();
                
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput1 = Console.ReadLine();
                }
                try
                {
                    result = calculator.TrigonometricOperations(cleanNum1, triFunction);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                History h1 = new History(triFunction, result);
                history.Add(h1);
                calculatorCount++;

            }
            else if (Regex.IsMatch(op, "[a|s|m|d|p]"))
            {
                // Ask the user to type the first number.
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput2 = Console.ReadLine();
                }
                
                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                History h1 = new History(op, result);
                history.Add(h1);
                calculatorCount++;

            }

            else
            {
                Console.WriteLine("Error: Unrecognized input.");
            }

            // Wait for the user to respond before closing.
            Console.WriteLine("Choose following option to proceed further");
            Console.WriteLine("\tC - Continue");
            Console.WriteLine("\tN - Dont want to continue ");
            Console.WriteLine("\th - I would like to see my previous calculations");
            string? decision = Console.ReadLine();
            decision = decision.Trim();
            decision = decision.ToLower();
            
            if (decision == "n") endApp = true;
            else if  (decision == "c") endApp = false;
            else if (decision == "h")
            {
                UtilityFunctions.ShowResults(history);
                Console.WriteLine("Do u want to delete the list y/n");
                string? response = Console.ReadLine();
                response = response.Trim();
                response = response.ToLower();
                
                if (!(Regex.IsMatch(response, "[n|y]")))
                    Console.WriteLine("Invalid response");
                
                if (response == "y") 
                    history = null;
            }

            Console.WriteLine("\n"); // Friendly line spacing.
        }
        UtilityFunctions.CalculatorUsage(calculatorCount);
        calculator.Finish();
    }
}
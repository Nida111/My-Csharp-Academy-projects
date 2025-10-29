namespace MathGame;

public class Game
{
    public Result PlayGame(string gameName)
    {
        return gameName switch
        {
            "a" => AdditionGame(),
            "s" => SubtractionGame(),
            "m" => MultiplicationGame(),
            "d" => DivisionGame(),
            _ => throw new ArgumentException("Unknown game")
        };

    }
    
    private Result AdditionGame()
        {
            Random random = new Random();
            Console.Clear();
            int gamePoints = 0;
            Console.WriteLine("Addition game selected");
            for (int i = 0; i < 5; i++)
            {
                int num1 = random.Next(1, 50);
                int num2 = random.Next(1, 50);
                Console.WriteLine($"{num1} + {num2}");
                int result = num1 + num2;
                string? userInput = Console.ReadLine();
                while (userInput == null)
                {
                    Console.WriteLine("The answer cannot be empty.");
                    userInput = Console.ReadLine();
                }
                int? validatedInput = InputValidation(userInput);
                if (result == validatedInput)
                {
                    Console.WriteLine("Good job. The answer is correct. You got 2 points\n");
                    gamePoints +=2;
                }
                else
                {
                    Console.WriteLine("Oh no! The answer is incorrect. You got 0 points\n");
                }
                
            }
            Console.WriteLine($"You got {gamePoints} points");
            return new Result("Addition", gamePoints);
            
        }

    private Result SubtractionGame()
    {
        Random random = new Random();
        Console.Clear();
        int gamePoints = 0;
        Console.WriteLine("Subtraction game selected");
        for (int i = 0; i < 5; i++)
        {
            int num1 = random.Next(1, 50);
            int num2 = random.Next(1, 50);
            Console.WriteLine($"{num1} - {num2}");
            int result = num1 - num2;
            string? userInput = Console.ReadLine();
            while (userInput == null)
            {
                Console.WriteLine("The answer cannot be empty.");
                userInput = Console.ReadLine();
            }

            int? validatedInput = InputValidation(userInput);
            if (result == validatedInput)
            {
                Console.WriteLine("Good job. The answer is correct. You got 2 points\n");
                gamePoints += 2;
            }
            else
            {
                Console.WriteLine("Oh no! The answer is incorrect. You got 0 points\n");
            }

        }

        Console.WriteLine($"You got {gamePoints} points");
        return new Result("Subtraction", gamePoints);
    }

    private Result MultiplicationGame()
        {
            Random random = new Random();
            Console.Clear();
            int gamePoints = 0;
            Console.WriteLine("Multiplication game selected");
            for (int i = 0; i < 5; i++)
            {
                int num1 = random.Next(1, 20);
                int num2 = random.Next(1,10);
                Console.WriteLine($"{num1} * {num2}");
                int result = num1 * num2;
                string? userInput = Console.ReadLine();
                while (userInput == null)
                {
                    Console.WriteLine("The answer cannot be empty.");
                    userInput = Console.ReadLine();
                }
                int? validatedInput = InputValidation(userInput);
                if (result == validatedInput)
                {
                    Console.WriteLine(" Good job. The answer is correct. You got 2 points");
                    gamePoints +=2;
                }
                else
                {
                    Console.WriteLine(" oops! The answer is incorrect. You got 0 points");
                }
            }
            Console.WriteLine($"You got {gamePoints} points");
            return new Result("Multiplication", gamePoints);
        }

        private Result DivisionGame()
        {
            // The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100
            // . Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
            Random random = new Random();
            Console.Clear();
            int gamePoints = 0;
            Console.WriteLine("Division game selected");
            
            for (int i = 0; i < 5; i++)
            {
                int num1;
                int num2;
                do
                { 
                    num1 = random.Next(1, 40);
                    num2 = random.Next(1, num1);
                } 
                while (num1 % num2 != 0);
                Console.WriteLine($"{num1} / {num2}");
                int result = num1 / num2;
                string? userInput = Console.ReadLine();
                while (userInput == null)
                {
                    Console.WriteLine("The answer cannot be empty.");
                    userInput = Console.ReadLine();
                }
                int? validatedInput = InputValidation(userInput);
                if (result == validatedInput)
                {
                    Console.WriteLine(" Good job. The answer is correct. You got 2 points");
                    gamePoints +=2;
                }
                else
                {
                    Console.WriteLine(" oops! The answer is incorrect. You got 0 points");
                }
            }
            Console.WriteLine($"You got {gamePoints} points");
            Result divisionResult = new Result("Division", gamePoints);
            return divisionResult;
            
        }
        
        private int? InputValidation(string input)
        {
            input = input.Trim();
            bool success = int.TryParse(input, out int number);
            if (success)
            {
               return number;
            }
            return null;
        }


        
        
}
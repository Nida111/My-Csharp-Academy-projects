namespace MathGame;

public class Game
{
    public Result PlayGame(string gameName)
    { 
        switch (gameName)
        {
            case "a":
                return AdditionGame();
            case "s" :
                return SubtractionGame();
            case "m" :
                return MultiplicationGame();
            case "d":
                return DivisionGame();
            default:
                throw new ArgumentException("Unknown Game");
        }

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
                int validatedInput = InputValidation(userInput);
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
            Result additionResult = new Result("Addition", gamePoints);
            return additionResult;
            
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

            int validatedInput = InputValidation(userInput);
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
        Result subtractionResult = new Result("Subtraction", gamePoints);
        return subtractionResult;
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
                int validatedInput = InputValidation(userInput);
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
            Result multiplyResult = new Result("Multiplication", gamePoints);
            return multiplyResult;
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
                int validatedInput = InputValidation(userInput);
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
        
        private  int InputValidation(string input)
        {
            input = input.Trim();
            int validInput = 0;
            bool success = int.TryParse(input, out int number);
            if (success)
            {
                validInput= number;
            }
            else
            {
                Console.WriteLine("your answer is in correct. U ot zero points ");
                    
            }
            return validInput;
        }


        
        
}
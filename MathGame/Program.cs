using System;
using System.Collections.Generic;

namespace MathGame;

class Program
{
    static void Main(string[] args)
    {
        UserName();
        MenuSelection();
        
        //this method takes the name of the user
        void UserName()
        {
            Console.WriteLine("Write your name");
            var name = Console.ReadLine();
            while (name == null)
            {
                Console.WriteLine("The name cannot be empty.");
                name = Console.ReadLine();
            }

            name =  name.Trim();
            Console.WriteLine($"Hey {name}. Welcome! to the math game\n");
        }
        
        //This method is used for menu selection
        void MenuSelection()
        {
            Console.WriteLine("What would you like to play? Choose from the menu: \n A - Addition \n S - Subtraction \n M - Multiplication \n D - Division \n Q - Quit" );
            string? gameSelected = Console.ReadLine();
            while (gameSelected == null)
            {
                Console.WriteLine("I didn't understand. Try again");
                gameSelected = Console.ReadLine();
            }
            gameSelected = gameSelected.Trim().ToLower();
            switch (gameSelected)
            {
                case "a":
                    AdditionGame();
                    break;
                case "s" :
                    SubtractionGame();
                    break;
                case "m" :
                    MultiplicationGame();
                    break;
                case "d":
                    DivisionGame();
                    break;
                case "qf" :
                    Console.WriteLine("game quited"); 
                    return;
                case "h":
                    GameHistory();
                    break;
                default:
                    Console.WriteLine("hey buddy! what are u trying to say? Please try again ");
                    MenuSelection();
                    break;
            }

        }
        
        void AdditionGame()
        {
            Console.WriteLine("Addition game selected"); 
            string addOperation = "addition";
            var addNumArray = NumbersAsInput(addOperation);
            int additionResult = 0;
            for (int i = 0; i < addNumArray.Length; i++)
            {
                additionResult  += addNumArray[i];
            }
            Console.WriteLine($"the result is {additionResult }");
            ContinueGameOrNot();
        }

        void SubtractionGame()
        {
            Console.WriteLine("Subtraction game selected");
            string subOperation = "subtration";
            var subNumArray = NumbersAsInput(subOperation);
            int subtrationResult = subNumArray[0];
            for (int i = 1; i < subNumArray.Length; i++)
            {
                subtrationResult  -=  subNumArray[i];
            }
            Console.WriteLine($"the result is {subtrationResult }");
            ContinueGameOrNot();
        }

        void MultiplicationGame()
        {
            Console.WriteLine("Multiplication game selected");
            string multiplyOperation = "multiplication";
            var multiplyNumArray = NumbersAsInput(multiplyOperation);
            int multiplyResult = multiplyNumArray[0];
            for (int i = 1; i < multiplyNumArray.Length; i++)
            {
                multiplyResult  *=  multiplyNumArray[i];
            }
            Console.WriteLine($"the result is {multiplyResult }");
            ContinueGameOrNot();
        }

        void DivisionGame()
        {
            // The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100
            // . Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
            Console.WriteLine("Division game selected");
            Console.WriteLine("First enter the dividend and then the divider. Both should be less than 100. Make sure that dividend is greater that divider.");
            var dividOperation = "division";
            var dividNumArray = NumbersAsInput(dividOperation);
            int dividend = dividNumArray[0];
            int divider = dividNumArray[1];
            if (dividend < 100 && dividend > divider)
            {
                if (dividend % divider == 0)
                {
                    int divisionResult = dividend / divider;
                    Console.WriteLine($"The result of the division is {divisionResult}");
                }
                else
                {
                    Console.WriteLine("Division not possible. Try again");
                    DivisionGame();
                }
            }
            else
            {
                Console.WriteLine("The numbers entered are not correct");
                DivisionGame();
            }
        }

        void GameHistory()
        {
            List<string> history = new List<string>();
            

        }
        
        
        // this method is used to convert user input to an array of numbers
        int[] NumbersAsInput(string operation)
        {
            Console.WriteLine($"Enter numbers for {operation}");
            var userInput = Console.ReadLine();
            while (userInput == null)
            {
                Console.WriteLine("I didn't understand. Try again");
                userInput = Console.ReadLine();
            }
            userInput = userInput.Trim();
            string[] stringNumbers = userInput.Split(" " , StringSplitOptions.RemoveEmptyEntries );
            int[] numberArray = new int[stringNumbers.Length];
            for (int i = 0; i < numberArray.Length; i++)
            { 
                bool success = int.TryParse(stringNumbers[i], out int number);
                if (success)
                {
                    numberArray[i] = number;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                    NumbersAsInput(operation);
                }
            }
            return numberArray;
        }
        
        
        void ContinueGameOrNot()
        {
            Console.WriteLine("Do u want to continue the game? y/n");
            string? input = Console.ReadLine();
            while (input == null)
            {
                Console.WriteLine("I didn't understand. Try again");
                input = Console.ReadLine();
            }
            input = input.Trim().ToLower();
            if (input == "y")
            {
                MenuSelection();
            }
            else if (input == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Please write y or n. I didn't understood");
            }
        }
    }
}
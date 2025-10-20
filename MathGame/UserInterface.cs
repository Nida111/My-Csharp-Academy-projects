namespace MathGame;

public class UserInterface
{
    public static void UserName()
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
    public static void MenuSelection()
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
                GameOperations.AdditionGame();
                break;
            case "s" :
                GameOperations.SubtractionGame();
                break;
            case "m" :
                GameOperations.MultiplicationGame();
                break;
            case "d":
                GameOperations.DivisionGame();
                break;
            case "q" :
                Console.WriteLine("game quited"); 
                return;
            case "h":
                ShowHistory();
                break;
            default:
                Console.WriteLine("hey buddy! what are u trying to say? Please try again ");
                MenuSelection();
                break;
        }

    }
    
    // this method is used to convert user input to an array of numbers
    public static int InputValidation(string input)
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
        
        
    public static void ContinueGameOrNot()
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
    
    public static void ShowHistory()
    {
        foreach (var entry in GameOperations.history)
            Console.WriteLine(entry);
        ContinueGameOrNot();
    }
    
}
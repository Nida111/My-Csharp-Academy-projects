namespace MathGame;

public static class UserInput
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
    public static string MenuSelection()
    {
        Console.WriteLine("What would you like   to play? Choose from the menu: \n A - Addition \n S - Subtraction \n M - Multiplication \n D - Division \n Q - Quit \n H - History \n" );
        string? optionSelected = Console.ReadLine();
        while (optionSelected == null)
        {
            Console.WriteLine("I didn't understand. Try again");
            optionSelected = Console.ReadLine();
        }
        optionSelected = optionSelected.Trim().ToLower();
        switch (optionSelected)
        {
            case "a":
                return "a";
            case "s" :
                return "s";
            case "m" :
                return "m";
            case "d":
                return "d";
            case "q" :
                return "q";
            case "h":
                return "h";
            default:
                Console.WriteLine("hey buddy! what are u trying to say? Please try again ");
                return MenuSelection();
        }

    }
    
    public static bool ContinueGameOrNot()
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
            return true;
        }
        else if (input == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Please write y or n. I didn't understood");
             return ContinueGameOrNot();
        }
        
    }
    
    public static void ShowResults(List<Result> history )
    {
        foreach (var entry in history)
            Console.WriteLine($"\nIn game {entry.Operation} you got {entry.Points} points " );
    }
    
}
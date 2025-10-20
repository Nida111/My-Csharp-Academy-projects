namespace MathGame;

public class UserInterce
{
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
                    case "qf" :
                        Console.WriteLine("game quited"); 
                        return;
                    case "h":
                        break;
                    default:
                        Console.WriteLine("hey buddy! what are u trying to say? Please try again ");
                        MenuSelection();
                        break;
                }
    
            }

}
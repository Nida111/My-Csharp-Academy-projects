namespace MathGame;

class Program
{
    static void Main()
    { 
        List<Result> history = new List<Result>(); 
        // a list of class result is created to hold all the results of the game
        bool gameContinue;
        Game game = new Game();
        UserInput.UserName();                                          // username is required
        do
        {
            var menuSelectionInput = UserInput.MenuSelection(); // user selects input from the menu
            if (menuSelectionInput == "h")
                UserInput.ShowResults(history);
            else if (menuSelectionInput == "q")
            {
                Console.WriteLine("game quited");
                Environment.Exit(0);
            }
            else
            {
                Result gameResults = game.PlayGame(menuSelectionInput); // the user input from the menu is passed to play the game
                history.Add(gameResults);
            }
            
            gameContinue = UserInput.ContinueGameOrNot();

        } while (gameContinue);
        


    }
    
}
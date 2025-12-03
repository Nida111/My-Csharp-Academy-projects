using HabitLogger.Domain;
using HabitLogger.Infrastructure;
using HabitLogger.Infrastructure.Data.Repositories;
using System.Globalization;
using ConsoleTables;

namespace HabitLogger.UI;

class Program
{
    static void Main(string[] args)
    {
        // first we will initialize the database
        DatabaseInitializer databaseInitializer = new DatabaseInitializer();
        databaseInitializer.CreateDatabase();
        
        // now we will create the user  
        //**********************             USER LOGIN              ***********************//
        User? user;
        UserHabit userHabit = new UserHabit();
        Console.WriteLine("Hey. Welcome to Habit Lodger. Now you can log your habits and improve yourself\n");
        string? userName;
        do
        {
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();
        } 
        while (string.IsNullOrWhiteSpace(userName));
    
        // Try to get user by name
        // if user is found, use that user and continue...
        // else crete user, then use that user and continue
        UserRepository userRepository = new UserRepository();
        try
        {
            user = userRepository.GetByName(userName); 
            if (user == null)
            {
                userRepository.Insert(new User
                {
                    Name = userName
                });
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        user = userRepository.GetByName(userName);
        userHabit.UserId = user.Id;
        
        //**********************             MENU SELECTION              ***********************//
        
        // now we will display the menu to the user

        

        Habit? habit;
        HabitRepository habitRepository = new HabitRepository();
        UserHabitRepository userHabitRepository = new UserHabitRepository();
        bool continueHabitLodger = false;

        while (!continueHabitLodger)
        {
            string? menuSelection;
            do
            {
                Console.WriteLine("What would you like to do");
                Console.WriteLine("\tA - Log a new habit");
                Console.WriteLine("\tB -View habit ");
                Console.WriteLine("\tC - Update a habit");
                Console.WriteLine("\tD - Delete a habit");
                Console.WriteLine("\tE - Exit");
                menuSelection = Console.ReadLine();
            } 
            while (string.IsNullOrWhiteSpace(menuSelection));
            menuSelection =menuSelection.ToLower();
            
            if (menuSelection == "a")   //////////////////////// create a new habit
            {
                string? habitName; 
                do
                {
                    Console.WriteLine("which habit would u like to add: ");
                    habitName = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(habitName));
            
                try
                {
                    habit = habitRepository.GetByName(habitName);
                    if (habit == null)
                    {
                        habitRepository.Insert(new Habit
                        {
                            Name = habitName
                        });
                    }
                }
            
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            
                habit = habitRepository.GetByName(habitName);
                userHabit.HabitId = habit.Id;
            
                // asking the log date of habit
                bool isValid = false;
                while (!isValid)
                {
                    Console.WriteLine("\n What date would you like to add. Type in format DD-MM-YYYY: ");
                    var date = Console.ReadLine();
                    // validating date format
                    var dateFormat = "dd-MM-yyyy";
                    isValid = DateTime.TryParseExact(date, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
                    if (isValid)
                    {
                        date = parsedDate.ToString("yyyy-MM-dd");
                        userHabit.OccuredOn = date;
                    }
                    else
                        Console.WriteLine("\n Invalid date format. Try again");
                }
            
                // asking user the quantity
                
                bool validQuantity = false;
                while (!validQuantity)
                {
                    string? userInput; 
                    do
                    {
                        Console.WriteLine("\n Please specify the quantity in numbers you want to log for this habit: ");
                        userInput = Console.ReadLine();
                    } 
                    while (string.IsNullOrWhiteSpace(userInput));
                    if (int.TryParse(userInput, out int  quantity))
                    {
                        userHabit.Quantity = quantity;
                        validQuantity = true;
                    }
                       
                    else
                        Console.WriteLine("\n Invalid input. Numbers only, please.");
                }
                
                // asking the user the unit of that quantity
                do
                {
                    Console.WriteLine("\n Please specify the unit for this habit. Examples: hours, glasses etc: ");
                    userHabit.Unit = Console.ReadLine();
                } 
                while (string.IsNullOrWhiteSpace(userHabit.Unit));
                userHabitRepository.Insert(userHabit);
                Console.WriteLine("\n Habit added successfully \n");

            }
            
            else if (menuSelection == "b")  //////////////////////// View Habits
            {
                List<UserHabit> userHabitsList = userHabitRepository.Get(user.Id);
                var index = 1;
                var table = new ConsoleTable("No", "Habit", "Date", "Unit", "Quantity");
                foreach (var ub in userHabitsList)
                {
                    var name = habitRepository.GetById(ub.HabitId);
                    table.AddRow(index , name, ub.OccuredOn, ub.Unit, ub.Quantity);
                    index++;
                }
                Console.WriteLine(table);
                
            }
            else if (menuSelection == "d")    //////////////////////// delete habit
            {
                List<UserHabit> userHabitsList = userHabitRepository.Get(user.Id);
                var index = 1;
                var table = new ConsoleTable("No", "Habit", "Date", "Unit", "Quantity");
                foreach (var ub in userHabitsList)
                {
                    var name = habitRepository.GetById(ub.HabitId);
                    table.AddRow(index , name, ub.OccuredOn, ub.Unit, ub.Quantity);
                    index++;
                }
                Console.WriteLine(table);
                
                Console.WriteLine("which habit would you like to delete");
                var deleteIndex = Convert.ToInt32(Console.ReadLine());       // this will give index of the habit which user wants to delete
                deleteIndex--;
                bool habitDeleted = false;
                while (!habitDeleted)
                {
                    if (deleteIndex < userHabitsList.Count)
                    {
                        var hid =userHabitsList[deleteIndex].HabitId;
                        var uid = userHabitsList[deleteIndex].UserId;
                        var occuredDate = userHabitsList[deleteIndex].OccuredOn;
                        userHabitRepository.Delete(uid, hid, occuredDate);
                        Console.WriteLine($"The habit has been deleted successfully.");
                        habitDeleted = true;
                    }
                    else
                        Console.WriteLine($"this number does not exist");
                }
            }
            
            else if (menuSelection == "c")      //////////////////////// update habit
            {
                List<UserHabit> userHabitsList = userHabitRepository.Get(user.Id);
                var index = 1;
                var table = new ConsoleTable("No", "Habit", "Date", "Unit", "Quantity");
                foreach (var ub in userHabitsList)
                {
                    var name = habitRepository.GetById(ub.HabitId);
                    table.AddRow(index , name, ub.OccuredOn, ub.Unit, ub.Quantity);
                    index++;
                }
                Console.WriteLine(table);
                
                Console.WriteLine("which habit would you like to update");
                var updateIndex = Convert.ToInt32(Console.ReadLine());       // this will give index of the habit which user wants to update
                updateIndex--;
                bool habitUpdated = false;
                while (!habitUpdated)
                {
                    
                    if (updateIndex < userHabitsList.Count)
                    {
                        string? updatedDate = null;
                        int updatedQuantity = 0;
                        string? updatedUnit;
                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.WriteLine("What date would you like to add. Type in format DD-MM-YYYY: ");
                            updatedDate = Console.ReadLine();
                            // validating date format
                            var dateFormat = "dd-MM-yyyy";
                            isValid = DateTime.TryParseExact(updatedDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
                            if (isValid)
                            {
                                updatedDate = parsedDate.ToString("yyyy-MM-dd");
                            }
                            else
                                Console.WriteLine("\n Invalid date format. Try again");
                        }
                
                        // asking user the quantity
                        bool validQuantity = false;
                        while (!validQuantity)
                        {
                            string? userInput; 
                            do
                            {
                                Console.WriteLine("Please specify the quantity in numbers you want to log for this habit: ");
                                userInput = Console.ReadLine();
                            } 
                            while (string.IsNullOrWhiteSpace(userInput));
                            
                            if (int.TryParse(userInput, out updatedQuantity))
                            {
                                validQuantity = true;
                            }
                       
                            else
                                Console.WriteLine("Invalid input. Numbers only, please.");
                        }
                
                        // asking the user the unit of that quantity
                        do
                        {
                            Console.WriteLine("Please specify the unit for this habit. Examples: hours, glasses etc: ");
                            updatedUnit = Console.ReadLine();
                        } 
                        while (string.IsNullOrWhiteSpace(updatedUnit));
                        userHabitRepository.Update(userHabitsList[updateIndex], updatedDate, updatedQuantity, updatedUnit);
                        Console.WriteLine($"The habit has been updated successfully.");
                        habitUpdated = true;
                    }
                    else
                        Console.WriteLine($"this number does not exist");
                }
                
                
                
                
            }
            
            else if (menuSelection == "e")
            {
                Console.WriteLine("Exiting...");
                continueHabitLodger = true; 
            }
                
        }
        
        
        
            

    }
    
}
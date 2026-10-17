namespace PodCastWorld
{
    class Program
    {
        // Constants
        const string GOODBYE = "Goodbye!"; // not useful currently
        const string PREFIX = "Please enter your ";

        // private static User? currentUser;  // only stores 1 user...
        private static User? currentUser;

        private static readonly IUserRepository userRepository = new InMemoryUserRepository();
        
        static void Main(string[] args)
        {   // greeter
            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.WriteLine("Welcome to PodCastWorld!");
            Console.WriteLine();
            Console.WriteLine("============================================\n");
            //
            bool keepGoing = true;

            while (keepGoing)
            {
                PrintMainMenu();

                // Read and trim the input (handles accidental leading/trailing spaces)
                string choice = (Console.ReadLine() ?? string.Empty).Trim();

                switch (choice)
                {
                    // case "1":
                    //     currentUser = UserManager.UserLogin(userRepository);
                    //     break;
                    case "1":
                    currentUser = UserManager.UserLogin(userRepository);

                    if (currentUser != null)
                    {
                        MenuRouter.ShowMenu(currentUser);
                    }
                    break;


                    case "2":
                        // Jump directly into the registration flow
                        // RegisterUser(); // UserValidator.cs
                        UserManager.RegisterUser(userRepository);
                        break;

                    case "3":
                        Console.WriteLine(GOODBYE);
                        keepGoing = false;          // exit the loop
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Try again.\n");
                        break;
                }
            }
        }

        // ------------------------------------------------------------
        // Helper: show the main menu once per loop iteration
        // ------------------------------------------------------------
        static void PrintMainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1. Login as a user.");
            Console.WriteLine("2. Register as a new user.");
            Console.WriteLine("3. Quit.\n");
            Console.WriteLine("Please enter a choice between 1 and 3: ");
        }

        
    }
}
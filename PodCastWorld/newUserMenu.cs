namespace PodCastWorld;

public static class UserManager
{
    public static void RegisterUser(IUserRepository userRepository)
    {
            Console.WriteLine("\nRegistration Menu");
            Console.WriteLine("Please enter your user type:\n");
            Console.WriteLine("1. Regular Listener.");
            Console.WriteLine("2. Premium Listener.");
            Console.WriteLine("3. Podcaster.\n");

            Console.WriteLine("Please enter a choice between 1 and 3: ");

            string choiceType = (Console.ReadLine() ?? string.Empty).Trim();

            switch (choiceType)
            {
                case "1":
                    RegisterRegUser(userRepository);
                    break;
                case "2":
                    Console.WriteLine("Premium_User\n");
                    break;
                case "3":
                    Console.WriteLine("Podcast_User\n");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.\n");
                    break;
            }

    }

    public static void RegisterRegUser(IUserRepository userRepository)
    {
        // move RegisterRegUser code here
        const string PREFIX = "Please enter your ";

        string name;
        int age;
        string email;
        string mobile;
        string password;

            // NAME
        while (true)
        {
            Console.WriteLine(PREFIX + "name:");
            name = Console.ReadLine() ?? "";

            if (UserValidator.IsValidName(name))
                break;

            UserValidator.PrintNameError();
        }

        // AGE
        while (true)
        {
            Console.WriteLine(PREFIX + "age:");

            if (UserValidator.IsValidAge(Console.ReadLine() ?? "", out age))
                break;

            UserValidator.PrintAgeError();
        }

        // EMAIL
        while (true)
        {
            Console.WriteLine(PREFIX + "email:");
            email = Console.ReadLine() ?? "";

            if (UserValidator.IsValidEmail(email))
                break;

            UserValidator.PrintEmailError();
        }

        // MOBILE
        while (true)
        {
            Console.WriteLine(PREFIX + "mobile number:");
            mobile = Console.ReadLine() ?? "";

            if (UserValidator.IsValidMobile(mobile))
                break;

            UserValidator.PrintMobileError();
        }

        // PASSWORD
        while (true)
        {
            Console.WriteLine(PREFIX + "password:");
            password = Console.ReadLine() ?? "";

            if (UserValidator.IsValidPassword(password))
                break;

            UserValidator.PrintPasswordError();
        }

            

            // Store temporarily in memory
        User newUser = new User(
            name,
            age,
            email,
            mobile,
            password);

        userRepository.Add(newUser);

        Console.WriteLine("\nRegistration successful!");    
    }

    public static User? UserLogin(IUserRepository userRepository)
    {
        Console.WriteLine("\nLogin");

        Console.WriteLine("Please enter your email:");
        string email = Console.ReadLine() ?? "";

        Console.WriteLine("Please enter your password:");
        string password = Console.ReadLine() ?? "";

        User? foundUser = userRepository.FindByEmail(email);

        if (foundUser == null)
        {
            Console.WriteLine("No account found.");
            return null;
        }

        if (foundUser.Authenticate(email, password))
        {
            Console.WriteLine($"Welcome {foundUser.Name}!");
            return foundUser;
        }

        Console.WriteLine("Invalid password.");
        return null;
    }
}

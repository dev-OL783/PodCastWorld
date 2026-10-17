namespace PodCastWorld;

public static class UserManager
{
    public static void RegisterUser(IUserRepository userRepository)
    {
        Console.WriteLine("\nRegistration Menu");
        Console.WriteLine("1. Regular Listener");
        Console.WriteLine("2. Premium Listener");
        Console.WriteLine("3. Podcaster");

        string choiceType = (Console.ReadLine() ?? string.Empty).Trim();

        User newUser = RegisterUserDetails(choiceType);

        userRepository.Add(newUser);

        Console.WriteLine("\nRegistration successful!");
    }

    public static User RegisterUserDetails(string choiceType)
    {
        const string PREFIX = "Please enter your ";

        string name;
        int age;
        string email;
        string mobile;
        string password;

        // Collect all details exactly as you already do...

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

        switch (choiceType)
        {
            case "1":
                return new RegularListener(
                    name,
                    age,
                    email,
                    mobile,
                    password);

            case "2":

                int paymentId = GetPaymentId();
                DateTime registrationDate = GetRegistrationDate();

                return new PremiumListener(
                    name,
                    age,
                    email,
                    mobile,
                    password,
                    paymentId,
                    registrationDate);
            

            case "3":
                return new Podcaster(
                    name,
                    age,
                    email,
                    mobile,
                    password);

            default:
                throw new Exception("Invalid user type.");
        }
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

    // Premium

    private static int GetPaymentId()
    {
        while (true)
        {
            Console.Write("Enter Payment ID: ");

            if (UserValidator.IsValidPaymentId(
                    Console.ReadLine() ?? "",
                    out int paymentId))
            {
                return paymentId;
            }

            UserValidator.PrintPaymentIdError();
        }
    }

    private static DateTime GetRegistrationDate()
    {
        while (true)
        {
            Console.Write(
                "Enter Registration Date (dd/MM/yyyy): ");

            if (UserValidator.IsValidRegistrationDate(
                    Console.ReadLine() ?? "",
                    out DateTime registrationDate))
            {
                return registrationDate;
            }

            UserValidator.PrintRegistrationDateError();
        }
    }

    // private static string GetPaymentId()
    // {
    //     while (true)
    //     {
    //         Console.Write("Enter Payment ID: ");
    //         string paymentId = Console.ReadLine() ?? "";

    //         if (UserValidator.IsValidPaymentId(paymentId))
    //             return paymentId;

    //         UserValidator.PrintPaymentIdError();
    //     }
    // }

    // private static DateTime GetRegistrationDate()
    // {
    //     while (true)
    //     {
    //         Console.Write("Enter Registration Date (dd/MM/yyyy): ");

    //         if (UserValidator.IsValidRegistrationDate(
    //                 Console.ReadLine() ?? "",
    //                 out DateTime registrationDate))
    //         {
    //             return registrationDate;
    //         }

    //         UserValidator.PrintRegistrationDateError();
    //     }
    // }
}


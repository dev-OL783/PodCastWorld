namespace PodCastWorld
{
    public static class UserMenu
    {
        public static void Show(User user)
        {
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine("\n=== User Menu ===");
                Console.WriteLine("1. View Details");
                Console.WriteLine("2. Change Password");
                Console.WriteLine("3. Logout");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        ViewDetails(user);
                        break;

                    case "2":
                        ChangePassword(user);
                        break;
                    
                    case "3":
                        Console.WriteLine("Logging out...");
                        loggedIn = false;
                        break;
                    case "4":
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // public static void RegisterPodcaster(IUserRepository userRepository)
        // {
        //     Console.WriteLine("=== Podcaster Registration ===");

        //     Console.Write("Name: ");
        //     string name = Console.ReadLine() ?? "";

        //     Console.Write("Age: ");
        //     int age = int.Parse(Console.ReadLine() ?? "0");

        //     Console.Write("Email: ");
        //     string email = Console.ReadLine() ?? "";

        //     Console.Write("Mobile Number: ");
        //     string mobile = Console.ReadLine() ?? "";

        //     Console.Write("Password: ");
        //     string password = Console.ReadLine() ?? "";

        //     Podcaster podcaster = new Podcaster(
        //         name,
        //         age,
        //         email,
        //         mobile,
        //         password);

        //     userRepository.Add(podcaster);

        //     Console.WriteLine("Podcaster registered successfully!");
        // }

        private static void ViewDetails(User user)
        {
            Console.WriteLine("\n=== User Details ===");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Mobile: {user.MobileNumber}");
        }

        private static void ChangePassword(User user)
        {
            Console.WriteLine("Enter current password:");
            string currentPassword = Console.ReadLine() ?? "";

            Console.WriteLine("Enter new password:");
            string newPassword = Console.ReadLine() ?? "";

            if (user.ChangePassword(currentPassword, newPassword))
            {
                Console.WriteLine("Password updated successfully.");
            }
            else
            {
                Console.WriteLine("Incorrect password.");
            }
        }
    }
}




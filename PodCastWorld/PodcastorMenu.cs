namespace PodCastWorld
{
    public static class PodcasterMenu
    {
        public static void Show(Podcaster podcaster)
        {
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine("\n=== Podcaster Menu ===");
                Console.WriteLine("1. See my details");
                Console.WriteLine("2. Change my password");
                Console.WriteLine("3. Create an episode");
                Console.WriteLine("4. View my episodes");
                Console.WriteLine("5. View statistics about my episodes");
                Console.WriteLine("6. View feedback about my episodes");
                Console.WriteLine("7. Log out");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        podcaster.ViewDetails();
                        break;

                    case "2":
                        ChangePassword(podcaster);
                        break;

                    case "3":
                        CreateEpisode(podcaster);
                        break;

                    case "4":
                        ViewEpisodes(podcaster);
                        break;

                    case "5":
                        ViewStatistics(podcaster);
                        break;

                    case "6":
                        ViewFeedback(podcaster);
                        break;

                    case "7":
                        loggedIn = false;
                        Console.WriteLine("Logging out...");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private static void ChangePassword(Podcaster podcaster)
        {
            Console.Write("Current Password: ");
            string current = Console.ReadLine() ?? "";

            Console.Write("New Password: ");
            string newPassword = Console.ReadLine() ?? "";

            if (podcaster.ChangePassword(current, newPassword))
                Console.WriteLine("Password updated.");
            else
                Console.WriteLine("Incorrect password.");
        }

        private static void CreateEpisode(Podcaster podcaster)
        {
            Console.WriteLine("\n=== Create Episode ===");

            Console.Write("Episode Title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            string description = Console.ReadLine() ?? "";

            Episode episode = new Episode(title, description);

            podcaster.Episodes.Add(episode);

            Console.WriteLine("Episode created successfully!");
        }

        private static void ViewEpisodes(Podcaster podcaster)
        {
            Console.WriteLine("\n=== My Episodes ===");

            if (podcaster.Episodes.Count == 0)
            {
                Console.WriteLine("No episodes created yet.");
                return;
            }

            for (int i = 0; i < podcaster.Episodes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {podcaster.Episodes[i]}");
            }
        }

        private static void ViewStatistics(Podcaster podcaster)
        {
            Console.WriteLine("\n=== Episode Statistics ===");

            if (podcaster.Episodes.Count == 0)
            {
                Console.WriteLine("No episodes found.");
                return;
            }

            int totalListens = 0;

            foreach (Episode episode in podcaster.Episodes)
            {
                totalListens += episode.ListenCount;
            }

            Console.WriteLine($"Episodes Created: {podcaster.Episodes.Count}");
            Console.WriteLine($"Total Listens: {totalListens}");
        }

        // private static void CreateEpisode(Podcaster podcaster)
        // {
        //     Console.WriteLine("Create episode not yet implemented.");
        // }

        // private static void ViewEpisodes(Podcaster podcaster)
        // {
        //     Console.WriteLine("View episodes not yet implemented.");
        // }

        // private static void ViewStatistics(Podcaster podcaster)
        // {
        //     Console.WriteLine("Statistics not yet implemented.");
        // }

        private static void ViewFeedback(Podcaster podcaster)
        {
            Console.WriteLine("Feedback not yet implemented.");
        }
    }
}
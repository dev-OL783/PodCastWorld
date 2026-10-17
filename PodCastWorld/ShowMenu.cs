namespace PodCastWorld;

public static class MenuRouter
{
    public static void ShowMenu(User user)
    {
        switch (user)
        {
            case Podcaster podcaster:
                PodcasterMenu.Show(podcaster);
                break;

            case PremiumListener premiumListener:
                UserMenu.Show(premiumListener);
                // PremiumListenerMenu.Show(premiumListener);
                break;

            case RegularListener regularListener:
                UserMenu.Show(regularListener);
                break;

            default:
                Console.WriteLine("Unknown user type.");
                break;
        }
    }
}

                    // if (currentUser != null)
                    // {
                    //     switch (currentUser)
                    //     {
                    //         case Podcaster podcaster:
                    //             PodcasterMenu.Show(podcaster);
                    //             break;

                    //         case PremiumListener premiumListener:
                    //         UserMenu.Show(premiumListener);
                    //         break;

                    //         case RegularListener regularListener:
                    //             UserMenu.Show(regularListener);
                    //             break;

                    //         default:
                    //             Console.WriteLine("Unknown user type.");
                    //             break;
                    //     }
                    // }
                    // break;
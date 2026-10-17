namespace PodCastWorld;

// user validation and authentication

public static class UserValidator
{
    public static bool IsValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        bool hasLetter = false;

        foreach (char c in name)
        {
            if (char.IsLetter(c))
                hasLetter = true;
            else if (!(c == ' ' || c == '\'' || c == '.' || c == '-'))
                return false;
        }

        return hasLetter;
    }

    public static bool IsValidAge(string input, out int age)
    {
        if (int.TryParse(input, out age))
        {
            return age >= 18 && age <= 99;
        }

        return false;
    }

    public static bool IsValidEmail(string email)
    {
        int atCount = email.Count(c => c == '@');

        return atCount == 1
            && email.IndexOf('@') > 0
            && email.IndexOf('@') < email.Length - 1;
    }

    public static bool IsValidMobile(string mobile)
    {
        return mobile.Length == 10
            && mobile.StartsWith("0")
            && mobile.All(char.IsDigit);
    }

    public static bool IsValidPassword(string password)
    {
        return password.Length >= 8
            && password.Any(char.IsUpper)
            && password.Any(char.IsLower)
            && password.Any(char.IsDigit);
    }
    
    public static string GetPasswordError(string password)
    {
        if (password.Length < 8)
            return "Password must be at least 8 characters long.";

        if (!password.Any(char.IsUpper))
            return "Password must contain an uppercase letter.";

        if (!password.Any(char.IsLower))
            return "Password must contain a lowercase letter.";

        if (!password.Any(char.IsDigit))
            return "Password must contain a number.";

        return "";
    }
    

    public static void PrintNameError()
    {
        Console.WriteLine("Name must contain valid letters.");
    }

    public static void PrintAgeError()
    {
        Console.WriteLine("Age must be between 18 and 99.");
    }

    public static void PrintEmailError()
    {
        Console.WriteLine("Email must contain exactly one @ symbol.");
    }

    public static void PrintMobileError()
    {
        Console.WriteLine("Mobile number must be 10 digits and start with 0.");
    }

    public static void PrintPasswordError()
    {
        Console.WriteLine("Password must contain uppercase, lowercase and a number.");
        
    }

    // premium

    public static bool IsValidPaymentId(string input, out int paymentId)
    {
        if (int.TryParse(input, out paymentId))
        {
            return paymentId >= 100000 && paymentId <= 999999;
        }

        return false;
    }

    public static bool IsValidRegistrationDate(
        string input,
        out DateTime registrationDate)
    {
        return DateTime.TryParseExact(
            input,
            "dd/MM/yyyy",
            null,
            System.Globalization.DateTimeStyles.None,
            out registrationDate);
    }

    public static void PrintPaymentIdError()
    {
        Console.WriteLine(
            "Payment ID must be a 6-digit number between 100000 and 999999.");
    }

    public static void PrintRegistrationDateError()
    {
        Console.WriteLine(
            "Date must be entered in dd/MM/yyyy format.");
    }



    // public static bool IsValidPaymentId(string paymentId)
    // {
    //     return !string.IsNullOrWhiteSpace(paymentId) && paymentId.Length >= 5;
    // }
    
    // public static bool IsValidRegistrationDate(string input, out DateTime registrationDate)
    // {
    //     return DateTime.TryParse(input, out registrationDate)
    //         && registrationDate <= DateTime.Now;
    // }

    // public static void PrintPaymentIdError()
    // {
    //     Console.WriteLine("Payment ID cannot be empty.");
    // }

    // public static void PrintRegistrationDateError()
    // {
    //     Console.WriteLine("Registration date must be a valid past date.");
    // }

    
}

namespace PodCastWorld;

public class RegularListener : User
{
    public RegularListener(
        string name,
        int age,
        string email,
        string mobileNumber,
        string password)
        : base(name, age, email, mobileNumber, password)
    {
    }
}


public class PremiumListener : User
{
    public int PaymentId { get; private set; }
    public DateTime RegistrationDate { get; private set; }

    public PremiumListener(
        string name,
        int age,
        string email,
        string mobileNumber,
        string password,
        int paymentId,
        DateTime registrationDate)
        : base(name, age, email, mobileNumber, password)
    {
        PaymentId = paymentId;
        RegistrationDate = registrationDate;
    }
}


public class Podcaster : User
{
    public List<Episode> Episodes { get; } = new();

    public Podcaster(
        string name,
        int age,
        string email,
        string mobileNumber,
        string password)
        : base(name, age, email, mobileNumber, password)
    {
    }
}

// public class PremiumListener : User
// {
//     public PremiumListener(
//         string name,
//         int age,
//         string email,
//         string mobileNumber,
//         string password)
//         : base(name, age, email, mobileNumber, password)
//     {
//     }
// }

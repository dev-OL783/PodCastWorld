namespace PodCastWorld;

public abstract class User
{
    public string Name { get; }
    public int Age { get; }
    public string Email { get; }
    public string MobileNumber { get; }

    private string _password;

    protected User(
        string name,
        int age,
        string email,
        string mobileNumber,
        string password)
    {
        Name = name;
        Age = age;
        Email = email;
        MobileNumber = mobileNumber;
        _password = password;
    }

    public bool Authenticate(string email, string password)
    {
        return Email == email && _password == password;
    }

    public bool ChangePassword(
        string currentPassword,
        string newPassword)
    {
        if (_password != currentPassword)
            return false;

        _password = newPassword;
        return true;
    }

    public virtual void ViewDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Mobile: {MobileNumber}");
    }
}
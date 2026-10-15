namespace PodCastWorld;

/// <summary>
/// USER CLASS: stores and makes retrievable data
/// </summary>
public class User
{
    // private string _name;
    // private int _age;
    // private string _email;
    // private string _mobileNumber;
    // private string _password;

    public string Name { get; }
    public int Age { get; }
    public string Email { get; }
    public string MobileNumber { get; }

    private string _password;



    public User(string name, int age, string email,
                string mobileNumber, string password)
    {
        Name = name;
        Age = age;
        Email = email;
        MobileNumber = mobileNumber;
        _password = password;
    }


    public void SetPassword(string password)
    {
        _password = password;
    }



    // authenticators moved from UserValidator.cs
    public bool Authenticate(string email, string password)
    {
        return Email == email && _password == password;
    }

    public bool ChangePassword(string currentPassword, string newPassword)
    {
        if (_password != currentPassword)
            return false;

        _password = newPassword;
        return true;
    }

}


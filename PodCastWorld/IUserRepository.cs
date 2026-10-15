namespace PodCastWorld;

public interface IUserRepository
{
    void Add(User user); // current User add to list

    User? FindByEmail(string email); // finds users by their email

    List<User> GetAll(); // the lsit of Users
}
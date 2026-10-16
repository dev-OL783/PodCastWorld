namespace PodCastWorld;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? FindByEmail(string email)
    {
        return _users.Find(u => u.Email == email);
    }

    public List<User> GetAll()
    {
        return _users;
    }
}
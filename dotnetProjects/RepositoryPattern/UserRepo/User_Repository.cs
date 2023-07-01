using System.Diagnostics;

public class User_Repository
{
    private readonly List<User> _users = new List<User>();
    public static User? CurrentUser { get; private set; }

    public bool LogIn(string email, string password)
    {
        User user = GetUserByEmail(email);
        if (user == null)
        {
            Console.WriteLine("User not found!");
            return false;
        }

        if (user.CheckPassword(password))
        {
            // Log the user in
            CurrentUser = user;
            return true;
        }
        else
        {
            Console.WriteLine("Password is incorrect");
            return false;
        }
    }
    // CRUD
    // Create
    public bool RegisterUser(string name, string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            Console.WriteLine("Error: User must have an email address");
            return false;
        }
        if (!email.Contains("@"))
        {
            Console.WriteLine("Error: Email address is not valid");
            return false;
        }
        
        User user = new(password);
        if (string.IsNullOrEmpty(name))
        {
            string[] pieces = email.Split('@');
            user.Name = pieces[0];
        }
        else
            user.Name = name;
        
        user.Email = email;

        _users.Add(user);
        return true;
    }
    // Read
    public List<User> GetAllUsers()
    {
        return _users;
    }
    public List<User> GetAllActiveUsers()
    {
        return _users.Where(u => !u.IsBanned).ToList();
    }
    public List<User> GetBannedUsers()
    {
        return _users.Where(u => u.IsBanned).ToList();
        // make empty list
        // loop through users
        // if user is banned, add to list
        // return list
    }
    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
        // loop through users
        // if Id matches on a user, return that user
        // after loop, return null
    }
    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }
    // Search for user by name

    // Update
    public bool UpdateUsername(int id, string name)
    {
        User? user = GetUserById(id);
        if (user == null)
        {
            Console.WriteLine($"Error: User not found: {id}");
            return false;
        }
        user.Name = name;
        return true;
    }
    public bool BanUser(string email)
    {
        User user = GetUserByEmail(email);
        if (user != null)
            return BanUser(user.Id);
        return false;
    }
    public bool BanUser(int id)
    {
        if (CurrentUser == null || !CurrentUser.IsAdmin)
        {
            Console.WriteLine("You do not have permission to ban");
            return false;
        }

        User? user = GetUserById(id);
        if (user == null)
        {
            Console.WriteLine($"Error: User not found: {id}");
            return false;
        }
        if (user.IsBanned)
        {
            Console.WriteLine("User is already banned");
            return true;
        }
        if (user.IsAdmin)
        {
            Console.WriteLine("Cannot ban an admin");
            return false;
        }

        user.IsBanned = true;
        return true;
    }
    public bool MakeAdmin(int id)
    {
        User user = GetUserById(id);
        if (user == null) return false;
        user.IsAdmin = true;
        return true;
    }
    public bool MakeAdmin(string email)
    {
        User user = GetUserByEmail(email);
        if (user == null) return false;
        return MakeAdmin(user.Id);
    }

    // Delete
}

public class UserUpdateModel
{
    public string Name { get; set; }
    public string AvatarURL { get; set; }
}

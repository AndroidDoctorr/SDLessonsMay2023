using System.Buffers.Text;

public class User
{
    public static int _count = 0;
    private string _passHash = "";

    public User(string password)
    {
        _passHash = MakeHash(password);

        Id = _count++;
    }

    public bool CheckPassword(string password)
    {
        string hash = MakeHash(password);
        return _passHash.Equals(hash);
    }
    private string MakeHash(string inputString)
    {
        // This is not really a hash!!! This is pretend
        // Base 64 is not encryption
        byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
        return Convert.ToBase64String(plainTextBytes);
    }

    public int Id { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsBanned { get; set; } = false;
    public bool IsAdmin { get; set; } = false;
}
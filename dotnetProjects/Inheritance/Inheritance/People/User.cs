public class User
{
// Give the user a FirstName, LastName, ID (an integer, with no setter), and BirthDate properties.
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    // FullName as a property
    // public string FullName => FirstName + " " + LastName;
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }

    public User() { }
    public User(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
    // FullName as a method
    public string FullName() {
        return FirstName + " " + LastName;
        // return $"{FirstName} {LastName}";
        // return $"{LastName}, {FirstName}";
    }

    // Double Bonus: Create a method that returns the age of the user in years.

    public int GetAge()
    {
        DateTime today = DateTime.Now;
        TimeSpan timeSpan = today - BirthDate;
        // int days = (int) Math.Round(timeSpan.TotalDays);
        double days = timeSpan.TotalDays;
        double years = days / 365.24;
        return (int) Math.Round(years);
    }
}
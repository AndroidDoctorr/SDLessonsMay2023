public class Customer : User
{
    public DateTime JoinDate { get; set; }
    public bool IsGoldMember
    {
        get
        {
            double years = (DateTime.Now - JoinDate).TotalDays / 365.24;
            return years >= 5.0;
        }
    }
    // public bool IsGoldMember => (DateTime.Now - JoinDate).TotalDays / 365.24 >= 5.0;
}
public class Employee : User
{
    public int EmployeeNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int PiecesOfFlair { get; set; }
    public int YearsWithCompany
    {
        get
        {
            double years = (DateTime.Now - HireDate).TotalDays / 365.24;
            return (int) Math.Round(years);
            // return Convert.ToInt32(years);
        }
    }
}

public class HourlyEmployee : Employee
{
    public decimal HourlyWage { get; set; }
    public decimal HoursWorked { get; set; }
    // Same thing, two different ways
    // public decimal GrossPay => HoursWorked * HourlyWage;
    public decimal GrossPay
    {
        get
        {
            return HourlyWage * HoursWorked;
        }
    }
}

public class SalaryEmployee : Employee
{
    public decimal Salary { get; set; }
}
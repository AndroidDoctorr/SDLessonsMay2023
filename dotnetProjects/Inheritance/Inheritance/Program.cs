User user = new();
user.FirstName = "Andrew";
user.LastName = "Torr";

User user2 = new("Andrew", "Torr", new DateTime(1985, 9, 22));

Console.WriteLine(user2.FullName());

Customer customer = new Customer();
customer.FirstName = "someone";

Employee employee = new Employee();
employee.HireDate = new DateTime(2020, 3, 1);
employee.FirstName = "Andrew";
employee.LastName = "Torr";

Console.WriteLine($"{employee.FullName()} has been here {employee.YearsWithCompany} years");
using System.Reflection.Metadata;
using System.Security.Cryptography;

Console.WriteLine("Hey!");


// Value types

// var exists, but don't use it, unless you absolutely have to
// var someVar = 4;

int someInt = 3;
float someFloat = 3.5f;
double aDouble = 4.7;
// casting
float anotherFloat = (float) 1.3;

// interpolation
Console.WriteLine($"test: {someInt * someFloat}");

// string name = "Andrew";

Console.Write("What's your name? ");

string name = Console.ReadLine();

Console.WriteLine($"Hey, {name}");

bool isAdult = false;
Console.Write("How old are you? ");

string ageString = Console.ReadLine();

int age = Convert.ToInt32(ageString);
int age2 = Int32.Parse(ageString);
// Parse means analyze and translate

// You can use try/catch
// We'll talk about it later but you can look it up now if you like


// 3 ways of doing the same thing
if (age >= 18) isAdult = true;

isAdult = age >= 18;

if (age >= 18)
{
    isAdult = true;
}

if (isAdult) Console.WriteLine("Hello, sir or madam");
else Console.WriteLine("Hey, kiddo!");

List<string> names = new List<string>()
{
    "Airy",
    "Brock",
    "Lee",
    "Roy",
};

string[] nameArray = {
    "Airy",
    "Brock",
    "Lee",
    "Roy",
};

names.Add("Joe");

foreach (string studentName in names)
{
    Random rng = new Random();
    int randomColor = rng.Next(0, 16);

    Console.ForegroundColor = (ConsoleColor) randomColor;

    Console.WriteLine($"Hey, {studentName}");
}

Console.ResetColor();

for (int i = 0; i < nameArray.Length; i++)
{
    string sName = nameArray[i];
    Console.WriteLine($"Hey again, {sName}");
}


Student student = new Student();
student.Name = "Jackson";

List<Student> students = new List<Student>();
students.Add(student);

foreach (Student s in students)
{
    Console.WriteLine(s.Name);
}

Coord point = new Coord();
point.x = RandomNumberGenerator.GetInt32(8);
point.y = RandomNumberGenerator.GetInt32(8);
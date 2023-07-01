using System.Reflection.Metadata;

StreamingContent content = new StreamingContent(
    "Pi",
    "A mathematician accidentally learns too much",
    5.0,
    Maturity.R,
    Genre.SciFi
);

// Expression - something that becomes a value when the program runs
// Examples:
// 5
// true
// (3 + 7) / 5
// "a string" + "another string"
// isActive && isEnabled

Console.WriteLine($"{content.Title} is a {content.Genre} movie and it " +
    $"{(content.IsFamilyFriendly ? "is" : "isn't")} family friendly");



SC_Repository repo = new();
StreamingContent item = repo.GetContentByTitle("hawk jones");

// Make this the StreamingContent class ToString() method
Console.WriteLine($"{item.Title} is a {item.Genre} movie and it " +
    $"{(item.IsFamilyFriendly ? "is" : "isn't")} family friendly");

repo.AddContent(content);
StreamingContent item2 = repo.GetContentByTitle("pi");
Console.WriteLine($"{item2.Title} is a {item2.Genre} movie and it " +
    $"{(item2.IsFamilyFriendly ? "is" : "isn't")} family friendly");

bool wasAdded = repo.AddContent(new StreamingContent());
Console.WriteLine(wasAdded);


List<StreamingContent> familyFriendlyItems = repo.GetFamilyFriendlyContent();
foreach (StreamingContent sc in familyFriendlyItems)
    Console.WriteLine(sc);


repo.DeleteContent("Popeye");
repo.DeleteContent("Pi");

StreamingContent primer = repo.GetContentByTitle("primer");
primer.Description = "Aaron and Abe play with physics a bit too much";

repo.UpdateContent("Primer", primer);
Console.WriteLine(primer.Id);


StreamingContent hawkJ = repo.GetContentByTitle("hawk jones");
Console.WriteLine(hawkJ.Id);



SC_Repository repo2 = new();
Movie fifthElement = new("Fifth Element", "space opera", 5, Maturity.PG13, Genre.SciFi, 113, "Luc Besson");
repo2.AddContent(fifthElement);

Show simpsons = new("The Simpsons", "Yellow people doing crazy stuff", 4, Maturity.PG, Genre.Comedy);
simpsons.NumberOfSeasons = 34;
repo2.AddContent(simpsons);
Episode ep1 = new Episode();
Episode ep2 = new Episode();
simpsons.Episodes.Add(ep1);
simpsons.Episodes.Add(ep2);


User_Repository userRepo = new();
userRepo.RegisterUser("TestUser", "test@email.com", "TestPass123");
userRepo.RegisterUser("", "test2@email.com", "SomePassword!!!");
userRepo.RegisterUser("AdminUser", "admin@email.com", "APassword12?");
userRepo.MakeAdmin("admin@email.com");

Playlist_Repository playlistRepo = new();


Console.WriteLine(userRepo.GetUserById(0).Name);

SC_Repo_UI UI = new(repo2, userRepo, playlistRepo);
UI.Run();
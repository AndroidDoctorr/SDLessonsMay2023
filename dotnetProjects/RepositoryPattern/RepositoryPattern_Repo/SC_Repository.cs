public class SC_Repository
{
    // Streaming Content Repository/Controller

    // Contents/the actual repo
    private readonly List<StreamingContent> _content = new List<StreamingContent>();
    // IRL this would be a reference to a database, or something like that
    // This is kind of like our mock database

    // Access methods, or CRUD
    // *Create   (POST)
    // *Read     (GET)
    // *Update   (PUT)
    // *Delete   (DELETE)


    public SC_Repository()
    {
        StreamingContent item1 = new(
            "Hawk Jones",
            "a buddy cop movie but with kids",
            5, Maturity.PG, Genre.Action);
        AddContent(item1);

        StreamingContent item2 = new(
            "Loaded Weapon",
            "National Lampoon slapstick buddy cop movie",
            5, Maturity.PG13, Genre.Comedy);
        AddContent(item2);

        StreamingContent item3 = new(
            "Primer",
            "I don't wanna spoil anything so I won't",
            5, Maturity.PG13, Genre.SciFi);
        AddContent(item3);

        StreamingContent item4 = new(
            "The Lion King",
            "Hamlet with animals",
            5, Maturity.G, Genre.Bromance
        );
        AddContent(item4);
    }

    // Create Method(s)
    public bool AddContent(StreamingContent item)
    {
        if (item == null) return false;
        // if (item.Title == null) return false;
        if (string.IsNullOrEmpty(item.Title))
        {
            ShowError("Content item must have a Title.");
            return false;
        }

        _content.Add(item);

        ShowSuccess($"Content added: {item.Title}!");
        return true;
    }
    // Practice challenge!
    // public bool AddContent(string Title, string Description, yadda yadda...)


    // Read methods
    public List<StreamingContent> GetAllContent()
    {
        return _content;
    }
    public List<Movie> GetAllMovies()
    {
        return _content
            .Where(sc => sc is Movie)
            .Select(sc => (Movie) sc)
            .ToList();

        List<Movie> movies = new List<Movie>();
        foreach (StreamingContent item in _content)
        {
            if (item is Movie) movies.Add((Movie) item);
        }
        return movies;
    }

    public StreamingContent GetContentByTitle(string title)
    {
        // LINQ
        // StreamingContent item = _content.FirstOrDefault(sc => sc.Title == title);
        // return item;
        // default usually means null
        // => arrow means "lambda expression"

        // FirstOrDefault works just like this:
        foreach (StreamingContent sc in _content)
        {
            if (sc.Title.ToLower() == title.ToLower())
            {
                return sc;
            }
        }
        return null;
    }

    public List<StreamingContent> GetContentsByGenre(Genre genre)
    {
        // => means lambda expression
        return _content.Where(sc => sc.Genre == genre).ToList();

        // This does the exact same thing but with a loop
        List<StreamingContent> genreContents = new List<StreamingContent>();
        foreach (StreamingContent sc in _content)
            if (sc.Genre == genre)
                genreContents.Add(sc);

        return genreContents;
    }

    // Write a method that returns all Family-Friendly content
    public List<StreamingContent> GetFamilyFriendlyContent()
    {
        return _content.Where(item => item.IsFamilyFriendly).ToList();
    }

    // Bonus: Write a method that searches by title (e.g. "pr" should return "Primer")
    public List<StreamingContent> SearchContents(string query)
    {
        return _content.Where(
            item => item.Title.ToLower().Contains(query.ToLower())
        ).ToList();
    }

    // Family friendly comedy
    public List<StreamingContent> GetFamilyFriendlyComedy()
    {
        // Lots of different ways to do this!!
        return _content
            .Where(sc => sc.IsFamilyFriendly && sc.Genre == Genre.Comedy)
            .ToList();

        // Methods can be "chained"
        return _content
            .Where(sc => sc.IsFamilyFriendly)
            .Where(sc => sc.Genre == Genre.Comedy)
            .ToList();

        return GetFamilyFriendlyContent()
            .Where(sc => sc.Genre == Genre.Comedy)
            .ToList();
    }

    // Update method(s)
    public bool UpdateContent(string title, StreamingContent newContent)
    {
        StreamingContent item = GetContentByTitle(title);
        if (item == null)
        {
            ShowError("Cannot update content item, item not found");
            return false;
        }

        item.Title = newContent.Title;
        item.Description = newContent.Description;
        item.Genre = newContent.Genre;
        item.MaturityRating = newContent.MaturityRating;
        item.ContentUrl = newContent.ContentUrl;
        item.StarRating = newContent.StarRating;

        ShowSuccess("Content updated!");
        return true;
    }

    // Delete method
    public bool DeleteContent(string title)
    {
        // Using a title to refer to content is probably a bad idea
        // What if there's more than one, like True Grit?
        // This is why things in databases typically have an ID that cannot change

        StreamingContent content = GetContentByTitle(title);

        if (content == null)
        {
            ShowError($"Cannot delete content - item not found: {title}");
            return false;
        }

        _content.Remove(content);
        ShowSuccess($"{title} removed!");
        return true;
    }

    // Helper Method
    // Methods that can be used by other methods as a shortcut/reference
    // Methods are RE-USABLE actions
    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"### Error: {message} ###");
        Console.ResetColor();
    }
    private void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"### Success: {message} ###");
        Console.ResetColor();
    }
}
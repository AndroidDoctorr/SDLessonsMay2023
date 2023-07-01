public class SC_Repo_UI
{
    private SC_Repository _repo;
    private User_Repository _auth;
    private Playlist_Repository _playlists;

    public SC_Repo_UI(User_Repository auth)
    {
        _repo = new SC_Repository();
        _auth = auth;
    }

    public SC_Repo_UI(SC_Repository repo, User_Repository auth, Playlist_Repository playlists)
    {
        // Dependency injection
        // If the class depends on something being given to it (injected)
        _repo = repo;
        _auth = auth;
        _playlists = playlists;
    }



    public void Run()
    {
        // Seed the database??

        // If not logged in, ask if user wants to log in or register?
        // OR just continue as anonymous user

        bool isLoggedIn = LogIn();
        // etc.
        if (isLoggedIn)
            ShowMenu();
        else
            ShowError("You are not authorized >:|\nGo away.");
    }

    private bool LogIn()
    {
        Console.Clear();
        ShowLogo();

        string email;
        bool isFirstEmail = true;
        do
        {
            if (isFirstEmail)
                isFirstEmail = false;
            else
                ShowError("Email cannot be empty");

            Console.Write("Email: ");
            email = Console.ReadLine();
        } while (string.IsNullOrEmpty(email));

        string password;
        bool isFirstPass = true;
        do
        {
            if (isFirstPass) isFirstPass = false;
            else ShowError("Password cannot be empty");

            Console.Write("Password: ");
            password = Console.ReadLine();
        } while (string.IsNullOrEmpty(password));

        // Log In
        return _auth.LogIn(email, password);
    }

    private void ShowMenu()
    {
        bool continueToRun = true;

        while (continueToRun)
        {
            Console.Clear();
            ShowLogo();
            Console.WriteLine($"Welcome, {User_Repository.CurrentUser.Name}");
            Console.WriteLine("Please select an option:\n" +
                "1. Show all content\n" +
                "2. Get content by title\n" +
                "3. Add a content item\n" +
                "4. Update a content item\n" +
                "5. Show all Movies\n" +
                "6. Ban User\n" +
                "7. Create Playlist\n" +
                "0. Exit\n");
            // Other options to add:
            // Un-ban user
            // Make user Admin
            // See playlists

            // Only show available options,
            // i.e. if you're not an admin, don't show the ban options

            Console.Write("Selection: ");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    ShowAllContent();
                    break;
                case "2":
                    ShowContentByTitle();
                    break;
                case "3":
                    AddContent();
                    break;
                case "4":
                    UpdateContent();
                    break;
                case "5":
                    ShowAllMovies();
                    break;
                case "6":
                    BanUser();
                    break;
                case "7":
                    CreatePlaylist();
                    break;
                case "0":
                    continueToRun = false;
                    Exit();
                    break;
                default:
                    break;
            }
        }
    }

    private void Exit()
    {
        Console.Clear();
        Console.WriteLine("\n\n      Goodbye!\n\n\n");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
    private void BanUser()
    {
        Console.Clear();
        Console.WriteLine("Who's getting the hammer?");
        Console.Write("Email: ");
        string email = Console.ReadLine();

        if (string.IsNullOrEmpty(email))
        {
            Console.WriteLine("Email cannot be empty");
            PauseAndContinue();
            return;
        }
        if (!User_Repository.CurrentUser.IsAdmin)
        {
            Console.WriteLine("You're not allowed to do that!");
            PauseAndContinue();
            return;
        }

        _auth.BanUser(email);
        Console.WriteLine("They're outta here!");
        PauseAndContinue();
    }
    private void CreatePlaylist()
    {
        Console.Clear();
        Console.WriteLine("What do you want to call this playlist?");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrEmpty(name))
        {
            ShowError("Playlist needs a name!");
            PauseAndContinue();
            return;
        }

        if (User_Repository.CurrentUser == default)
        {
            ShowError("You must be logged in to make a playlist");
            PauseAndContinue();
            return;
        }

        Playlist playlist = new(name, User_Repository.CurrentUser.Id);
        _playlists.SavePlaylist(playlist);

        Console.WriteLine("Playlist saved!");
        PauseAndContinue();
    }
    private void ShowAllContent()
    {
        Console.Clear();
        List<StreamingContent> contents = _repo.GetAllContent();

        int index = 1;
        foreach (StreamingContent content in contents)
            Console.WriteLine($"{index++}. {content.Title}");

        PauseAndContinue();
    }
    public void ShowAllMovies()
    {
        Console.Clear();
        List<Movie> contents = _repo.GetAllMovies();

        int index = 1;
        foreach (Movie content in contents)
            Console.WriteLine($"{index++}. {content.Title}");

        PauseAndContinue();
    }
    private void ShowContentByTitle()
    {
        // UX = User Experience
        // What the user feels interacting with your software
        // Meet the user _all_ the way
        string title;
        do
        {
            Console.Clear();
            Console.Write("Please enter a title: ");
            title = Console.ReadLine();
        } while (string.IsNullOrEmpty(title));

        StreamingContent content = _repo.GetContentByTitle(title.ToLower());

        if (content == null)
            ShowError("Content not found :(");
        else
            Console.WriteLine(content);

        PauseAndContinue();
    }
    private void AddContent()
    {
        Console.Clear();
        Console.WriteLine("Enter the details for the new item...");

        Console.Write("Title: ");
        string title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title))
        {
            ShowError("Content must have a title!");
            PauseAndContinue();
            return;
        }

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Star Rating: ");
        string rating = Console.ReadLine();

        Console.WriteLine("Maturity Ratings:");
        foreach (Maturity m in Enum.GetValues(typeof(Maturity)))
            Console.WriteLine($"{(int) m}. {m}");

        string maturity = Console.ReadLine();

        Console.WriteLine("Genre:");
        foreach (Genre g in Enum.GetValues(typeof(Genre)))
            Console.WriteLine($"{(int) g}. {g}");

        string genre = Console.ReadLine();

        StreamingContent content = new StreamingContent();

        // Do the next part...

        content.Title = title;
        content.Description = description;
        // string => double
        double ratingDouble = Convert.ToDouble(rating);
        content.StarRating = ratingDouble;
        // string => int => Maturity
        int maturityInt = Convert.ToInt32(maturity);
        Maturity mat = (Maturity) maturityInt;
        content.MaturityRating = mat;

        // string => int => Genre
        int genreInt = Convert.ToInt32(genre);
        Genre gen = (Genre) genreInt;
        content.Genre = gen;

        _repo.AddContent(content);

        Console.WriteLine("\n\nContent added!");
        PauseAndContinue();
    }
    private void UpdateContent()
    {
        // How can you do this part??

        // Write pseudocode first
        // describe broad steps

        // 0. (option) Show a list of all content
        // 1. Get the title from the user
        Console.Write("Please enter the title: ");
        string title = Console.ReadLine();
        // 1.5 Make sure the title isn't null or empty
        // 2. Find the thing, if it exists
        // 2.5. If it doesn't, show an error and return

        // 3a. Ask the user for all the details
        // (copy the code from the Create method)

        // 3b. Ask the user what detail they want to update
        // if/else statement for updating one detail

        // 4. Apply new details using repo Update method
    }

    // Delete Content - Another practice item, I also do this in the video

    private void PauseAndContinue()
    {
        Console.WriteLine("\n\nPress any key to continue...");
        Console.ReadKey();
    }
    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"### UI Error: {message} ###");
        Console.ResetColor();
    }
    private void ShowLogo()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("DOTNETFLIX\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
public class Show : StreamingContent
{
    public int NumberOfEpisodes => Episodes.Count;
    public int NumberOfSeasons { get; set; }
    public List<Episode> Episodes { get; set; } = new();

    public Show() { }
    public Show(
        string title,
        string description,
        double rating,
        Maturity maturity,
        Genre genre) : base(title, description, rating, maturity, genre) { }

    public override string ToString()
    {
        return $"{Title} - ({NumberOfSeasons} Seasons, {NumberOfEpisodes} Episodes)\n" +
            $"{Description}\n" +
            $"{Genre}, {StarRating}/5 Stars, Rated {MaturityRating}";
    }
}

public class Episode
{
    public int Number;
    public string Title;
    public int Season;
    public double RunTime;

    public Episode() { }
    public Episode(int number, string title, int season, double runTime)
    {
        Number = number;
        Title = title;
        Season = season;
        RunTime = runTime;
    }
}
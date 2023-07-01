public class Movie : StreamingContent
{
    public double RunTime { get; set; }
    public string Director { get; set; }

    public Movie() { }
    public Movie(
        string title,
        string d,
        double r,
        Maturity m,
        Genre genre,
        double runTime,
        string director) : base(title, d, r, m, genre)
    {
        RunTime = runTime;
        Director = director;
        int y = X;
    }
}

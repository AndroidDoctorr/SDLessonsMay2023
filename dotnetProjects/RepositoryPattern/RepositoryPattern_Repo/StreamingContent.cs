public enum Maturity { G = 1, PG, PG13, R, NC17, TVY, TVG, TVPG, TVMA }
public enum Genre { Horror = 1, Action, SciFi, RomCom, Comedy, Documentary, Bromance, Romance, Romans }

public class StreamingContent
{
    // static = highlander
    // there can be only one
    private static int _count = 0;
    // private means only accessible inside this class
    protected int X = 5;
    // protected means "private plus" - inherited members can access

    public int Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double StarRating { get; set; }
    public Maturity MaturityRating { get; set; }
    public Genre Genre { get; set; }
    public string ContentUrl { get; set; }

    public bool IsFamilyFriendly
    {
        get
        {
            // Switch Expression
            // For each value of Thing, give Other Value
            return MaturityRating switch
            {
                Maturity.G => true,
                Maturity.PG => true,
                Maturity.TVY => true,
                Maturity.TVG => true,
                Maturity.TVPG => true,
                _ => false,
            };

            // Switch Case
            // For each value of Thing, do Other Action
            switch (MaturityRating)
            {
                case Maturity.G:
                    return true;
                case Maturity.PG:
                    return true;
                default:
                    return false;
            }

            if (MaturityRating == Maturity.G)
                return true;
            if (MaturityRating == Maturity.PG)
                return true;
            return false;
        }
    }


    public StreamingContent() {
        Id = _count++;
    }
    public StreamingContent(string title, string d, double r, Maturity m, Genre genre)
    {
        Id = _count++;
        Title = title;
        Description = d;
        StarRating = r;
        MaturityRating = m;
        Genre = genre;
    }


    public override string ToString()
    {
        return $"{Title} - {Description}\n" +
            $"{Genre}, {StarRating}/5 Stars, Rated {MaturityRating}";
    }
}
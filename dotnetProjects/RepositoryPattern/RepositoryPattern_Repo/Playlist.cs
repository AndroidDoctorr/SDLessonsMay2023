public class Playlist
{
    private int _count = 0;
    public int Id { get; private set; }
    public int OwnerId { get; private set; }
    public string Name { get; set; }
    public List<int> ContentIds { get; } = new List<int>();

    public Playlist(string name, int ownerId)
    {
        Id = _count++;
        OwnerId = ownerId;
        Name = string.IsNullOrEmpty(name) ? "Untitled Playlist" : name;
    }
    
    public bool AddContent(StreamingContent content)
    {
        // IF we want items in the list to be unique
        if (ContentIds.Contains(content.Id)) return false;

        if (content == null) return false;

        ContentIds.Add(content.Id);
        return true;
    }
    public bool ChangeName(string name)
    {
        if (string.IsNullOrEmpty(name)) return false;
        Name = name;
        return true;
    }
}
public class Playlist_Repository
{
    private readonly List<Playlist> _playlists = new List<Playlist>();

    public bool SavePlaylist(Playlist playlist)
    {
        if (playlist == null) return false;

        _playlists.Add(playlist);
        return true;
    }

    public List<Playlist> GetUserPlaylists(int ownerId)
    {
        return _playlists.Where(p => p.OwnerId == ownerId).ToList();
    }
    public Playlist? GetPlaylistById(int id)
    {
        return _playlists.FirstOrDefault(p => p.Id == id);
    }
}
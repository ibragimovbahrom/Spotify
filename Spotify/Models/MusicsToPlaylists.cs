using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class MusicsToPlaylists
    {
        [Key]
        public int Id { get; set; }
        public int MusicId  { get; set; }
        public int PlaylistId { get; set; }
        public Playlists? Playlists { get; set; }
        public Musics? Musics { get; set; }
    }
}

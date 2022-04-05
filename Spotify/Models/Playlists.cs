using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Playlists
    {
        [Key]
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public int OwnerId { get; set; }
        public Users? Users { get; set; }
        public List<MusicsToPlaylists> MusicsToPlaylists { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Users
    {
        [Key]
        public int? UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Playlists> Playlists { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Musics
    {
        [Key]
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public int AuthorId { get; set; }
        public int DurationSec { get; set; }
        public string MusicUrl { get; set; }
        public string MusicPhoto { get; set; }
        public int AlbumId { get; set; }

        public Albums? Albums { get; set; }
        public Authors? Authors { get; set; }
        public List<MusicsToPlaylists> MusicsToPlaylists { get; set; }
    }
}

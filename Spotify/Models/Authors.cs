using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPhoto { get; set; }
        public List<Musics> Musics { get; set; }
    }
}

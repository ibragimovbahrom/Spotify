using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class CategoryAlbums
    {
        [Key]
        public int CategoryId { get; set; }
        public string NameCategory { get; set; }
        public string Foto { get; set; }
        public List<Albums> Albums { get; set; }
    }
}

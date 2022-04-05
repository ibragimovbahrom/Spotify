using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Albums
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set;}
        public string AlbumFoto { get; set; }
        public int? CategoryId { get; set; }
        public CategoryAlbums? CategoryAlbums { get; set; }
        public List<Musics> Musics { get; set; }
    }
}

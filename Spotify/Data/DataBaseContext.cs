using Microsoft.EntityFrameworkCore;
using Spotify.Models;

namespace Spotify.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Playlists> Playlists { get; set; } = null! ;
        public DbSet<MusicsToPlaylists> MusicsToPlaylists { get;set; } = null! ;
        public DbSet<Albums> Albums { get; set; } = null ! ;
        public DbSet<CategoryAlbums> CategoryAlbums { get; set; } = null! ;
        public DbSet<Musics> Musics { get; set; } = null! ;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlists>()
                .HasOne(a => a.Users)
                .WithMany(s => s.Playlists)
                .HasForeignKey(a => a.OwnerId);

            modelBuilder.Entity<MusicsToPlaylists>()
                .HasOne(d => d.Playlists)
                .WithMany(f => f.MusicsToPlaylists)
                .HasForeignKey(d => d.PlaylistId);

            modelBuilder.Entity<Albums>()
                .HasOne(g => g.CategoryAlbums)
                .WithMany(h => h.Albums)
                .HasForeignKey(g => g.CategoryId);

            modelBuilder.Entity<Musics>()
                .HasOne(j => j.Albums)
                .WithMany(k => k.Musics)
                .HasForeignKey(j => j.AlbumId);

            modelBuilder.Entity<MusicsToPlaylists>()
                .HasOne(l => l.Musics)
                .WithMany(z => z.MusicsToPlaylists)
                .HasForeignKey(l => l.MusicId);

            modelBuilder.Entity<Musics>()
                .HasOne(x => x.Authors)
                .WithMany(c => c.Musics)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}

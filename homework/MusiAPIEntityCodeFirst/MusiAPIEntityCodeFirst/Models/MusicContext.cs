using System;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusiAPIEntityCodeFirst.Models
{
    public partial class MusicContext : DbContext
    {
        public MusicContext()
        {
        }

        public MusicContext(DbContextOptions<MusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Music;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 4, ArtistName = "Iron Maiden" });
            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 5, ArtistName = "ACDC" });
            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 6, ArtistName = "Metallica" });

            modelBuilder.Entity<Song>().HasData(new Song { SongId = 4, Title = "Fear of The Dark", ArtistId = 4 });
            modelBuilder.Entity<Song>().HasData(new Song { SongId = 5, Title = "Thunderstruck", ArtistId = 5 });
            modelBuilder.Entity<Song>().HasData(new Song { SongId = 6, Title = "Master of Puppet", ArtistId = 6 });


            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPICodeFirst.Models
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options) { }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        public MusicDBContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MusicDB;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(item =>
            {
                item.Property(myclass => myclass.ArtistId).IsRequired();
            });

            modelBuilder.Entity<Song>(item =>
            {
                item.Property(myclass => myclass.SongId).IsRequired();
            });

            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 1, ArtistName = "Ozzy Osbourne" });
            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 2, ArtistName = "Led Zeppelin" });
            modelBuilder.Entity<Artist>().HasData(new Artist { ArtistId = 3, ArtistName = "Deep Purple" });

            modelBuilder.Entity<Song>().HasData(new Song { SongId = 1, Title = "Crazy Train", ArtistId = 1 });
            modelBuilder.Entity<Song>().HasData(new Song { SongId = 2, Title = "Starway to Heaven", ArtistId = 2 });
            modelBuilder.Entity<Song>().HasData(new Song { SongId = 3, Title = "My Woman From Tokyo", ArtistId = 3 });

        }
    }
}

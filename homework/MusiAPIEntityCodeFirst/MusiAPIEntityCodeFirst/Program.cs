using Microsoft.EntityFrameworkCore;
using MusiAPIEntityCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusiAPIEntityCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Artist> artists = new List<Artist>();
            List<Song> songs = new List<Song>();
            using (var db = new MusicContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                artists = db.Artists.ToList();
                songs = db.Songs.Include("Artist").ToList();

                songs.ForEach(song => Console.WriteLine($"Artist name: {song.Artist.ArtistName}, Song title: {song.Title}"));
            }
        }
    }
}

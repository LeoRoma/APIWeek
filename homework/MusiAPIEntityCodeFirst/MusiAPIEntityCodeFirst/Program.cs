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
            using(var db = new MusicContext())
            {
                List<Artist> artists = new List<Artist>();
                List<Song> songs = new List<Song>();

                artists = db.Artists.ToList();
                songs = db.Songs.ToList();

                artists.ForEach(artist => Console.WriteLine($"Name: {artist.ArtistName}"));
                songs.ForEach(song => Console.WriteLine($"Song title: {song.Title}"));
            }
        }
    }
}

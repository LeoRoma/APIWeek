using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPICodeFirst.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public int? ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
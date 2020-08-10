using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPICodeFirst.Models
{
    public class Artist
    {
        public Artist()
        {
            Songs = new HashSet<Song>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

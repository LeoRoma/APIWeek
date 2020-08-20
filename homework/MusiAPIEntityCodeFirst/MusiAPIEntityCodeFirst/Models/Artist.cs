using System;
using System.Collections.Generic;

namespace MusiAPIEntityCodeFirst.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Songs = new HashSet<Song>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string BirthPlace { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

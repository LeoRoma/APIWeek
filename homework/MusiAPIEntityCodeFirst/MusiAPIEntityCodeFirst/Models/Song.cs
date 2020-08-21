using System;
using System.Collections.Generic;

namespace MusiAPIEntityCodeFirst.Models
{
    public partial class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public int? ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}

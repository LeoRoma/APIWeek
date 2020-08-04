using System;
using System.Collections.Generic;

namespace MusicAPI.Models
{
    public partial class Songs
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public int? ArtistId { get; set; }

        public virtual Artists Artist { get; set; }
    }
}

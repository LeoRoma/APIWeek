using System;
using System.Collections.Generic;

namespace MusicAPI.Models
{
    public partial class Artists
    {
        public Artists()
        {
            Songs = new HashSet<Songs>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string BirthPlace { get; set; }

        public virtual ICollection<Songs> Songs { get; set; }
    }
}

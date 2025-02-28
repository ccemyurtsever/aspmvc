using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.Entity.Entites
{
    public class Anime
    {
        public int animeId { get; set; }
        public string? animeName { get; set; }
        public int animeSeason { get; set; }
        public int animeEpisode { get; set; }
        public string? animeDescription { get; set; }
        public string? animeUrl { get; set; } // Video url
        public string? animeImage { get; set; } // İmage url 
        public int IMDB { get; set; } // Double yap
    }
}

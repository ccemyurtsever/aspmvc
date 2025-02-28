using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.UI.DTOs.AnimeDTOs
{
    public class UpdateAnimeDTO
    {
        public int animeId { get; set; }
        public string? animeName { get; set; }
        public int animeSeason { get; set; }
        public int animeEpisode { get; set; }
        public string? animeDescription { get; set; }
        public string? animeUrl { get; set; }
        public string? animeImage { get; set; }
        public int IMDB { get; set; }
    }
}

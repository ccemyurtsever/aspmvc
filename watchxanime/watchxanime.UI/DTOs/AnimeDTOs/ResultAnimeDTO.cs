namespace watchxanime.UI.DTOs.AnimeDTOs
{
    public class ResultAnimeDTO
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

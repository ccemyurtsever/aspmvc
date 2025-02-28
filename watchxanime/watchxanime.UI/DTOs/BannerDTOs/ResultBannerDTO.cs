namespace watchxanime.UI.DTOs.BannerDTOs
{
    public class ResultBannerDTO
    {
        public int BannerId { get; set; }    
        public string? Title { get; set; }    
        public string? ImageUrl { get; set; } 
        public string? Link { get; set; }      
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public bool IsShown { get; set; }
    }
}

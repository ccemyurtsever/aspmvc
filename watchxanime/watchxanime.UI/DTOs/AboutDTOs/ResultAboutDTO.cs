namespace watchxanime.UI.DTOs.AboutDTOs
{
    public class ResultAboutDTO
    {
        public int AboutUsId { get; set; }    // Primary key
        public string? Title { get; set; }     // Başlık
        public string? Description { get; set; } // Hakkımızda açıklaması
        public DateTime CreatedAt { get; set; } // Oluşturulma tarihi
        public DateTime UpdatedAt { get; set; } // Güncellenme tarihi
        public bool IsShown { get; set; }
    }
}

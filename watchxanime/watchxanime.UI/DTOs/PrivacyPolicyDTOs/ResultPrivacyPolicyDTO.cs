namespace watchxanime.UI.DTOs.PrivacyPolicyDTOs
{
    public class ResultPrivacyPolicyDTO
    {
        public int PrivacyPolicyId { get; set; }    // Primary Key
        public string? Title { get; set; }            // Başlık
        public string? Content { get; set; }          // Politika metni
        public DateTime CreatedAt { get; set; }      // Oluşturulma tarihi
        public DateTime UpdatedAt { get; set; }      // Güncellenme tarihi
        public bool IsShown { get; set; }           // Politika aktif mi?
    }
}

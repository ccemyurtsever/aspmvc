using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.DTO.DTOs.PrivacyPolicyDTOs
{
    public class CreatePrivacyPolicyDTO
    {
        public string? Title { get; set; }            // Başlık
        public string? Content { get; set; }          // Politika metni
        public DateTime CreatedAt { get; set; }      // Oluşturulma tarihi
        public DateTime UpdatedAt { get; set; }      // Güncellenme tarihi
        public bool IsShown { get; set; }           // Politika aktif mi?
    }
}

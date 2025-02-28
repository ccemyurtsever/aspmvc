using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.DTO.DTOs.AboutDTOs
{
    public class UpdateAboutDTO
    {
        public int AboutUsId { get; set; }   
        public string? Title { get; set; }     // Başlık
        public string? Description { get; set; } // Hakkımızda açıklaması
        public DateTime CreatedAt { get; set; } // Oluşturulma tarihi
        public DateTime UpdatedAt { get; set; } // Güncellenme tarihi
        public bool IsShown { get; set; }
    }
}

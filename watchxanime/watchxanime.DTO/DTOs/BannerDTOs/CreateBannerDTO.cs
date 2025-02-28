using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.DTO.DTOs.BannerDTOs
{
    public class CreateBannerDTO
    {
        public string? Title { get; set; }     // Banner başlığı
        public string? ImageUrl { get; set; }  // Banner için görsel URL'si
        public string? Link { get; set; }      // Banner'a tıklanınca yönlendirilecek link
        public DateTime StartDate { get; set; }  // Banner'ın başlangıç tarihi
        public DateTime EndDate { get; set; }    // Banner'ın bitiş tarihi
        public bool IsShown { get; set; }
    }
}

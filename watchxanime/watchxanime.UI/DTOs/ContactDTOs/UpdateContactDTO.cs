using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.UI.DTOs.ContactDTOs
{
    public class UpdateContactDTO
    {
        public int ContactId { get; set; }          // Primary Key: Bu alan, 'Contact' tablosunun birincil anahtarıdır.
        public string? NameLastname { get; set; }   // İletişimi kuran kişinin adı.
        public string? Email { get; set; }           // Kullanıcının e-posta adresi.
        public string? Phone { get; set; }           // Kullanıcının telefon numarası (isteğe bağlı).
        public string? Message { get; set; }         // Kullanıcının gönderdiği mesaj.
        public DateTime CreatedAt { get; set; }     // Mesajın gönderildiği tarih.
        public bool IsRead { get; set; }            // Mesajın okunup okunmadığı.
    }
}

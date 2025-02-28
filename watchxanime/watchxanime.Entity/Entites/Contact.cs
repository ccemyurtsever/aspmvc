using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.Entity.Entites
{
    public class Contact
    {
        public int ContactId { get; set; }         
        public string? NameLastname { get; set; }  
        public string? Email { get; set; }           
        public string? Phone { get; set; }          
        public string? Message { get; set; }         
        public DateTime CreatedAt { get; set; }     
        public bool IsRead { get; set; }           
    }

}

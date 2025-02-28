using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.Entity.Entites
{
    public class AboutUs
    {
        public int AboutUsId { get; set; }   
        public string? Title { get; set; }   
        public string? Description { get; set; } 
        public DateTime CreatedAt { get; set; } // Oluşturulma tarihi
        public DateTime UpdatedAt { get; set; } // Güncellenme tarihi
        public bool IsShown { get; set; }
    }

}

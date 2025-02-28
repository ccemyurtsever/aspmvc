using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.Entity.Entites
{
    public class Banner
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.UI.DTOs.AboutDTOs
{
    public class CreateAboutDTO
    {
        public string? Title { get; set; }     
        public string? Description { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public bool IsShown { get; set; }
    }
}

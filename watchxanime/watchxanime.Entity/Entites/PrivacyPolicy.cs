using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.Entity.Entites
{
    public class PrivacyPolicy
    {
        public int PrivacyPolicyId { get; set; }    
        public string? Title { get; set; }           
        public string? Content { get; set; }         
        public DateTime CreatedAt { get; set; }      
        public DateTime UpdatedAt { get; set; }      
        public bool IsShown { get; set; }         
    }

}

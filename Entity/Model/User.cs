using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class User : IdentityUser
    {
       
        public string? FirstName {  get; set; }
        public string? LastName { get; set;}
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }

        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Subscription>? Subscription { get; set; }
    }
}

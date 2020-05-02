using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System;


namespace EmpowerHealthyStudents.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Event> Events { get; set; }

        public virtual List<BlogPost> BlogPosts { get; set;  }

    }
}

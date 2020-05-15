using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpowerHealthyStudents.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string File { get; set; }
        public string Image { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Grade { get; set; }
        

        public string FileType { get; set; }
        [Required]

        public string Subject { get; set; }

        public virtual ICollection<ProductReview> ProductReviews { get; set; }


    }
}

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
        [NotMapped]
        public IFormFile File { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}

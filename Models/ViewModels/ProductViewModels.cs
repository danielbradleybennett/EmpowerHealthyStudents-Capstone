using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpowerHealthyStudents.Models.ViewModels
{
    public class ProductViewModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public IFormFile Image { get; set; }
        public string FilePath { get; set; }

        public string ImagePath { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string FileType { get; set; }
    }
}
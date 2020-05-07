using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpowerHealthyStudents.Models.ViewModels
{
    
        public class BlogPostViewModels
        {
         [Key]
         public int Id { get; set; }

         [Required]
         public string Blog { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public List<BlogComment> BlogComments { get; set; }

    }
}

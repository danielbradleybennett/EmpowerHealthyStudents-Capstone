using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmpowerHealthyStudents.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }
    }
}

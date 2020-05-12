﻿using System;
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
        
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int BlogPostId { get; set; }

       
    }
}

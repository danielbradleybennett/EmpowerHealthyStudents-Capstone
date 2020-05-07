using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpowerHealthyStudents.Models
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }
        
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }

        public int? BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
      
    }
}

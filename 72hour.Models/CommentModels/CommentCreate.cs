using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Models.CommentModels
{
    public class CommentCreate
    {
        
        [Required]
        public string Text { get; set; }

        [Required]
        public int PostId { get; set; }

        // [Required] wouldn't make this required since we have the user name through the Identity Context
        public Guid AuthorId { get; set; } 
    }
}

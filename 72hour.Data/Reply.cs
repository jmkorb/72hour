using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Comments))]
        public int CommentId { get; set; } // had to switch this so the foreign key attribute sits on top of it
        public string Text { get; set; }

        public virtual Comment Comments { get; set; } // I would change this to comment instead of comments

        public Guid AutorId { get; set; }
    }
}

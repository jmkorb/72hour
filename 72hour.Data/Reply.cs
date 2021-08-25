using _72hour.Models;
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

        [ForeignKey(nameof(Comment))]
        public string Text { get; set; }

        public virtual Comment Comments { get; set; }

        public Guid AuthorId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Models.CommentModels
{
    public class CommentListDetail
    {
        public int Id { get; set; }

        public Guid AuthorId { get; set; }

        public int PostId { get; set; }
    }
}

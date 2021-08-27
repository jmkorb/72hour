using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Models.PostModels
{
    public class PostListDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<CommentListDetail> Comments { get; set; }
        public List<LikeItemDetail> Likes { get; set; }
    }
}

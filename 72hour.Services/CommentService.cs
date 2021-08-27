using _72hour.Data;
using _72hour.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Services
{
    public class CommentService
    {       
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(CommentCreate comment)
        {
            var entity =
                new Comment
                {
                    AuthorId = _userId,
                    Text = comment.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListDetail> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new CommentListDetail
                        {
                            PostId = e.PostId,
                           
                            
                        }
                        );
                return query.ToArray();
            }
        }

        public CommentListDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == id && e.AuthorId == _userId);
                return
                    new CommentListDetail
                    {
                        Id = entity.Id,
                        AuthorId = entity.AuthorId,
                       
                        
                    };
            }
        }

        public bool UpdateComment(CommentEdit Comment)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == Comment.Id && e.AuthorId == _userId);

                entity.Id = Comment.Id;
                entity.Text = Comment.Text;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int CommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == CommentId && e.AuthorId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
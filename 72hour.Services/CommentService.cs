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
                    // need to add PostId as well or else will throw an exception when inserting
                    PostId = comment.PostId,
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
                           // what about the other properties?
                            
                        }
                        );
                return query.ToArray();
            }
        }

        // this should be by Post Id
        public IEnumerable<CommentListDetail> GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .SingleOrDefault(e => e.Id == id && e.AuthorId == _userId);

                return entity?.Comments.Select(c => new CommentListDetail { Id = c.Id, AuthorId = c.AuthorId, PostId = c.PostId }).ToList() ?? Enumerable.Empty<CommentListDetail>();
                   
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

                // might be a good idea to see if the above actually returned someting

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
                    .Single(e => e.Id == CommentId && e.AuthorId == _userId); // better to use single or default

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
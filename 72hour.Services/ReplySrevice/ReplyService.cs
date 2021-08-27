using _72hour.Data;
using _72hour.Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Services.ReplySrevice
{
    public class ReplyService
    {
        private readonly Guid _authorId;
        public ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }
        public async Task<ReplyDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var reply =
                    await
                    ctx.Comments.SingleOrDefaultAsync(c => c.Id == id);
                if (reply is null)
                {
                    return null;
                }
                return new ReplyDetail
                {
                    Id = reply.Id,
                    Text = reply.Text
                };
            }
        }
        public async Task<bool> Post(ReplyCreate reply)
        {
            var entity = new Reply
            {
                CommentId = reply.CommentId,
                Text = reply.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                var comment = await ctx.Comments.FindAsync(reply.CommentId);
                if (comment is null)
                {
                    return false;
                }

                entity.Comments = comment;
                entity.Comments.Replies.Add(entity);
                ctx.Replies.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}

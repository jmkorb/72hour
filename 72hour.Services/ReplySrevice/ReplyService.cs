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
        public async Task<IEnumerable<ReplyDetail>> Get(int id) // could be more than one so have to return IEnumerable
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    await
                    ctx.Comments.SingleOrDefaultAsync(c => c.Id == id); // This is great

                if (comment is null)
                {
                    return null;
                }

                return comment.Replies.Select(r => new ReplyDetail { Text = r.Text, Id = r.Id }); // transform Replies into ReplyDetail
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
                entity.Comments.Replies.Add(entity); // only have to do this, step above is redundant
                ctx.Replies.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}

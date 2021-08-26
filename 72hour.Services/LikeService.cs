using _72hour.Data;
using _72hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> Post(LikeCreate like)
        {
            var entity = new Like
            {
                PostId = like.PostId,
                OwnerId = _userId,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                var post = await ctx.Posts.FindAsync(like.PostId);
                if (post is null)
                {
                    return false;
                }

                entity.Post = post;
                ctx.Likes.Add(entity);

                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}

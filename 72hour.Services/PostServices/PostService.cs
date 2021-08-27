using _72hour.Data;
using _72hour.Models;
using _72hour.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Services.PostServices
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> Post(PostCreate post)
        {
            var entity = new Post
            {
                Title = post.Title,
                Text= post.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<IEnumerable<PostListDetail>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Posts
                    .Select(p => new PostListDetail
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Text = p.Text,
                        Comments = p.Comments,
                        Likes = p.Likes
                    }).ToListAsync();

                return query;
            }
        }

        //public async Task<PostDetail> Get(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var post =
        //            await
        //            ctx
        //            .Posts
        //            .SingleOrDefaultAsync(p => p.Id == id);
        //    }
        //}


    }
}

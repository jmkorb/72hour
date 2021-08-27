using _72hour.Services.PostServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace _72hour.WebAPI.Controllers.PostController
{
    [Authorize]
    public class PostController : ApiController
    {
        [HttpPost]
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new PostService(userId);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreatePostService();
            var posts = await svc.Get();
            return Ok(posts);
        }
    }
}
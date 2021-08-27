using _72hour.Models;
using _72hour.Models.LikeModels;
using _72hour.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace _72hour.WebAPI.Controllers
{
    [Authorize]
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new LikeService(userId);
            return svc;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(LikeCreate like)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var svc = CreateLikeService();
            var success = await svc.Post(like);
            if (success)
            {
                return Ok();
            }

            return InternalServerError();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateLikeService();
            var likes = await svc.GetLikesByPostId(id);

            if (id < 1)
                return BadRequest();

            return Ok(likes);
        }
    }

  
}

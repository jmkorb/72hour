using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace _72hour.WebAPI.Controllers.ReplyController
{
    public class ReplyController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateReplyService();
            var reply = await svc.Get(id);
            return Ok(reply);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(ReplyCreate reply)
        {
            if (reply is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateReplyService();
            var success = await svc.Post(reply);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
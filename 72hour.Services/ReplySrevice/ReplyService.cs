using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Services.ReplySrevice
{
    class ReplyService
    {
        private readonly Guid _authorId;
        public ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }

    }
}

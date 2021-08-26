﻿using _72hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public Guid AuthorId { get; set; }

        public virtual List<Reply> Replies { get; set; }

        [ForeignKey(nameof(Post))]

        public int PostId { get; set; }

        public virtual Post Posts { get; set; }


    }
}

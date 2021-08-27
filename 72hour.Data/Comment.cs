﻿using _72hour.Data;
using _72hour.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Data
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public Guid AuthorId { get; set; }

        public virtual List<Reply> Replies { get; set; }

        [ForeignKey(nameof(Posts))]

        public int PostId { get; set; }

        public virtual Post Posts { get; set; }

    }
}

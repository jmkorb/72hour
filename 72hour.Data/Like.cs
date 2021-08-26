﻿using _72hour.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [ForeignKey(nameof(Posts))]
        public int PostId { get; set; }
        public virtual Post Posts { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
    }
}

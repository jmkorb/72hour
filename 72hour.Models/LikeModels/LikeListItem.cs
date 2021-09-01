﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Models.LikeModels
{
    public class LikeListItem
    {
        public int LikeId { get; set; }
        public int PostId { get; set; }
        // I would maybe add owner id to this so we can see who liked the post? 
    }
}

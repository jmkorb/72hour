﻿using _72hour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Models.ReplyModels
{
    class ReplyDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Comment Commments { get; set; }
    }
}

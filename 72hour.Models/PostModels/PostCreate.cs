using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _72hour.Models.PostModels
{
    public class PostCreate 
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}

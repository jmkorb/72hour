using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72hour.Data
{
    class Reply
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Comments))]
        public string Text { get; set; }

        public virtual Comment Comments { get; set; }

        public Guid AutorId { get; set; }
    }
}

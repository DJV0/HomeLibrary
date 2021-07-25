using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}

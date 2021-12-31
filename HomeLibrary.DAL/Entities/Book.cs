using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishDate { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}

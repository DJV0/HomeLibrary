using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

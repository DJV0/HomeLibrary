using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Entities
{
    public class Tag
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}

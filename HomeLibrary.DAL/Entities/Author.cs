﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}

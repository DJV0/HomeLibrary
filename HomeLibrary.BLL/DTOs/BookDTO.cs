using HomeLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.DTOs
{
    public class BookDTO : BaseEntity
    {
        [Required(ErrorMessage ="Enter the book title")]
        public string Title { get; set; }
    }
}

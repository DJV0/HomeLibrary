using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Shared.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter full name")]
        public string FullName { get; set; }
    }
}

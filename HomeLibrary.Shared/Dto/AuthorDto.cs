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

        [Required(ErrorMessage ="Enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }
    }
}

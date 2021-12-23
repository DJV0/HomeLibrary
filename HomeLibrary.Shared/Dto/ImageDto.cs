using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibrary.Shared.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter image url")]
        public string Url { get; set; }

        [Required(ErrorMessage ="Enter book id")]
        public int BookId { get; set; }
    }
}

using HomeLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.DTOs
{
    public class ImageDTO : BaseEntity
    {
        [Required(ErrorMessage = "Input image url")]
        public string Url { get; set; }

        [Required(ErrorMessage ="Set book id")]
        public int? BookId { get; set; }
    }
}

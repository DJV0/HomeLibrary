﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Shared.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter a title")]
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishDate { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
        public ICollection<ImageDto> Images { get; set; }
        public ICollection<TagDto> Tags { get; set; }
    }
}

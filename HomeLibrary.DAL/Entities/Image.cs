﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.DAL.Entities
{
    public class Image : BaseEntity
    {
        [Required]
        public string Url { get; set; }
    }
}

﻿using HomeLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.DTOs
{
    public class AuthorDTO : BaseEntity
    {
        [Required(ErrorMessage ="Enter first name")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }
    }
}

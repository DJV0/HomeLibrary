using HomeLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.DTOs
{
    public class ImageDTO : BaseEntity
    {
        public string Url { get; set; }
    }
}

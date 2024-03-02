using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public double Price { get; set; }
        public string Description { get; set; }
        public string? PictureUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}

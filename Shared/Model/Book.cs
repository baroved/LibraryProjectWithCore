using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class Book : AbstractItem
    {
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}

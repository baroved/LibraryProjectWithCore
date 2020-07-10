using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class WriterDiscount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        [Required]
        public int Percent { get; set; }
    }
}

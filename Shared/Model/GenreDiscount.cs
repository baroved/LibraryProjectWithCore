using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class GenreDiscount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int Percent { get; set; }
    }
}
